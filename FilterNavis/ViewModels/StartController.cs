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
    public class StartController
    {
        public StartController(ExternalCommandData commandData)
        {
            // Получение и запись информации о текущей модели
            CurrentModel.GetParamCurrentModel(commandData);


            StartWindow startWindow = new StartWindow();
        }
    }
}
