using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.UI;
using RoomAffiliation.Support;
using RoomAffiliation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RoomAffiliation.Controllers
{
    public class SetAffiliationRoomController
    {
        public SetAffiliationRoomController(List<Room> roomList, List<Element> elementList)
        {
            // Создание пустого списка ситуаций принадлежности
            List <AffiliationSituation> affiliationSituationList = new List<AffiliationSituation> ();

            /// Необходимо получить отрезки границ с координатами для каждого помещения.
            foreach (Room room in roomList)
            {
                // Формирование орции получения сегментов помещения
                var spatOpts = new SpatialElementBoundaryOptions();
                spatOpts.SpatialElementBoundaryLocation = SpatialElementBoundaryLocation.Finish;
                spatOpts.StoreFreeBoundaryFaces = true;
                var boundarySegmentsList = room.GetBoundarySegments(spatOpts);

                // Создание пустого списка отрезков границ помещения
                List<RoomAffiliation.Models.LineSegment> lineSegmentList = new List<RoomAffiliation.Models.LineSegment>();

                // Создание экстремумов точек границ помещения 
                int index = 0;
                double XminRoom = 0;
                double XmaxRoom = 0;
                double YminRoom = 0;
                double YmaxRoom = 0;
                double ZminRoom = 0;                

                // Заполнение списка отрезков границ помещения
                if (null != boundarySegmentsList)  //Проверка есть ли сегменты
                {
                    foreach (IList<Autodesk.Revit.DB.BoundarySegment> segmentList in boundarySegmentsList)
                    {
                        foreach (Autodesk.Revit.DB.BoundarySegment boundarySegment in segmentList)
                        {
                            Models.LineSegment lineSegment = new Models.LineSegment();

                            lineSegment.startPoint = new XYZ(
                                boundarySegment.GetCurve().GetEndPoint(0).X,
                                boundarySegment.GetCurve().GetEndPoint(0).Y,
                                boundarySegment.GetCurve().GetEndPoint(0).Z);

                            lineSegment.endPoint = new XYZ(
                                boundarySegment.GetCurve().GetEndPoint(1).X,
                                boundarySegment.GetCurve().GetEndPoint(1).Y,
                                boundarySegment.GetCurve().GetEndPoint(1).Z);

                            // Добавление отрезка в список отрезков
                            lineSegmentList.Add(lineSegment);

                            // Создание переменных экстремумов отрезка границы
                            double Xmin;
                            double Xmax;
                            double Ymin;
                            double Ymax;
                            double Zmin;
                            double Zmax;

                            // Назначение Xmin и Xmax
                            if (lineSegment.startPoint.X < lineSegment.endPoint.X) Xmin = lineSegment.startPoint.X;
                            else Xmin = lineSegment.endPoint.X;
                            if (lineSegment.startPoint.X > lineSegment.endPoint.X) Xmax = lineSegment.startPoint.X;
                            else Xmax = lineSegment.endPoint.X;

                            // Назначение Xmin и Xmax
                            if (lineSegment.startPoint.Y < lineSegment.endPoint.Y) Ymin = lineSegment.startPoint.Y;
                            else Ymin = lineSegment.endPoint.Y;
                            if (lineSegment.startPoint.Y > lineSegment.endPoint.Y) Ymax = lineSegment.startPoint.Y;
                            else Ymax = lineSegment.endPoint.Y;

                            // Назначение Xmin и Xmax
                            if (lineSegment.startPoint.Z < lineSegment.endPoint.Z) Zmin = lineSegment.startPoint.Z;
                            else Zmin = lineSegment.endPoint.Z;
                            if (lineSegment.startPoint.Z > lineSegment.endPoint.Z) Zmax = lineSegment.startPoint.Z;
                            else Zmax = lineSegment.endPoint.Z;
                            
                            // Первичное назначение экстремумов и переназначение
                            if (index == 0)
                            {
                                XminRoom = Xmin; XmaxRoom = Xmax;
                                YminRoom = Ymin; YmaxRoom = Ymax;
                                ZminRoom = Zmin; 
                            }
                            else
                            {
                                if (Xmin < XminRoom) XminRoom = Xmin;
                                if (Xmax > XmaxRoom) XmaxRoom = Xmax;

                                if (Ymin < YminRoom) YminRoom = Ymin;
                                if (Ymax > YmaxRoom) YmaxRoom = Ymax;

                                if (Zmin < ZminRoom) ZminRoom = Zmin;                                
                            }

                            // Добаление к индексу (+1).
                            index++;                           
                        }
                    }
                }

                double ZmaxRoom = ZminRoom +  room.get_Parameter(BuiltInParameter.ROOM_HEIGHT).AsDouble();

                /// Перебор списка элементов.
                /// Фильтрация элементов, точка вставки которых находится в объеме помещения
                foreach (var element in elementList)
                {
                    // Получение точки вставки элемента
                    LocationPoint locationPointElement = element.Location as LocationPoint;
                    XYZ startPointElement = locationPointElement.Point;

                    // Получение конечной точки элемента (вторая точка отрезка элемента) 
                    XYZ endPointElement = new XYZ(startPointElement.X, YmaxRoom + 1, startPointElement.Z);

                    if (startPointElement.Z >= ZminRoom && startPointElement.Z <= ZmaxRoom) 
                    {
                        // Формирование отрезка проверки
                        Models.LineSegment elementLineSegment = new Models.LineSegment()
                        {
                            startPoint = startPointElement,
                            endPoint = endPointElement,
                        };


                        /// Проверка должна быть произведена для каждого отрезка границы помещения
                        /// Проверка на пересечение отрезков

                        int intersectionCount = 0;

                        foreach (var roomLineSegment in lineSegmentList)
                        {

                            bool isIntersection = SupportMethods.CheckIntersection(roomLineSegment, elementLineSegment);

                            if (isIntersection)
                            {
                                intersectionCount++;
                            }
                        }

                        // Проверка количества пересечений (если нечетное - то точка внутри, если четное - вне помещения)
                        if (intersectionCount % 2 == 1)
                        {
                            AffiliationSituation affiliationSituation = new AffiliationSituation()
                            {
                                room = room,
                                element = element,
                            };
                            affiliationSituationList.Add(affiliationSituation);
                        }

                        TransactionController transactionController = new TransactionController(affiliationSituationList);
                    }  
                }                
            }
        }
    }
}
