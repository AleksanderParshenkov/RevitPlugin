#region Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System.Diagnostics;

#endregion


namespace RevitPlugin
{
    [Transaction(TransactionMode.Manual)]
    public class AffiliationRoom : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData,ref string message,ElementSet elements)
        {
            global::AffiliationRoom.App filter = new global::AffiliationRoom.App();
            filter.Execute(commandData, ref message, elements);

            return Result.Succeeded;
        }
    }
}
