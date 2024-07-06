﻿using Autodesk.Revit.DB;
using FilterNavis.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilterNavis.Models
{
    public class ModelParameter
    {
        public string Name { get; set; }
        public ElementId Id { get; set; }
        public StorageType StorageType { get; set; }
        public List<FilterConditionEnum.FilterConditionFull> ConditionFilters { get; set; }
    }
}
