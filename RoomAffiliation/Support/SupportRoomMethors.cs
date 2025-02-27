using Autodesk.Revit.DB;
using RoomAffiliation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using LineSegment = RoomAffiliation.Models.LineSegment;

namespace RoomAffiliation.Support
{
    public static class SupportRoomMethors
    {
        public static bool CheckElementIsInRoom(Element item, List<LineSegment> segments)
        {
            // Предварительный результат метода
            bool result = false;

            // Получение точки вставки элемента
            XYZ locationPointElement = (item.Location as LocationPoint).Point;

            // Проверка на принадлежность вершинам
            foreach (var segment in segments)
            {
                if (Math.Abs(locationPointElement.X - segment.startPoint.X) <= Config.LengthReserve
                    && Math.Abs(locationPointElement.Y - segment.startPoint.Y) <= Config.LengthReserve) result = true;

                if (Math.Abs(locationPointElement.X - segment.endPoint.X) <= Config.LengthReserve
                    && Math.Abs(locationPointElement.Y - segment.endPoint.Y) <= Config.LengthReserve) result = true;
            }

            //// Проверка на принадлежность границам 
            //foreach (var lineSegment in segments)
            //{
            //    double x1 = lineSegment.startPoint.X;
            //    double y1 = lineSegment.startPoint.Y;

            //    double x2 = lineSegment.endPoint.X;
            //    double y2 = lineSegment.endPoint.Y;

            //    double x = locationPointElement.X;
            //    double y = locationPointElement.Y;

            //    if (((x - x1) * (y2 - y1) - (x2 - x1) * (y - y1)) == 0)
            //    {
            //        result = true;
            //    }
            //}

            // Проверка принадлежности к границам  (с погрешностью к вертикальным и горизонтальным сегментам)
            foreach (var lineSegment in segments)
            {
                double Xmin = lineSegment.startPoint.X;
                double Xmax = lineSegment.endPoint.X;

                double Ymin = lineSegment.startPoint.Y;
                double Ymax = lineSegment.endPoint.Y;

                if (Xmin > Xmax)
                {
                    Xmin = lineSegment.endPoint.X;
                    Xmax = lineSegment.startPoint.X;
                }
                if (Ymin > Ymax)
                {
                    Ymin = lineSegment.endPoint.Y;
                    Ymax = lineSegment.startPoint.Y;
                }

                if (Math.Abs(Ymin - Ymax) <= Config.LengthReserve
                    && Math.Abs(Ymin - locationPointElement.Y) <= Config.LengthReserve
                    && ((locationPointElement.X >= Xmin) && (locationPointElement.X <= Xmax))) return true;

                if (Math.Abs(Xmin - Xmax) <= Config.LengthReserve
                    && Math.Abs(Xmin - locationPointElement.X) <= Config.LengthReserve
                    && ((locationPointElement.Y >= Ymin) && (locationPointElement.Y <= Ymax))) return true;
            }

            // Проверка на пересечение отрезков с мнимым отрезком, образованным точкой элемента
            int i = 0;
            foreach (LineSegment segment in segments)
            {
                if  (SupprotGeometryMethods. CheckIntersection(item, segment)) i++;

                if (item.Id.IntegerValue == 15946) MessageBox.Show($"Проверяетс элемент. I = {i}");
            }
            // Проверка количества пересечений (если нечетное - то точка внутри, если четное - вне помещения)
            if (i % 2 == 1)
            {
                result = true;
            }

            return result;
        }
    }
}
