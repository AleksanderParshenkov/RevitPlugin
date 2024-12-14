using DimensionsControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DimensionsControl.Support
{
    public static class JsonName
    {
        public static string MainJsonFileName { get; set; }
        public static string ReportJsonFileName { get; set; }

        public static void GetJsonFileName()
        {
            string path = $@"\\picompany.ru\pikp\lib\02_Revit\70_PIKTools\ИОС-ОВ-ВК-ЭОМ-СС\Вспомогательные материалы\Контроль размеров\";
            string titleModel = $@"{CurrentModel.Doc.Title.Replace($@"_{CurrentModel.Doc.Application.Username}", "")}";
            string revitServerName = "";
            string guid = "";
            try 
            { 
                revitServerName = revitServerName + CurrentModel.Doc.GetWorksharingCentralModelPath()?.CentralServerPath;
                guid = CurrentModel.Doc.WorksharingCentralGUID.ToString();
            }
            catch 
            { 
                revitServerName = "PC-" + CurrentModel.Doc.Application.Username;
                guid = "none";
            }

            MainJsonFileName = $@"{path}{titleModel}_{revitServerName}_{guid}.json";
            ReportJsonFileName = $@"{path}{titleModel}_{revitServerName}_{guid}_report.txt";
        }
    }
}
