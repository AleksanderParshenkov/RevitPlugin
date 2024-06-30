#region Usings
using CheckModulName.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Media;
#endregion

namespace CheckModulName.ViewModels
{
    /// <summary>
    /// Класс со вспомогательными методами,
    /// используемых в разных классах и методах
    /// </summary>
    public static class SupportMethods
    {
        /// <summary>
        /// Получение описания enum
        /// </summary>
        public static string GetDescription(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute),
                false);

            if (attributes != null &&
                attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }
        
        /// <summary>
        /// Очистка интерфейса и полей класса ModulFields
        /// Используется как очистка данных перед проверкой иного модуля
        /// </summary>
        public static void ClearWindow()
        {
            //Очистка значений полей "Наименование" в интерфейсе
            CurrentWindow.Wnd.field0Name.Text = "";
            CurrentWindow.Wnd.field1Name.Text = "";
            CurrentWindow.Wnd.field2Name.Text = "";
            CurrentWindow.Wnd.field3Name.Text = "";
            CurrentWindow.Wnd.field4Name.Text = "";
            CurrentWindow.Wnd.field5Name.Text = "";
            CurrentWindow.Wnd.field6Name.Text = "";
            CurrentWindow.Wnd.field7Name.Text = "";
            CurrentWindow.Wnd.field8Name.Text = "";
            CurrentWindow.Wnd.field9Name.Text = "";
            CurrentWindow.Wnd.field10Name.Text = "";
            CurrentWindow.Wnd.field11Name.Text = "";
            CurrentWindow.Wnd.field12Name.Text = "";
            CurrentWindow.Wnd.field13Name.Text = "";

            //Очистка значений полей "Описание" в интерфейсе
            CurrentWindow.Wnd.field0Description.Text = "";
            CurrentWindow.Wnd.field1Description.Text = "";
            CurrentWindow.Wnd.field2Description.Text = "";
            CurrentWindow.Wnd.field3Description.Text = "";
            CurrentWindow.Wnd.field4Description.Text = "";
            CurrentWindow.Wnd.field5Description.Text = "";
            CurrentWindow.Wnd.field6Description.Text = "";
            CurrentWindow.Wnd.field7Description.Text = "";
            CurrentWindow.Wnd.field8Description.Text = "";
            CurrentWindow.Wnd.field9Description.Text = "";
            CurrentWindow.Wnd.field10Description.Text = "";
            CurrentWindow.Wnd.field11Description.Text = "";
            CurrentWindow.Wnd.field12Description.Text = "";
            CurrentWindow.Wnd.field13Description.Text = "";

            //Очистка значений полей "Значение" в интерфейсе
            CurrentWindow.Wnd.field0Value.Text = "";
            CurrentWindow.Wnd.field1Value.Text = "";
            CurrentWindow.Wnd.field2Value.Text = "";
            CurrentWindow.Wnd.field3Value.Text = "";
            CurrentWindow.Wnd.field4Value.Text = "";
            CurrentWindow.Wnd.field5Value.Text = "";
            CurrentWindow.Wnd.field6Value.Text = "";
            CurrentWindow.Wnd.field7Value.Text = "";
            CurrentWindow.Wnd.field8Value.Text = "";
            CurrentWindow.Wnd.field9Value.Text = "";
            CurrentWindow.Wnd.field10Value.Text = "";
            CurrentWindow.Wnd.field11Value.Text = "";
            CurrentWindow.Wnd.field12Value.Text = "";
            CurrentWindow.Wnd.field13Value.Text = "";

            //Очистка значений свойств в статическом классе модуля
            ModulFields.ModulDiscipline = "";
            ModulFields.ModulType = "";
            ModulFields.ModulPath = "";
            ModulFields.ModulName = "";
            ModulFields.ModulNameIsError = false;
            ModulFields.field0Value = "";
            ModulFields.field0IsError = false;
            ModulFields.field1Value = "";
            ModulFields.field1IsError = false;
            ModulFields.field2Value = "";
            ModulFields.field2IsError = false;
            ModulFields.field3Value = "";
            ModulFields.field3IsError = false;
            ModulFields.field4Value = "";
            ModulFields.field4IsError = false;
            ModulFields.field5Value = "";
            ModulFields.field5IsError = false;
            ModulFields.field6Value = "";
            ModulFields.field6IsError = false;
            ModulFields.field7Value = "";
            ModulFields.field7IsError = false;
            ModulFields.field8Value = "";
            ModulFields.field8IsError = false;
            ModulFields.field9Value = "";
            ModulFields.field9IsError = false;
            ModulFields.field10Value = "";
            ModulFields.field10IsError = false;
            ModulFields.field11Value = "";
            ModulFields.field11IsError = false;
            ModulFields.field12Value = "";
            ModulFields.field12IsError = false;
            ModulFields.field13Value = "";
            ModulFields.field13IsError = false;

            //Очистка заливок цветом в интерфейсе
            CurrentWindow.Wnd.ModulName.Background = Brushes.White;
            CurrentWindow.Wnd.field0Value.Background = Brushes.White;
            CurrentWindow.Wnd.field1Value.Background = Brushes.White;
            CurrentWindow.Wnd.field2Value.Background = Brushes.White;
            CurrentWindow.Wnd.field3Value.Background = Brushes.White;
            CurrentWindow.Wnd.field4Value.Background = Brushes.White;
            CurrentWindow.Wnd.field5Value.Background = Brushes.White;
            CurrentWindow.Wnd.field6Value.Background = Brushes.White;
            CurrentWindow.Wnd.field7Value.Background = Brushes.White;
            CurrentWindow.Wnd.field8Value.Background = Brushes.White;
            CurrentWindow.Wnd.field9Value.Background = Brushes.White;
            CurrentWindow.Wnd.field10Value.Background = Brushes.White;
            CurrentWindow.Wnd.field11Value.Background = Brushes.White;
            CurrentWindow.Wnd.field12Value.Background = Brushes.White;
            CurrentWindow.Wnd.field13Value.Background = Brushes.White;
        }

