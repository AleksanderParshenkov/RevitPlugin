using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitPlugin
{
    [Transaction(TransactionMode.Manual)]
    public class CheckModulName : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            global::CheckModulName.App filter = new global::CheckModulName.App();
            filter.Execute(commandData, ref message, elements);

            return Result.Succeeded;
        }
    }
}
