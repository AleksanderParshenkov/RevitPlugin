using Autodesk.Revit.DB;
using DevExpress.Mvvm;

namespace AffiliationRoom.Models
{
    class LinkDocument : ViewModelBase
    {
        public string Name { get; set; }    
        public RevitLinkInstance LinkInstance { get; set; }
        public Document LinkInstanceDocument { get; set; }
    }
}