        /// <summary>
        /// Общее заполнение полей "Наименование", 
        /// если модуль определен как "квартира"
        /// </summary>
        public static void WritedFieldNamesForKV()
        {
            CurrentWindow.Wnd.field0Name.Text = "Дисциплина";
            CurrentWindow.Wnd.field1Name.Text = "Модуль";
            CurrentWindow.Wnd.field2Name.Text = "Тип сборки квартиры";
            CurrentWindow.Wnd.field3Name.Text = "Конструкция С/У";
            CurrentWindow.Wnd.field4Name.Text = "Ширина по фасадам";
            CurrentWindow.Wnd.field5Name.Text = "Класс здания";
            CurrentWindow.Wnd.field6Name.Text = "Тип квартиры";
            CurrentWindow.Wnd.field7Name.Text = "Матрица";
            CurrentWindow.Wnd.field8Name.Text = "Длина фасада x Глубина";
            CurrentWindow.Wnd.field9Name.Text = "Отзеркаленность";
            CurrentWindow.Wnd.field10Name.Text = "Номер версии";
            CurrentWindow.Wnd.field11Name.Text = "Летние помещения";
            CurrentWindow.Wnd.field12Name.Text = "Применение к этажу";
            CurrentWindow.Wnd.field13Name.Text = "";

        }

        /// <summary>
        /// Общее заполнение полей "Описание", 
        /// если модуль определен как "квартира"
        /// </summary>
        public static void WritedFieldDescriptionForKV()
        {

            CurrentWindow.Wnd.field0Description.Text = "";
            CurrentWindow.Wnd.field1Description.Text = "KV - для квартир";
            CurrentWindow.Wnd.field2Description.Text = "Basic - эскиз, DD - АР РД, WB - WhiteBox";
            CurrentWindow.Wnd.field3Description.Text = "STK - СТК, BE - cтр. исполнение, N - без С/У";
            CurrentWindow.Wnd.field4Description.Text = "Число (для рядовых) или Число X Число (для торцевых). Округление до 0.000";
            CurrentWindow.Wnd.field5Description.Text = "ST - стандарт, STP - стандарт+, К - комфорт";
            CurrentWindow.Wnd.field6Description.Text = "N комнат: 0 (Студия), 1, 2, 3, 4 ,5; Функ. тип: E - совм. кухни, K - отд. кухни, N - кухни-ниши; Размер по пресету: S - маленькая, M - средняя, L - большая";
            CurrentWindow.Wnd.field7Description.Text = "R - рядовая, T - торцевая, TY - уник. торцевая, RY - уник. рядовая, TP - пристройка; 0n.n  - номер варианта планировки";
            CurrentWindow.Wnd.field8Description.Text = "Число x Число. Округление до 0.000";
            CurrentWindow.Wnd.field9Description.Text = "A - обычная, Z - зеркальная";
            CurrentWindow.Wnd.field10Description.Text = "Vn, где n - число";
            CurrentWindow.Wnd.field11Description.Text = "(N) - без летних помещений";
            CurrentWindow.Wnd.field12Description.Text = "(N) - типовой этаж, (1) - 1 этаж";
            CurrentWindow.Wnd.field13Description.Text = "";
        }

