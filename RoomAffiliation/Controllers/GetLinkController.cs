using Autodesk.Revit.DB;
using RoomAffiliation.Support;

namespace RoomAffiliation.Controllers
{
    public class GetLinkController
    {
        public GetLinkController(RevitLinkInstance linkInstance)
        {
            LinkModel.GetParamLinkModel(linkInstance);
        }
    }
}
