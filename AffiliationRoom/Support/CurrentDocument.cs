using Autodesk.Revit.UI;

namespace AffiliationRoom.Support
{
    public static class CurrentDocument
    {
        public static ExternalCommandData CommandData { internal get; set; }
        public static UIApplication UiApp { internal get; set; }
        public static UIDocument UiDoc { internal get; set; }
        public static Autodesk.Revit.DB.Document Doc { internal get; set; }

        public static void GetParamCurrentModel(ExternalCommandData commandData)
        {
            CommandData = commandData;
            UiApp = CommandData.Application;
            UiDoc = UiApp.ActiveUIDocument;
            Doc = UiDoc.Document;
        }
    }
}
