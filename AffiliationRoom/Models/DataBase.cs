using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AffiliationRoom.Models
{
    class DataBase
    {
        public static IEnumerable<ParametersCouple> GetParametersCouple()
        {
            return new ParametersCouple[]
            {
                new ParametersCouple{
                    RoomParameter = "Имя",
                    ElementParameter = "ROM_Имя помещения в офисе"
                },
                new ParametersCouple{
                    RoomParameter = "Номер",
                    ElementParameter = "ROM_Номер"
                }
            };
        }
    }
}
