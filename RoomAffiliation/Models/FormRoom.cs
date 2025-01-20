using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomAffiliation.Models
{
    public class FormRoom
    {     
        public List<XYZ> Points { get; set; }
        public double Zmin { get; set; }
        public double Zmax { get; set; }
        public Room room { get; set; }

        public void GetFormRoomProperties()
        {

        }
    }   
}
