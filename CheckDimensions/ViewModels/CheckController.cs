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
            // Получаем список видов текущей модели
            // Поиск вида
            FilteredElementCollector viewCollector = new FilteredElementCollector(CurrentModel.Doc).WhereElementIsNotElementType().OfCategory(BuiltInCategory.OST_Views);
            List<View> currentViewList = viewCollector.Select(x=> x as  View).ToList(); 

            // Получаем список размеров из json, которым не найдена пара в модели
            List<MyDimension> wrongMyDimensionDeletedList = new List<MyDimension>();   
            List<MyDimension> wrongMyDimensionDeletedViewList = new List<MyDimension>();
            List<ChangeDimension> wrongMyDimensionChangedList = new List<ChangeDimension>();

            foreach (MyDimension myDimensionFromJson in myDimensionsFromJsonList)
            {
                bool isHaveChange = false;

                if (!currentViewList.Select(x => x.Id.IntegerValue).Contains(myDimensionFromJson.ViewId))
                {
                    wrongMyDimensionDeletedViewList.Add(myDimensionFromJson);
                }
                else
                {
                    if (!myDimensionList.Select(x => x.Id).Contains(myDimensionFromJson.Id)) wrongMyDimensionDeletedList.Add(myDimensionFromJson);
                    else
                    {
                        int Id = myDimensionFromJson.Id;

                        List <string> dimensionValues = new List<string>();
                        List<string> jsonDimensionValues = new List<string>();

                        dimensionValues = myDimensionList.Where(x => x.Id == Id).Select(x => x.ValueStringList).FirstOrDefault().ToList();
                        jsonDimensionValues = myDimensionFromJson.ValueStringList;                        

                        for (int i = 0; i < dimensionValues.Count; i++)
                        {
                            if (dimensionValues[i] != jsonDimensionValues[i])
                            {
                                isHaveChange = true;
                            }
                        }  
                        
                        if (isHaveChange)
                        {
                            ChangeDimension changeDimension = new ChangeDimension();
                            changeDimension.Id = myDimensionFromJson.Id;
                            changeDimension.FamilySymbol = myDimensionFromJson.FamilySymbol;
                            changeDimension.ViewId = myDimensionFromJson.ViewId;
                            changeDimension.ViewName = myDimensionFromJson.ViewName;
                            changeDimension.SheetName = myDimensionFromJson.SheetName;
                            changeDimension.ViewInList = myDimensionFromJson.ViewInList;
                            changeDimension.SegmentCount = myDimensionFromJson.SegmentCount;
                            changeDimension.ValueList = myDimensionFromJson.ValueList;
                            changeDimension.ValueStringList = myDimensionFromJson.ValueStringList;
                            changeDimension.TextPositionList = myDimensionFromJson.TextPositionList;
                            changeDimension.TextPositionXList = myDimensionFromJson.TextPositionXList;
                            changeDimension.TextPositionYList = myDimensionFromJson.TextPositionYList;
                            changeDimension.TextPositionZList = myDimensionFromJson.TextPositionZList;

                            changeDimension.CurrentValueStringList = dimensionValues;
                            wrongMyDimensionChangedList.Add(changeDimension);
                        }
                    }
                }
            }

            //***

            // Поиск требуемого семейства и типоразмера для вставки
            FilteredElementCollector elementCollector = new FilteredElementCollector(CurrentModel.Doc)
                .OfClass(typeof(FamilySymbol))
                .OfCategory(BuiltInCategory.OST_DetailComponents);
            FamilySymbol elementType = elementCollector
                .FirstOrDefault(x => x.get_Parameter(BuiltInParameter.SYMBOL_NAME_PARAM).AsString() == "DC_Указатель контроля размеров") as FamilySymbol;


            // Транзакция            
            using (Transaction tr = new Transaction(CurrentModel.Doc, "Контроль размеров. Создание указателей"))
            {
                tr.Start();

                // Удаление указателей размеров
                FilteredElementCollector elementCollector2 = new FilteredElementCollector(CurrentModel.Doc).WhereElementIsNotElementType().OfCategory(BuiltInCategory.OST_DetailComponents);
                List<Element> elementToDeleteList = elementCollector2.Where(x => x.get_Parameter(BuiltInParameter.ELEM_FAMILY_PARAM).AsValueString() == "DC_Указатель контроля размеров").ToList();
                foreach (Element elementToDelete in elementToDeleteList)
                {
                    ElementId elementId = elementToDelete.Id;
                    CurrentModel.Doc.Delete(elementId);
                }

                // Перебор удаленных размеров
                foreach (MyDimension dimension in wrongMyDimensionDeletedList) 
                {
                    // Поиск вида
                    FilteredElementCollector elementCollector1 = new FilteredElementCollector(CurrentModel.Doc).WhereElementIsNotElementType().OfCategory(BuiltInCategory.OST_Views);
                    View elementView = elementCollector1.FirstOrDefault(x => x.Id.IntegerValue == dimension.ViewId) as View;

                    ///****
                    if (elementType != null) 
                    {
                        if (elementType.IsActive == false) { elementType.Activate(); }

                        for (int i = 0; i < dimension.TextPositionList.Count(); i++)
                        {
                            XYZ xyz = new XYZ(dimension.TextPositionXList[i], dimension.TextPositionYList[i], dimension.TextPositionZList[i]);

                            //Создает элемент узла
                            Element newElement = CurrentModel.Doc.Create.NewFamilyInstance(xyz, elementType, elementView);

                            //CurrentModel.Doc.Create.NewFamilyInstance(xyz, elementType, elementView);
                            // Вид - BS_Вид
                            Parameter BS_View = newElement.get_Parameter(new Guid("df1b9a2d-bb0d-47b8-8a49-3a529fccfb47"));
                            BS_View.Set(dimension.ViewName);

                            // Длина - BS_Марка
                            Parameter BS_Mark = newElement.get_Parameter(new Guid("7d8b77eb-64e0-424c-b11b-ce21ceec4ea9"));
                            BS_Mark.Set(dimension.ValueStringList[i]);

                            // Количество сегментов - BS_Примечание
                            Parameter BS_Prim = newElement.get_Parameter(new Guid("941bc7a1-a062-406d-83f7-fd177760f277"));
                            BS_Prim.Set(dimension.SegmentCount.ToString());

                            // Имя листа - комментарий
                            Parameter comment = newElement.get_Parameter(BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS);
                            comment.Set(dimension.SheetName);

                            // Изменение - BS_Текст
                            Parameter BS_Text = newElement.get_Parameter(new Guid("504b1647-561e-4ce9-8ec6-576b38e24b51"));
                            BS_Text.Set("Удален");
                        }
                    }                    
                }

                // Перебор измененных размеров
                foreach (ChangeDimension dimension in wrongMyDimensionChangedList)
                {
                    // Поиск вида
                    FilteredElementCollector elementCollector1 = new FilteredElementCollector(CurrentModel.Doc).WhereElementIsNotElementType().OfCategory(BuiltInCategory.OST_Views);
                    View elementView = elementCollector1.FirstOrDefault(x => x.Id.IntegerValue == dimension.ViewId) as View;

                    ///****
                    if (elementType != null)
                    {
                        if (elementType.IsActive == false) { elementType.Activate(); }

                        for (int i = 0; i < dimension.ValueStringList.Count(); i++)
                        {
                            if (dimension.ValueStringList[i] != dimension.CurrentValueStringList[i])
                            {
                                

                                XYZ xyz = new XYZ(dimension.TextPositionXList[i], dimension.TextPositionYList[i], dimension.TextPositionZList[i]);

                                //Создает элемент узла
                                Element newElement = CurrentModel.Doc.Create.NewFamilyInstance(xyz, elementType, elementView);

                                //CurrentModel.Doc.Create.NewFamilyInstance(xyz, elementType, elementView);
                                // Вид - BS_Вид
                                Parameter BS_View = newElement.get_Parameter(new Guid("df1b9a2d-bb0d-47b8-8a49-3a529fccfb47"));
                                BS_View.Set(dimension.ViewName);

                                // Длина - BS_Марка
                                Parameter BS_Mark = newElement.get_Parameter(new Guid("7d8b77eb-64e0-424c-b11b-ce21ceec4ea9"));
                                BS_Mark.Set(dimension.ValueStringList[i] + "->" + dimension.CurrentValueStringList[i]);

                                // Количество сегментов - BS_Примечание
                                Parameter BS_Prim = newElement.get_Parameter(new Guid("941bc7a1-a062-406d-83f7-fd177760f277"));
                                BS_Prim.Set(dimension.SegmentCount.ToString());

                                // Имя листа - комментарий
                                Parameter comment = newElement.get_Parameter(BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS);
                                comment.Set(dimension.SheetName);

                                // Изменение - BS_Текст
                                Parameter BS_Text = newElement.get_Parameter(new Guid("504b1647-561e-4ce9-8ec6-576b38e24b51"));
                                BS_Text.Set("Изменен");

                                dimension.ValueStringList[i] = dimension.ValueStringList[i] + "->" + dimension.CurrentValueStringList[i];
                            }
                        }
                    }
                }


                tr.Commit();
            }
            //***

            ReportDimensions.ReportDimensionList = wrongMyDimensionDeletedList;

            // Отчет пользователю
            // Подготавливаем коллекцию для DataGrid
            // Создаем пустую коллекцию как ресурс для ДатаГрид
            var itemsSourceFromDeletedViewDataGrid = new ObservableCollection<ItemToDataGrid>();
            var itemsDeletedSourceDataGrid = new ObservableCollection<ItemToDataGrid>();
            var itemsChangedSourceDataGrid = new ObservableCollection<ItemToDataGrid>();

            foreach (var dimension in wrongMyDimensionDeletedList)
            {
                ItemToDataGrid itemToDataGrid = new ItemToDataGrid();
                itemToDataGrid.GetParamItemToDataGrid(dimension);
                itemsDeletedSourceDataGrid.Add(itemToDataGrid);
            }

            foreach (var dimension in wrongMyDimensionDeletedViewList)
            {
                ItemToDataGrid itemToDataGrid = new ItemToDataGrid();
                itemToDataGrid.GetParamItemToDataGrid(dimension);
                itemsSourceFromDeletedViewDataGrid.Add(itemToDataGrid);
            }

            foreach (var dimension in wrongMyDimensionChangedList)
            {
                ItemToDataGrid itemToDataGrid = new ItemToDataGrid();
                itemToDataGrid.GetParamItemToDataGrid(dimension);
                itemsChangedSourceDataGrid.Add(itemToDataGrid);
            }


            // Показываем пользователю окно с отчетом по удаленным размерам
            MainWindow reportDataGridWindow = new MainWindow();
            reportDataGridWindow.DGR_1.ItemsSource = itemsSourceFromDeletedViewDataGrid;
            reportDataGridWindow.DGR_2.ItemsSource = itemsDeletedSourceDataGrid;
            reportDataGridWindow.DGR_3.ItemsSource = itemsChangedSourceDataGrid;
            reportDataGridWindow.Show();
        }
    }
}
