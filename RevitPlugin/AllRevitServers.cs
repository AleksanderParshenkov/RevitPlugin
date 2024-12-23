#region Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System.Diagnostics;

#endregion


// Õ≈ »—œŒÀ‹«Œ¬¿“‹


namespace RevitPlugin
{
    [Transaction(TransactionMode.Manual)]
    public class AllRevitServers : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData,ref string message,ElementSet elements)
        {
            global::AllRevitServers.App filter = new global::AllRevitServers.App();
            filter.Execute(commandData, ref message, elements);

            return Result.Succeeded;
        }
    }
}
