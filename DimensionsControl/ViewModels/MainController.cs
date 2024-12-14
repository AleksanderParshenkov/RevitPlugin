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

namespace DimensionsControl.ViewModels
{
    internal class MainController
    {
        public MainController(ExternalCommandData commandData)
        {
            // Получение и запись информации о текущей модели
            CurrentModel.GetParamCurrentModel(commandData);

            // Создание экземпляра основного интерфейса (окна)
            MainWindow Wnd = new MainWindow();
        }
    }
}
