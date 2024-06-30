#region Usings
using CheckModulName.Models;
using CheckModulName.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
#endregion

namespace CheckModulName.Views
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Инициализация основного окна
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            CurrentWindow.Wnd = this;
            this.Show();
        }

        /// <summary>
        /// Обработчик кнопки "Получить имя текущего модуля" (текущей модели)
        /// </summary>
        private void btn_TakeCurrentName_Click(object sender, RoutedEventArgs e)
        {
            CurrentWindow.Wnd.ModulName.Background = Brushes.White;

            ModulName.Text = CurrentModel.CurrentModulName
                    .Replace($"_{CurrentModel.CurrentUser}", "")
                    .Replace($"_отсоединено", "");
        }

        /// <summary>
        /// Обработчик кнопки проверки модулей одиночно и пакетно
        /// </summary>
        private void btn_StartCheck_Click(object sender, RoutedEventArgs e)
        {           
           VariantController variantControl = new VariantController(ModulName.Text);
        }

        /// <summary>
        /// Обработчик изменения текста пользователем в основном окне в поле имени модуля
        /// </summary>
        private void textChangedEventHandler(object sender, TextChangedEventArgs args)
        {
            CurrentWindow.Wnd.ModulName.Background = Brushes.White;
        }
    }
}
