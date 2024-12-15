using System;
using System.IO;

namespace CheckDimensions.Support
{
    public static class SupportReportMethods
    {
        public static void WriteStringLine(int dimensionCount)
        {
            //добавление в файл
            using (StreamWriter writer = new StreamWriter(JsonName.ReportJsonFileName, true))
            {
                string dataTime = DateTime.Now.ToString();
                string user = CurrentModel.Doc.Application.Username;

                string str = dataTime + "\t" + user + "\t" + dimensionCount.ToString();

                writer.WriteLineAsync(str);
            }
        }
    }
}
