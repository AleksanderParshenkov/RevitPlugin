#region Namespaces
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
#endregion


namespace RevitPlugin
{
    [Transaction(TransactionMode.Manual)]
    public class CheckDimensions : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData,ref string message,ElementSet elements)
        {
            global::CheckDimensions.App filter = new global::CheckDimensions.App();
            filter.Execute(commandData, ref message, elements);

            return Result.Succeeded;
        }
    }
}
