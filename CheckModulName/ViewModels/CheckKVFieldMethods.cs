#region Usings
using CheckModulName.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using static CheckModulName.Models.Enums;
#endregion

namespace CheckModulName.ViewModels
{
    /// <summary>
    /// Класс с общими методами проверок полей по квартирам
    /// независимо от дисциплин
    /// </summary>
    public static class CheckKVFieldMethods
    {
        /// <summary>
        /// Поле 1
        /// </summary>
        public static void CheckField1()
        {
            if (ModulFields.field1Value != Enums.field1_Modul.KV.ToString())
            {
                ModulFields.field1IsError = true;
            }
        }

        /// <summary>
        /// Поле 2
        /// </summary>
        public static void CheckField2()
        {           
            if (ModulFields.field2Value != Enums.field2_ApartmentBuildType.WB.ToString() &&
                ModulFields.field2Value != Enums.field2_ApartmentBuildType.Basic.ToString() &&
                ModulFields.field2Value != Enums.field2_ApartmentBuildType.DD.ToString())
            {
                ModulFields.field2IsError = true;
            }
        }

        /// <summary>
        /// Поле 3
        /// </summary>
        public static void CheckField3()
        {
            List<string> listEnumField3 = new List<string>();
            var AllValueField3 = Enum.GetValues(typeof(field3_WCStructure));
            foreach (var v in AllValueField3) listEnumField3.Add(v.ToString());
            if (!listEnumField3.Contains(ModulFields.field3Value))
            {
                ModulFields.field3IsError = true;
            }
        }

        /// <summary>
        /// Поле 4
        /// </summary>
        public static void CheckField4()
        {
            List<char> field4ValueFiltered = ModulFields.field4Value
                .Where(x => x != 'X')
                .Where(x => x != '.')
                .Where(x => !char.IsDigit(x)).ToList();
            if (field4ValueFiltered.Count > 0)
            {
                ModulFields.field4IsError = true;
            }
            else
            {
                if (ModulFields.field7Value.Contains("T")) // торцевые
                {
                    if (!ModulFields.field4Value.Contains("X"))
                    {
                        ModulFields.field4IsError = true;
                    }
                }
                else // не торцевые
                {
                    if (ModulFields.field4Value.Contains("X"))
                    {
                        ModulFields.field4IsError = true;
                    }
                }
            }

            for (int i = 0; i < ModulFields.field4Value.Length; i++)
            {
                if (i == 0) { }
                else
                {
                    if ((char.IsPunctuation(ModulFields.field4Value[i]) || char.IsLetter(ModulFields.field4Value[i]))
                        && ModulFields.field4Value[i] == ModulFields.field4Value[i - 1])
                    {
                        ModulFields.field4IsError = true;
                    }
                }
            }
        }

        /// <summary>
        /// Поле 5
        /// </summary>
        public static void CheckField5()
        {
            List<string> listEnumField5 = new List<string>();
            var AllValueField5 = Enum.GetValues(typeof(field5_BuildingClass));
            foreach (var v in AllValueField5) listEnumField5.Add(v.ToString());
            if (!listEnumField5.Contains(ModulFields.field5Value))
            {
                ModulFields.field5IsError = true;
            }
        }

        /// <summary>
        /// Поле 6
        /// </summary>
        public static void CheckField6()
        {
            if (ModulFields.field6Value.Count() != 3)
            {
                ModulFields.field6IsError = true;
            }
            else
            {
                char field5ValueSimbol1 = ModulFields.field6Value[0];
                char field5ValueSimbol2 = ModulFields.field6Value[1];
                char field5ValueSimbol3 = ModulFields.field6Value[2];

                List<string> listEnumField6_KitchenFuncionalType = new List<string>();
                var AllValueField6_KitchenFuncionalType = Enum.GetValues(typeof(field6_KitchenFuncionalType));
                foreach (var v in AllValueField6_KitchenFuncionalType) listEnumField6_KitchenFuncionalType.Add(v.ToString());

                List<string> listEnumField6_KitchenPreset = new List<string>();
                var AllValueField6_KitchenPreset = Enum.GetValues(typeof(field6_KitchenPreset));
                foreach (var v in AllValueField6_KitchenPreset) listEnumField6_KitchenPreset.Add(v.ToString());

                if (char.IsDigit(field5ValueSimbol1) &&
                    listEnumField6_KitchenFuncionalType.Contains(field5ValueSimbol2.ToString()) &&
                    listEnumField6_KitchenPreset.Contains(field5ValueSimbol3.ToString())) { }
                else
                {
                    ModulFields.field6IsError = true;
                }
            }
            
        }

