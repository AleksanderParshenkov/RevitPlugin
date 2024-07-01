#region Usings
using CheckModulName.Models;
using System.Collections.Generic;
using System.Linq;
#endregion

namespace CheckModulName.ViewModels
{
    /// <summary>
    /// Класс с инструкциями проверки модулей квартир
    /// по дисциплинам
    /// </summary>
    public static class CheckModulKV
    {
        /// <summary>
        /// Проверка модулей АР
        /// </summary>
        public static void CheckModulAR(List<string> listField)
        {           
            // Общие для всех дисциплин проверки полей
            CheckKVFieldMethods.CheckField1();
            CheckKVFieldMethods.CheckField2();
            CheckKVFieldMethods.CheckField3();
            CheckKVFieldMethods.CheckField4();
            CheckKVFieldMethods.CheckField5();
            CheckKVFieldMethods.CheckField6();
            CheckKVFieldMethods.CheckField7();
            CheckKVFieldMethods.CheckField8();
            CheckKVFieldMethods.CheckField9();
            CheckKVFieldMethods.CheckField10();
            CheckKVFieldMethods.CheckField11();
            CheckKVFieldMethods.CheckField12();
        }

        /// <summary>
        /// Проверка модулей АИ
        /// </summary>
        public static void CheckModulAI(List<string> listField)
        {
            // Общие для всех дисциплин проверки полей
            CheckKVFieldMethods.CheckField1();

            //Поле 2            
            if (ModulFields.field2Value != "AD")
            {
                ModulFields.field2IsError = true;
            }

            // Общие для всех дисциплин проверки полей
            CheckKVFieldMethods.CheckField3();
            CheckKVFieldMethods.CheckField4();
            CheckKVFieldMethods.CheckField5();
            CheckKVFieldMethods.CheckField6();
            CheckKVFieldMethods.CheckField7();
            CheckKVFieldMethods.CheckField8();
            CheckKVFieldMethods.CheckField9();
            CheckKVFieldMethods.CheckField10();
            CheckKVFieldMethods.CheckField11();
            CheckKVFieldMethods.CheckField12();
        }

        /// <summary>
        /// Проверка модулей ЭОМ
        /// </summary>
        public static void CheckModulEOM()
        {
            //Поле 0
            if (ModulFields.field0Value != Enums.field0_Discipline.EOM.GetDescription())
            {
                ModulFields.field0IsError = true;
            }

            // Общие для всех дисциплин проверки полей
            CheckKVFieldMethods.CheckField1();
            CheckKVFieldMethods.CheckField2();
            CheckKVFieldMethods.CheckField3();
            CheckKVFieldMethods.CheckField4();
            CheckKVFieldMethods.CheckField5();
            CheckKVFieldMethods.CheckField6();
            CheckKVFieldMethods.CheckField7();
            CheckKVFieldMethods.CheckField8();
            CheckKVFieldMethods.CheckField9();
            CheckKVFieldMethods.CheckField10();
            CheckKVFieldMethods.CheckField11();
            CheckKVFieldMethods.CheckField12();

            //Поле 13

            if (ModulFields.field13Value.Length == 0)
            {
                ModulFields.field13IsError = true;
            }
            else if (ModulFields.field13Value.Length == 1)
            {
                if (ModulFields.field13Value != Enums.field13_EOM_MirrowType.S.ToString())
                {
                    ModulFields.field13IsError = true;
                }
            }
            else
            {
                string field13ValueWithoutLetters = ModulFields.field13Value.Substring(1);
                if (ModulFields.field13Value.StartsWith(Enums.field13_EOM_MirrowType.R.ToString()) &&
                    field13ValueWithoutLetters.Where(x => char.IsLetter(x) == false).ToList().Count() == ModulFields.field13Value.Length - 1) { }
                else
                {
                    ModulFields.field13IsError = true;
                }
            }
        }

