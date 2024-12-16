using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.DB.Structure;
using Autodesk.Revit.UI;
using CheckDimensions.Models;
using CheckDimensions.Support;
using CheckDimensions.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;

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
            List<MyDimension> myDimensionsFromJsonList = SupportJsonMethods.Deserialization();

            // Сравнение полученных размеров из json с размерами из модеди
            // Получаем список размеров из json, которым не найдена пара в модели
            List<MyDimension> wrongMyDimensionList = new List<MyDimension>();   
            foreach (MyDimension myDimensionFromJson in myDimensionsFromJsonList)
            {
                if (!myDimensionList.Select(x => x.Id).Contains(myDimensionFromJson.Id)) wrongMyDimensionList.Add(myDimensionFromJson);
            }


            //***

            // Поиск требуемого семейства и типоразмера для вставки
            FilteredElementCollector elementCollector = new FilteredElementCollector(CurrentModel.Doc)
                .OfClass(typeof(FamilySymbol))
                .OfCategory(BuiltInCategory.OST_DetailComponents);
            FamilySymbol elementType = elementCollector
                .FirstOrDefault(x => x.get_Parameter(BuiltInParameter.SYMBOL_NAME_PARAM).AsString() == "Контроль размеров") as FamilySymbol;


            // Транзакция            
            using (Transaction tr = new Transaction(CurrentModel.Doc, "Контроль размеров. Создание указателей"))
            {
                tr.Start();

                foreach (MyDimension dimension in wrongMyDimensionList) 
                {
                    // Поиск вида
                    FilteredElementCollector elementCollector1 = new FilteredElementCollector(CurrentModel.Doc).WhereElementIsNotElementType().OfCategory(BuiltInCategory.OST_Views);
                    View elementView = elementCollector1.FirstOrDefault(x => x.Name == dimension.ViewName) as View;


                    for (int i = 0; i < dimension.TextPositionList.Count(); i++)
                    {
                        XYZ xyz = new XYZ(dimension.TextPositionXList[i], dimension.TextPositionYList[i], dimension.TextPositionZList[i]);

                        //Создает элемент узла
                        Element newElement = CurrentModel.Doc.Create.NewFamilyInstance(xyz, elementType, elementView);

                        // BS_Вид
                        Parameter bs_View = newElement.get_Parameter(new Guid("df1b9a2d-bb0d-47b8-8a49-3a529fccfb47"));
                        bs_View.Set(dimension.ViewName);

                        // Длина

                        // Количество сегментов

                        // Имя листа
                        

                    }
                }

                tr.Commit();
            }
            //***









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
