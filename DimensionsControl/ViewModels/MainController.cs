using Autodesk.Revit.UI;
using DimensionsControl.Models;
using DimensionsControl.Views;

namespace DimensionsControl.ViewModels
{
    internal class MainController
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
