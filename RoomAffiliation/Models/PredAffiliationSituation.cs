using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomAffiliation.Models
{
    public class PredAffiliationSituation
    {
        public Element element {  get; set; }        
        public Room room { get; set; }
        public List<RoomAffiliation.Models.LineSegment> lineSegmentList { get; set; }  
    }
}
