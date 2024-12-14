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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.ShowDialog();
        }

        private void btn_CheckDimension_Click(object sender, RoutedEventArgs e)
        {
            CheckController checkController = new CheckController();
        }

        private void btn_WriteDimension_Click(object sender, RoutedEventArgs e)
        {
            WriteController writeController = new WriteController();
        }
    }
}
