using Autodesk.Revit.UI;

namespace GetFamilyTypeListFromIds.Models
{
    public static class CurrentModel
    {
        /// <summary>
        /// Основные свойства текущей модели.
        /// Заполняются методом внутри класса
        /// </summary>
        public static ExternalCommandData CommandData { get; internal set; }
        public static UIApplication UiApp { get; internal set; }
        public static UIDocument UiDoc { get; internal set; }
        public static Autodesk.Revit.ApplicationServices.Application App { get; internal set; }
        public static Autodesk.Revit.DB.Document Doc { get; internal set; }


        /// <summary>
        /// Метод получения основных свойств класса текущей модели.
        /// </summary>
        /// <param name="commandData">Основное получаемое свойство текущей модели класса ExternalCommandData</param>
        public static void GetParamCurrentModel(ExternalCommandData commandData)
        {
            CommandData = commandData;
            UiApp = CommandData.Application;
            UiDoc = UiApp.ActiveUIDocument;
            App = UiApp.Application;
            Doc = UiDoc.Document;   
        }        
    }
}
