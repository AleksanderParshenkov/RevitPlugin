using AffiliationRoom.Models;
using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AffiliationRoom.Services
{
    class CheckElementMethods
    {
        public static bool CheckElementIsInRoom(Element item, List<LineSegmentRoom> segments)
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

            // Проверка на принадлежность границам 
            // Точка находится на границе, если длина границы равна сумме длинн от точки элемента до каждой точки границы
            foreach (var segment in segments)
            {
                //d2= (х2— х1)2+ (y2— y1)2

                // Получаем длину сегмента
                double segmentLength = Math.Sqrt(Math.Pow(segment.startPoint.X - segment.endPoint.X, 2) + Math.Pow(segment.startPoint.Y - segment.endPoint.Y, 2));

                double lineToStartPointLength = Math.Sqrt(Math.Pow(segment.startPoint.X - locationPointElement.X, 2) + Math.Pow(segment.startPoint.Y - locationPointElement.Y, 2));

                double lineToEndPointLength = Math.Sqrt(Math.Pow(locationPointElement.X - segment.endPoint.X, 2) + Math.Pow(locationPointElement.Y - segment.endPoint.Y, 2));

                if (Math.Abs(segmentLength - (lineToStartPointLength + lineToEndPointLength)) <= Config.LengthReserve) result = true;
            }

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
            foreach (var segment in segments)
            {
                if (SharedGeometryMethods.CheckIntersection(item, segment)) i++;

                //if (item.Id.IntegerValue == 12756622) MessageBox.Show($"Проверяетс элемент. I = {i} из количества проверяемых сегментов {segments.Count}");
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
