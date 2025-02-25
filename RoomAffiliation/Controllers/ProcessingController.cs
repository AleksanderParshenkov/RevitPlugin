using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.DB;
using RoomAffiliation.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoomAffiliation.Models;
using System.Windows;
using System.Xml.Linq;

namespace RoomAffiliation.Controllers
{
    public  class ProcessingController
    {
        public ProcessingController() 
        {
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

                        if (point.X >= extremumsAndLineSegments.Xmin && point.X <= extremumsAndLineSegments.Xmax &&
                            point.Y >= extremumsAndLineSegments.Ymin && point.Y <= extremumsAndLineSegments.Ymax &&
                            point.Z + 1 >= extremumsAndLineSegments.Zmin && point.Z <= extremumsAndLineSegments.Zmax + 1) return true;
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
                

            //// Получение списка элементов текущей модели
            //List<Element> elementList = SupportMethods.GetElementListFromCurrentDocument(CurrentModel.Doc);

            //// Удаление значений параметров элементов, указанных в конфиге
            //elementList = SupportMethods.DeleteValueParameters(elementList);

            //// Получение предварительных ситуаций
            //List<PredAffiliationSituation> predAffiliationSituationList = SupportMethods.GetPredAffiliationSituationList(roomList, elementList);

            //// Получение проверенных ситуаций
            //List<AffiliationSituation> AffiliationSituationList = SupportMethods.GetAffiliationSituationList(predAffiliationSituationList);

            //MessageBox.Show(AffiliationSituationList.Count().ToString());

            

        }
    }
}
