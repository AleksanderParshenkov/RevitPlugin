using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using RoomAffiliation.Support;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RoomAffiliation.Models
{
    public class ExtremumsCoordinateRoom
    {
        public double Xmin {  get; set; }
        public double Ymin { get; set; }
        public double Zmin { get; set; }
        public double Xmax { get; set; }
        public double Ymax { get; set; }
        public double Zmax { get; set; }
        public List<RoomAffiliation.Models.LineSegment> LineSegmentList {  get; set; }

        public ExtremumsCoordinateRoom(Room room) 
        {
            // Формирование опции получения сегментов помещения
            var spatOpts = new SpatialElementBoundaryOptions();
            spatOpts.SpatialElementBoundaryLocation = SpatialElementBoundaryLocation.Finish;
            spatOpts.StoreFreeBoundaryFaces = true;
            var boundarySegmentsList = room.GetBoundarySegments(spatOpts);

            // Создание пустого списка отрезков границ помещения
            List<RoomAffiliation.Models.LineSegment> lineSegmentList = new List<RoomAffiliation.Models.LineSegment>();
           
            double angleRadian = LinkModel.AngleRadian;
            Transform transform = LinkModel.Transform;

            // Заполнение списка отрезков границ помещения
            if (null != boundarySegmentsList)  //Проверка есть ли сегменты
            {
                foreach (IList<Autodesk.Revit.DB.BoundarySegment> segmentList in boundarySegmentsList)
                {
                    foreach (Autodesk.Revit.DB.BoundarySegment boundarySegment in segmentList)
                    {
                        Models.LineSegment lineSegment = new Models.LineSegment();
                        lineSegment.startPoint = new XYZ(
                            (boundarySegment.GetCurve().GetEndPoint(0).X * Math.Cos(angleRadian) - boundarySegment.GetCurve().GetEndPoint(0).Y * Math.Sin(angleRadian)) + transform.Origin.X,
                            (boundarySegment.GetCurve().GetEndPoint(0).X * Math.Sin(angleRadian) + boundarySegment.GetCurve().GetEndPoint(0).Y * Math.Cos(angleRadian)) + transform.Origin.Y,
                            boundarySegment.GetCurve().GetEndPoint(0).Z + transform.Origin.Z);
                        lineSegment.endPoint = new XYZ(
                            (boundarySegment.GetCurve().GetEndPoint(1).X * Math.Cos(angleRadian) - boundarySegment.GetCurve().GetEndPoint(1).Y * Math.Sin(angleRadian)) + transform.Origin.X,
                            (boundarySegment.GetCurve().GetEndPoint(1).X * Math.Sin(angleRadian) + boundarySegment.GetCurve().GetEndPoint(1).Y * Math.Cos(angleRadian)) + transform.Origin.Y,
                            boundarySegment.GetCurve().GetEndPoint(1).Z + transform.Origin.Z);

                        // Добавление отрезка в список отрезков
                        lineSegmentList.Add(lineSegment);
                    }
                }
            }           

            // Добавление запаса к точкам границ помещения
            //lineSegmentList = SupportMethods.AddZapasToPoint(lineSegmentList);

            LineSegmentList = lineSegmentList;

            Xmin = 100000; Ymin = 100000; Zmin = 100000;
            Xmax = -100000; Ymax = -100000; Zmax = -100000;

            // Перебор начальных точек сегментов границ текущего помещения
            foreach (var point in lineSegmentList.Select(x => x.startPoint))
            {
                if (point.X < Xmin) Xmin = point.X;
                if (point.Y < Ymin) Ymin = point.Y;
                if (point.Z < Zmin) Zmin = point.Z;

                if (point.X > Xmax) Xmax = point.X;
                if (point.Y > Ymax) Ymax = point.Y;
                if (point.Z > Zmax) Zmax = point.Z;
            }

            // Перебор конечных точек сегментов границ текущего помещения
            foreach (var point in lineSegmentList.Select(x => x.endPoint))
            {
                if (point.X < Xmin) Xmin = point.X;
                if (point.Y < Ymin) Ymin = point.Z;
                if (point.Z < Zmin) Zmin = point.Z;

                if (point.X > Xmax) Xmax = point.X;
                if (point.Y > Ymax) Ymax = point.Y;
                if (point.Z > Zmax) Zmax = point.Z;
            }

            Zmax = Zmin + room.get_Parameter(BuiltInParameter.ROOM_HEIGHT).AsDouble();
        }
    }
}
