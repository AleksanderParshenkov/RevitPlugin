using QuickFilter.ViewModels;
using System.Windows;
using Autodesk.Revit.DB; // Обязательная


namespace QuickFilter.Views
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {            
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}
