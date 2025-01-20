using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickFilter.Enums
{
    public static class FilterConditionEnum
    {
        public enum FilterConditionFull
        {
            [Description("Равно")]
            Equals = 0,
            [Description("Не равно")]
            NotEquals = 1,
            [Description("Больше")]
            More = 2,
            [Description("Больше или равно")]
            MoreAndEquals = 3,
            [Description("Меньше")]
            Less = 4,
            [Description("Меньше или равно")]
            LessAndEquals = 5,
            [Description("Содержит")]
            Contained = 6,
            [Description("Не содержит")]
            NotContained = 7,
            [Description("Начинается с")]
            StartWith = 8,
            [Description("Не начинается с")]
            NotStartWith = 9,
            [Description("Заканчивается на")]
            EndWith = 10,
            [Description("Не заканчивается на")]
            NotEndWith = 11,
            [Description("Имеет значение")]
            HadValue = 12,
            [Description("Не имеет значения")]
            NotHadValue = 13
        }
    }
}
