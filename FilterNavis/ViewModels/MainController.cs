using Autodesk.Revit.DB;
using FilterNavis.Models;
using FilterNavis.Support;
using FilterNavis.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FilterNavis.ViewModels
{
    public class MainController
    {   
        public MainController() 
        {
            if (PluginMode.IsCheckLinkRevitModel)
            {
                CurrentModel.GetCurrentModelElements();
                CurrentModel.GetLinkModelElements();
            }
            else
            {
                CurrentModel.GetCurrentModelElements();
            }
            
            List <Element> elementCollector = new List <Element>();
            if (CurrentModel.CurrentModelElementsList != null && CurrentModel.CurrentModelElementsList.Count > 0) foreach (var  element in CurrentModel.CurrentModelElementsList) { elementCollector.Add(element); }
            if (CurrentModel.LinkModelElementsList != null && CurrentModel.LinkModelElementsList.Count > 0) foreach (var element in CurrentModel.LinkModelElementsList) { elementCollector.Add(element); }

            CurrentModel.ModelElements = elementCollector;
            CurrentModel.GetAllCategoies();

            MainWindow Wnd = new MainWindow();
            CurrentWindow.Wnd = Wnd;

            SupportMethods.SetItemSourceToComboBoxMainWindow();
        }
    }
}
