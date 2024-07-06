using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilterNavis.Enums
{
    public static class FilterConditionEnum
    {
        public enum FilterConditionFull
        {
            Равно = 0,
            Не_равно = 1,
            Больше = 2,
            Больше_или_равно = 3,
            Меньше = 4,
            Меньше_или_равно = 5,
            Содержит = 6,
            Не_содержит = 7,
            Начинается_с = 8,
            Не_начинается_с = 9,
            Заканчикавется_на = 10,
            Не_заканчивается_на = 11,
            Имеет_значение = 12,
            Не_имеет_значение = 13
        }
    }
}
