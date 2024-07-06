using Autodesk.Revit.DB;
using FilterNavis.Enums;
using FilterNavis.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FilterNavis.ViewModels
{
    public static class FilterAndSelect
    {
        public static List<Element> AllFilterMethod()
        {
            List<Element> listElemenntsStart = CurrentModel.AllElementsList;
            List<Element> listElemenntsAnd = listElemenntsStart.ToList();
            List<Element> listElemenntsOr0 = new List<Element>();
            List<Element> listElemenntsOr1 = new List<Element>();
            List<Element> listElemenntsOr2 = new List<Element>();
            List<Element> listElemenntsOr3 = new List<Element>();
            List<Element> listElemenntsOr4 = new List<Element>();

            if (CurrentWindow.IsCheckRow0 && CurrentWindow.IsWritedRow0)
            {
                listElemenntsAnd = listElemenntsAnd.Where(x => x.Category.Name == CurrentWindow.Category0.Name).ToList();
                int value = CurrentWindow.Parameter0.Id.IntegerValue;
                var builtInParameter = (BuiltInParameter)value;
                if (CurrentWindow.Wnd.AndOr0.SelectedIndex == 1) // 1 - И; 0 - ИЛИ
                {
                    listElemenntsAnd = FilterMethod(listElemenntsAnd, builtInParameter, CurrentWindow.Parameter0.StorageType, (FilterConditionEnum.FilterConditionFull)CurrentWindow.Wnd.Condition0.SelectedItem, CurrentWindow.Value0).ToList();
                }
                else
                {
                    listElemenntsOr0 = FilterMethod(listElemenntsStart, builtInParameter, CurrentWindow.Parameter0.StorageType, (FilterConditionEnum.FilterConditionFull)CurrentWindow.Wnd.Condition0.SelectedItem, CurrentWindow.Value0).ToList();
                }
            }
            if (CurrentWindow.IsCheckRow1 && CurrentWindow.IsWritedRow1)
            {
                int value = CurrentWindow.Parameter1.Id.IntegerValue;
                var builtInParameter = (BuiltInParameter)value;

                if (CurrentWindow.Wnd.AndOr1.SelectedIndex == 1) // 1 - И; 0 - ИЛИ
                {
                    listElemenntsAnd = listElemenntsAnd.Where(x => x.Category.Name == CurrentWindow.Category1.Name).ToList();
                    listElemenntsAnd = FilterMethod(listElemenntsAnd, builtInParameter, CurrentWindow.Parameter1.StorageType, (FilterConditionEnum.FilterConditionFull)CurrentWindow.Wnd.Condition1.SelectedItem, CurrentWindow.Value1).ToList();
                }
                else
                {
                    listElemenntsOr1 = listElemenntsStart.Where(x => x.Category.Name == CurrentWindow.Category1.Name).ToList();
                    listElemenntsOr1 = FilterMethod(listElemenntsOr1, builtInParameter, CurrentWindow.Parameter1.StorageType, (FilterConditionEnum.FilterConditionFull)CurrentWindow.Wnd.Condition1.SelectedItem, CurrentWindow.Value1).ToList();
                }
            }
            if (CurrentWindow.IsCheckRow2 && CurrentWindow.IsWritedRow2)
            {
                int value = CurrentWindow.Parameter2.Id.IntegerValue;
                var builtInParameter = (BuiltInParameter)value;

                if (CurrentWindow.Wnd.AndOr2.SelectedIndex == 1) // 1 - И; 0 - ИЛИ
                {
                    listElemenntsAnd = listElemenntsAnd.Where(x => x.Category.Name == CurrentWindow.Category2.Name).ToList();
                    listElemenntsAnd = FilterMethod(listElemenntsAnd, builtInParameter, CurrentWindow.Parameter2.StorageType, (FilterConditionEnum.FilterConditionFull)CurrentWindow.Wnd.Condition2.SelectedItem, CurrentWindow.Value2).ToList();
                }
                else
                {
                    listElemenntsOr2 = listElemenntsStart.Where(x => x.Category.Name == CurrentWindow.Category2.Name).ToList();
                    listElemenntsOr2 = FilterMethod(listElemenntsOr2, builtInParameter, CurrentWindow.Parameter2.StorageType, (FilterConditionEnum.FilterConditionFull)CurrentWindow.Wnd.Condition2.SelectedItem, CurrentWindow.Value2).ToList();
                }
            }
            if (CurrentWindow.IsCheckRow3 && CurrentWindow.IsWritedRow3)
            {
                int value = CurrentWindow.Parameter3.Id.IntegerValue;
                var builtInParameter = (BuiltInParameter)value;

                if (CurrentWindow.Wnd.AndOr3.SelectedIndex == 1) // 1 - И; 0 - ИЛИ
                {
                    listElemenntsAnd = listElemenntsAnd.Where(x => x.Category.Name == CurrentWindow.Category3.Name).ToList();
                    listElemenntsAnd = FilterMethod(listElemenntsAnd, builtInParameter, CurrentWindow.Parameter3.StorageType, (FilterConditionEnum.FilterConditionFull)CurrentWindow.Wnd.Condition3.SelectedItem, CurrentWindow.Value3).ToList();
                }
                else
                {
                    listElemenntsOr3 = listElemenntsStart.Where(x => x.Category.Name == CurrentWindow.Category3.Name).ToList();
                    listElemenntsOr3 = FilterMethod(listElemenntsOr3, builtInParameter, CurrentWindow.Parameter3.StorageType, (FilterConditionEnum.FilterConditionFull)CurrentWindow.Wnd.Condition3.SelectedItem, CurrentWindow.Value3).ToList();
                }
            }
            if (CurrentWindow.IsCheckRow4 && CurrentWindow.IsWritedRow4)
            {
                int value = CurrentWindow.Parameter4.Id.IntegerValue;
                var builtInParameter = (BuiltInParameter)value;

                if (CurrentWindow.Wnd.AndOr4.SelectedIndex == 1) // 1 - И; 0 - ИЛИ
                {
                    listElemenntsAnd = listElemenntsAnd.Where(x => x.Category.Name == CurrentWindow.Category4.Name).ToList();
                    listElemenntsAnd = FilterMethod(listElemenntsAnd, builtInParameter, CurrentWindow.Parameter4.StorageType, (FilterConditionEnum.FilterConditionFull)CurrentWindow.Wnd.Condition4.SelectedItem, CurrentWindow.Value4).ToList();
                }
                else
                {
                    listElemenntsOr4 = listElemenntsStart.Where(x => x.Category.Name == CurrentWindow.Category4.Name).ToList();
                    listElemenntsOr4 = FilterMethod(listElemenntsOr4, builtInParameter, CurrentWindow.Parameter4.StorageType, (FilterConditionEnum.FilterConditionFull)CurrentWindow.Wnd.Condition4.SelectedItem, CurrentWindow.Value4).ToList();
                }
            }

            List<Element> result = new List<Element>();
            foreach (var item in listElemenntsAnd)
            {
                result.Add(item);
            }
            foreach (var item in listElemenntsOr0)
            {
                result.Add(item);
            }
            foreach (var item in listElemenntsOr1)
            {
                result.Add(item);
            }
            foreach (var item in listElemenntsOr2)
            {
                result.Add(item);
            }
            foreach (var item in listElemenntsOr3)
            {
                result.Add(item);
            }
            foreach (var item in listElemenntsOr4)
            {
                result.Add(item);
            }

            //result = result.Distinct(new ElementsIEqualityComparer()).ToList();

            return result;
        }
        public class ElementsIEqualityComparer : IEqualityComparer<Element>
        {
            public bool Equals(Element x, Element y)
            {
                return x.Id == y.Id;
            }

            public int GetHashCode(Element obj)
            {
                return HashCode.Combine(obj.Id);
            }
        }

        public static List<Element> FilterMethod(List<Element> listElemennts, BuiltInParameter a, StorageType storageType, FilterConditionEnum.FilterConditionFull filterConditionFullItem, string value)
        {
            if (storageType == StorageType.Double || storageType == StorageType.Integer)
            {
                if (filterConditionFullItem == FilterConditionEnum.FilterConditionFull.Равно) // 0 - равно
                {
                    listElemennts = listElemennts.Where(x => { return double.Parse(x.get_Parameter(a).AsValueString().Split(' ')[0], new CultureInfo("en-GB")) == double.Parse(value, new CultureInfo("en-GB")); }).ToList();
                }
                if (filterConditionFullItem == FilterConditionEnum.FilterConditionFull.Не_равно) // 1 - не равно
                {
                    listElemennts = listElemennts.Where(x => { return double.Parse(x.get_Parameter(a).AsValueString().Split(' ')[0], new CultureInfo("en-GB")) != double.Parse(value, new CultureInfo("en-GB")); }).ToList();
                }
                if (filterConditionFullItem == FilterConditionEnum.FilterConditionFull.Больше) // 2 - больше
                {
                    listElemennts = listElemennts.Where(x => { return double.Parse(x.get_Parameter(a).AsValueString().Split(' ')[0], new CultureInfo("en-GB")) > double.Parse(value, new CultureInfo("en-GB")); }).ToList();
                }
                if (filterConditionFullItem == FilterConditionEnum.FilterConditionFull.Больше_или_равно) // 3 - больше или равно
                {
                    listElemennts = listElemennts.Where(x => { return double.Parse(x.get_Parameter(a).AsValueString().Split(' ')[0], new CultureInfo("en-GB")) >= double.Parse(value, new CultureInfo("en-GB")); }).ToList();
                }
                if (filterConditionFullItem == FilterConditionEnum.FilterConditionFull.Меньше) // 4 - меньше
                {
                    listElemennts = listElemennts.Where(x => { return double.Parse(x.get_Parameter(a).AsValueString().Split(' ')[0], new CultureInfo("en-GB")) < double.Parse(value, new CultureInfo("en-GB")); }).ToList();
                }
                if (filterConditionFullItem == FilterConditionEnum.FilterConditionFull.Меньше_или_равно) // 5 - меньше или равно
                {
                    listElemennts = listElemennts.Where(x => { return double.Parse(x.get_Parameter(a).AsValueString().Split(' ')[0], new CultureInfo("en-GB")) <= double.Parse(value, new CultureInfo("en-GB")); }).ToList();
                }
            }

            if (storageType == StorageType.String)
            {
                if (filterConditionFullItem == FilterConditionEnum.FilterConditionFull.Равно) // 0 - равно
                {
                    listElemennts = listElemennts.Where(x => { return x.get_Parameter(a).AsString() == value; }).ToList();
                }
                if (filterConditionFullItem == FilterConditionEnum.FilterConditionFull.Не_равно) // 1 - не равно
                {
                    listElemennts = listElemennts.Where(x => { return x.get_Parameter(a).AsString() != value; }).ToList();
                }
                if (filterConditionFullItem == FilterConditionEnum.FilterConditionFull.Содержит) // 6 - содержит
                {
                    listElemennts = listElemennts.Where(x => { return x.get_Parameter(a).AsString() != null && x.get_Parameter(a).AsString().Contains(value); }).ToList();
                }
                if (filterConditionFullItem == FilterConditionEnum.FilterConditionFull.Не_содержит) // 7 - не содержит
                {
                    listElemennts = listElemennts.Where(x => { return x.get_Parameter(a).AsString() == null || !x.get_Parameter(a).AsString().Contains(value); }).ToList();
                }
                if (filterConditionFullItem == FilterConditionEnum.FilterConditionFull.Начинается_с) // 8 - начинается на
                {
                    listElemennts = listElemennts.Where(x => { return x.get_Parameter(a).AsString() != null && x.get_Parameter(a).AsString().StartsWith(value); }).ToList();
                }
                if (filterConditionFullItem == FilterConditionEnum.FilterConditionFull.Не_начинается_с) // 9 - не начинается на
                {
                    listElemennts = listElemennts.Where(x => { return x.get_Parameter(a).AsString() != null && !x.get_Parameter(a).AsString().StartsWith(value); }).ToList();
                }
                if (filterConditionFullItem == FilterConditionEnum.FilterConditionFull.Заканчикавется_на) // 10 - заканчивается на
                {
                    listElemennts = listElemennts.Where(x => { return x.get_Parameter(a).AsString() != null && x.get_Parameter(a).AsString().EndsWith(value); }).ToList();
                }
                if (filterConditionFullItem == FilterConditionEnum.FilterConditionFull.Не_заканчивается_на) // 11 - не заканчивается на
                {
                    listElemennts = listElemennts.Where(x => { return x.get_Parameter(a).AsString() != null && !x.get_Parameter(a).AsString().EndsWith(value); }).ToList();
                }
                if (filterConditionFullItem == FilterConditionEnum.FilterConditionFull.Имеет_значение) // 12 - имеет значение
                {
                    listElemennts = listElemennts.Where(x => { return x.get_Parameter(a).AsString() != null && x.get_Parameter(a).AsString() != ""; }).ToList();
                }
                if (filterConditionFullItem == FilterConditionEnum.FilterConditionFull.Не_имеет_значение) // 13 - не имеет значение
                {
                    listElemennts = listElemennts.Where(x => { return x.get_Parameter(a).AsString() == null || x.get_Parameter(a).AsString() == ""; }).ToList();
                }
            }
            return listElemennts;
        }

        public static void SelectedMethod(List<Element> elements)
        {
            var ids = elements.Select(x => x.Id).Distinct().ToList();
            CurrentModel.UiDoc.Selection.SetElementIds(ids);

        }
        public static void SelectedMethod()
        {
            List<Element> elements = new List<Element>();
            var ids = elements.Select(x => x.Id).ToList();
            CurrentModel.UiDoc.Selection.SetElementIds(ids);

        }
    }
}
