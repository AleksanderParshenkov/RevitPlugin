using Autodesk.Revit.DB;
using DevExpress.Mvvm;
using System.Collections.Generic;

namespace QuickFilter.Models
{
    internal class FilterPack : ViewModelBase
    {
        public bool IsCheck {  get; set; }
        public Category Category { get; set; }
        public List<Parameter> ParameterList { get; set; }
        public string Filter { get; set; }
        public string Value { get; set; }
    }
}
