#region Usings
using System.Collections.Generic;
using System.IO;
using System.Linq;
#endregion

namespace CheckModulName.ViewModels
{
    /// <summary>
    /// Класс с методом для поиска всех модудей по 
    /// переданному пользователем пути
    /// (пакетный метод проверки модулей)
    /// </summary>
    public static class FindAllModulesInFolder
    {
        /// <summary>
        /// Поиск модулей по указанному пути во всех вложенных папках
        /// </summary>
        public static List<string> AllModulesInFolder(string item0)
        {
            List <string> modules = new List<string>();

            //Старт поиска с углублением в каждую вложенную папку, не сорержащую ".rvt"
            List<string> allFolderInFolderPath1 = Directory.GetDirectories(item0).ToList();
            foreach (string item1 in allFolderInFolderPath1) 
            {                
                if (item1.Contains(".rvt")) modules.Add(item1);
                else
                {
                    List<string> allFolderInFolderPath2 = Directory.GetDirectories(item1).ToList();
                    foreach (string item2 in allFolderInFolderPath2)
                    {
                        if (item2.Contains(".rvt")) modules.Add(item2);
                        else
                        {
                            List<string> allFolderInFolderPath3 = Directory.GetDirectories(item2).ToList();
                            foreach (string item3 in allFolderInFolderPath3)
                            {
                                if (item3.Contains(".rvt")) modules.Add(item3);
                                else
                                {
                                    List<string> allFolderInFolderPath4 = Directory.GetDirectories(item3).ToList();
                                    foreach (string item4 in allFolderInFolderPath4)
                                    {
                                        if (item4.Contains(".rvt")) modules.Add(item4);
                                        else
                                        {
                                            List<string> allFolderInFolderPath5 = Directory.GetDirectories(item4).ToList();
                                            foreach (string item5 in allFolderInFolderPath5)
                                            {
                                                if (item5.Contains(".rvt")) modules.Add(item5);
                                                else
                                                {
                                                    List<string> allFolderInFolderPath6 = Directory.GetDirectories(item5).ToList();
                                                    foreach (string item6 in allFolderInFolderPath6)
                                                    {
                                                        if (item6.Contains(".rvt")) modules.Add(item6);
                                                        else
                                                        {
                                                            List<string> allFolderInFolderPath7 = Directory.GetDirectories(item6).ToList();
                                                            foreach (string item7 in allFolderInFolderPath7)
                                                            {
                                                                if (item7.Contains(".rvt")) modules.Add(item7);
                                                                else
                                                                {
                                                                    List<string> allFolderInFolderPath8 = Directory.GetDirectories(item7).ToList();
                                                                    foreach (string item8 in allFolderInFolderPath8)
                                                                    {
                                                                        if (item8.Contains(".rvt")) modules.Add(item8);
                                                                        else
                                                                        {
                                                                            List<string> allFolderInFolderPath9 = Directory.GetDirectories(item8).ToList();
                                                                            foreach (string item9 in allFolderInFolderPath9)
                                                                            {
                                                                                if (item8.Contains(".rvt")) modules.Add(item9);
                                                                                else
                                                                                {
                                                                                    List<string> allFolderInFolderPath10 = Directory.GetDirectories(item9).ToList();
                                                                                    foreach (string item10 in allFolderInFolderPath10)
                                                                                    {
                                                                                        if (item8.Contains(".rvt")) modules.Add(item10);
                                                                                        else
                                                                                        {

                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return modules;
        }
    }
}
