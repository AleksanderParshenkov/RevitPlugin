using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
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
            MainViewModel mainViewModel = new MainViewModel(commandData);
            MainWindow window = new MainWindow(mainViewModel);
            window.ShowDialog();
            return Result.Succeeded;
        }
    }
}
