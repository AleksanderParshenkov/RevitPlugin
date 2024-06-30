#region Usings
using System;
#endregion

namespace CheckModulName.Models
{
    /// <summary>
    /// Класс со свойствами для записи файла-отчета
    /// </summary>
    public static  class ReportTxt
    {
        public static string Path {  get; private set; }
        public static string User { get; private set; }
        public static string Header { get; private set; }

        /// <summary>
        /// Получение значений стартовых свойств
        /// </summary>
        public static void GetAllProperty()
        {
            User = Environment.UserName;

            // Первая (верхняя) строка файла-отчета
            Header = $"Дисциплина\tТ" +
                $"ип модуля\t" +
                $"Путь\t" +
                $"Имя модуля\t" +
                $"Ошибка имени модуля\t" +
                $"Поле 0\tОшибка 0\t" +
                $"Поле 1\tОшибка 1\t" +
                $"Поле 2\t Ошибка 2\t" +
                $"Поле 3\t Ошибка 3\t" +
                $"Поле 4\t Ошибка 4\t" +
                $"Поле 5\t Ошибка 5\t" +
                $"Поле 6\t Ошибка 6\t" +
                $"Поле 7\t Ошибка 7\t" +
                $"Поле 8\t Ошибка 8\t" +
                $"Поле 9\t Ошибка 9\t" +
                $"Поле 10\t Ошибка 10\t" +
                $"Поле 11\t Ошибка 11\t" +
                $"Поле 12\t Ошибка 12\t" +
                $"Поле 13\t Ошибка 13";

            Path = $@"C:\Users\" + User + $@"\Documents\ReportModules.txt";
        }
    }
}
