using AffiliationRoom.Models;
using AffiliationRoom.Support;
using Autodesk.Revit.DB;
using System.Collections.Generic;
using System.Linq;

namespace AffiliationRoom.Services
{
    static class GetLinkDocumentList
    {
        public static IEnumerable<LinkDocument> GetLinkDocumentListMethod()
        {
            var result = new FilteredElementCollector(CurrentDocument.Doc)
                .WhereElementIsNotElementType()
                .OfClass(typeof(RevitLinkInstance))
                .Where(instance => RevitLinkType.IsLoaded(CurrentDocument.Doc, instance.GetTypeId()))
                .Select(x => (RevitLinkInstance)x)
                .Select(x =>
                {
                    LinkDocument linkDocument = new LinkDocument();
                    linkDocument.Name = x.Name;
                    linkDocument.LinkInstance = x;
                    linkDocument.LinkInstanceDocument = x.GetLinkDocument();
                    return linkDocument;
                });

            return result;
        }
    }
}
