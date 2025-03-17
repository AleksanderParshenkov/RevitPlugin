using Autodesk.Revit.Creation;
using Autodesk.Revit.DB;
using GetFamilyTypeListFromIds.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GetFamilyTypeListFromIds.Services
{
    public static class GetFamilyMethod
    {
        public static string GetFamilyTypeListFromIdList (string ids)
        {
            if (ids == null || ids == "") return "";

            List <int> list = ids.Split (';').ToList ().Select (int.Parse).ToList ();

            List<Element> elementListCurrentModel = new FilteredElementCollector(CurrentModel.Doc)
                    .WhereElementIsNotElementType()                    
                    .Select(x => x as Element)
                    .Where(x => list.Contains(x.Id.IntegerValue))
                    .ToList();

            if(elementListCurrentModel == null) return "";

            List <string> resultList = elementListCurrentModel.Select (x =>
            {
                string falimy = x.get_Parameter(BuiltInParameter.ELEM_FAMILY_PARAM).AsValueString();
                string type = x.get_Parameter(BuiltInParameter.ELEM_TYPE_PARAM).AsValueString();
                return falimy + " : " + type;
            }).ToList ();

            resultList = resultList.Distinct().ToList();

            return string.Join ("\n", resultList);
        }
    }
}
