using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using QuickFilter.Models;
using QuickFilter.ViewModels;
using QuickFilter.Views;

namespace QuickFilter
{
    [Regeneration(RegenerationOption.Manual)]
    [Transaction(TransactionMode.Manual)]
    public class Cmd : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            CurrentModel.SetValues(commandData);
            MainViewModel mainViewModel = new MainViewModel();
            MainWindow window = new MainWindow();
            window.ShowDialog();
            return Result.Succeeded;
        }
    }
}
