using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickFilter.Models
{
    public class CurrentModel
    {
        private static ExternalCommandData commandData;
        private static UIApplication uiApp;
        private static UIDocument uiDoc;
        private static Autodesk.Revit.DB.Document doc;

        private CurrentModel() { }
                
        public static void SetValues(ExternalCommandData _commandData)
        {
            if (commandData == null)
            {
                commandData = _commandData;
                uiApp = commandData.Application;
                uiDoc = uiApp.ActiveUIDocument;
                doc = uiDoc.Document;
            }
        }
                
        public static Document getDocument()
        {
            return doc;
        }
    }
}
