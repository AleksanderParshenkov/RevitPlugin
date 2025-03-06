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
                List<Room> roomList = GetElementListFromDocument.GetRoomList(selectedLinkDocument.LinkInstanceDocument)
                    .OrderByDescending(x=>x.Area).ToList();

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
                    double xMin = lineSegmentRooms.Min(x => x.startPoint.X) - Config.LengthReserve;
                    double xMax = lineSegmentRooms.Max(x => x.startPoint.X) + Config.LengthReserve;

                    // Получение экстремумов помещений по оси Z
                    double yMin = lineSegmentRooms.Min(x => x.startPoint.Y) - Config.LengthReserve;
                    double yMax = lineSegmentRooms.Max(x => x.startPoint.Y) + Config.LengthReserve;

                    // Получение экстремумов помещений по оси Z
                    double zMin = lineSegmentRooms.Min(x => x.startPoint.Z) - Config.HeightReserve;
                    double zMax = zMin + room.get_Parameter(BuiltInParameter.ROOM_HEIGHT).AsDouble() + Config.HeightReserve + Config.HeightReserve;

                    // Получение отфильтрованных элементов по экстремумам
                    List<Element> elements = elementList.Where(x =>
                    {
                        LocationPoint locationPointElement = x.Location as LocationPoint;
                        XYZ point = locationPointElement.Point;

                        if (point.X >= xMin && point.X <= xMax &&
                            point.Y >= yMin && point.Y <= yMax &&
                            point.Z >= zMin && point.Z <= zMax) return true;
                        else return false;
                    }).ToList();                    

                    // Перебор элементов, ранее отфильтрованных как предположительно принадлежащих текущему помещению
                    foreach (var element in elements)
                    {
                        bool isInRoom = false;

                        isInRoom = CheckElementMethods.CheckElementIsInRoom(element, lineSegmentRooms);

                        if (isInRoom)
                        {
                            // Запись принадлежности элементам
                            ChangeElementFromDocument.SetValueParametersFromRoom(element, room, parametersCouples);
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
