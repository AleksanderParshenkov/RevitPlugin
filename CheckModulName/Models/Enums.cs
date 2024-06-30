#region Usings
using System.ComponentModel;
#endregion

namespace CheckModulName.Models
{
    /// <summary>
    /// Класс с используемыми Enum
    /// </summary>
    public class Enums
    {
        /// <summary>
        /// Корректное кол-во полей для каждого типа модуля
        /// по дисциплине
        /// </summary>
        public enum Modul_FieldCountDiscipline
        {
            [Description("12")]
            AR_KV,
            [Description("8")]
            AR_LLU,

            [Description("12")]
            AI_KV,
            [Description("8")]
            AI_LLU,

            [Description("14")]
            EOM_KV,
            [Description("9")]
            EOM_LLU,

            [Description("14")]
            VK_KV,

            [Description("14")]
            OV1_KV,
            [Description("12")]
            OV1_LLU,

            [Description("14")]
            OV2V_KV,
            [Description("12")]
            OV2V_LLU,

            [Description("14")]
            OV2K_KV,
            [Description("12")]
            OV2K_LLU
        }

        /// <summary>
        /// Варианты возможных дисциплин
        /// </summary>
        public enum Modul_Discipline
        {
            [Description("AR")]
            AR,
            [Description("AI")]
            AI,
            [Description("EOM")]
            EOM,
            [Description("VK")]
            VK,
            [Description("OV1")]
            OV1,
            [Description("OV2.V")]
            OV2V,
            [Description("OV2.K")]
            OV2K,
            [Description("none")]
            none,
        }

        /// <summary>
        /// Варианты возможных типов модулей
        /// </summary>
        public enum Modul_Type
        {
            [Description("Квартира")]
            KV,
            [Description("ЛЛУ")]
            LLU,
            [Description("none")]
            none,
        }

        /// <summary>
        /// Варианты заполнения поля 0
        /// </summary>
        public enum field0_Discipline
        {
            [Description("EOM")]
            EOM,
            [Description("VK")]
            VK,
            [Description("OV1")]
            OV1,
            [Description("OV2.V")]
            OV2V,
            [Description("OV2.K")]
            OV2K,
        }

        /// <summary>
        /// Варианты заполнения поля 1
        /// </summary>
        public enum field1_Modul
        {
            [Description("Квартира")]
            KV,
            [Description("ЛЛУ")]
            LLU       
        }

        /// <summary>
        /// Варианты заполнения поля 2
        /// </summary>
        public enum field2_ApartmentBuildType
        {
            [Description("Эскизная группа")]
            Basic,
            [Description("Группа АР")]
            DD,
            [Description("Группа WhiteBox")]
            WB
        }

        /// <summary>
        /// Варианты заполнения поля 3
        /// для КВ
        /// </summary>
        public enum field3_WCStructure
        {
            [Description("СТК")]
            STK,
            [Description("Строительное исполнение")]
            BE,
            [Description("Без С/У")]
            N
        }

        /// <summary>
        /// Варианты заполнения поля 3
        /// для ЛЛУ
        /// </summary>
        public enum field3_LLUMorfType
        {
            [Description("Широтная")]
            SH,
            [Description("Меридиональная")]
            MR,
            [Description("Угловая")]
            UG,
            [Description("Прямоугольная")]
            PR,
            [Description("Прямоугольная со сдвижкой")]
            PRS,
            [Description("Квадратная")]
            KV
        }

        /// <summary>
        /// Варианты заполнения поля 4
        /// </summary>
        public enum field5_BuildingClass
        {
            [Description("Стандарт")]
            ST,
            [Description("Стандарт плюс")]
            STP,
            [Description("Комфорт")]
            К
        }

        /// <summary>
        /// Варианты заполнения поля 6
        /// </summary>
        public enum field6_KitchenFuncionalType
        {
            [Description("Cовмещенные кухни")]
            E,
            [Description("Отдельные кухни")]
            K,
            [Description("Кухни-ниши")]
            N
        }

        /// <summary>
        /// Варианты заполнения поля 6
        /// </summary>
        public enum field6_KitchenPreset
        {
            [Description("Маленькая")]
            S,
            [Description("Средняя")]
            M,
            [Description("Большая")]
            L
        }

        /// <summary>
        /// Варианты заполнения поля 7
        /// </summary>
        public enum field7_ApartmentMatrix
        {
            [Description("Рядовая")]
            R,
            [Description("Торцевая")]
            T,
            [Description("Уникальная торцевая")]
            TY,
            [Description("Уникальная рядовая")]
            RY,
            [Description("Пристройка")]
            TP
        }

        /// <summary>
        /// Варианты заполнения поля 9
        /// </summary>
        public enum field9_MirrowType
        {
            [Description("Обычная")]
            A,
            [Description("Отзеркаленная")]
            Z
        }

        /// <summary>
        /// Варианты заполнения поля 10
        /// для ЛЛУ
        /// </summary>
        public enum field10_LLUHeatSystemType
        {
            [Description("Горизонтальная. Есть радиатор на этаже в лестничной клетке")]
            H,
            [Description("Вертикальная (стояки в квартире). Есть радиатор на этаже в лестничной клетке")]
            V,
            [Description("Горизонтальная. Нет радиатора на этаже в лестничной клетке")]
            H0,
            [Description("Вертикальная (стояки в квартире). Нет радиатора на этаже в лестничной клетке")]
            V0
        }

        /// <summary>
        /// Варианты заполнения поля 11
        /// </summary>
        public enum field11_SummerRoom
        {
            [Description("Летние помещения отсутствуют")]
            N,
            [Description("Не важно для ИОС")]
            none
        }

        /// <summary>
        /// Варианты заполнения поля 12
        /// </summary>
        public enum field12_Floor
        {
            [Description("N")]
            NT,
            [Description("1")]
            N1
        }

        /// <summary>
        /// Варианты заполнения поля 13
        /// для ЭОМ
        /// </summary>
        public enum field13_EOM_MirrowType
        {
            [Description("Прямая форма")]
            S,
            [Description("Обратная форма")]
            R
        }

        /// <summary>
        /// Варианты заполнения поля 13
        /// для ВК
        /// </summary>
        public enum field13_VK_PlacePipe
        {
            [Description("Стояк К основного С/У внутри квартиры")]
            IN1,
            [Description("Стояк К кухни внутри квартиры")]
            IN2,
            [Description("Стояк К гостевого С/У внутри квартиры")]
            IN3,
            [Description("Стояк К основного С/У вне квартиры")]
            OUT1,
            [Description("Стояк К кухни вне квартиры")]
            OUT2,
            [Description("Стояк К гостевого С/У вне квартиры")]
            OUT3
        }

        /// <summary>
        /// Варианты заполнения поля 13
        /// для ОВ1
        /// </summary>
        public enum field13_OV1_HeatZoneCount
        {
            [Description("1z")]
            z1,
            [Description("2z")]
            z2,
            [Description("2zp")]
            zp2,
            [Description("N")]
            N
        }

        /// <summary>
        /// Варианты заполнения поля 13
        /// для ОВ2В и ОВ2К
        /// </summary>
        public enum field13_OV2_HeatZoneCount
        {
            [Description("none")]
            none            
        }
    }
}
