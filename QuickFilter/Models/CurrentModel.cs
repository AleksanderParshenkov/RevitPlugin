using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickFilter.Models
{
    class CurrentModel
    {
        public ExternalCommandData CommandData { internal get; set; }
        public UIApplication UiApp { internal get; set; }
        public UIDocument UiDoc { internal get; set; }
        public Autodesk.Revit.DB.Document Doc { internal get; set; }

        public void GetFullInfo(ExternalCommandData commandData)
        {
            CommandData = commandData;
            UiApp = CommandData.Application;
            UiDoc = UiApp.ActiveUIDocument;
            Doc = UiDoc.Document;
        }
    }
}
