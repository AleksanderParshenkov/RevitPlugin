using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomAffiliation.Models
{
    public static class CorrectBuiltInCategoryList
    {
        public static List<BuiltInCategory> _categories = new List<BuiltInCategory>()
        {
            BuiltInCategory.OST_DuctAccessory, // Арматура воздуховодов
            BuiltInCategory.OST_PipeAccessory, // Арматура трубопроводов
            BuiltInCategory.OST_DuctTerminal, // Воздухораспределители
            BuiltInCategory.OST_LightingDevices, // Выключатели
            BuiltInCategory.OST_IOSModelGroups, // Группы элементов модели
            BuiltInCategory.OST_DataDevices, // Датчики
            BuiltInCategory.OST_Furniture, // Мебель
            BuiltInCategory.OST_GenericModel, // Обобщенные модели
            BuiltInCategory.OST_MechanicalEquipment, // Оборудование
            BuiltInCategory.OST_LightingFixtures, // Осветительные приборы
            BuiltInCategory.OST_PlumbingFixtures, // Сантехнические приборы
            BuiltInCategory.OST_Assemblies, // Сборки
            BuiltInCategory.OST_SpecialityEquipment, // Специальное оборудование
            BuiltInCategory.OST_ElectricalFixtures, // Электрические приборы            
            BuiltInCategory.OST_ElectricalEquipment // Электрооборудование
        };
    }
}
