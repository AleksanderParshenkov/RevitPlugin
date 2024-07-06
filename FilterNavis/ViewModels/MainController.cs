using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using FilterNavis.Models;
using FilterNavis.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FilterNavis.ViewModels
{
    public class MainController
    {
        public MainController(ExternalCommandData commandData)
        {
            // Получение и запись информации о текущей модели
            CurrentModel.GetParamCurrentModel(commandData);

            List <Autodesk.Revit.DB.Document> a =  CurrentModel.GetLinkRevitDocuments();

            List<Element> ReferecesElementList = new List<Element>();

            foreach (var  Item in a)
            {
                List<Element> elementsCollectorCurrentModel = new FilteredElementCollector(Item)
                                .WhereElementIsNotElementType()
                                .Where(x => x.Category != null)
                                .ToList();

                foreach (var Element in elementsCollectorCurrentModel)
                {
                    ReferecesElementList.Add(Element);
                }
            }

            MessageBox.Show(ReferecesElementList.Count().ToString());
            
            

            // Создание экземпляра основного интерфейса (окна)
            MainWindow Wnd = new MainWindow();
        }
    }
}
