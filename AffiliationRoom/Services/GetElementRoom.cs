using AffiliationRoom.Models;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AffiliationRoom.Services
{
    static class GetElementRoom
    {
        public static List <LineSegmentRoom> GetLineSegmentRoomList(Room room, Transform transform, double angle)
        {
            // Формирование опции получения сегментов помещения
            var spatOpts = new SpatialElementBoundaryOptions();
            spatOpts.SpatialElementBoundaryLocation = SpatialElementBoundaryLocation.Finish;
            spatOpts.StoreFreeBoundaryFaces = true;
            var boundarySegmentsList = room.GetBoundarySegments(spatOpts);

            // Создание пустого списка отрезков границ помещения
            List<LineSegmentRoom> result = new List<LineSegmentRoom>();

            // Заполнение списка отрезков границ помещения
            if (null != boundarySegmentsList)  //Проверка есть ли сегменты
            {
                foreach (IList<Autodesk.Revit.DB.BoundarySegment> segmentList in boundarySegmentsList)
                {
                    foreach (Autodesk.Revit.DB.BoundarySegment boundarySegment in segmentList)
                    {
                        List<XYZ> tessellates = boundarySegment.GetCurve().Tessellate().ToList();

                        if (tessellates.Count == 2)
                        {
                            LineSegmentRoom lineSegment = new LineSegmentRoom();

                            lineSegment.startPoint = new XYZ(
                                (boundarySegment.GetCurve().GetEndPoint(0).X * Math.Cos(angle) - boundarySegment.GetCurve().GetEndPoint(0).Y * Math.Sin(angle)) + transform.Origin.X,
                                (boundarySegment.GetCurve().GetEndPoint(0).X * Math.Sin(angle) + boundarySegment.GetCurve().GetEndPoint(0).Y * Math.Cos(angle)) + transform.Origin.Y,
                                boundarySegment.GetCurve().GetEndPoint(0).Z + transform.Origin.Z);
                            lineSegment.endPoint = new XYZ(
                                (boundarySegment.GetCurve().GetEndPoint(1).X * Math.Cos(angle) - boundarySegment.GetCurve().GetEndPoint(1).Y * Math.Sin(angle)) + transform.Origin.X,
                                (boundarySegment.GetCurve().GetEndPoint(1).X * Math.Sin(angle) + boundarySegment.GetCurve().GetEndPoint(1).Y * Math.Cos(angle)) + transform.Origin.Y,
                                boundarySegment.GetCurve().GetEndPoint(1).Z + transform.Origin.Z);

                            result.Add(lineSegment);
                        }
                        else
                        {
                            for (int i = 0; i < tessellates.Count; i++)
                            {
                                LineSegmentRoom lineSegment = new LineSegmentRoom();

                                if (i == 0)
                                {

                                    lineSegment.startPoint = new XYZ(
                                        (tessellates[i].X * Math.Cos(angle) - tessellates[i].Y * Math.Sin(angle)) + transform.Origin.X,
                                        (tessellates[i].X * Math.Sin(angle) + tessellates[i].Y * Math.Cos(angle)) + transform.Origin.Y,
                                        tessellates[i].Z + transform.Origin.Z);

                                    lineSegment.endPoint = new XYZ(
                                        (tessellates[tessellates.Count - 1].X * Math.Cos(angle) - tessellates[tessellates.Count - 1].Y * Math.Sin(angle)) + transform.Origin.X,
                                        (tessellates[tessellates.Count - 1].X * Math.Sin(angle) + tessellates[tessellates.Count - 1].Y * Math.Cos(angle)) + transform.Origin.Y,
                                        tessellates[tessellates.Count - 1].Z + transform.Origin.Z);
                                }
                                else
                                {
                                    lineSegment.startPoint = tessellates[i];
                                    lineSegment.endPoint = tessellates[i - 1];

                                    lineSegment.startPoint = new XYZ(
                                        (tessellates[i].X * Math.Cos(angle) - tessellates[i].Y * Math.Sin(angle)) + transform.Origin.X,
                                        (tessellates[i].X * Math.Sin(angle) + tessellates[i].Y * Math.Cos(angle)) + transform.Origin.Y,
                                        tessellates[i].Z + transform.Origin.Z);

                                    lineSegment.endPoint = new XYZ(
                                        (tessellates[i - 1].X * Math.Cos(angle) - tessellates[i - 1].Y * Math.Sin(angle)) + transform.Origin.X,
                                        (tessellates[i - 1].X * Math.Sin(angle) + tessellates[i - 1].Y * Math.Cos(angle)) + transform.Origin.Y,
                                        tessellates[i - 1].Z + transform.Origin.Z);
                                }
                                result.Add(lineSegment);
                            }
                        }
                    }
                }
            }

            return result;
        }
    }
}
