#region Usings
using CheckModulName.Models;
using System.IO;
#endregion

namespace CheckModulName.ViewModels
{
    /// <summary>
    /// Класс с методами создания, перезаписи и добавления информации в файл-отчет
    /// Файл отчет создается в папке "Документы" у текущего пользователя
    /// </summary>
    public static class TxtReportMethods
    {
        /// <summary>
        /// Создание файла-отчета
        /// </summary>
        public static void CreateFiles()
        {
            // Получение и заполнение первичных данных в файле-отчета
            ReportTxt.GetAllProperty();

            // Создание файла
            using (FileStream fs = File.Create(ReportTxt.Path)) { }

            // Полная перезапись файла 
            try
            {
                using (StreamWriter writer = new StreamWriter(ReportTxt.Path, false))
                {                    
                    writer.WriteLine(ReportTxt.Header);
                }
            }
            catch { }
        }

        /// <summary>
        /// Запись строки в файл-отчет
        /// </summary>
        public static void WriteStringLine(string str)
        {
            //добавление в файл
            using (StreamWriter writer = new StreamWriter(ReportTxt.Path, true))
            {
                writer.WriteLineAsync(str);
            }
        }

        /// <summary>
        /// Объединение данных по модулю в строку
        /// для последующей записи в файл-отчет
        /// </summary>
        public static string GetStringLineForTxtReport()
        {
            string strInReport = "";
            strInReport += ModulFields.ModulDiscipline;
            strInReport += $"\t";
            strInReport += ModulFields.ModulType;
            strInReport += $"\t";
            strInReport += ModulFields.ModulPath;

            strInReport += $"\t";
            strInReport += ModulFields.ModulName;
            strInReport += $"\t";
            strInReport += ModulFields.ModulNameIsError.ToString();

            strInReport += $"\t";
            strInReport += ModulFields.field0Value;
            strInReport += $"\t";
            strInReport += ModulFields.field0IsError.ToString();

            strInReport += $"\t";
            strInReport += ModulFields.field1Value;
            strInReport += $"\t";
            strInReport += ModulFields.field1IsError.ToString();

            strInReport += $"\t";
            strInReport += ModulFields.field2Value;
            strInReport += $"\t";
            strInReport += ModulFields.field2IsError.ToString();

            strInReport += $"\t";
            strInReport += ModulFields.field3Value;
            strInReport += $"\t";
            strInReport += ModulFields.field3IsError.ToString();

            strInReport += $"\t";
            strInReport += ModulFields.field4Value;
            strInReport += $"\t";
            strInReport += ModulFields.field4IsError.ToString();

            strInReport += $"\t";
            strInReport += ModulFields.field5Value;
            strInReport += $"\t";
            strInReport += ModulFields.field5IsError.ToString();

            strInReport += $"\t";
            strInReport += ModulFields.field6Value;
            strInReport += $"\t";
            strInReport += ModulFields.field6IsError.ToString();

            strInReport += $"\t";
            strInReport += ModulFields.field7Value;
            strInReport += $"\t";
            strInReport += ModulFields.field7IsError.ToString();

            strInReport += $"\t";
            strInReport += ModulFields.field8Value;
            strInReport += $"\t";
            strInReport += ModulFields.field8IsError.ToString();

            strInReport += $"\t";
            strInReport += ModulFields.field9Value;
            strInReport += $"\t";
            strInReport += ModulFields.field9IsError.ToString();

            strInReport += $"\t";
            strInReport += ModulFields.field10Value;
            strInReport += $"\t";
            strInReport += ModulFields.field10IsError.ToString();

            strInReport += $"\t";
            strInReport += ModulFields.field11Value;
            strInReport += $"\t";
            strInReport += ModulFields.field11IsError.ToString();

            strInReport += $"\t";
            strInReport += ModulFields.field12Value;
            strInReport += $"\t";
            strInReport += ModulFields.field12IsError.ToString();

            strInReport += $"\t";
            strInReport += ModulFields.field13Value;
            strInReport += $"\t";
            strInReport += ModulFields.field13IsError.ToString();

            return strInReport ;
        }
    }
}
