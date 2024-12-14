using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Events;
using DimensionsControl.Models;
using DimensionsControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DimensionsControl.Views;
using Autodesk.Revit.DB;
using DimensionsControl.Support;
using System.IO;

namespace DimensionsControl.ViewModels
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


            //MessageBox.Show(string.Join(";\n", myDimensionList.Select(x => (x.SegmentCount.ToString() + " " + x.Id))));
        }
    }
}
