﻿using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
using CheckDimensions.ViewModels;

namespace CheckDimensions
{
    [Transaction(TransactionMode.Manual)]
    public class App : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, Autodesk.Revit.DB.ElementSet elements)
        {
            MainController mainController = new MainController(commandData);

            return Result.Succeeded;
        }
    }
}
