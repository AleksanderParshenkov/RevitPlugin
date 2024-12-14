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

            File.WriteAllText(JsonName.MainJsonFileName, json);
        }

        public static List<MyDimension> Deserialization()
        {
            string fileName = JsonName.MainJsonFileName;
            string jsonString = File.ReadAllText(fileName);
                                    
            List<MyDimension> resultList = JsonSerializer.Deserialize<List<MyDimension>>(jsonString);

            return resultList;
        }
    }
}
