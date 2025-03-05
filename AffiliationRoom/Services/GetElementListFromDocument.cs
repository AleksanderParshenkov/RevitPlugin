using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;

namespace AffiliationRoom.Services
{
    public static class GetElementListFromDocument
    {
        public static List<Room> GetRoomList(Document document)
        {
            return new FilteredElementCollector(document)
                .WhereElementIsNotElementType()
                .OfCategory(BuiltInCategory.OST_Rooms)
                .Select(x => (Room)x)
                .Where(x => x.Area >0 && x.Perimeter > 0)
                .ToList();
        }

        public static List<Element> GetElementList(Document document)
        {
            List < Element > result = new List<Element>();

            foreach (var item in Config._categories)
            {
                List<Element> elementListCurrentModel = new FilteredElementCollector(document)
                    .WhereElementIsNotElementType()
                    .OfCategory(item)
                    .Select(x => x as Element)
                    .ToList();

                foreach (var element in elementListCurrentModel) result.Add((Element)element);
            }

            return result;
        }
    }
}
