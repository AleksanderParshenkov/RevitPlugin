#region Usings
using CheckModulName.Models;
using System.Collections.Generic;
using System.Linq;
#endregion

namespace CheckModulName.ViewModels
{
    public class CheckModulController
    {
        /// <summary>
        /// Класс процесса проверки модуля
        /// </summary>
        public CheckModulController()
        {
            //Разбиение имени на поля
            List<string> listValueField = ModulFields.ModulName.Split('_').ToList();

            //Проверка случая, когда найдено только одно поле (исключает ошибку "Индекс вне диапазона")
            if (listValueField.Count == 1 ) 
            {
                ModulFields.ModulDiscipline = Enums.Modul_Discipline.none.GetDescription();
                ModulFields.ModulType = Enums.Modul_Type.none.GetDescription();
                ModulFields.ModulNameIsError = true;
            }

            //Проверка случая, когда модуль модуль ассоциируется и с KV, и с LLU
            else if ((listValueField[0].Contains(Enums.field1_Modul.KV.ToString()) || listValueField[1].Contains(Enums.field1_Modul.KV.ToString())) &&
                ModulFields.ModulName.Contains(Enums.field1_Modul.LLU.ToString()))
            {
                ModulFields.ModulDiscipline = Enums.Modul_Discipline.none.GetDescription();
                ModulFields.ModulType = Enums.Modul_Type.none.GetDescription();
                ModulFields.ModulNameIsError = true;
            }

            //Проверка случая, когда модуль ассоциировался с KV
            else if (listValueField[0].Contains(Enums.field1_Modul.KV.ToString()) || listValueField[1].Contains(Enums.field1_Modul.KV.ToString()))
            {        
                ModulFields.ModulType = Enums.Modul_Type.KV.GetDescription();                

                if (ModulFields.ModulName.Contains(Enums.field0_Discipline.EOM.GetDescription()))
                {                    
                    ModulFields.ModulDiscipline = Enums.Modul_Discipline.EOM.GetDescription();
                    if (listValueField.Count() != int.Parse(Enums.Modul_FieldCountDiscipline.EOM_KV.GetDescription())) ModulFields.ModulNameIsError = true;
                    
                    SupportMethods.WriteValueFielsdMainWindowIOSKV(listValueField);                      
                    CheckModulKV.CheckModulEOM();
                }
                else if (ModulFields.ModulName.Contains(Enums.field0_Discipline.VK.GetDescription()))
                {
                    ModulFields.ModulDiscipline = Enums.Modul_Discipline.VK.GetDescription();
                    if (listValueField.Count() != int.Parse(Enums.Modul_FieldCountDiscipline.VK_KV.GetDescription())) ModulFields.ModulNameIsError = true;

                    SupportMethods.WriteValueFielsdMainWindowIOSKV(listValueField);
                    CheckModulKV.CheckModulVK(listValueField);
                }
                else if (ModulFields.ModulName.Contains(Enums.field0_Discipline.OV1.GetDescription()))
                {
                    ModulFields.ModulDiscipline = Enums.Modul_Discipline.OV1.GetDescription();
                    if (listValueField.Count() != int.Parse(Enums.Modul_FieldCountDiscipline.OV1_KV.GetDescription())) ModulFields.ModulNameIsError = true;

                    SupportMethods.WriteValueFielsdMainWindowIOSKV(listValueField);
                    CheckModulKV.CheckModulOV1(listValueField);
                }
                else if (ModulFields.ModulName.Contains(Enums.field0_Discipline.OV2V.GetDescription()))
                {
                    ModulFields.ModulDiscipline = Enums.Modul_Discipline.OV2V.GetDescription();
                    if (listValueField.Count() != int.Parse(Enums.Modul_FieldCountDiscipline.OV2V_KV.GetDescription())) ModulFields.ModulNameIsError = true;

                    SupportMethods.WriteValueFielsdMainWindowIOSKV(listValueField);                    
                    CheckModulKV.CheckModulOV2V(listValueField);
                }
                else if (ModulFields.ModulName.Contains(Enums.field0_Discipline.OV2K.GetDescription()))
                {
                    ModulFields.ModulDiscipline = Enums.Modul_Discipline.OV2K.GetDescription();
                    if (listValueField.Count() != int.Parse(Enums.Modul_FieldCountDiscipline.OV2K_KV.GetDescription())) ModulFields.ModulNameIsError = true;

                    SupportMethods.WriteValueFielsdMainWindowIOSKV(listValueField);
                    CheckModulKV.CheckModulOV2K(listValueField);
                }
                else if (ModulFields.ModulName.Contains("AD"))
                {
                    ModulFields.ModulDiscipline = Enums.Modul_Discipline.AI.GetDescription();
                    if (listValueField.Count() != int.Parse(Enums.Modul_FieldCountDiscipline.AI_KV.GetDescription())) ModulFields.ModulNameIsError = true;

                    SupportMethods.WriteValueFielsdMainWindowARAIKV(listValueField);
                    CheckModulKV.CheckModulAI(listValueField);
                }
                else if (listValueField[0] == Enums.field1_Modul.KV.ToString())
                {
                    ModulFields.ModulDiscipline = Enums.Modul_Discipline.AR.GetDescription();
                    if (listValueField.Count() != int.Parse(Enums.Modul_FieldCountDiscipline.AR_KV.GetDescription())) ModulFields.ModulNameIsError = true;

                    SupportMethods.WriteValueFielsdMainWindowARAIKV(listValueField);
                    CheckModulKV.CheckModulAR(listValueField);
                }
                else
                {
                    ModulFields.ModulDiscipline = Enums.Modul_Discipline.none.GetDescription();
                    ModulFields.ModulNameIsError = true;
                }
            }

            //Проверка случая, когда модуль ассоциировался с LLU
            else if (listValueField[0].Contains(Enums.field1_Modul.LLU.ToString()) || listValueField[1].Contains(Enums.field1_Modul.LLU.ToString()))
            {                
                ModulFields.ModulType = Enums.Modul_Type.LLU.GetDescription();

                if (ModulFields.ModulName.Contains(Enums.field0_Discipline.EOM.GetDescription()))
                {
                    ModulFields.ModulDiscipline = Enums.Modul_Discipline.EOM.GetDescription();
                    if (listValueField.Count() != int.Parse(Enums.Modul_FieldCountDiscipline.EOM_LLU.GetDescription())) ModulFields.ModulNameIsError = true;

                    SupportMethods.WriteValueFielsdMainWindowIOSLLU(listValueField);
                    CheckModulLLU.CheckModulEOM(listValueField);
                }                
                else if (ModulFields.ModulName.Contains(Enums.field0_Discipline.OV1.GetDescription()))
                {
                    ModulFields.ModulDiscipline = Enums.Modul_Discipline.OV1.GetDescription();
                    if (listValueField.Count() != int.Parse(Enums.Modul_FieldCountDiscipline.OV1_LLU.GetDescription())) ModulFields.ModulNameIsError = true;

                    SupportMethods.WriteValueFielsdMainWindowIOSLLU(listValueField);
                    CheckModulLLU.CheckModulOV1(listValueField);
                }
                else if (ModulFields.ModulName.Contains(Enums.field0_Discipline.OV2V.GetDescription()))
                {
                    ModulFields.ModulDiscipline = Enums.Modul_Discipline.OV2V.GetDescription();
                    if (listValueField.Count() != int.Parse(Enums.Modul_FieldCountDiscipline.OV2V_LLU.GetDescription())) ModulFields.ModulNameIsError = true;

                    SupportMethods.WriteValueFielsdMainWindowIOSLLU(listValueField);
                    CheckModulLLU.CheckModulOV2V(listValueField);
                }
                else if (ModulFields.ModulName.Contains("AD"))
                {
                    ModulFields.ModulDiscipline = Enums.Modul_Discipline.AI.GetDescription();
                    if (listValueField.Count() != int.Parse(Enums.Modul_FieldCountDiscipline.AI_LLU.GetDescription())) ModulFields.ModulNameIsError = true;

                    SupportMethods.WriteValueFielsdMainWindowARAILLU(listValueField);
                    CheckModulLLU.CheckModulAI(listValueField);
                }
                else if (listValueField[0] == Enums.field1_Modul.LLU.ToString())
                {
                    ModulFields.ModulDiscipline = Enums.Modul_Discipline.AR.GetDescription();
                    if (listValueField.Count() != int.Parse(Enums.Modul_FieldCountDiscipline.AR_LLU.GetDescription())) ModulFields.ModulNameIsError = true;

                    SupportMethods.WriteValueFielsdMainWindowARAILLU(listValueField);
                    CheckModulLLU.CheckModulAR(listValueField);
                }
                else
                {
                    ModulFields.ModulDiscipline = Enums.Modul_Discipline.none.GetDescription();
                    ModulFields.ModulNameIsError = true;
                }
            }

            //Для случая, когда ассоциация не найдена
            else
            {
                ModulFields.ModulDiscipline = Enums.Modul_Discipline.none.GetDescription();
                ModulFields.ModulType = Enums.Modul_Type.none.GetDescription();
                ModulFields.ModulNameIsError = true;                
            }
        }
    }
}
