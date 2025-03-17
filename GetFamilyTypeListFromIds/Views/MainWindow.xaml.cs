using GetFamilyTypeListFromIds.Services;
using System.Windows;

namespace GetFamilyTypeListFromIds.Views
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Result.Text = GetFamilyMethod.GetFamilyTypeListFromIdList(Ids.Text);
        }
    }
}
