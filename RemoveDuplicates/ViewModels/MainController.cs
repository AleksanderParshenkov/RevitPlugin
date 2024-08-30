#region Usings
using Autodesk.Revit.UI;
using RemoveDuplicates.Models;
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
        }
    }
}
