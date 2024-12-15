using CheckDimensions.Models;
using System.Collections.Generic;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace CheckDimensions.Support
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
