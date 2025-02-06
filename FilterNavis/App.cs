#region Namespaces
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using FilterNavis.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
#endregion

namespace FilterNavis
{
    // Точка входа dll
    [Regeneration(RegenerationOption.Manual)]
    [Transaction(TransactionMode.Manual)]
    public class App : IExternalCommand
    {
        
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {    
            /// <summary>
            /// Создание экземпляра основного контроллера,
            /// задача которого - заполнение свойств статического класса,
            /// являющихся постоянными сведениями о текущей запущенной модели
            /// </summary>
            StartController mainController = new StartController(commandData);

            return Result.Succeeded;
        }
    }
}
