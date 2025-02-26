using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using RoomAffiliation.Models;
using RoomAffiliation.Support;
using System.Collections.Generic;
using System.Linq;

namespace RoomAffiliation.Controllers
{
    public class TransactionController
    {
        public TransactionController(Element element, Room room)
        {
            List<ParametersCouple> parametersCoupeleList = MainConfigParameters.ParametersCouple
                    .Where(x => x.RoomParameter != "" && x.ElementParameter != "")
                    .ToList();

            string value;

            foreach (var parametersCoupe in parametersCoupeleList)
            {                
                Parameter parameterRoom = room.LookupParameter(parametersCoupe.RoomParameter);

                if (parameterRoom.StorageType == StorageType.String)
                {
                    if (parameterRoom.AsString() != "" || parameterRoom.AsString() != null)
                    {
                        value = parameterRoom.AsString();
                    }
                    else
                    {
                        value = parameterRoom.AsValueString();
                    }
                    element.LookupParameter(parametersCoupe.ElementParameter).Set(value);
                }
                if (parameterRoom.StorageType == StorageType.Integer)
                {
                    value = parameterRoom.AsInteger().ToString();
                    element.LookupParameter(parametersCoupe.ElementParameter).Set(int.Parse(value));
                }
                if (parameterRoom.StorageType == StorageType.Double)
                {
                    value = parameterRoom.AsInteger().ToString();
                    element.LookupParameter(parametersCoupe.ElementParameter).Set(double.Parse(value));
                }
                else
                {

                }
            }
        }
    }
}
