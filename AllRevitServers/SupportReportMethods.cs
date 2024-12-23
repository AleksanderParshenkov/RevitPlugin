using System;
using System.IO;

namespace AllRevitServers
{
    public static class SupportReportMethods
    {
        public static void WriteStr(string path, string str)
        {
            //добавление в файл
            using (StreamWriter writer = new StreamWriter(path, false))
            {
                writer.WriteLine(str);
                //writer.WriteLineAsync(str);
                //writer.Close();
            }
        }
    }
}
