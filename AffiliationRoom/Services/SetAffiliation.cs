using AffiliationRoom.Models;
using AffiliationRoom.Support;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AffiliationRoom.Services
{
    static class SetAffiliation
    {
        public static void SetAffiliationMethod(LinkDocument selectedLinkDocument, ObservableCollection<ParametersCouple> parametersCouples)
        {

            DateTime now = DateTime.Now;

            using (Transaction tr = new Transaction(CurrentDocument.Doc, "Принадлежность помещений"))
            {
                tr.Start();

                
                // Получение трансформации выбранной связи
                Transform transform = selectedLinkDocument.LinkInstance.GetTotalTransform();                                

                // Получение угла поворота связи
                double angleTransform = SharedGeometryMethods.GetAngle(transform);

                // Получение списка помещений из связанной модели
                List<Room> roomList = GetElementListFromDocument.GetRoomList(selectedLinkDocument.LinkInstanceDocument);

                // Получение списка элементов текущей модели
                List<Element> elementList = GetElementListFromDocument.GetElementList(CurrentDocument.Doc);

                // Удаление значений параметров элементов, указанных в конфиге
                ChangeElementFromDocument.DeleteValueParameters(elementList, parametersCouples);

                //Перебор помещений
                foreach (Room room in roomList)
                {
                    // Получение сегментов помещения с учетом трансформации выбранной связи
                    List <LineSegmentRoom> lineSegmentRooms = GetElementRoom.GetLineSegmentRoomList(room, transform, angleTransform);

                    // Получение экстремумов помещений по оси Z
                    double zMin = lineSegmentRooms.Min(x => x.startPoint.Z);
                    double zMax = zMin + room.get_Parameter(BuiltInParameter.ROOM_HEIGHT).AsDouble() + Config.HeightReserve;


                    // Получение отфильтрованных элементов по экстремумам
                    List<Element> elements = elementList.Where(x =>
                    {
                        LocationPoint locationPointElement = x.Location as LocationPoint;
                        XYZ point = locationPointElement.Point;

                        if (point.X >= extremumsAndLineSegments.Xmin - Config.LengthReserve && point.X <= extremumsAndLineSegments.Xmax + Config.LengthReserve &&
                            point.Y >= extremumsAndLineSegments.Ymin - Config.LengthReserve && point.Y <= extremumsAndLineSegments.Ymax + Config.LengthReserve &&
                            point.Z >= extremumsAndLineSegments.Zmin - Config.LengthReserve && point.Z <= extremumsAndLineSegments.Zmax + Config.LengthReserve) return true;
                        else return false;
                    }).ToList();

                    // Получение сегментов помещения
                    List<RoomAffiliation.Models.LineSegment> lineSegments = extremumsAndLineSegments.LineSegmentList;

                    foreach (var item in elements)
                    {
                        bool isInRoom = false;

                        isInRoom = SupportRoomMethors.CheckElementIsInRoom(item, lineSegments);

                        if (isInRoom)
                        {
                            // Запись принадлежности элементам
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
