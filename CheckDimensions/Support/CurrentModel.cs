using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckDimensions.Support
{
    public static class CurrentModel
    {
        public static ExternalCommandData CommandData { internal get; set; }
        public static UIApplication UiApp { internal get; set; }
        public static UIDocument UiDoc { internal get; set; }
        public static Autodesk.Revit.ApplicationServices.Application App { internal get; set; }
        public static Autodesk.Revit.DB.Document Doc { internal get; set; }
        public static string CurrentModulName { internal get; set; }
        public static string CurrentUser { internal get; set; }

        /// <summary>
        /// Заполнение свойств
        /// </summary>
        public static void GetParamCurrentModel(ExternalCommandData commandData)
        {
            CommandData = commandData;
            UiApp = CommandData.Application;
            UiDoc = UiApp.ActiveUIDocument;
            App = UiApp.Application;
            Doc = UiDoc.Document;
            CurrentModulName = Doc.Title;
            CurrentUser = App.Username;
        }
    }
}
