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

                        List <XYZ> tessellates =  boundarySegment.GetCurve().Tessellate().ToList();

                        lineSegment.startPoint = tessellates[0];
                        lineSegment.endPoint = tessellates[1];


                        //lineSegment.startPoint = new XYZ(
                        //    (boundarySegment.GetCurve().GetEndPoint(0).X * Math.Cos(angleRadian) - boundarySegment.GetCurve().GetEndPoint(0).Y * Math.Sin(angleRadian)) + transform.Origin.X,
                        //    (boundarySegment.GetCurve().GetEndPoint(0).X * Math.Sin(angleRadian) + boundarySegment.GetCurve().GetEndPoint(0).Y * Math.Cos(angleRadian)) + transform.Origin.Y,
                        //    boundarySegment.GetCurve().GetEndPoint(0).Z + transform.Origin.Z);
                        //lineSegment.endPoint = new XYZ(
                        //    (boundarySegment.GetCurve().GetEndPoint(1).X * Math.Cos(angleRadian) - boundarySegment.GetCurve().GetEndPoint(1).Y * Math.Sin(angleRadian)) + transform.Origin.X,
                        //    (boundarySegment.GetCurve().GetEndPoint(1).X * Math.Sin(angleRadian) + boundarySegment.GetCurve().GetEndPoint(1).Y * Math.Cos(angleRadian)) + transform.Origin.Y,
                        //    boundarySegment.GetCurve().GetEndPoint(1).Z + transform.Origin.Z);

                        // Добавление отрезка в список отрезков
                        lineSegmentList.Add(lineSegment);
                    }
                }
            } 

            LineSegmentList = lineSegmentList;

            Xmin = lineSegmentList.FirstOrDefault().startPoint.X;
            Ymin = lineSegmentList.FirstOrDefault().startPoint.Y; 
            Zmin = lineSegmentList.FirstOrDefault().startPoint.Z;

            Xmax = lineSegmentList.FirstOrDefault().startPoint.X;
            Ymax = lineSegmentList.FirstOrDefault().startPoint.Y;
            Zmax = lineSegmentList.FirstOrDefault().startPoint.Z;


            // Перебор начальных точек сегментов границ текущего помещения
            foreach (var segment in lineSegmentList)
            {
                // Задание минимальных значений
                if (segment.startPoint.X < Xmin) Xmin = segment.startPoint.X;
                if (segment.startPoint.Y < Ymin) Ymin = segment.startPoint.Y;
                if (segment.startPoint.Z < Zmin) Zmin = segment.startPoint.Z;

                if (segment.endPoint.X < Xmin) Xmin = segment.endPoint.X;
                if (segment.endPoint.Y < Ymin) Ymin = segment.endPoint.Y;
                if (segment.endPoint.Z < Zmin) Zmin = segment.endPoint.Z;

                // Задание максимальных значений
                if (segment.startPoint.X > Xmax) Xmax = segment.startPoint.X;
                if (segment.startPoint.Y > Ymax) Ymax = segment.startPoint.Y;

                if (segment.endPoint.X > Xmax) Xmax = segment.endPoint.X;
                if (segment.endPoint.Y > Ymax) Ymax = segment.endPoint.Y;
            }            

            Zmax = Zmin + room.get_Parameter(BuiltInParameter.ROOM_HEIGHT).AsDouble();
        }
    }
}
