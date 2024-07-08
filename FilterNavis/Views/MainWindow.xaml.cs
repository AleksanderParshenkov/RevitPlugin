using FilterNavis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FilterNavis.ViewModels;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Windows.Diagnostics;
using Binding = System.Windows.Data.Binding;
using System.Data.Common;
using FilterNavis.Enums;
using FilterNavis.Support;

namespace FilterNavis.Views
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            if (PluginMode.IsCheckLinkRevitModel) { IsCheckLinks.IsChecked = true; }
            else { IsCheckLinks.IsChecked = false;}

            

            double screenHeight = SystemParameters.FullPrimaryScreenHeight;
            double screenWidth = SystemParameters.FullPrimaryScreenWidth;
            this.Top = (screenHeight - this.Height) / 0x00000002;
            this.Left = (screenWidth - this.Width) / 0x00000002;

            this.Show();
        }

        private void btn_StartFiltering_Click(object sender, RoutedEventArgs e)
        {
            // Добавлен чек
            CheckController checkController = new CheckController();
            //FilterAndSelect.SelectedMethod();


            //// Check right write all rows in main filter
            //CurrentWindow.IsWritedRow0 = SharedMethodCheckRows.CheckWritedRows(CheckRow0, AndOr0, Category0, Parameter0, Condition0, Value0);
            //CurrentWindow.IsCheckRow0 = SharedMethodCheckRows.CheckUseRows(CheckRow0, CurrentWindow.IsWritedRow0);
            //CurrentWindow.IsWritedRow1 = SharedMethodCheckRows.CheckWritedRows(CheckRow1, AndOr1, Category1, Parameter1, Condition1, Value1);
            //CurrentWindow.IsCheckRow1 = SharedMethodCheckRows.CheckUseRows(CheckRow1, CurrentWindow.IsWritedRow1);
            //CurrentWindow.IsWritedRow2 = SharedMethodCheckRows.CheckWritedRows(CheckRow2, AndOr2, Category2, Parameter2, Condition2, Value2);
            //CurrentWindow.IsCheckRow2 = SharedMethodCheckRows.CheckUseRows(CheckRow2, CurrentWindow.IsWritedRow2);
            //CurrentWindow.IsWritedRow3 = SharedMethodCheckRows.CheckWritedRows(CheckRow3, AndOr3, Category3, Parameter3, Condition3, Value3);
            //CurrentWindow.IsCheckRow3 = SharedMethodCheckRows.CheckUseRows(CheckRow3, CurrentWindow.IsWritedRow3);
            //CurrentWindow.IsWritedRow4 = SharedMethodCheckRows.CheckWritedRows(CheckRow4, AndOr4, Category4, Parameter4, Condition4, Value4);
            //CurrentWindow.IsCheckRow4 = SharedMethodCheckRows.CheckUseRows(CheckRow4, CurrentWindow.IsWritedRow4);

            //if (CurrentWindow.IsWritedRow0 && CurrentWindow.IsCheckRow0)
            //{
            //    CurrentWindow.AndOrOr0 = (FilterAndOrOrEnum.FilterAndOrOr)this.AndOr0.SelectedItem;
            //    CurrentWindow.Category0 = this.Category0.SelectedItem as ModelCategory;
            //    CurrentWindow.Parameter0 = this.Parameter0.SelectedItem as ModelParameter;
            //    CurrentWindow.Condition0 = (FilterConditionEnum.FilterConditionFull)this.Condition0.SelectedItem;
            //    CurrentWindow.Value0 = this.Value0.Text;
            //}
            //if (CurrentWindow.IsWritedRow1 && CurrentWindow.IsCheckRow1)
            //{
            //    CurrentWindow.AndOrOr1 = (FilterAndOrOrEnum.FilterAndOrOr)this.AndOr1.SelectedItem;
            //    CurrentWindow.Category1 = this.Category1.SelectedItem as ModelCategory;
            //    CurrentWindow.Parameter1 = this.Parameter1.SelectedItem as ModelParameter;
            //    CurrentWindow.Condition1 = (FilterConditionEnum.FilterConditionFull)this.Condition1.SelectedItem;
            //    CurrentWindow.Value1 = this.Value1.Text;
            //}
            //if (CurrentWindow.IsWritedRow2 && CurrentWindow.IsCheckRow2)
            //{
            //    CurrentWindow.AndOrOr2 = (FilterAndOrOrEnum.FilterAndOrOr)this.AndOr2.SelectedItem;
            //    CurrentWindow.Category2 = this.Category2.SelectedItem as ModelCategory;
            //    CurrentWindow.Parameter2 = this.Parameter2.SelectedItem as ModelParameter;
            //    CurrentWindow.Condition2 = (FilterConditionEnum.FilterConditionFull)this.Condition2.SelectedItem;
            //    CurrentWindow.Value2 = this.Value2.Text;
            //}
            //if (CurrentWindow.IsWritedRow3 && CurrentWindow.IsCheckRow3)
            //{
            //    CurrentWindow.AndOrOr3 = (FilterAndOrOrEnum.FilterAndOrOr)this.AndOr3.SelectedItem;
            //    CurrentWindow.Category3 = this.Category3.SelectedItem as ModelCategory;
            //    CurrentWindow.Parameter3 = this.Parameter3.SelectedItem as ModelParameter;
            //    CurrentWindow.Condition3 = (FilterConditionEnum.FilterConditionFull)this.Condition3.SelectedItem;
            //    CurrentWindow.Value3 = this.Value3.Text;
            //}
            //if (CurrentWindow.IsWritedRow4 && CurrentWindow.IsCheckRow4)
            //{
            //    CurrentWindow.AndOrOr4 = (FilterAndOrOrEnum.FilterAndOrOr)this.AndOr4.SelectedItem;
            //    CurrentWindow.Category4 = this.Category4.SelectedItem as ModelCategory;
            //    CurrentWindow.Parameter4 = this.Parameter4.SelectedItem as ModelParameter;
            //    CurrentWindow.Condition4 = (FilterConditionEnum.FilterConditionFull)this.Condition4.SelectedItem;
            //    CurrentWindow.Value4 = this.Value4.Text;
            //}


            //List<Element> elements = FilterAndSelect.AllFilterMethod();
            //FilterAndSelect.SelectedMethod(elements);
        }
    }
}
