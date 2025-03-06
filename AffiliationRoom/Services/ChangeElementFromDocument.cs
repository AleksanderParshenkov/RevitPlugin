using AffiliationRoom.Models;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AffiliationRoom.Services
{
    static class ChangeElementFromDocument
    {
        public static void DeleteValueParameters(List<Element> elements, ObservableCollection<ParametersCouple> parametersCoupleList)
        {
            foreach (var element in elements)
            {
                foreach (var parameterCoupele in parametersCoupleList)
                {
                    // Получение значения параметра помещения
                    Parameter parameterElement = element.LookupParameter(parameterCoupele.ElementParameter);

                    if (parameterElement.StorageType == StorageType.String)
                    {
                        parameterElement.Set("");
                    }
                    if (parameterElement.StorageType == StorageType.Integer || parameterElement.StorageType == StorageType.Double)
                    {
                        parameterElement.Set(0);
                    }
                }
            }
        }

        public static void SetValueParametersFromRoom (Element element, Room room, ObservableCollection<ParametersCouple> parametersCoupleList)
        {
            string value;

            foreach (var parametersCoupe in parametersCoupleList)
            {
                Parameter parameterRoom = room.LookupParameter(parametersCoupe.RoomParameter);

                if (parameterRoom.StorageType == StorageType.String)
                {
                    if (parameterRoom.AsString() != "" || parameterRoom.AsString() != null) value = parameterRoom.AsString();                    
                    else value = parameterRoom.AsValueString();                    

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
            }
        }
    }
}
