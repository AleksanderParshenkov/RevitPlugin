#region Usings
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Events;
using Autodesk.Revit.UI.Selection;
using RemoveDuplicates.Models;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
#endregion

namespace RemoveDuplicates.ViewModels
{
    /// <summary>
    /// Основной контроллер,
    /// задача которого - заполнение свойств статического класса,
    /// являющихся постоянными сведениями о текущей запущенной модели, 
    /// а также запустить основной интерфейс плагина для последующей работы
    /// </summary>
    public class MainController
    {
        public MainController(ExternalCommandData commandData)
        {
            // Получение и запись информации о текущей модели
            CurrentModel.GetParamCurrentModel(commandData);

            // Временное
            // Access current selection

            MessageBox.Show("gaoighahga");

            Selection sel = CurrentModel.UiDoc.Selection;

            // Retrieve elements from database

            FilteredElementCollector col
              = new FilteredElementCollector(CurrentModel.Doc).WhereElementIsNotElementType();

            var ids = col.Select(x => x.Id).ToList();
            CurrentModel.UiDoc.Selection.SetElementIds(ids);
        }
    }
}