        /// <summary>
        /// Проверка модулей ВК
        /// </summary>
        public static void CheckModulVK(List<string> listField)
        {
            //Поле 0
            if (ModulFields.field0Value != Enums.field0_Discipline.VK.GetDescription())
            {                
                ModulFields.field0IsError = true;
            }

            // Общие для всех дисциплин проверки полей
            CheckKVFieldMethods.CheckField1();
            CheckKVFieldMethods.CheckField2();
            CheckKVFieldMethods.CheckField3();
            CheckKVFieldMethods.CheckField4();
            CheckKVFieldMethods.CheckField5();
            CheckKVFieldMethods.CheckField6();
            CheckKVFieldMethods.CheckField7();
            CheckKVFieldMethods.CheckField8();
            CheckKVFieldMethods.CheckField9();
            CheckKVFieldMethods.CheckField10();

            //Поле 11  
            if (ModulFields.field11Value != "none")
            {
                ModulFields.field11IsError = true;
            }

            //Поле 12
            CheckKVFieldMethods.CheckField12();

            //Поле 13 
            if (!ModulFields.field13Value.Contains("IN") &&
                !ModulFields.field13Value.Contains("OUT"))
            {
                ModulFields.field13IsError = true;
            }
            string field13ValueWithoutEnums = ModulFields.field13Value;
            field13ValueWithoutEnums = field13ValueWithoutEnums.Replace(Enums.field13_VK_PlacePipe.IN1.ToString(), "");
            field13ValueWithoutEnums = field13ValueWithoutEnums.Replace(Enums.field13_VK_PlacePipe.IN2.ToString(), "");
            field13ValueWithoutEnums = field13ValueWithoutEnums.Replace(Enums.field13_VK_PlacePipe.IN3.ToString(), "");
            field13ValueWithoutEnums = field13ValueWithoutEnums.Replace(Enums.field13_VK_PlacePipe.OUT1.ToString(), "");
            field13ValueWithoutEnums = field13ValueWithoutEnums.Replace(Enums.field13_VK_PlacePipe.OUT2.ToString(), "");
            field13ValueWithoutEnums = field13ValueWithoutEnums.Replace(Enums.field13_VK_PlacePipe.OUT3.ToString(), "");
            if (field13ValueWithoutEnums != "")
            {
                ModulFields.field13IsError = true;
            }
            List<char> char1 = ModulFields.field13Value.Where(x => x == '1').ToList();
            List<char> char2 = ModulFields.field13Value.Where(x => x == '2').ToList();
            List<char> char3 = ModulFields.field13Value.Where(x => x == '3').ToList();
            if (char1.Count() > 1 || char2.Count() > 1 || char3.Count() > 1)
            {
                ModulFields.field13IsError = true;
            }
        }

        /// <summary>
        /// Проверка модулей ОВ1
        /// </summary>
        public static void CheckModulOV1(List<string> listField)
        {
            //Поле 0
            if (ModulFields.field0Value != Enums.field0_Discipline.OV1.GetDescription())
            {
                ModulFields.field0IsError = true;
            }

            // Общие для всех дисциплин проверки полей
            CheckKVFieldMethods.CheckField1();
            CheckKVFieldMethods.CheckField2();
            CheckKVFieldMethods.CheckField3();
            CheckKVFieldMethods.CheckField4();
            CheckKVFieldMethods.CheckField5();
            CheckKVFieldMethods.CheckField6();
            CheckKVFieldMethods.CheckField7();
            CheckKVFieldMethods.CheckField8();
            CheckKVFieldMethods.CheckField9();
            CheckKVFieldMethods.CheckField10();
            CheckKVFieldMethods.CheckField11();
            CheckKVFieldMethods.CheckField12();

            //Поле 13
            if (ModulFields.field13Value != Enums.field13_OV1_HeatZoneCount.z1.GetDescription() &&
                ModulFields.field13Value != Enums.field13_OV1_HeatZoneCount.z2.GetDescription() &&
                ModulFields.field13Value != Enums.field13_OV1_HeatZoneCount.zp2.GetDescription() &&
                ModulFields.field13Value != Enums.field13_OV1_HeatZoneCount.N.GetDescription())
            {
                ModulFields.field13IsError = true;
            }
        }

        /// <summary>
        /// Проверка модулей ОВ2В
        /// </summary>
        public static void CheckModulOV2V(List<string> listField)
        {
            //Поле 0
            if (ModulFields.field0Value != Enums.field0_Discipline.OV2V.GetDescription())
            {
                ModulFields.field0IsError = true;
            }

            // Общие для всех дисциплин проверки полей
            CheckKVFieldMethods.CheckField1();
            CheckKVFieldMethods.CheckField2();
            CheckKVFieldMethods.CheckField3();
            CheckKVFieldMethods.CheckField4();
            CheckKVFieldMethods.CheckField5();
            CheckKVFieldMethods.CheckField6();
            CheckKVFieldMethods.CheckField7();
            CheckKVFieldMethods.CheckField8();
            CheckKVFieldMethods.CheckField9();
            CheckKVFieldMethods.CheckField10();
            CheckKVFieldMethods.CheckField11();
            CheckKVFieldMethods.CheckField12();

            //Поле 13
            if (ModulFields.field13Value != "none")
            {
                ModulFields.field13IsError = true;
            }
        }

        /// <summary>
        /// Проверка модулей ОВ2К
        /// </summary>
        public static void CheckModulOV2K(List<string> listField)
        {
            //Поле 0
            if (ModulFields.field0Value != Enums.field0_Discipline.OV2K.GetDescription())
            {
                ModulFields.field0IsError = true;
            }

            // Общие для всех дисциплин проверки полей
            CheckKVFieldMethods.CheckField1();
            CheckKVFieldMethods.CheckField2();
            CheckKVFieldMethods.CheckField3();
            CheckKVFieldMethods.CheckField4();
            CheckKVFieldMethods.CheckField5();
            CheckKVFieldMethods.CheckField6();
            CheckKVFieldMethods.CheckField7();
            CheckKVFieldMethods.CheckField8();
            CheckKVFieldMethods.CheckField9();
            CheckKVFieldMethods.CheckField10();
            CheckKVFieldMethods.CheckField11();
            CheckKVFieldMethods.CheckField12();

            //Поле 13
            if (ModulFields.field13Value != "none")
            {
                ModulFields.field13IsError = true;
            }
        }
    }
}
