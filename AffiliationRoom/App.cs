using AffiliationRoom.Support;
using AffiliationRoom.Views;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace AffiliationRoom
{
    [Regeneration(RegenerationOption.Manual)]
    [Transaction(TransactionMode.Manual)]
    public class App : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            CurrentDocument.GetParamCurrentModel(commandData);
            MainWindow window = new MainWindow();
            window.ShowDialog();
            return Result.Succeeded;
        }
    }
}
