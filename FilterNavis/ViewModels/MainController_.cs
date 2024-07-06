using Autodesk.Revit.UI;
using FilterNavis.Models;
using FilterNavis.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilterNavis.ViewModels
{
    public class MainController_
    {
        public MainController_(ExternalCommandData commandData)
        {
            // Writing full values in static class of current Revit Document
            CurrentModel.CommandData = commandData;
            CurrentModel.UiDoc = CurrentModel.CommandData.Application.ActiveUIDocument;
            CurrentModel.Doc = CurrentModel.UiDoc.Document;
            CurrentModel.Choices = CurrentModel.UiDoc.Selection;
            CurrentModel.ActiveView = CurrentModel.UiDoc.ActiveView;
            CurrentModel.Title = CurrentModel.Doc.Title;
            CurrentModel.FullName = CurrentModel.Doc.PathName;
            CurrentModel.AllElementsList = SharedMethodsStartViewInformation.GetAllMyElemetns(CurrentModel.Doc);
            CurrentModel.AllCategoriesList = SharedMethodsStartViewInformation.GetAllMyCategories(CurrentModel.AllElementsList, CurrentModel.Doc);

            // Initialization main window plague and writing this window to the static class            
            MainWindow Wnd = new MainWindow();
        }
    }
}
