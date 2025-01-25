using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.UI;
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
            /// Необходимо получить отрезки границ с координатами для каждого помещения.
            foreach (Room room in roomList)
            {
                // Формирование орции получения сегментов помещения
                var spatOpts = new SpatialElementBoundaryOptions();
                spatOpts.SpatialElementBoundaryLocation = SpatialElementBoundaryLocation.Finish;
                spatOpts.StoreFreeBoundaryFaces = true;
                var boundarySegmentsList = room.GetBoundarySegments(spatOpts);

                List<RoomAffiliation.Models.LineSegment> lineSegmentList = new List<RoomAffiliation.Models.LineSegment>();
                

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

                            lineSegmentList.Add(lineSegment);
                        }
                    }
                }

                MessageBox.Show(lineSegmentList.Count.ToString());
            }
        }
    }
}
