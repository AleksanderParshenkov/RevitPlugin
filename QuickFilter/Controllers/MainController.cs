using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using QuickFilter.StaticModels;
using QuickFilter.Support;
using QuickFilter.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using static QuickFilter.Enums.FilterAndOrOrEnum;

namespace QuickFilter.Controllers
{
    public class MainController
    {
        public MainController(ExternalCommandData commandData) 
        {
            // Получение и запись информации о текущей модели
            CurrentModel.GetParamCurrentModel(commandData);

            // Получение всех элементов экземпляра в модели
            FilteredElementCollector col
              = new FilteredElementCollector(CurrentModel.Doc).WhereElementIsNotElementType();
            List <Element> elementList = col.Select(x=>x as Element).ToList();  

            // Получение указльного списка обрабатываемых категорий
            List <Category> categoryList = elementList.Where(x => x.Category != null)
                .Select(x=>x.Category)
                .Where(x=>x.Name.Contains(".dwg") == false && (x.CategoryType == CategoryType.Model || x.CategoryType == CategoryType.Annotation))
                .Distinct(new SupportMethodsObjectDistinct.CategoryIEqualityComparer())
                .ToList();

            // Получение списка Enum для чекбокса "И или ИЛИ"
            List <FilterAndOrOr> filterAndOrOrList = new List<FilterAndOrOr>();
            foreach(FilterAndOrOr item in Enum.GetValues(typeof(FilterAndOrOr)))
            {
                filterAndOrOrList.Add(item);
            }


            MainWindow wnd = new MainWindow();
            wnd.AndOr0.ItemsSource = filterAndOrOrList;
            wnd.Category0.ItemsSource = categoryList;
            wnd.ShowDialog();
        }        
    }
}
