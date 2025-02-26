using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using RoomAffiliation.Models;
using RoomAffiliation.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace RoomAffiliation.Controllers
{
    public  class ProcessingController
    {
        public ProcessingController() 
        {
            DateTime now = DateTime.Now;

            using (Transaction tr = new Transaction(CurrentModel.Doc, "Принадлежность помещений"))
            {
                tr.Start();

                // Получение списка помещений из связанной модели
                List<Room> roomList = SupportMethods.GetRoomListFromLinkDocument(LinkModel.LinkInstanceDocument);

                // Получение списка элементов текущей модели
                List<Element> elementList = SupportMethods.GetElementListFromCurrentDocument(CurrentModel.Doc);

                // Удаление значений параметров элементов, указанных в конфиге
                elementList = SupportMethods.DeleteValueParameters(elementList);

                foreach (Room room in roomList)
                {
                    // Получение экстремумов помещения
                    ExtremumsCoordinateRoom extremumsAndLineSegments = new ExtremumsCoordinateRoom(room);

                    // Получение отфильтрованных элементов по экстремумам
                    List<Element> elements = elementList.Where(x =>
                    {
                        LocationPoint locationPointElement = x.Location as LocationPoint;
                        XYZ point = locationPointElement.Point;

                        if (point.X >= extremumsAndLineSegments.Xmin - Config.LengthReserve && point.X <= extremumsAndLineSegments.Xmax + Config.LengthReserve &&
                            point.Y >= extremumsAndLineSegments.Ymin - Config.LengthReserve && point.Y <= extremumsAndLineSegments.Ymax + Config.LengthReserve &&
                            point.Z + Config.LengthReserve >= extremumsAndLineSegments.Zmin && point.Z <= extremumsAndLineSegments.Zmax + Config.LengthReserve) return true;
                        else return false;
                    }).ToList();

                    // Получение сегментов помещения
                    List <RoomAffiliation.Models.LineSegment> lineSegments = extremumsAndLineSegments.LineSegmentList;

                    foreach (var item  in elements)
                    {
                        bool isInRoom = false;

                        isInRoom = SupportMethods.CheckElementIsInRoom(item, lineSegments);

                        if (isInRoom) 
                        {
                            // Запись принадлежности элементам. Транзакция
                            TransactionController transactionController = new TransactionController(item, room);
                        }
                    }
                }

                tr.Commit();
            }

            DateTime over = DateTime.Now;

            MessageBox.Show($"Старт: {now}\n" +
                $"Окончание: {over}");
        }
    }
}
