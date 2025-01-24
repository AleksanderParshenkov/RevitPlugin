using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.UI;
using RoomAffiliation.Support;
using RoomAffiliation.Models;
using RoomAffiliation.Views;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace RoomAffiliation.Controllers
{
    public class MainController
    {
        public MainController(ExternalCommandData commandData) 
        {
            // Получение и запись информации о текущей модели
            CurrentModel.GetParamCurrentModel(commandData);

            //Получение списка RevitLinkInstance
            var elementsCollectorCurrentModel = new FilteredElementCollector(CurrentModel.Doc)
                .WhereElementIsNotElementType()
                .OfClass(typeof(RevitLinkInstance))
                .Where(instance => RevitLinkType.IsLoaded(CurrentModel.Doc, instance.GetTypeId()))
                .Select(x => (RevitLinkInstance)x);

            // Выдача основного окна 
            MainWindow wnd = new MainWindow();
            wnd.cmb_LinkedModels.ItemsSource = elementsCollectorCurrentModel;            
            wnd.ShowDialog();

            



            var link = LinkModel.LinkInstance.GetTotalTransform();

            // Получение корректировки координат
            var transformXLink = link.Origin.X;
            var transformYLink = link.Origin.Y;
            var transformZLink = link.Origin.Z;

            // Получение корректировки угла
            var transformBasysXLink = link.BasisX;
            var transformBasysYLink = link.BasisY;
            var transformBasysZLink = link.BasisZ;

            // Превращение RevitLinkInstance в Document
            Document linkDocument = elementsCollectorCurrentModel.FirstOrDefault().GetLinkDocument();

            // Получение экземпляров всех помещений в связанном документе
            var elementsCollectorLinkModel = new FilteredElementCollector(linkDocument)
                .WhereElementIsNotElementType()
                .OfCategory(BuiltInCategory.OST_Rooms);
            List <Room> rooms = elementsCollectorLinkModel.Select(x => (Room)x).ToList();

            // Создаем пустой список форм
            List <FormRoom> formRoomList = new List<FormRoom> ();

            // Заполняем список форм
            foreach (var room in rooms)
            {
                // Формирование орции получения сегментов помещения
                var spatOpts = new SpatialElementBoundaryOptions();
                spatOpts.SpatialElementBoundaryLocation = SpatialElementBoundaryLocation.Finish;
                spatOpts.StoreFreeBoundaryFaces = true;
                var boundarySegmentsList = room.GetBoundarySegments(spatOpts);

                // Создание списка точек (начала сегментов)
                List <XYZ> xyzList = new List<XYZ> ();

                // Создание переменных Z
                double Zmin = 1000000000;

                // Получение точек как точек начала сегментов контура помещений 
                if (null != boundarySegmentsList)  //Помещение размещено
                {                    
                    foreach (IList<Autodesk.Revit.DB.BoundarySegment> segmentList in boundarySegmentsList)
                    {
                        foreach (Autodesk.Revit.DB.BoundarySegment boundarySegment in segmentList)
                        {
                            double x = boundarySegment.GetCurve().GetEndPoint(0).X;
                            double y = boundarySegment.GetCurve().GetEndPoint(0).Y;
                            double z = boundarySegment.GetCurve().GetEndPoint(0).Z;

                            xyzList.Add(new XYZ(x, y, z));

                            if (z < Zmin) Zmin = z;
                        }
                    }
                }

                double Zmax = Zmin + room.get_Parameter(BuiltInParameter.ROOM_HEIGHT).AsDouble();

                FormRoom formRoom = new FormRoom();
                formRoom.room = room;
                formRoom.Zmin = Zmin;
                formRoom.Zmax = Zmax;
                formRoom.Points = xyzList;
                formRoomList.Add (formRoom);
            }

            MessageBox.Show(string.Join("; ", formRoomList.Select(x=> x.Zmax)));



        }
    }
}
