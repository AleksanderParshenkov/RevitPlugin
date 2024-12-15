using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.DB;
using DimensionsControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Autodesk.Revit.UI;

namespace DimensionsControl.ViewModels
{
    [Regeneration(RegenerationOption.Manual)]
    [Transaction(TransactionMode.Manual)]
    public class CreateController : IExternalCommand
    {        
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            List<MyDimension> dimensions = ReportDimensions.ReportDimensionList;

            using (Transaction tr = new Transaction(CurrentModel.Doc, "Создание указателей размеров"))
            {
                tr.Start();

                foreach (MyDimension dimension in dimensions)
                {
                    for (int i = 0; i < dimension.TextPositionList.Count; i++)
                    {
                        XYZ xyz = dimension.TextPositionList[i];
                        string value = dimension.ValueStringList[i];

                        CurrentModel.Doc.Create.NewFamilyInstance(xyz, , dimension.View);
                    }
                }
                tr.Commit();
            }
            return Result.Succeeded;
        }
    }
}
