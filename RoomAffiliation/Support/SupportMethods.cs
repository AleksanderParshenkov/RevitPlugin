using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using RoomAffiliation.Models;
using RoomAffiliation.Views;
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

        public static List<Room> GetRoomListFromLinkDocument(Document document)
        {
            List<Room> resultList = new List<Room>();

            // Получение экземпляров всех помещений в связанном документе
            var elementsCollectorLinkModel = new FilteredElementCollector(LinkModel.LinkInstanceDocument)
                .WhereElementIsNotElementType()
                .OfCategory(BuiltInCategory.OST_Rooms);
            List<Room> rooms = elementsCollectorLinkModel.Select(x => (Room)x).ToList();

            foreach (var roomsItem in rooms)
            {
                if (roomsItem.Area > 0 && roomsItem.Perimeter > 0) { resultList.Add(roomsItem); }
            }

            return resultList;
        }
        public static List<Element> GetElementListFromCurrentDocument(Document document)
        {
            // Получение списка элементов в текущей модели
            List <Element> elementListCurrentModel = new FilteredElementCollector(document)
                .WhereElementIsNotElementType()
                .OfCategory(BuiltInCategory.OST_Furniture)
                .Select(x => x as Element)
                .ToList();

            return elementListCurrentModel;
        }

        public static List<ParametersCouple> GetCoupleParametersList(MainWindow wnd)
        {
            List<ParametersCouple> parametersCouples = new List<ParametersCouple>();

            ParametersCouple parametersCouple_1 = new ParametersCouple()
            {
                RoomParameter = wnd.tb_ParameterRoom_1.Text,
                ElementParameter = wnd.tb_ParameterElement_1.Text,
            };
            ParametersCouple parametersCouple_2 = new ParametersCouple()
            {
                RoomParameter = wnd.tb_ParameterRoom_2.Text,
                ElementParameter = wnd.tb_ParameterElement_2.Text,
            };
            ParametersCouple parametersCouple_3 = new ParametersCouple()
            {
                RoomParameter = wnd.tb_ParameterRoom_3.Text,
                ElementParameter = wnd.tb_ParameterElement_3.Text,
            };
            ParametersCouple parametersCouple_4 = new ParametersCouple()
            {
                RoomParameter = wnd.tb_ParameterRoom_4.Text,
                ElementParameter = wnd.tb_ParameterElement_4.Text,
            };
            ParametersCouple parametersCouple_5 = new ParametersCouple()
            {
                RoomParameter = wnd.tb_ParameterRoom_5.Text,
                ElementParameter = wnd.tb_ParameterElement_5.Text,
            };

            parametersCouples.Add(parametersCouple_1);
            parametersCouples.Add(parametersCouple_2);
            parametersCouples.Add(parametersCouple_3);
            parametersCouples.Add(parametersCouple_4);
            parametersCouples.Add(parametersCouple_5);

            return parametersCouples;
        }
    }
}
