using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickFilter.Support
{
    public class SupportMethodsObjectDistinct
    {
        public class CategoryIEqualityComparer : IEqualityComparer<Category>
        {
            public bool Equals(Category x, Category y)
            {
                return x.Name == y.Name;
            }

            public int GetHashCode(Category obj)
            {
                //return HashCode.Combine(obj.Name);

                return obj.Name.GetHashCode();
            }
        }

    }
}
