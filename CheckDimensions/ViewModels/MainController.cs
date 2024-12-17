using Autodesk.Revit.UI;
using CheckDimensions.Support;
using CheckDimensions.Views;

namespace CheckDimensions.ViewModels
{
    internal class MainController
    {
        public MainController(ExternalCommandData commandData)
        {
            // Получение и запись информации о текущей модели//
            CurrentModel.GetParamCurrentModel(commandData);


            CheckController checkController = new CheckController();
        }
    }
}
