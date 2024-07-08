using Autodesk.Revit.DB;
using FilterNavis.Enums;
using FilterNavis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CSharp;

namespace FilterNavis.ViewModels
{
    public static class SharedMethodsStartViewInformation
    {        
        public static List<ModelParameter> GetAllMyParameters(Document document, Category modelCategory)
        {
            List<ModelParameter> myParameters = new List<ModelParameter>();

            int value = modelCategory.Id.IntegerValue;
            var a = (BuiltInCategory)value;
            var number = (int)a;

            List<Element> elementsCollector = new FilteredElementCollector(document).OfCategory(a)
                .WhereElementIsNotElementType()
                .ToList();
            Element element = elementsCollector.FirstOrDefault();

            if (element != null)
            {
                var parameterSet = element.Parameters;

                foreach (var parameter in parameterSet)
                {
                    Parameter thisparameter = parameter as Parameter;
                    ModelParameter myParameter = new ModelParameter();
                    myParameter.Id = thisparameter.Id;
                    myParameter.StorageType = thisparameter.StorageType;
                    myParameter.Name = thisparameter.Definition.Name;

                    if (thisparameter.StorageType == StorageType.String || thisparameter.StorageType == StorageType.ElementId)
                    {
                        myParameter.ConditionFilters = new List<FilterConditionEnum.FilterConditionFull>()
                        {
                            FilterConditionEnum.FilterConditionFull.Equals,
                            FilterConditionEnum.FilterConditionFull.NotEquals,
                            FilterConditionEnum.FilterConditionFull.HadValue,
                            FilterConditionEnum.FilterConditionFull.NotHadValue,
                            FilterConditionEnum.FilterConditionFull.StartWith,
                            FilterConditionEnum.FilterConditionFull.NotStartWith,
                            FilterConditionEnum.FilterConditionFull.EndWith,
                            FilterConditionEnum.FilterConditionFull.NotEndWith,
                            FilterConditionEnum.FilterConditionFull.Contained,
                            FilterConditionEnum.FilterConditionFull.NotContained,
                        };
                    }
                    else if ((thisparameter.StorageType == StorageType.Integer || myParameter.StorageType == StorageType.Double) && thisparameter.Definition.ParameterType != ParameterType.YesNo)
                    {
                        myParameter.ConditionFilters = new List<FilterConditionEnum.FilterConditionFull>()
                        {
                            FilterConditionEnum.FilterConditionFull.Less,
                            FilterConditionEnum.FilterConditionFull.LessAndEquals,
                            FilterConditionEnum.FilterConditionFull.More,
                            FilterConditionEnum.FilterConditionFull.MoreAndEquals,
                            FilterConditionEnum.FilterConditionFull.Equals,
                            FilterConditionEnum.FilterConditionFull.NotEquals
                        };
                    }
                    else if (thisparameter.StorageType == StorageType.Integer && thisparameter.Definition.ParameterType == ParameterType.YesNo)
                    {
                        myParameter.ConditionFilters = new List<FilterConditionEnum.FilterConditionFull>()
                        {
                            FilterConditionEnum.FilterConditionFull.Equals,
                            FilterConditionEnum.FilterConditionFull.NotEquals
                        };
                    }
                    else
                    {
                        myParameter.ConditionFilters = new List<FilterConditionEnum.FilterConditionFull>()
                        {
                            FilterConditionEnum.FilterConditionFull.Equals,
                            FilterConditionEnum.FilterConditionFull.NotEquals,
                            FilterConditionEnum.FilterConditionFull.HadValue,
                            FilterConditionEnum.FilterConditionFull.NotHadValue,
                            FilterConditionEnum.FilterConditionFull.StartWith,
                            FilterConditionEnum.FilterConditionFull.NotStartWith,
                            FilterConditionEnum.FilterConditionFull.EndWith,
                            FilterConditionEnum.FilterConditionFull.NotEndWith,
                            FilterConditionEnum.FilterConditionFull.Contained,
                            FilterConditionEnum.FilterConditionFull.NotContained,
                            FilterConditionEnum.FilterConditionFull.Less,
                            FilterConditionEnum.FilterConditionFull.LessAndEquals,
                            FilterConditionEnum.FilterConditionFull.More,
                            FilterConditionEnum.FilterConditionFull.MoreAndEquals,
                            FilterConditionEnum.FilterConditionFull.Equals,
                            FilterConditionEnum.FilterConditionFull.NotEquals
                        };
                    }

                    myParameters.Add(myParameter);
                }
            }
            myParameters = myParameters                
                .Where(x => x.StorageType != StorageType.ElementId)
                .OrderBy(x => x.Name).ToList();
            return myParameters;
        }
    }
}
