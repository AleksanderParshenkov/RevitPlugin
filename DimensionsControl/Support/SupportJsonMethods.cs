using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using DimensionsControl.Models;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace DimensionsControl.Support
{
    public static class SupportJsonMethods
    {
        public static void Serialization(List <MyDimension> mydimensionList)
        {
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            
            string json = JsonSerializer.Serialize(mydimensionList, options);

            File.WriteAllText(@"\\picompany.ru\pikp\lib\02_Revit\70_PIKTools\ИОС-ОВ-ВК-ЭОМ-СС\Вспомогательные материалы\Контроль размеров\customers.json", json);
        }
    }
}
