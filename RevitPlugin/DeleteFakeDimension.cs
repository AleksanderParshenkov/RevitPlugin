#region Namespaces
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
#endregion

namespace RevitPlugin
{
    [Transaction(TransactionMode.Manual)]
    public class DeleteFakeDimension : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData,ref string message,ElementSet elements)
        {
            global::DeleteFakeDimension.App filter = new global::DeleteFakeDimension.App();
            filter.Execute(commandData, ref message, elements);

            return Result.Succeeded;
        }
    }
}
