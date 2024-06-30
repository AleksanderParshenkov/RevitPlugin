#region Usings
using CheckModulName.Models;
using System.Collections.Generic;
using System.Windows.Media;
#endregion

namespace CheckModulName.ViewModels
{
    /// <summary>
    /// Основной контроллер выбора одиночной или пакетной проверки модулей 
    /// по введенному пользователем имени модуля
    /// </summary>
    public class VariantController
    {
        public VariantController (string modulName)
        {
            /// <summary>
            /// Проверка возможности проверить модули пакетно
            /// </summary>
            if (modulName.Contains("d$") && modulName.Contains("btr01"))
            {
                //Определение процесса пакетной проверки модулей
                ModulFields.ProcessCheckPackModules = true;

                //Очистка полей окна
                SupportMethods.ClearWindow();

                // Создание файла-отчета в документах пользователя
                TxtReportMethods.CreateFiles();

                // Поиск папок-модулей в указанной пользовтаелм папке на RS.
                // Получаем список полных путей модулей
                string path = CurrentWindow.Wnd.ModulName.Text;    
                List <string> modules = new List<string>();
                modules = FindAllModulesInFolder.AllModulesInFolder(path);

                // Прогон проверки каждого из модулей
                foreach ( string module in modules) 
                {
                    // Разделение полного пути модуля на имя и локальный путь к папке нахождения  
                    string currentModuName = module.Substring(module.LastIndexOf("\\") + 1);
                    string currentModulPath = module.Replace(currentModuName, "");
                    currentModuName = currentModuName.Replace(".rvt", "");

                    //Запись значений в класс Модуля
                    ModulFields.ModulName = currentModuName;
                    ModulFields.ModulPath = currentModulPath;
                    
                    //Проверка имени модуля
                    CheckModulController checkControl = new CheckModulController();

                    //Запись свойств модуля как строку в файл отчета
                    string strInReport = TxtReportMethods.GetStringLineForTxtReport();                    
                    TxtReportMethods.WriteStringLine(strInReport);                    
                }

                //Запись значений в класс Модуля
                CurrentWindow.Wnd.ModulName.Text = "Записано в файл ReportModules";
                CurrentWindow.Wnd.ModulName.Background = Brushes.LightBlue;
            }

            /// <summary>
            /// Старт процесса одиночной проверки модуля, 
            /// т.к. пакетная проверка признана невозможной
            /// </summary>
            else
            {
                //Определение процесса НЕ пакетной проверки модулей
                ModulFields.ProcessCheckPackModules = false;

                //Очистка полей окна
                SupportMethods.ClearWindow();

                //Проверка имени модуля
                ModulFields.ModulName = CurrentWindow.Wnd.ModulName.Text;
                CheckModulController checkControl = new CheckModulController();

                //Заполнение полей имени, значения и описания в основном окне по полученному модулю
                SupportMethods.WritedFieldValueInWindow();
                SupportMethods.WriteFieldNameAndDescriptionForDisciplineAndType();

                //Выделение цветом полей значений в интерфейсе с не корректными значениями
                SupportMethods.BrushesFieldValue();
            }
        }
    }
}
