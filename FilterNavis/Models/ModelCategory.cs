using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilterNavis.Models
{
    public class ModelCategory
    {        
        public string Name { get; set; }
        public ElementId Id { get; set; }
        public List<ModelParameter> CategoryParameters { get; set; }        
    }
}
