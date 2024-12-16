using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WriteDimensions.Models
{
    public class MyDimension
    {
        public int Id { get; set; }
        public FamilySymbol FamilySymbol { get; set; }
        //public View View { get; set; }

        public int ViewId { get; set; }
        public string ViewName { get; set; }
        public string SheetName { get; set; }

        public bool ViewInList { get; set; }
        public int SegmentCount { get; set; }


        public List <double?> ValueList { get; set; }
        public List <string> ValueStringList { get; set; }        
        public List<XYZ> TextPositionList { get; set; }


        public List<double> TextPositionXList { get; set; }
        public List<double> TextPositionYList { get; set; }
        public List<double> TextPositionZList { get; set; }

        public void GetParamMyDimension(Dimension dimension)
        {
            // Запись Id размера, Id вида и имя вида, на котором он размещен
            this.Id = dimension.Id.IntegerValue;            

            //this.FamilySymbol = dimension.Get

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
            this.TextPositionXList = new List<double>();
            this.TextPositionYList = new List<double>();
            this.TextPositionZList = new List<double>();



            // Получение массива позиций текста, дюймовых и стринговых значений  
            if (this.SegmentCount == 1)
            {
                this.TextPositionList.Add(dimension.TextPosition);
                this.ValueList.Add(dimension.Value);
                this.ValueStringList.Add(dimension.ValueString);

                TextPositionXList.Add(dimension.TextPosition.X);
                TextPositionYList.Add(dimension.TextPosition.Y);
                TextPositionZList.Add(dimension.TextPosition.Z);
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

                foreach (var textPosition in TextPositionList)
                {
                    TextPositionXList.Add(textPosition.X);
                    TextPositionYList.Add(textPosition.Y);
                    TextPositionZList.Add(textPosition.Z);
                }
            }
        }
    }
}
