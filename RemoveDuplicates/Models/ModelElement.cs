using Autodesk.Revit.DB;
using RemoveDuplicates.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveDuplicates.Models
{
    public class ModelElement
    {
        //private FamilyTypeEnum familyType { get; set; }
        private bool isPlaced { get; set; }
        private bool isDuplicateFamily { get; set; }
        private bool isDuplicateType { get; set; }
        private bool isEasyInstance { get; set; }
        private bool isInParentFamilyWithChangeParameter { get; set; }
        private bool isInParentFamilyWithoutChangeParameter { get; set; }
        private bool isPlacingInUtilityNetwork { get; set; }
        private bool isInUtilityNetworkSegmentConfigure {  get; set; }
        private bool isInGroup { get; set; }
        private bool isInAssembly { get; set; }
        private Category category { get; set; }
    }

    public class Duplicate : ModelElement
    {

    }
}
