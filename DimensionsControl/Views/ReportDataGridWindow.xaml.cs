using DimensionsControl.ViewModels;
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

namespace DimensionsControl.Views
{
    /// <summary>
    /// Логика взаимодействия для ReportDataGridWindow.xaml
    /// </summary>
    public partial class ReportDataGridWindow : Window
    {
        public ReportDataGridWindow()
        {
            InitializeComponent();
        }

        private void btn_Create_Click(object sender, RoutedEventArgs e)
        {
            CreateController createController = new CreateController();
        }

        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            DeleteController deleteController = new DeleteController();
        }
    }
}
