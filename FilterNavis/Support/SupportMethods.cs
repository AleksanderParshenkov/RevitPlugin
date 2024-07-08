using Autodesk.Revit.DB;
using FilterNavis.Enums;
using FilterNavis.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FilterNavis.Support
{
    public static class SupportMethods
    {
        /// <summary>
        /// Получение описания enum
        /// </summary>
        public static string GetDescription(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute),
                false);

            if (attributes != null &&
                attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }
        public static List<string> GetAllDescription(Array valueEnumList)
        {            
            List<string> list = new List<string>();

            foreach (var item in valueEnumList)
            {
                var item1 = item as Enum;
                string description = GetDescription(item1);
                list.Add(description);
            }
            return list;
        }

        public static void SetItemSourceToComboBoxMainWindow()
        {
            List<ModelCategory> categories = CurrentModel.AllModelCategoriesList;

            CurrentWindow.Wnd.AndOr0.ItemsSource = SupportMethods.GetAllDescription(Enum.GetValues(typeof(FilterAndOrOrEnum.FilterAndOrOr)));
            CurrentWindow.Wnd.AndOr0.SelectedIndex = 1;
            CurrentWindow.Wnd.AndOr1.ItemsSource = CurrentWindow.Wnd.AndOr0.ItemsSource;
            CurrentWindow.Wnd.AndOr1.SelectedIndex = 1;
            CurrentWindow.Wnd.AndOr2.ItemsSource = CurrentWindow.Wnd.AndOr0.ItemsSource;
            CurrentWindow.Wnd.AndOr2.SelectedIndex = 1;
            CurrentWindow.Wnd.AndOr3.ItemsSource = CurrentWindow.Wnd.AndOr0.ItemsSource;
            CurrentWindow.Wnd.AndOr3.SelectedIndex = 1;
            CurrentWindow.Wnd.AndOr4.ItemsSource = CurrentWindow.Wnd.AndOr0.ItemsSource;
            CurrentWindow.Wnd.AndOr4.SelectedIndex = 1;

            CurrentWindow.Wnd.Category0.ItemsSource = categories;
            CurrentWindow.Wnd.Category1.ItemsSource = CurrentWindow.Wnd.Category0.ItemsSource;
            CurrentWindow.Wnd.Category2.ItemsSource = CurrentWindow.Wnd.Category0.ItemsSource;
            CurrentWindow.Wnd.Category3.ItemsSource = CurrentWindow.Wnd.Category0.ItemsSource;
            CurrentWindow.Wnd.Category4.ItemsSource = CurrentWindow.Wnd.Category0.ItemsSource;
        }
    }
}
