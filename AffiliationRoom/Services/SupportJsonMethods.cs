using AffiliationRoom.Models;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Windows.Forms;


namespace AffiliationRoom.Services
{
    class SupportJsonMethods
    {
        public static void Serialization(ObservableCollection<ParametersCouple> parametersCoupleList)
        {
            System.Windows.Forms.SaveFileDialog saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();

            saveFileDialog1.Filter = "json files (*.json)|*.json";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel) return;

            // Сериализируем json
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            string json = JsonSerializer.Serialize(parametersCoupleList, options);

            // получаем выбранный файл
            string filename = saveFileDialog1.FileName;

            // сохраняем текст в файл
            System.IO.File.WriteAllText(filename, json);
            MessageBox.Show("Файл сохранен");            
        }

        public static ObservableCollection<ParametersCouple> Deserialization()
        {            
            System.Windows.Forms.OpenFileDialog openFileDialog1 = new System.Windows.Forms.OpenFileDialog();

            openFileDialog1.Filter = "json files (*.json)|*.json";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.Cancel) return null;

            // получаем выбранный файл
            string filename = openFileDialog1.FileName;

            // читаем файл в строку
            string jsonString = File.ReadAllText(filename);

            ObservableCollection<ParametersCouple> resultList = JsonSerializer.Deserialize<ObservableCollection<ParametersCouple>>(jsonString);

            return resultList;
        }
    }
}
