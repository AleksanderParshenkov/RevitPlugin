using Autodesk.Revit.DB;
using FilterNavis.Enums;
using FilterNavis.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilterNavis.Models
{
    public class CurrentWindow
    {
        public static MainWindow Wnd { get; set; }
        public static bool IsWritedRow0 { get; set; }
        public static bool IsWritedRow1 { get; set; }
        public static bool IsWritedRow2 { get; set; }
        public static bool IsWritedRow3 { get; set; }
        public static bool IsWritedRow4 { get; set; }

        public static bool IsCheckRow0 { get; set; }
        public static bool IsCheckRow1 { get; set; }
        public static bool IsCheckRow2 { get; set; }
        public static bool IsCheckRow3 { get; set; }
        public static bool IsCheckRow4 { get; set; }

        public static FilterAndOrOrEnum.FilterAndOrOr AndOrOr0 { get; set; }
        public static FilterAndOrOrEnum.FilterAndOrOr AndOrOr1 { get; set; }
        public static FilterAndOrOrEnum.FilterAndOrOr AndOrOr2 { get; set; }
        public static FilterAndOrOrEnum.FilterAndOrOr AndOrOr3 { get; set; }
        public static FilterAndOrOrEnum.FilterAndOrOr AndOrOr4 { get; set; }

        public static ModelCategory Category0 { get; set; }
        public static ModelCategory Category1 { get; set; }
        public static ModelCategory Category2 { get; set; }
        public static ModelCategory Category3 { get; set; }
        public static ModelCategory Category4 { get; set; }

        public static ModelParameter Parameter0 { get; set; }
        public static ModelParameter Parameter1 { get; set; }
        public static ModelParameter Parameter2 { get; set; }
        public static ModelParameter Parameter3 { get; set; }
        public static ModelParameter Parameter4 { get; set; }

        public static FilterConditionEnum.FilterConditionFull Condition0 { get; set; }
        public static FilterConditionEnum.FilterConditionFull Condition1 { get; set; }
        public static FilterConditionEnum.FilterConditionFull Condition2 { get; set; }
        public static FilterConditionEnum.FilterConditionFull Condition3 { get; set; }
        public static FilterConditionEnum.FilterConditionFull Condition4 { get; set; }


        public static string Value0 { get; set; }
        public static string Value1 { get; set; }
        public static string Value2 { get; set; }
        public static string Value3 { get; set; }
        public static string Value4 { get; set; }
    }
}
