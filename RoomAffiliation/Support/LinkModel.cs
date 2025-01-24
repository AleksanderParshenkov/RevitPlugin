using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Windows.Controls;

namespace RoomAffiliation.Support
{
    public static class LinkModel
    {
        public static RevitLinkInstance LinkInstance { get; set; }

        /// <summary>
        /// Заполнение свойств
        /// </summary>
        public static void GetParamLinkModel(RevitLinkInstance linkInstance)
        {
            LinkInstance = linkInstance;
        }
    }
}
