using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilterNavis.Models
{
    public class CurrentElement
    {
        public Element Element { get; set; }
        public string Id { get; set; }
        public string TitleModel { get; set; }
    }
}
