using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.UI;
using RoomAffiliation.Models;
using RoomAffiliation.Support;
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
            // Получение и запись информации о текущей модели.
            CurrentModel.GetParamCurrentModel(commandData);

            //Получение списка RevitLinkInstance
            var linksCollectorCurrentModel = new FilteredElementCollector(CurrentModel.Doc)
                .WhereElementIsNotElementType()
                .OfClass(typeof(RevitLinkInstance))
                .Where(instance => RevitLinkType.IsLoaded(CurrentModel.Doc, instance.GetTypeId()))
                .Select(x => (RevitLinkInstance)x);

            // Выдача основного окна.
            MainWindow wnd = new MainWindow();
            MainVIew.MainWindow = wnd;
            MainVIew.MainWindow.cmb_LinkedModels.ItemsSource = linksCollectorCurrentModel;
            MainVIew.WriteStartValues();
            MainVIew.MainWindow.ShowDialog();

            // Перевод на контроллер процесса после работы окна
            ProcessingController processingController = new ProcessingController();
        }
    }
}
