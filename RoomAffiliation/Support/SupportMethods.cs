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
            List<Element> elementListCurrentModel = new FilteredElementCollector(document)
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

        public static bool CheckIntersection(Models.LineSegment segment_1, Models.LineSegment segment_2)
        {
            // Назначение переменных для выполнения расчета
            double x1 = segment_1.startPoint.X;
            double y1 = segment_1.startPoint.Y;

            double x2 = segment_1.endPoint.X;
            double y2 = segment_1.endPoint.Y;

            double x3 = segment_2.startPoint.X;
            double y3 = segment_2.startPoint.Y;

            double x4 = segment_2.endPoint.X;
            double y4 = segment_2.endPoint.Y;

            // Проверка параллельности отрезков
            double k1 = (x2 - x1) / (y2 - y1);
            double k2 = (x4 - x3) / (y4 - y3);
            if (k1 == k2) { return false; }
            
            // Нахождение пересечения прямых
            double X= ((x1 * y2 - x2 * y1) * (x4 - x3) - (x3 * y4 - x4 * y3) * (x2 - x1)) / ((y1 - y2) * (x4 - x3) - (y3 - y4) * (x2 - x1));
            double Y = ((y3 - y4) * X - (x3 * y4 - x4 * y3)) / (x4 - x3);

            // Проверка нахождения точки пересечения на отрезках
            if ((((x1 <= X)&&(x2 >= X)&&(x3 <= X)&&(x4 >= X)) || ((y1 <= Y) && (y2 >= Y) && (y3 <= Y) && (y4 >= Y)))) { return true; }

            return false;
        }
    }
}
