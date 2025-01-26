using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomAffiliation.Models
{
    public  class AffiliationSituation
    {
        public Room room { get; set; }
        public Element element { get; set; }
    }
}