        /// <summary>
        /// Общее заполнение полей "Наименование", 
        /// если модуль определен как "ЛЛУ"
        /// </summary>
        public static void WritedFieldNamesForLLU()
        {
            CurrentWindow.Wnd.field0Name.Text = "Дисциплина";
            CurrentWindow.Wnd.field1Name.Text = "Модуль";
            CurrentWindow.Wnd.field2Name.Text = "Тип сборки ЛЛУ";
            CurrentWindow.Wnd.field3Name.Text = "Тип морфотипа секции";
            CurrentWindow.Wnd.field4Name.Text = "Этажность морфотипа";
            CurrentWindow.Wnd.field5Name.Text = "Шаговость";
            CurrentWindow.Wnd.field6Name.Text = "Габариты ЛЛУ";
            CurrentWindow.Wnd.field7Name.Text = "Класс здания";
            CurrentWindow.Wnd.field8Name.Text = "Применение к этажу";
            CurrentWindow.Wnd.field9Name.Text = "";
            CurrentWindow.Wnd.field10Name.Text = "";
            CurrentWindow.Wnd.field11Name.Text = "";
            CurrentWindow.Wnd.field12Name.Text = "";
            CurrentWindow.Wnd.field13Name.Text = "";
        }

        /// <summary>
        /// Общее заполнение полей "Описание", 
        /// если модуль определен как "ЛЛУ"
        /// </summary>
        public static void WritedFieldDescriptionForLLU()
        {
            CurrentWindow.Wnd.field0Description.Text = "";
            CurrentWindow.Wnd.field1Description.Text = "LLU - для лестнично-лифтового узла";
            CurrentWindow.Wnd.field2Description.Text = "Basic - эскиз, DD - АР РД";
            CurrentWindow.Wnd.field3Description.Text = "SH - широтная; MR - меридиональная; UG - угловая; PR - прямоугольная; PRS - прямоугольная со сдвижкой; KV - квадратная";
            CurrentWindow.Wnd.field4Description.Text = "Цифра - целое положительное число";
            CurrentWindow.Wnd.field5Description.Text = "Цифра - целое положительное число (1-2 знака), количество шагов в секции; Для квадратной башни - N";
            CurrentWindow.Wnd.field6Description.Text = "Число X Число. Округление до 0.000";
            CurrentWindow.Wnd.field7Description.Text = "ST - стандарт, STP - стандарт+, К - комфорт";
            CurrentWindow.Wnd.field8Description.Text = "(N) - типовой этаж, (1) - 1 этаж";
            CurrentWindow.Wnd.field9Description.Text = "";
            CurrentWindow.Wnd.field10Description.Text = "";
            CurrentWindow.Wnd.field11Description.Text = "";
            CurrentWindow.Wnd.field12Description.Text = "";
            CurrentWindow.Wnd.field13Description.Text = "";
        }

        /// <summary>
        /// Общее заполнение полей "Значение" для модулей квартир по ИОС
        /// на основе заполненных свойств класса модуля
        /// </summary>
        public static void WriteValueFielsdMainWindowIOSKV(List<string> fieldlist)
        {
            try
            {
                ModulFields.field0Value = fieldlist[0];
                ModulFields.field1Value = fieldlist[1];
                ModulFields.field2Value = fieldlist[2];
                ModulFields.field3Value = fieldlist[3];
                ModulFields.field4Value = fieldlist[4];
                ModulFields.field5Value = fieldlist[5];
                ModulFields.field6Value = fieldlist[6];
                ModulFields.field7Value = fieldlist[7];
                ModulFields.field8Value = fieldlist[8];
                ModulFields.field9Value = fieldlist[9];
                ModulFields.field10Value = fieldlist[10];
                ModulFields.field11Value = fieldlist[11];
                ModulFields.field12Value = fieldlist[12];
                ModulFields.field13Value = fieldlist[13];
            }
            catch { }            
        }

