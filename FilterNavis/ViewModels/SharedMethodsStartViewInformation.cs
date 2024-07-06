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
        public static List<Element> GetAllMyElemetns(Document document)
        {
            List<Element> elementsCollector = new FilteredElementCollector(document)
                .WhereElementIsNotElementType()
                .Where(x => x.Category != null)
                .ToList();
            return elementsCollector;
        }

        public static List<ModelCategory> GetAllMyCategories(List<Element> elementsCollector, Document document)
        {
            List<ModelCategory> categories = new List<ModelCategory>();
            var UsedCategories = elementsCollector
                .Select(x => x.Category).ToList();
                //.Distinct(new CategoryIEqualityComparer()).ToList();

            foreach (var item in UsedCategories)
            {
                if (item.Name != null && item.Name != "")
                {
                    ModelCategory category = new ModelCategory();
                    category.Name = item.Name;
                    category.Id = item.Id;
                    category.ModelParameter = GetAllMyParameters(document, item);
                    categories.Add(category);
                }
            }
            categories = categories.Where(x => x.ModelParameter.Count() != 0 && x.ModelParameter != null).OrderBy(x => x.Name).ToList();
            return categories;
        }

        public static List<ModelParameter> GetAllMyParameters(Document document, Category mycategory)
        {
            List<ModelParameter> myParameters = new List<ModelParameter>();

            int value = mycategory.Id.IntegerValue;
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
                            FilterConditionEnum.FilterConditionFull.Равно,
                            FilterConditionEnum.FilterConditionFull.Не_равно,
                            FilterConditionEnum.FilterConditionFull.Имеет_значение,
                            FilterConditionEnum.FilterConditionFull.Не_имеет_значение,
                            FilterConditionEnum.FilterConditionFull.Начинается_с,
                            FilterConditionEnum.FilterConditionFull.Не_начинается_с,
                            FilterConditionEnum.FilterConditionFull.Заканчикавется_на,
                            FilterConditionEnum.FilterConditionFull.Не_заканчивается_на,
                            FilterConditionEnum.FilterConditionFull.Содержит,
                            FilterConditionEnum.FilterConditionFull.Не_содержит,
                        };
                    }
                    else if ((thisparameter.StorageType == StorageType.Integer || myParameter.StorageType == StorageType.Double) && thisparameter.Definition.ParameterType != ParameterType.YesNo)
                    {
                        myParameter.ConditionFilters = new List<FilterConditionEnum.FilterConditionFull>()
                        {
                            FilterConditionEnum.FilterConditionFull.Меньше,
                            FilterConditionEnum.FilterConditionFull.Меньше_или_равно,
                            FilterConditionEnum.FilterConditionFull.Больше,
                            FilterConditionEnum.FilterConditionFull.Больше_или_равно,
                            FilterConditionEnum.FilterConditionFull.Равно,
                            FilterConditionEnum.FilterConditionFull.Не_равно
                        };
                    }
                    else if (thisparameter.StorageType == StorageType.Integer && thisparameter.Definition.ParameterType == ParameterType.YesNo)
                    {
                        myParameter.ConditionFilters = new List<FilterConditionEnum.FilterConditionFull>()
                        {
                            FilterConditionEnum.FilterConditionFull.Равно,
                            FilterConditionEnum.FilterConditionFull.Не_равно
                        };
                    }
                    else
                    {
                        myParameter.ConditionFilters = new List<FilterConditionEnum.FilterConditionFull>()
                        {
                            FilterConditionEnum.FilterConditionFull.Равно,
                            FilterConditionEnum.FilterConditionFull.Не_равно,
                            FilterConditionEnum.FilterConditionFull.Имеет_значение,
                            FilterConditionEnum.FilterConditionFull.Не_имеет_значение,
                            FilterConditionEnum.FilterConditionFull.Начинается_с,
                            FilterConditionEnum.FilterConditionFull.Не_начинается_с,
                            FilterConditionEnum.FilterConditionFull.Заканчикавется_на,
                            FilterConditionEnum.FilterConditionFull.Не_заканчивается_на,
                            FilterConditionEnum.FilterConditionFull.Содержит,
                            FilterConditionEnum.FilterConditionFull.Не_содержит,
                            FilterConditionEnum.FilterConditionFull.Меньше,
                            FilterConditionEnum.FilterConditionFull.Меньше_или_равно,
                            FilterConditionEnum.FilterConditionFull.Больше,
                            FilterConditionEnum.FilterConditionFull.Больше_или_равно,
                            FilterConditionEnum.FilterConditionFull.Равно,
                            FilterConditionEnum.FilterConditionFull.Не_равно
                        };
                    }

                    myParameters.Add(myParameter);
                }
            }
            myParameters = myParameters
                //.Distinct(new MyParameterIEqualityComparer())
                .Where(x => x.StorageType != StorageType.ElementId)
                .OrderBy(x => x.Name).ToList();
            return myParameters;
        }

        //public class MyParameterIEqualityComparer : IEqualityComparer<ModelParameter>
        //{
        //    public bool Equals(ModelParameter x, ModelParameter y)
        //    {
        //        return x.Id == y.Id;
        //    }

        //    public int GetHashCode(ModelParameter obj)
        //    {
        //        return HashCode.Combine(obj.Id, obj.Id);
        //    }
        //}
    }
}
