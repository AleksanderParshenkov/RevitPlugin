using Autodesk.Revit.DB;
using RoomAffiliation.Models;
using System.Collections.Generic;
using System.Linq;

namespace RoomAffiliation.Support
{
    public class SupportMethods
    {
        public static List<Autodesk.Revit.DB.Document> GetLinkRevitDocuments()
        {
            List<Autodesk.Revit.DB.Document> elementsCollectorCurrentModel = new FilteredElementCollector(CurrentModel.Doc)
                .WhereElementIsNotElementType()
                .OfClass(typeof(RevitLinkInstance))
                .Where(instance => RevitLinkType.IsLoaded(CurrentModel.Doc, instance.GetTypeId()))
                .Select(x => (RevitLinkInstance)x)
                .Select(instance => instance.GetLinkDocument())
                .ToList();

            return elementsCollectorCurrentModel;
        }
    }
}
