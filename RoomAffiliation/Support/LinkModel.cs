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

        // Смещения по осям.
        public static double OriginX { get; set; }  
        public static double OriginY { get; set; }
        public static double OriginZ { get; set; }

        // Смещения по углам.
        public static XYZ BasisX { get; set; }
        public static XYZ BasisY { get; set; }
        public static XYZ BasisZ { get; set; }

        // Эксземпляр класса Document связанной модели
        public static Document LinkInstanceDocument { get; set; }


        /// <summary>
        /// Заполнение свойств
        /// </summary>
        public static void GetParamLinkModel(RevitLinkInstance linkInstance)
        {
            LinkInstance = linkInstance;

            Transform = LinkModel.LinkInstance.GetTotalTransform();

            // Получение корректировки координат
            OriginX = Transform.Origin.X;
            OriginY = Transform.Origin.Y;
            OriginZ = Transform.Origin.Z;

            // Получение корректировки углов
            BasisX = Transform.BasisX;
            BasisY = Transform.BasisY;
            BasisZ = Transform.BasisZ;

            // Превращение RevitLinkInstance в Document
            LinkInstanceDocument = LinkInstance.GetLinkDocument();
        }
    }
}
