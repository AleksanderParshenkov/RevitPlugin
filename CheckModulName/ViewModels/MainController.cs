#region Usings
using Autodesk.Revit.UI;
using CheckModulName.Models;
using CheckModulName.Views;
#endregion

namespace CheckModulName.ViewModels
{
    /// <summary>
    /// Основной контроллер,
    /// задача которого - заполнение свойств статического класса,
    /// являющихся постоянными сведениями о текущей запущенной модели, 
    /// а также запустить основной интерфейс плагина для последующей работы
    /// </summary>
    public class MainController
    {
        public MainController(ExternalCommandData commandData)
        {
            // Получение и запись информации о текущей модели
            CurrentModel.GetParamCurrentModel(commandData);

            // Создание экземпляра основного интерфейса (окна)
            MainWindow Wnd = new MainWindow();
        }
    }
}
