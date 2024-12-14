using DimensionsControl.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DimensionsControl.Support
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
