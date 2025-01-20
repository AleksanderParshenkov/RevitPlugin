using Autodesk.Revit.DB;
using DimensionsControl.Models;
using DimensionsControl.Support;
using DimensionsControl.Views;
using System.Collections.Generic;
using System.Linq;

namespace DimensionsControl.ViewModels
{
    internal class WriteController
    {
        public WriteController()
        {
            // Показываем предупреждение пользователю
            ReportWarningWriteWindow reportWarningWriteWindow = new ReportWarningWriteWindow();

            // Получаем список всех линейных размеров из модели
            List <Dimension> dimensionList = SupportCheckModelMethods.GetAllDimensionsFromModel();

            // Инициализируем пустой список экземпляров класса MyDimension
            List<MyDimension> myDimensionList = new List<MyDimension>();

            // Наполняем список экземпляров класса MyDimension на основе элементов списка dimensionList
            foreach (Dimension dimension in dimensionList)
            {
                MyDimension myDimension = new MyDimension();
                myDimension.GetParamMyDimension(dimension); 
                myDimensionList.Add(myDimension);
            }

            // Получение и запись статических имен json файлов
            JsonName.GetJsonFileName();

            // Запись отчета изменения файла в отдельном txt. Добавление строки ДатаВремя_User_Количество размеров
            SupportReportMethods.WriteStringLine(myDimensionList.Count());            

            // Сериализация json
            SupportJsonMethods.Serialization(myDimensionList);


            //MessageBox.Show(string.Join(";\n", myDimensionList.Select(x => (x.SegmentCount.ToString() + " " + x.Id))));
        }
    }
}
