﻿using Autodesk.Revit.DB;
using RoomAffiliation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomAffiliation.Support
{
    public static class SupprotGeometryMethods
    {
        public static bool CheckIntersection(Element element, Models.LineSegment segment)
        {
            // Получение точки элемента
            LocationPoint locationPointElement = element.Location as LocationPoint;
            XYZ startPointElement = locationPointElement.Point;

            // Первичные проверки расположения точек сегмента
            if (startPointElement.X > segment.startPoint.X && startPointElement.X > segment.startPoint.Y) return false;
            if (startPointElement.X < segment.startPoint.X && startPointElement.X < segment.startPoint.Y) return false;

            if (startPointElement.Y > segment.startPoint.Y && startPointElement.Y > segment.startPoint.Y) return false;

            // Назанчение максимального Y (для сравнения отрезков)
            double YmaxRoom = segment.startPoint.Y;
            if (segment.startPoint.Y < segment.endPoint.Y) YmaxRoom = segment.endPoint.Y;
            else YmaxRoom = YmaxRoom + Config.LengthReserve;


            // Получение конечной точки элемента (вторая точка отрезка элемента) 
            XYZ endPointElement = new XYZ(startPointElement.X, YmaxRoom + 100, startPointElement.Z);

            // Формирование отрезка проверки
            Models.LineSegment segment_2 = new Models.LineSegment();
            segment_2.startPoint = startPointElement;
            segment_2.endPoint = endPointElement;

            // Первичное создание переменных
            double Ax = 0;
            double Ay = 0;
            double Bx = 0;
            double By = 0;
            double Cx = 0;
            double Cy = 0;
            double Dx = 0;
            double Dy = 0;

            // Переназначение точек первого отрезка, где первая точка слева 
            if (segment.startPoint.X <= segment.endPoint.X)
            {
                Ax = segment.startPoint.X;
                Ay = segment.startPoint.Y;

                Bx = segment.endPoint.X;
                By = segment.endPoint.Y;
            }
            else
            {
                Ax = segment.endPoint.X;
                Ay = segment.endPoint.Y;

                Bx = segment.startPoint.X;
                By = segment.startPoint.Y;
            }

            // Переназначение точек второго отрезка, где первая точка слева 
            if (segment_2.startPoint.X <= segment_2.endPoint.X)
            {
                Cx = segment_2.startPoint.X;
                Cy = segment_2.startPoint.Y;

                Dx = segment_2.endPoint.X;
                Dy = segment_2.endPoint.Y;
            }
            else
            {
                Cx = segment_2.endPoint.X;
                Cy = segment_2.endPoint.Y;

                Dx = segment_2.startPoint.X;
                Dy = segment_2.startPoint.Y;
            }

            // Назначение левого и правого проверяемых отрезков
            Models.LineSegment leftSegment = null;
            Models.LineSegment rightSegment = null;

            if (Ax < Cx)
            {
                leftSegment = new Models.LineSegment() { startPoint = new XYZ(Ax, Ay, 0), endPoint = new XYZ(Bx, By, 0) };
                rightSegment = new Models.LineSegment() { startPoint = new XYZ(Cx, Cy, 0), endPoint = new XYZ(Dx, Dy, 0) };
            }
            else
            {
                leftSegment = new Models.LineSegment() { startPoint = new XYZ(Cx, Cy, 0), endPoint = new XYZ(Dx, Dy, 0) };
                rightSegment = new Models.LineSegment() { startPoint = new XYZ(Ax, Ay, 0), endPoint = new XYZ(Bx, By, 0) };
            }

            // Проверка наличия просветов между отрезками по X
            if (leftSegment.endPoint.X < rightSegment.startPoint.X) { return false; } // т.е. если отрезками есть просвет по Х - то они не пересекаются

            // Проверка наличия просветов между отрезками по Y
            if (((leftSegment.startPoint.Y < rightSegment.startPoint.Y && leftSegment.startPoint.Y < rightSegment.endPoint.Y) && (leftSegment.endPoint.Y < rightSegment.startPoint.Y && leftSegment.endPoint.Y < rightSegment.endPoint.Y))
                ||
                ((leftSegment.startPoint.Y > rightSegment.startPoint.Y && leftSegment.startPoint.Y > rightSegment.endPoint.Y) && (leftSegment.endPoint.Y > rightSegment.startPoint.Y && leftSegment.endPoint.Y > rightSegment.endPoint.Y)))
            {
                return false;
            }

            double p1x = leftSegment.startPoint.X;
            double p1y = leftSegment.startPoint.Y;

            double p2x = leftSegment.endPoint.X;
            double p2y = leftSegment.endPoint.Y;

            double p3x = rightSegment.startPoint.X;
            double p3y = rightSegment.startPoint.Y;

            double p4x = rightSegment.endPoint.X;
            double p4y = rightSegment.endPoint.Y;


            // Проверка вертикальности обоих отрезков (т.е. они параллельны, а один отрезок вертикальный всегда, т.к. является услоным)
            if (p1x == p2x && p3x == p4x) { return false; }
            if (p1x - p2x == 0) // только левый отрезок вертикальный
            {
                //найдём Xa, Ya - точки пересечения двух прямых
                double Xa = p1x;
                double A2 = (p3y - p4y) / (p3x - p4x);
                double b2 = p3y - A2 * p3x;
                double Ya = A2 * Xa + b2;

                if (p3x <= Xa && p4x >= Xa && Math.Min(p1y, p2y) <= Ya &&
                        Math.Max(p1y, p2y) >= Ya)
                {
                    return true;
                }

                return false;
            }
            if (p3x - p4x == 0) // только правый отрезок вертикальный
            {
                //найдём Xa, Ya - точки пересечения двух прямых
                double Xa = p3x;
                double A1 = (p1y - p2y) / (p1x - p2x);
                double b1 = p1y - A1 * p1x;
                double Ya = A1 * Xa + b1;

                if (p1x <= Xa && p2x >= Xa && Math.Min(p3y, p4y) <= Ya &&
                        Math.Max(p3y, p4y) >= Ya)
                {
                    return true;
                }

                return false;
            }
            else // общий случай, когда оба отрезка не вертикальные
            {
                //оба отрезка невертикальные
                double A1 = (p1y - p2y) / (p1x - p2x);
                double A2 = (p3y - p4y) / (p3x - p4x);
                double b1 = p1y - A1 * p1x;
                double b2 = p3y - A2 * p3x;

                if (A1 == A2)
                {
                    return false; //отрезки параллельны
                }

                //Xa - абсцисса точки пересечения двух прямых
                double Xa = (b2 - b1) / (A1 - A2);

                if ((Xa < Math.Max(p1x, p3x)) || (Xa > Math.Min(p2x, p4x)))
                {
                    return false; //точка Xa находится вне пересечения проекций отрезков на ось X 
                }
                else
                {
                    return true;
                }
            }
        }
    }
}
