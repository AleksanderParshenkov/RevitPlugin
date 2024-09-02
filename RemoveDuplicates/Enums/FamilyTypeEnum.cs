using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveDuplicates.Enums
{
    public enum FamilyTypeEnum
    {
        [Description("Системное семейство")]
        System,
        [Description("Пользовательское семейство")]
        User,
    }
}