        /// <summary>
        /// Общее заполнение полей "Значение" для модулей ЛЛУ по ИОС
        /// на основе заполненных свойств класса модуля
        /// </summary>
        public static void WriteValueFielsdMainWindowIOSLLU(List<string> fieldlist)
        {
            try
            {
                ModulFields.field0Value = fieldlist[0];
                ModulFields.field1Value = fieldlist[1];
                ModulFields.field2Value = fieldlist[2];
                ModulFields.field3Value = fieldlist[3];
                ModulFields.field4Value = fieldlist[4];
                ModulFields.field5Value = fieldlist[5];
                ModulFields.field6Value = fieldlist[6];
                ModulFields.field7Value = fieldlist[7];
                ModulFields.field8Value = fieldlist[8];
                ModulFields.field9Value = fieldlist[9];
                ModulFields.field10Value = fieldlist[10];
                ModulFields.field11Value = fieldlist[11];
                ModulFields.field12Value = fieldlist[12];
                ModulFields.field13Value = fieldlist[13];
            }
            catch { }
        }

        /// <summary>
        /// Общее заполнение полей "Значение" для модулей квартир по АР и АИ
        /// на основе заполненных свойств класса модуля
        /// </summary>
        public static void WriteValueFielsdMainWindowARAIKV(List<string> fieldlist)
        {
            try
            {
                ModulFields.field0Value = "";
                ModulFields.field1Value = fieldlist[0];
                ModulFields.field2Value = fieldlist[1];
                ModulFields.field3Value = fieldlist[2];
                ModulFields.field4Value = fieldlist[3];
                ModulFields.field5Value = fieldlist[4];
                ModulFields.field6Value = fieldlist[5];
                ModulFields.field7Value = fieldlist[6];
                ModulFields.field8Value = fieldlist[7];
                ModulFields.field9Value = fieldlist[8];
                ModulFields.field10Value = fieldlist[9];
                ModulFields.field11Value = fieldlist[10];
                ModulFields.field12Value = fieldlist[11];
                ModulFields.field13Value = fieldlist[12];
            }
            catch { }
        }

        /// <summary>
        /// Общее заполнение полей "Значение" для модулей ЛЛУ по АР и АИ
        /// на основе заполненных свойств класса модуля
        /// </summary>
        public static void WriteValueFielsdMainWindowARAILLU(List<string> fieldlist)
        {
            try
            {
                ModulFields.field0Value = "";
                ModulFields.field1Value = fieldlist[0];
                ModulFields.field2Value = fieldlist[1];
                ModulFields.field3Value = fieldlist[2];
                ModulFields.field4Value = fieldlist[3];
                ModulFields.field5Value = fieldlist[4];
                ModulFields.field6Value = fieldlist[5];
                ModulFields.field7Value = fieldlist[6];
                ModulFields.field8Value = fieldlist[7];
                ModulFields.field9Value = fieldlist[8];
                ModulFields.field10Value = fieldlist[9];
                ModulFields.field11Value = fieldlist[10];
                ModulFields.field12Value = fieldlist[11];
                ModulFields.field13Value = fieldlist[12];
            }
            catch { }
        }

        /// <summary>
        /// Определение заливки значений в полях "Значение"
        /// Заливка, если в поле или имени найдена ошибка
        /// </summary>
        public static void BrushesFieldValue()
        {
            var bc = new BrushConverter();
            var colorError = (Brush)bc.ConvertFrom("#FFBEAC");
            var colorNotError = (Brush)bc.ConvertFrom("#98FB98");

            if (ModulFields.field0IsError) CurrentWindow.Wnd.field0Value.Background = colorError;
            if (ModulFields.field1IsError) CurrentWindow.Wnd.field1Value.Background = colorError;
            if (ModulFields.field2IsError) CurrentWindow.Wnd.field2Value.Background = colorError;
            if (ModulFields.field3IsError) CurrentWindow.Wnd.field3Value.Background = colorError;
            if (ModulFields.field4IsError) CurrentWindow.Wnd.field4Value.Background = colorError;
            if (ModulFields.field5IsError) CurrentWindow.Wnd.field5Value.Background = colorError;
            if (ModulFields.field6IsError) CurrentWindow.Wnd.field6Value.Background = colorError;
            if (ModulFields.field7IsError) CurrentWindow.Wnd.field7Value.Background = colorError;
            if (ModulFields.field8IsError) CurrentWindow.Wnd.field8Value.Background = colorError;
            if (ModulFields.field9IsError) CurrentWindow.Wnd.field9Value.Background = colorError;
            if (ModulFields.field10IsError) CurrentWindow.Wnd.field10Value.Background = colorError;
            if (ModulFields.field11IsError) CurrentWindow.Wnd.field11Value.Background = colorError;
            if (ModulFields.field12IsError) CurrentWindow.Wnd.field12Value.Background = colorError;
            if (ModulFields.field13IsError) CurrentWindow.Wnd.field13Value.Background = colorError;

            if (ModulFields.field0IsError || ModulFields.field1IsError || ModulFields.field2IsError || ModulFields.field3IsError
                || ModulFields.field4IsError || ModulFields.field5IsError || ModulFields.field6IsError || ModulFields.field7IsError
                || ModulFields.field8IsError || ModulFields.field8IsError || ModulFields.field9IsError || ModulFields.field10IsError
                || ModulFields.field11IsError || ModulFields.field12IsError || ModulFields.field13IsError || ModulFields.ModulNameIsError)
            {
                CurrentWindow.Wnd.ModulName.Background = colorError;
            }
            else CurrentWindow.Wnd.ModulName.Background = colorNotError;
        }

