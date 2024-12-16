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
    public class WriteDimensions : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData,ref string message,ElementSet elements)
        {
            global::WriteDimensions.App filter = new global::WriteDimensions.App();
            filter.Execute(commandData, ref message, elements);

            return Result.Succeeded;
        }
    }
}
