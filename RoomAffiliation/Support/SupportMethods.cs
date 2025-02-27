using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using RoomAffiliation.Models;
using RoomAffiliation.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using LineSegment = RoomAffiliation.Models.LineSegment;

namespace RoomAffiliation.Support
{
    public class SupportMethods
    {
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
            List<Element> resultList = new List<Element>();

            foreach (var item in CorrectBuiltInCategoryList._categories)
            {
                // Получение списка элементов в текущей модели
                List<Element> elementListCurrentModel = new FilteredElementCollector(document)
                    .WhereElementIsNotElementType()
                    .OfCategory(item)
                    .Select(x => x as Element)
                    .ToList();

                foreach (var element in elementListCurrentModel) resultList.Add((Element)element);
            }

            return resultList;
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

        

        public static List<Element> DeleteValueParameters(List<Element> elements)
        {
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

            return elements;
        }

        public static double GetAngle(Autodesk.Revit.DB.Transform transform)
        {
            double angleRadian = 0;
            double basisXx = 0;
            double basisXy = 0;

            // Удаление лишних экстремумов
            if (transform.BasisX.X > 1) basisXx = 1;
            else if (transform.BasisX.X < -1) basisXx = -1;
            else basisXx = transform.BasisX.X;

            if (transform.BasisX.Y > 1) basisXy = 1;
            else if (transform.BasisX.Y < -1) basisXy = -1;
            else basisXy = transform.BasisX.Y;


            if (basisXy >= 0) // Верхний полукруг
            {
                if (basisXx == 1) angleRadian = 0;
                else if (basisXx >= 0) angleRadian = Math.Acos(basisXx) + Math.PI * 2 / 4 * 0; // Четверть 1
                else angleRadian = Math.Acos(basisXx) + Math.PI * 2 / 4 * 0; // Четверть 2
            }
            else // Нижний полукруг
            {
                if (basisXx == -1) angleRadian = Math.PI * 2 / 4 * 2;
                else if (basisXx <= 0) angleRadian = Math.PI * 2 / 4 * 2 - Math.Acos(basisXx) + Math.PI * 2 / 4 * 2; // Четверть 3
                else angleRadian = Math.PI * 2 / 4 - Math.Acos(basisXx) + Math.PI * 2 / 4 * 3; // Четверть 4
            }

            return angleRadian;
        }

        
    }
}
