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
    /// Класс с общими методами проверок полей по ЛЛУ
    /// независимо от дисциплин
    /// </summary>
    public class CheckLLUFieldMethods
    {
        /// <summary>
        /// Поле 1
        /// </summary>
        public static void CheckField1()
        {
            if (ModulFields.field1Value != Enums.field1_Modul.LLU.ToString())
            {
                ModulFields.field1IsError = true;
            }
        }

        /// <summary>
        /// Поле 2
        /// </summary>
        public static void CheckField2()
        {           
            if (ModulFields.field2Value != Enums.field2_ApartmentBuildType.Basic.ToString() &&
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
            if (ModulFields.field3Value != Enums.field3_LLUMorfType.KV.ToString() &&
                ModulFields.field3Value != Enums.field3_LLUMorfType.MR.ToString() &&
                ModulFields.field3Value != Enums.field3_LLUMorfType.PR.ToString() &&
                ModulFields.field3Value != Enums.field3_LLUMorfType.PRS.ToString() &&
                ModulFields.field3Value != Enums.field3_LLUMorfType.SH.ToString() &&
                ModulFields.field3Value != Enums.field3_LLUMorfType.UG.ToString())
            {
                ModulFields.field3IsError = true;
            }
        }

        /// <summary>
        /// Поле 4
        /// </summary>
        public static void CheckField4()
        {            
            if (ModulFields.field4Value.Where(x => !char.IsDigit(x)).ToList().Count > 0) 
            {
                ModulFields.field4IsError = true;
            }
        }

        /// <summary>
        /// Поле 5
        /// </summary>
        public static void CheckField5()
        {
            if (ModulFields.field3Value == Enums.field3_LLUMorfType.KV.ToString() && ModulFields.field5Value != "N")
            {
                ModulFields.field5IsError = true;
            }
            else if (ModulFields.field5Value.Where(x => !char.IsDigit(x)).ToList().Count > 0 || ModulFields.field5Value.Length > 2)
            {
                ModulFields.field5IsError = true;
            }

        }

        /// <summary>
        /// Поле 6
        /// </summary>
        public static void CheckField6()
        {
            if (!ModulFields.field6Value.Contains("X"))
            {
                ModulFields.field6IsError = true;
            }
            else
            {
                List<char> field6ValueFiltered = ModulFields.field6Value
                .Where(x => x != 'X')
                .Where(x => x != '.')
                .Where(x => !char.IsDigit(x)).ToList();

                if (field6ValueFiltered.Count == 0) { }
                else
                {
                    ModulFields.field6IsError = true;
                }
            }

            for (int i = 0; i < ModulFields.field6Value.Length; i++)
            {
                if (i == 0) { }
                else
                {
                    if ((char.IsPunctuation(ModulFields.field6Value[i]) || char.IsLetter(ModulFields.field6Value[i]))
                        && ModulFields.field6Value[i] == ModulFields.field6Value[i - 1])
                    {
                        ModulFields.field6IsError = true;
                    }
                }
            }
        }

        /// <summary>
        /// Поле 7
        /// </summary>
        public static void CheckField7()
        {
            List<string> listEnumField7 = new List<string>();
            var AllValueField7 = Enum.GetValues(typeof(field5_BuildingClass));
            foreach (var v in AllValueField7) listEnumField7.Add(v.ToString());
            if (!listEnumField7.Contains(ModulFields.field7Value))
            {
                ModulFields.field7IsError = true;
            }
        }

        /// <summary>
        /// Поле 8
        /// </summary>
        public static void CheckField8()
        {
            if (!ModulFields.field8Value.Contains("(") || !ModulFields.field8Value.Contains(")"))
            {
                ModulFields.field8IsError = true;
            }
            else
            {
                var field8ValueWithoutBrackets = ModulFields.field8Value.Where(x => x != '(').Where(x => x != ')').ToList();
                if (field8ValueWithoutBrackets.Count == 1)
                {
                    if (field8ValueWithoutBrackets[0].ToString() == Enums.field12_Floor.NT.GetDescription() ||
                        field8ValueWithoutBrackets[0].ToString() == Enums.field12_Floor.N1.GetDescription()) { }
                    else
                    {
                        ModulFields.field8IsError = true;
                    }
                }
                else
                {
                    ModulFields.field8IsError = true;
                }
            }

        }
    }
}
