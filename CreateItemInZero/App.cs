using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.DB.Structure;

namespace CreateItemInZero
{
    [Transaction(TransactionMode.Manual)]
    public class App : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Autodesk.Revit.ApplicationServices.Application app = uiapp.Application;
            Autodesk.Revit.DB.Document doc = uidoc.Document;

            // Поиск требуемого уровня
            FilteredElementCollector levelCollector = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Levels).WhereElementIsNotElementType();
            Level firstLevel = levelCollector.ToElements().Cast<Level>().FirstOrDefault(i => i.Name == "Этаж 1" || i.Name == "Уровень 1");


            // Поиск требуемого семейства и типоразмера для вставки
            FilteredElementCollector elementCollector = new FilteredElementCollector(doc).OfClass(typeof(FamilySymbol)).OfCategory(BuiltInCategory.OST_GenericModel);
            FamilySymbol elementType = elementCollector.FirstElement() as FamilySymbol;

            // Назначение стартовых координат
            XYZ origin = new XYZ(0, 0, 0);

            //Транзакция
            using (Transaction tr = new Transaction(doc, "Установка семейства в начало координат"))
            {
                tr.Start();
                                
                //Создает колонну
                doc.Create.NewFamilyInstance(origin, elementType, firstLevel, StructuralType.NonStructural);

                tr.Commit();
            }
            return Result.Succeeded;
        }
        
    }
}
