using Autodesk.Revit.DB;
using DimensionsControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DimensionsControl.Support
{
    public static class SupportCheckModelMethods
    {
        public static List <Dimension> GetAllDimensionsFromModel()
        {
            // Получение коллектора размеров из модули
            FilteredElementCollector dimensionCollector = new FilteredElementCollector(CurrentModel.Doc).OfCategory(BuiltInCategory.OST_Dimensions).WhereElementIsNotElementType();

            // Преобразование Element в Dimension
            List<Dimension> dimensionList = dimensionCollector.Select(x=>x as Dimension).ToList();

            // Выделение из списка Dimension только линейных размеров
            dimensionList = dimensionList.Where(x => x.DimensionShape == DimensionShape.Linear).ToList();

            return dimensionList;
        }
    }
}
