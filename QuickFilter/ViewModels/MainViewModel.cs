using Autodesk.Revit.UI;
using DevExpress.Mvvm;
using QuickFilter.Models;

namespace QuickFilter.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        CurrentModel Model { get; set; } 

        public MainViewModel (ExternalCommandData commandData)
        {
            Model.GetFullInfo (commandData);
        }    
    }
}
