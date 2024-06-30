#region Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System.Diagnostics;

#endregion


// �� ������������


namespace RevitPlugin
{
    [Transaction(TransactionMode.Manual)]
    public class SelectAll : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData,ref string message,ElementSet elements)
        {
            global::SelectAll.App filter = new global::SelectAll.App();
            filter.Execute(commandData, ref message, elements);

            return Result.Succeeded;
        }
    }
}
