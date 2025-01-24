using Autodesk.Revit.DB;
using RoomAffiliation.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
