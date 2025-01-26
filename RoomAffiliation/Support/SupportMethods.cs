﻿using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using RoomAffiliation.Models;
using RoomAffiliation.Views;
using System;
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
            if (segment_1.startPoint.X <= segment_1.endPoint.X) 
            {
                Ax = segment_1.startPoint.X;
                Ay = segment_1.startPoint.Y;

                Bx = segment_1.endPoint.X;
                By = segment_1.endPoint.Y;
            }
            else
            {
                Ax = segment_1.endPoint.X;
                Ay = segment_1.endPoint.Y;

                Bx = segment_1.startPoint.X;
                By = segment_1.startPoint.Y;
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

        public static List<Element> DeleteValueParameters (List<Element> elements)
        {
            using (Transaction tr = new Transaction(CurrentModel.Doc, "Принадлежность помещений"))
            {
                tr.Start();

                List<ParametersCouple> parametersCoupeleList = MainConfigParameters.ParametersCouple
                    .Where(x => x.RoomParameter != "" && x.ElementParameter != "")
                    .ToList();

                foreach (var element in elements)
                {
                    foreach (var parameterCoupele in parametersCoupeleList)
                    {
                        // Получение значения параметра помещения
                        Parameter parameterElement = element.LookupParameter(parameterCoupele.ElementParameter);

                        if (parameterElement.StorageType == StorageType.String)
                        {
                            parameterElement.Set("");
                        }
                        if (parameterElement.StorageType == StorageType.Integer)
                        {
                            parameterElement.Set(0);
                        }
                        if (parameterElement.StorageType == StorageType.Double)
                        {
                            parameterElement.Set(0);
                        }
                        else
                        {

                        }
                    }
                }

                
                tr.Commit();
            }

            return elements;
        }
    }
}
