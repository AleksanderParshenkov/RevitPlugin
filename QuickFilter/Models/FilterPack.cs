using Autodesk.Revit.DB;
using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickFilter.Models
{
    internal class FilterPack : ViewModelBase
    {
        bool IsCheck {  get; set; }
        Parameter Parameter { get; set; }
        string Filter { get; set; }
        string Value { get; set; }
    }
}
