using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckDimensions.Models
{
    public class ItemToDataGrid
    {
        public string ValueString { get; set; }
        public int SegmentCount { get; set; }
        public string ViewName { get; set; }
        public string SheetName { get; set; }

        public void GetParamItemToDataGrid(MyDimension myDimension)
        {
            ValueString = string.Join(", ", myDimension.ValueStringList);
            SegmentCount = myDimension.SegmentCount;
            ViewName = myDimension.ViewName;
            SheetName = myDimension.SheetName;
        }
    }
}
