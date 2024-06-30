#region Usings
using CheckModulName.Models;
using System.Collections.Generic;
using System.Linq;
#endregion

namespace CheckModulName.ViewModels
{
    /// <summary>
    /// Класс с инструкциями проверки модулей ЛЛУ
    /// по дисциплинам
    /// </summary>
    public class CheckModulLLU
    {
        /// <summary>
        /// Проверка модулей ЭОМ
        /// </summary>
        public static void CheckModulEOM(List<string> listField)
        {
            //Поле 0
            if (ModulFields.field0Value != Enums.field0_Discipline.EOM.GetDescription())
            {
                ModulFields.field0IsError = true;
            }

            // Общие для всех дисциплин проверки полей
            CheckLLUFieldMethods.CheckField1();
            CheckLLUFieldMethods.CheckField2();
            CheckLLUFieldMethods.CheckField3();
            CheckLLUFieldMethods.CheckField4();
            CheckLLUFieldMethods.CheckField5();
            CheckLLUFieldMethods.CheckField6();
            CheckLLUFieldMethods.CheckField7();
            CheckLLUFieldMethods.CheckField8();
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
            CheckLLUFieldMethods.CheckField1();
            CheckLLUFieldMethods.CheckField2();
            CheckLLUFieldMethods.CheckField3();
            CheckLLUFieldMethods.CheckField4();
            CheckLLUFieldMethods.CheckField5();
            CheckLLUFieldMethods.CheckField6();
            CheckLLUFieldMethods.CheckField7();
            CheckLLUFieldMethods.CheckField8();

            //Поле 9 
            if (ModulFields.field9Value != Enums.field13_OV1_HeatZoneCount.z1.GetDescription() &&
                ModulFields.field9Value != Enums.field13_OV1_HeatZoneCount.z2.GetDescription() &&
                ModulFields.field9Value != Enums.field13_OV1_HeatZoneCount.zp2.GetDescription())
            {
                ModulFields.field9IsError = true;
            }

            //Поле 10
            if (ModulFields.field10Value != Enums.field10_LLUHeatSystemType.H.ToString() &&
                ModulFields.field10Value != Enums.field10_LLUHeatSystemType.V.ToString() &&
                ModulFields.field10Value != Enums.field10_LLUHeatSystemType.H0.ToString() &&
                ModulFields.field10Value != Enums.field10_LLUHeatSystemType.V0.ToString())
            {
                ModulFields.field10IsError = true;
            }

            //Поле 11
            int error11 = 0;
            if (ModulFields.field11Value.Contains("-"))
            {
                List<string> list = ModulFields.field11Value.Split('-').ToList();
                foreach (var item in list)
                {
                    List <char> itemWithoutDigit = item.Where(x => !char.IsDigit(x)).ToList();
                    if (itemWithoutDigit.Count() > 0) error11 = 1;
                    else
                    {
                        int itemValueDigit = int.Parse(item);
                        if (itemValueDigit < 2 || itemValueDigit > 12)
                        {
                            error11 = 1;
                        }
                    }
                }
            }
            else
            {
                List<char> itemWithoutDigit = ModulFields.field11Value.Where(x => !char.IsDigit(x)).ToList();
                if (itemWithoutDigit.Count() > 0) error11 = 1;
                else
                {
                    int itemValueDigit = int.Parse(ModulFields.field11Value);
                    if (itemValueDigit < 2 || itemValueDigit > 12)
                    {
                        error11 = 1;
                    }
                }
            }

            if (error11 == 1)
            {
                ModulFields.field11IsError = true;
            }

            //Поле 12
            CurrentWindow.Wnd.field12Name.Text = "";
            CurrentWindow.Wnd.field12Description.Text = "";

            //Поле 13
            CurrentWindow.Wnd.field13Name.Text = "";
            CurrentWindow.Wnd.field13Description.Text = "";
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
            CheckLLUFieldMethods.CheckField1();
            CheckLLUFieldMethods.CheckField2();
            CheckLLUFieldMethods.CheckField3();
            CheckLLUFieldMethods.CheckField4();
            CheckLLUFieldMethods.CheckField5();
            CheckLLUFieldMethods.CheckField6();
            CheckLLUFieldMethods.CheckField7();
            CheckLLUFieldMethods.CheckField8();

            //Поле 9
            if (ModulFields.field9Value != Enums.field13_OV1_HeatZoneCount.z1.GetDescription() &&
                ModulFields.field9Value != Enums.field13_OV1_HeatZoneCount.z2.GetDescription() &&
                ModulFields.field9Value != Enums.field13_OV1_HeatZoneCount.zp2.GetDescription())
            {
                ModulFields.field9IsError = true;
            }

            //Поле 10
            if (ModulFields.field10Value != "none")
            {
                ModulFields.field10IsError = true;
            }

            //Поле 11
            if (ModulFields.field11Value != "0")
            {
                ModulFields.field11IsError = true;
            }

        }

        /// <summary>
        /// Проверка модулей АР
        /// </summary>
        public static void CheckModulAR(List<string> listField)
        {
            // Общие для всех дисциплин проверки полей
            CheckLLUFieldMethods.CheckField1();
            CheckLLUFieldMethods.CheckField2();
            CheckLLUFieldMethods.CheckField3();
            CheckLLUFieldMethods.CheckField4();
            CheckLLUFieldMethods.CheckField5();
            CheckLLUFieldMethods.CheckField6();
            CheckLLUFieldMethods.CheckField7();
            CheckLLUFieldMethods.CheckField8();
        }

        /// <summary>
        /// Проверка модулей АИ
        /// </summary>
        public static void CheckModulAI(List<string> listField)
        {
            // Общие для всех дисциплин проверки полей
            CheckLLUFieldMethods.CheckField1();
                        
            //Поле 2            
            if (ModulFields.field2Value != "AD")
            {
                ModulFields.field2IsError = true;
            }

            // Общие для всех дисциплин проверки полей
            CheckLLUFieldMethods.CheckField3();
            CheckLLUFieldMethods.CheckField4();
            CheckLLUFieldMethods.CheckField5();
            CheckLLUFieldMethods.CheckField6();
            CheckLLUFieldMethods.CheckField7();
            CheckLLUFieldMethods.CheckField8();
        }
    }
}