        /// <summary>
        /// Запись значений в полях "значение" 
        /// на основе данных свойств класса модуля
        /// </summary>
        public static void WritedFieldValueInWindow()
        {
            CurrentWindow.Wnd.field0Value.Text = ModulFields.field0Value;
            CurrentWindow.Wnd.field1Value.Text = ModulFields.field1Value;
            CurrentWindow.Wnd.field2Value.Text = ModulFields.field2Value;
            CurrentWindow.Wnd.field3Value.Text = ModulFields.field3Value;
            CurrentWindow.Wnd.field4Value.Text = ModulFields.field4Value;
            CurrentWindow.Wnd.field5Value.Text = ModulFields.field5Value;
            CurrentWindow.Wnd.field6Value.Text = ModulFields.field6Value;
            CurrentWindow.Wnd.field7Value.Text = ModulFields.field7Value;
            CurrentWindow.Wnd.field8Value.Text = ModulFields.field8Value;
            CurrentWindow.Wnd.field9Value.Text = ModulFields.field9Value;
            CurrentWindow.Wnd.field10Value.Text = ModulFields.field10Value;
            CurrentWindow.Wnd.field11Value.Text = ModulFields.field11Value;
            CurrentWindow.Wnd.field12Value.Text = ModulFields.field12Value;
            CurrentWindow.Wnd.field13Value.Text = ModulFields.field13Value;
        }