        /// <summary>
        /// Поле 7
        /// </summary>
        public static void CheckField7()
        {            
            if (!ModulFields.field7Value.Contains("(") || !ModulFields.field7Value.Contains(")"))
            {
                ModulFields.field7IsError = true;
            }
            else
            {
                string field7Value_FirstValueInBrackets = ModulFields.field7Value.Substring(
                    ModulFields.field7Value.IndexOf("(") + 1,
                    ModulFields.field7Value.IndexOf(")") - 1);
                string field7Value_LastValueAfterBrackets = ModulFields.field7Value.Substring(
                    ModulFields.field7Value.IndexOf(")") + 1);

                //Проверка первой части в скобках
                if (field7Value_FirstValueInBrackets.Length != 3 || field7Value_FirstValueInBrackets
                    .Where(x => x != '.')
                    .Where(x => !char.IsDigit(x))
                    .ToList().Count() > 0)
                {
                    ModulFields.field7IsError = true;
                }

                //Проверка второй части после скобок
                var field7Value_LastValueAfterBrackets_ApartmentMatrix = field7Value_LastValueAfterBrackets.Where(x => char.IsLetter(x)).ToList();
                var field7Value_LastValueAfterBrackets_VariantOfPlan = field7Value_LastValueAfterBrackets.Where(x => !char.IsLetter(x)).Where(x => x != '.').Where(x => !char.IsDigit(x)).ToList();

                List<string> listEnumField7_ApartmentMatrix = new List<string>();
                var AllValueField7_ApartmentMatrix = Enum.GetValues(typeof(field7_ApartmentMatrix));
                foreach (var v in AllValueField7_ApartmentMatrix) listEnumField7_ApartmentMatrix.Add(v.ToString());

                if (listEnumField7_ApartmentMatrix.Contains(string.Join("", field7Value_LastValueAfterBrackets_ApartmentMatrix)) &&
                    field7Value_LastValueAfterBrackets_VariantOfPlan.Count == 0) { }
                else
                {
                    ModulFields.field7IsError = true;
                }

            }
            for (int i = 0; i < ModulFields.field7Value.Length; i++)
            {
                if (i == 0) { }
                else
                {
                    if ((char.IsPunctuation(ModulFields.field7Value[i]) || char.IsLetter(ModulFields.field7Value[i]))
                        && ModulFields.field7Value[i] == ModulFields.field7Value[i - 1])
                    {
                        ModulFields.field7IsError = true;
                    }
                }
            }
        }

        /// <summary>
        /// Поле 8
        /// </summary>
        public static void CheckField8()
        {
            if (!ModulFields.field8Value.Contains("x"))
            {
                ModulFields.field8IsError = true;
            }
            else
            {
                List<char> field8ValueFiltered = ModulFields.field8Value
                .Where(x => x != 'x')
                .Where(x => x != '.')
                .Where(x => !char.IsDigit(x)).ToList();

                if (field8ValueFiltered.Count == 0) { }
                else 
                {
                    ModulFields.field8IsError = true;
                }
            }
            for (int i = 0; i < ModulFields.field8Value.Length; i++)
            {
                if (i == 0) { }
                else
                {
                    if ((char.IsPunctuation(ModulFields.field8Value[i]) || char.IsLetter(ModulFields.field8Value[i]))
                        && ModulFields.field8Value[i] == ModulFields.field8Value[i - 1])
                    {
                        ModulFields.field8IsError = true;
                    }
                }
            }
        }

        /// <summary>
        /// Поле 9
        /// </summary>
        public static void CheckField9()
        {
            if (ModulFields.field9Value != Enums.field9_MirrowType.A.ToString() &&
                ModulFields.field9Value != Enums.field9_MirrowType.Z.ToString())
            {
                ModulFields.field9IsError = true;
            }
        }

        /// <summary>
        /// Поле 10
        /// </summary>
        public static void CheckField10()
        {
            if (!ModulFields.field10Value.StartsWith("V"))
            {
                ModulFields.field10IsError = true;
            }
            else
            {
                var listField10ValueWithoutLetter = ModulFields.field10Value.Where(x => x != 'V').ToList();
                if (listField10ValueWithoutLetter.Where(x => char.IsDigit(x)).ToList().Count() != ModulFields.field10Value.Length - 1)
                {
                    ModulFields.field10IsError = true;
                }
            }
        }

        /// <summary>
        /// Поле 11
        /// </summary>
        public static void CheckField11()
        {
            if (!ModulFields.field11Value.Contains("(") || !ModulFields.field11Value.Contains(")"))
            {
                ModulFields.field11IsError = true;
            }
            else
            {
                var field11ValueWithoutBrackets = ModulFields.field11Value.Where(x => x != '(').Where(x => x != ')').ToList();
                if (field11ValueWithoutBrackets.Count == 1 &&
                    field11ValueWithoutBrackets[0].ToString() == Enums.field11_SummerRoom.N.ToString()) { }
                else
                {
                    ModulFields.field11IsError = true;
                }
            }
            for (int i = 0; i < ModulFields.field11Value.Length; i++)
            {
                if (i == 0) { }
                else
                {
                    if ((char.IsPunctuation(ModulFields.field11Value[i]) || char.IsLetter(ModulFields.field11Value[i]))
                        && ModulFields.field11Value[i] == ModulFields.field11Value[i - 1])
                    {
                        ModulFields.field11IsError = true;
                    }
                }
            }
        }

        /// <summary>
        /// Поле 12
        /// </summary>
        public static void CheckField12()
        {
            if (!ModulFields.field12Value.Contains("(") || !ModulFields.field12Value.Contains(")"))
            {
                ModulFields.field12IsError = true;
            }
            else
            {
                var field12ValueWithoutBrackets = ModulFields.field12Value.Where(x => x != '(').Where(x => x != ')').ToList();
                if (field12ValueWithoutBrackets.Count == 1)
                {
                    if (field12ValueWithoutBrackets[0].ToString() == Enums.field12_Floor.NT.GetDescription() ||
                        field12ValueWithoutBrackets[0].ToString() == Enums.field12_Floor.N1.GetDescription()) { }
                    else 
                    {
                        ModulFields.field12IsError = true;
                    }
                }
                else
                {
                    ModulFields.field12IsError = true;
                }
            }
            for (int i = 0; i < ModulFields.field12Value.Length; i++)
            {
                if (i == 0) { }
                else
                {
                    if ((char.IsPunctuation(ModulFields.field12Value[i]) || char.IsLetter(ModulFields.field12Value[i]))
                        && ModulFields.field12Value[i] == ModulFields.field12Value[i - 1])
                    {
                        ModulFields.field12IsError = true;
                    }
                }
            }
        }
    }
}
