using Autodesk.Revit.DB;
using RoomAffiliation.Models;
using RoomAffiliation.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomAffiliation.Controllers
{
    public class TransactionController
    {
        public TransactionController(List<AffiliationSituation> affiliationSituationList)
        {
            using (Transaction tr = new Transaction(CurrentModel.Doc, "Принадлежность помещений"))
            {
                tr.Start();

                List<ParametersCouple> parametersCoupeleList = MainConfigParameters.ParametersCouple
                    .Where(x => x.RoomParameter != "" &&  x.ElementParameter != "")
                    .ToList();

                string value;

                foreach (var situation  in affiliationSituationList)
                {
                    foreach (var parametersCoupe in parametersCoupeleList)
                    {
                        // Получение значения параметра помещения
                        Parameter parameterRoom = situation.room.LookupParameter(parametersCoupe.RoomParameter);
                        
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
                            situation.element.LookupParameter(parametersCoupe.ElementParameter).Set(value);                            
                        }
                        if (parameterRoom.StorageType == StorageType.Integer)
                        {
                            value = parameterRoom.AsInteger().ToString();
                            situation.element.LookupParameter(parametersCoupe.ElementParameter).Set(int.Parse(value));
                        }
                        if (parameterRoom.StorageType == StorageType.Double)
                        {
                            value = parameterRoom.AsInteger().ToString();
                            situation.element.LookupParameter(parametersCoupe.ElementParameter).Set(double.Parse(value));
                        }
                        else
                        {

                        }
                    }
                }
                tr.Commit();
            }
        }
    }
}