        /// <summary>
        /// Заполнение полей "Наименование" и "Описание" 
        /// по дисциплинам и типам модулей
        /// (заполняются уникальные для дисциплины значения)
        /// </summary>
        public static void WriteFieldNameAndDescriptionForDisciplineAndType()
        {
            if (ModulFields.ModulType == Enums.Modul_Type.KV.GetDescription())
            {
                // Запись общих для всех дисциплин данных в полях "Наименование" и "Описание"
                WritedFieldNamesForKV();
                WritedFieldDescriptionForKV();

                // Заполнение полей наименования и описания для АР
                if (ModulFields.ModulDiscipline == Enums.Modul_Discipline.AR.GetDescription()) { }

                // Заполнение полей наименования и описания для АИ
                else if (ModulFields.ModulDiscipline == Enums.Modul_Discipline.AI.GetDescription())
                {
                    CurrentWindow.Wnd.field2Description.Text = "AD -для архитектурных интерьеров (АИ)";
                }

                // Заполнение полей наименования и описания для ЭОМ
                else if (ModulFields.ModulDiscipline == Enums.Modul_Discipline.EOM.GetDescription())
                {
                    CurrentWindow.Wnd.field0Description.Text = "EOM - для электрооборудования и освещения (ЭОМ)";

                    CurrentWindow.Wnd.field13Name.Text = "Прямая / обратная";
                    CurrentWindow.Wnd.field13Description.Text = "S - прямая, Rn - обратная с номером варианта";
                }

                // Заполнение полей наименования и описания для ВК
                else if (ModulFields.ModulDiscipline == Enums.Modul_Discipline.VK.GetDescription())
                {
                    CurrentWindow.Wnd.field0Description.Text = "VK - для водоснабжения и канализации (ВК)";

                    CurrentWindow.Wnd.field11Description.Text = "none - для ВК";

                    CurrentWindow.Wnd.field13Name.Text = "Стояки канализации";
                    CurrentWindow.Wnd.field13Description.Text = "IN(внутри)n или OUT(снаружи)n, где n - 1, 2 или 3";
                }

                // Заполнение полей наименования и описания для ОВ1
                else if (ModulFields.ModulDiscipline == Enums.Modul_Discipline.OV1.GetDescription())
                {
                    CurrentWindow.Wnd.field0Description.Text = "OV1 - для отопления (ОВ1)";

                    CurrentWindow.Wnd.field13Name.Text = "Зональность отопления";
                    CurrentWindow.Wnd.field13Description.Text = "1z - стояковая, одной зона; 2z - стояковая, две зоны; 2zp - переходной этаж; N - лучевая разводка";
                }

                // Заполнение полей наименования и описания для ОВ2В
                else if (ModulFields.ModulDiscipline == Enums.Modul_Discipline.OV2V.GetDescription())
                {
                    CurrentWindow.Wnd.field0Description.Text = "OV2.V - для вентиляции (ОВ2.В)";

                    CurrentWindow.Wnd.field13Name.Text = "Зональность отопления";
                    CurrentWindow.Wnd.field13Description.Text = "none - для модулей вертиляции";
                }

                // Заполнение полей наименования и описания для ОВ2К
                else if (ModulFields.ModulDiscipline == Enums.Modul_Discipline.OV2K.GetDescription())
                {
                    CurrentWindow.Wnd.field0Description.Text = "OV2.K - для кондиционирования (ОВ2.К)";

                    CurrentWindow.Wnd.field13Name.Text = "Зональность отопления";
                    CurrentWindow.Wnd.field13Description.Text = "none - для модулей кондиционирования";
                }
            }
            else if (ModulFields.ModulType == Enums.Modul_Type.LLU.GetDescription())
            {
                // Запись общих для всех дисциплин данных в полях "Наименование" и "Описание"
                WritedFieldNamesForLLU();
                WritedFieldDescriptionForLLU();

                // Заполнение полей наименования и описания для АР
                if (ModulFields.ModulDiscipline == Enums.Modul_Discipline.AR.GetDescription()) { }

                // Заполнение полей наименования и описания для АИ
                else if (ModulFields.ModulDiscipline == Enums.Modul_Discipline.AI.GetDescription())
                {
                    CurrentWindow.Wnd.field2Description.Text = "AD -для архитектурных интерьеров (АИ)";
                }

                // Заполнение полей наименования и описания для ЭОМ
                else if (ModulFields.ModulDiscipline == Enums.Modul_Discipline.EOM.GetDescription())
                {
                    CurrentWindow.Wnd.field0Description.Text = "EOM - для электрооборудования и освещения (ЭОМ)";
                }                

                // Заполнение полей наименования и описания для ОВ1
                else if (ModulFields.ModulDiscipline == Enums.Modul_Discipline.OV1.GetDescription())
                {
                    CurrentWindow.Wnd.field0Description.Text = "OV1 - для отопления (ОВ1)";

                    CurrentWindow.Wnd.field9Name.Text = "Зональность";
                    CurrentWindow.Wnd.field9Description.Text = "1z - стояковая, одной зона; 2z - стояковая, две зоны; zp - переходной этаж";

                    CurrentWindow.Wnd.field10Name.Text = "Тип системы отопления";
                    CurrentWindow.Wnd.field10Description.Text = "H - горизонтальная с радиатором в ЛК, H0 - горизонтальная без радиатора в ЛК, V -вертикальная с радиатором в ЛК, V0 - вертикальная без радиатора в ЛК";

                    CurrentWindow.Wnd.field11Name.Text = "Количество контуров";
                    CurrentWindow.Wnd.field11Description.Text = "количество выводов коллекторов (до четырех целых чисел до 12 через дефис). Пример: 5-12-5-12";
                }

                // Заполнение полей наименования и описания для ОВ2В
                else if (ModulFields.ModulDiscipline == Enums.Modul_Discipline.OV2V.GetDescription())
                {
                    CurrentWindow.Wnd.field0Description.Text = "OV2.V - для вентиляции (ОВ2.В)";

                    CurrentWindow.Wnd.field9Name.Text = "Зональность";
                    CurrentWindow.Wnd.field9Description.Text = "1z - стояковая, одной зона; 2z - стояковая, две зоны; zp - переходной этаж";

                    CurrentWindow.Wnd.field10Name.Text = "Тип системы отопления";
                    CurrentWindow.Wnd.field10Description.Text = "none - для модулей вентиляции";

                    CurrentWindow.Wnd.field11Name.Text = "Количество контуров";
                    CurrentWindow.Wnd.field11Description.Text = "0 - для модулей вентиляции";
                }
            }
        }
    }
}

