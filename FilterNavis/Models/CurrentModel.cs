using Autodesk.Revit.Creation;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using static FilterNavis.ViewModels.SharedMethodsStartViewInformation;

namespace FilterNavis.Models
{
    public static class CurrentModel
    {
        /// <summary>
        /// Основные свойства текущей модели.
        /// Заполняются методом внутри класса
        /// </summary>
        public static ExternalCommandData CommandData { get; internal set; }
        public static UIApplication UiApp { get; internal set; }
        public static UIDocument UiDoc { get; internal set; }
        public static Autodesk.Revit.ApplicationServices.Application App { get; internal set; }
        public static Autodesk.Revit.DB.Document Doc { get; internal set; }
        public static string CurrentModulName { get; internal set; }
        public static string CurrentRevitUser { internal get; set; }
        public static string Title { get; internal set; }
        public static string TitleFull { get; internal set; }
        public static string FullName { get; internal set; }

        /// <summary>
        /// Дополнительные свойства класса.
        /// Заполняются методами по ходу работы.
        /// </summary>
        public static Selection Choices { get; set; }
        public static View ActiveView { get; set; }

        public static List<Element> CurrentModelElementsList { get; set; }        
        public static List<Element> LinkModelElementsList { get; set; }
        public static List<Element> ModelElements { get; set; }
        public static List<ModelCategory> AllModelCategoriesList { get; set; }

        /// <summary>
        /// Метод получения основных свойств класса текущей модели.
        /// </summary>
        /// <param name="commandData">Основное получаемое свойство текущей модели класса ExternalCommandData</param>
        public static void GetParamCurrentModel(ExternalCommandData commandData)
        {
            CommandData = commandData;
            UiApp = CommandData.Application;
            UiDoc = UiApp.ActiveUIDocument;
            App = UiApp.Application;
            Doc = UiDoc.Document;
            CurrentModulName = Doc.Title;
            CurrentRevitUser = App.Username;

            TitleFull = Doc.Title;

            Title = Doc.Title
                    .Replace($"_{CurrentRevitUser}", "")
                    .Replace($"_отсоединено", "");

            FullName = Doc.PathName;

            
            
        }

        /// <summary>
        /// 
        /// </summary>
        public static void GetCurrentModelElements()
        {
            // Получуние всех элементов текущей модели
            List<Element> elementsCollectorCurrentModel = new FilteredElementCollector(Doc)
                .WhereElementIsNotElementType()
                .Where(x => x.Category != null)
                .ToList();
            
            CurrentModelElementsList = elementsCollectorCurrentModel.ToList();
        }

        public static void GetLinkModelElements()
        {
            List<Autodesk.Revit.DB.Document> linkDocumentList = GetLinkRevitDocuments();

            List<Element> referecesElementList = new List<Element>();

            foreach (var linkDocument in linkDocumentList)
            {
                List<Element> elementsCollectorCurrentModel = new FilteredElementCollector(linkDocument)
                                .WhereElementIsNotElementType()
                                .Where(x => x.Category != null)
                                .ToList();

                foreach (var Element in elementsCollectorCurrentModel)
                {
                    referecesElementList.Add(Element);
                }
            }
            
            LinkModelElementsList = referecesElementList.ToList();
        }

        public static List<Autodesk.Revit.DB.Document> GetLinkRevitDocuments()
        {
            List<Autodesk.Revit.DB.Document> elementsCollectorCurrentModel = new FilteredElementCollector(Doc)
                .WhereElementIsNotElementType()
                .OfClass(typeof(RevitLinkInstance))
                .Where(instance => RevitLinkType.IsLoaded(Doc,instance.GetTypeId()))
                .Select(x => (RevitLinkInstance)x)
                .Select(instance => instance.GetLinkDocument())
                .ToList();

            return elementsCollectorCurrentModel;
        }

        public static void GetAllCategoies()
        {
            
            var allCategories = ModelElements
                .Select(x => x.Category)
                .OrderBy(x => x.Name)
                .ToList();

            MessageBox.Show(ModelElements.Count.ToString());

            List<Category> categoriesDistinct = new List<Category>();
            foreach (var category in allCategories)
            {
                var categoriesDistinctName = categoriesDistinct.Select(x => x.Name).ToList();
                if (!categoriesDistinctName.Contains(category.Name)) categoriesDistinct.Add(category);
            }

            List<ModelCategory> categoriesResultList = new List<ModelCategory>();
            foreach (var item in categoriesDistinct)
            {
                if (item.Name != null && item.Name != "")
                {
                    ModelCategory category = new ModelCategory();
                    category.Name = item.Name;
                    category.Id = item.Id;
                    category.ModelParameter = GetAllMyParameters(Doc, item);
                    categoriesResultList.Add(category);
                }
            }
            categoriesResultList = categoriesResultList.Where(x => x.ModelParameter.Count() != 0 && x.ModelParameter != null).OrderBy(x => x.Name).ToList();
            
            AllModelCategoriesList = categoriesResultList;
        }
    }
}
