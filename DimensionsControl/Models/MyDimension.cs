using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DimensionsControl.Models
{
    public class MyDimension
    {
        public int Id { get; set; }
        public int ViewId { get; set; }
        public string ViewName { get; set; }
        public string SheetName { get; set; }

        public bool ViewInList { get; set; }
        public int SegmentCount { get; set; }


        public List <double?> ValueList { get; set; }
        public List <string> ValueStringList { get; set; }        
        public List<XYZ> TextPositionList { get; set; }


        public void GetParamMyDimension(Dimension dimension)
        {
            // Запись Id размера, Id вида и имя вида, на котором он размещен
            this.Id = dimension.Id.IntegerValue;
            this.ViewId = dimension.View.Id.IntegerValue;
            this.ViewName = dimension.View.get_Parameter(BuiltInParameter.VIEW_NAME).AsString();


            // Размещенность размера на листах
            string numberSheet = dimension.View.get_Parameter(BuiltInParameter.VIEWER_SHEET_NUMBER).AsString();
            if (numberSheet == null || numberSheet == "" || numberSheet == "---")
            {
                this.ViewInList = false;
                this.SheetName = "none";
            }
            else 
            {
                this.ViewInList = true;
                this.SheetName = dimension.View.get_Parameter(BuiltInParameter.VIEWPORT_SHEET_NAME).AsString();
            } 


            // Количество сегментов в размере
            if (dimension.ValueString == null || dimension.ValueString == "") this.SegmentCount = dimension.Segments.Size;
            else this.SegmentCount = 1;

            this.ValueList = new List<double?>();
            this.ValueStringList = new List<string>();
            this.TextPositionList = new List<XYZ>();

            // Получение массива позиций текста, дюймовых и стринговых значений  
            if (this.SegmentCount == 1)
            {
                this.TextPositionList.Add(dimension.TextPosition);
                this.ValueList.Add(dimension.Value);
                this.ValueStringList.Add(dimension.ValueString);
            }
            else
            {
                foreach (var segment in dimension.Segments)
                {
                    DimensionSegment dimensionSegment = segment as DimensionSegment;
                    this.TextPositionList.Add(dimensionSegment.TextPosition);
                    this.ValueList.Add(dimensionSegment.Value);
                    this.ValueStringList.Add(dimensionSegment.ValueString);
                }
            }
        }
    }
}
