using Autodesk.Revit.DB;
using System.Collections.Generic;
using System.Linq;
using WriteDimensions.Models;
using WriteDimensions.Support;
using WriteDimensions.Views;

namespace WriteDimensions.ViewModels
{
    internal class WriteController
    {
        public WriteController()
        {
             
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
        }
    }
}
