using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FilterNavis.ViewModels
{
    public static class SharedMethodCheckRows
    {
        public static bool CheckWritedRows(CheckBox on, ComboBox andOr, ComboBox category, ComboBox parameter, ComboBox condition, TextBox value)
        {
            bool writedRow = false;

            // Проверка первой строки
            if (on.IsChecked == true)
            {
                if (andOr.SelectedItem != null &&
                    category.SelectedItem != null &&
                    parameter.SelectedItem != null &&
                    condition.SelectedItem != null) // &&
                                                    //value.Text != null &&
                                                    //value.Text != "")
                {
                    writedRow = true;
                }
            }
            if (on.IsChecked == true && writedRow == false)
            {
                andOr.BorderBrush = System.Windows.Media.Brushes.Red;
            }

            return writedRow;

        }

        public static bool CheckUseRows(CheckBox on, bool WritedRow)
        {
            bool checkedRow = false;
            if (on.IsChecked == true && WritedRow == true)
            {
                checkedRow = true;
            }
            return checkedRow;
        }
    }
}
