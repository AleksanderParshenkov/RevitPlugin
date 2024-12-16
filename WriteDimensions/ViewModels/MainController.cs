using Autodesk.Revit.UI;
using WriteDimensions.Models;
using WriteDimensions.Support;
using WriteDimensions.Views;

namespace WriteDimensions.ViewModels
{
    internal class MainController
    {
        public MainController(ExternalCommandData commandData)
        {
            // Получение и запись информации о текущей модели
            CurrentModel.GetParamCurrentModel(commandData);

            MainConfig.IsAproove = false;

            // Создание экземпляра основного интерфейса (окна)
            MainWindow Wnd = new MainWindow();

            if (MainConfig.IsAproove == true) { WriteController writeController = new WriteController(); }
            else { }
        }
    }
}
