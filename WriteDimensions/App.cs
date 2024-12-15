using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
using WriteDimensions.ViewModels;

namespace WriteDimensions
{
    [Transaction(TransactionMode.Manual)]
    public class App : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, Autodesk.Revit.DB.ElementSet elements)
        {
            MainController mainController = new MainController(commandData);

            return Result.Succeeded;
        }
    }
}
