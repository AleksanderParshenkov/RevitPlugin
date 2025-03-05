using AffiliationRoom.Models;
using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
