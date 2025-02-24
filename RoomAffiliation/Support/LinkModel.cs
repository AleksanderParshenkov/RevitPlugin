using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Windows.Controls;

namespace RoomAffiliation.Support
{
    public static class LinkModel
    {
        // Ссылка на модели.
        public static RevitLinkInstance LinkInstance { get; set; }

        // Значения трансформации (смещения) относительно текущей модели.
        public static Transform Transform { get; set; }

        // Эксземпляр класса Document связанной модели
        public static Document LinkInstanceDocument { get; set; }


        /// <summary>
        /// Заполнение свойств
        /// </summary>
        public static void GetParamLinkModel(RevitLinkInstance linkInstance)
        {
            LinkInstance = linkInstance;

            Transform = LinkModel.LinkInstance.GetTotalTransform();

            // Превращение RevitLinkInstance в Document
            LinkInstanceDocument = LinkInstance.GetLinkDocument();
        }
    }
}
