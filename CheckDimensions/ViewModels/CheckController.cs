using Autodesk.Revit.DB;
using CheckDimensions.Models;
using CheckDimensions.Support;
using CheckDimensions.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace CheckDimensions.ViewModels
{
    internal class CheckController
    {
        public CheckController()
        {
            // Получаем список всех линейных размеров из модели
            List<Dimension> dimensionList = SupportCheckModelMethods.GetAllDimensionsFromModel();


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

            // Получаем список экземпляров класса MyDimension из json 
            List<MyDimension> myDimensionsFronJsonList = SupportJsonMethods.Deserialization();

            // Сравнение полученных размеров из json с размерами из модеди
            // Получаем список размеров из json, которым не найдена пара в модели
            List<MyDimension> wrongMyDimensionList = new List<MyDimension>();   
            foreach (MyDimension myDimensionFromJson in myDimensionsFronJsonList)
            {
                if (!myDimensionList.Select(x => x.Id).Contains(myDimensionFromJson.Id)) wrongMyDimensionList.Add(myDimensionFromJson);
            }

            ReportDimensions.ReportDimensionList = wrongMyDimensionList;

            // Отчет пользователю
            // Подготавливаем коллекцию для DataGrid
            // Создаем пустую коллекцию как ресурс для ДатаГрид
            var itemsSourceDataGrid = new ObservableCollection<ItemToDataGrid>();
            foreach (var dimension in wrongMyDimensionList)
            {
                ItemToDataGrid itemToDataGrid = new ItemToDataGrid();
                itemToDataGrid.GetParamItemToDataGrid(dimension);
                itemsSourceDataGrid.Add(itemToDataGrid);
            }

            // Показываем пользователю окно с отчетом по удаленным размерам
            MainWindow reportDataGridWindow = new MainWindow();
            reportDataGridWindow.DGR.ItemsSource = itemsSourceDataGrid;
            reportDataGridWindow.Show();
        }
    }
}
