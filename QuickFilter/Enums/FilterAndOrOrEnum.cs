using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickFilter.Enums
{
    public static class FilterAndOrOrEnum
    {
        public enum FilterAndOrOr
        {
            [Description("ИЛИ")]
            or = 0,
            [Description("И")]
            and = 1
        }
    }
}
