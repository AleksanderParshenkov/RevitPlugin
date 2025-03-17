using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using GetFamilyTypeListFromIds.Models;
using GetFamilyTypeListFromIds.Views;

namespace GetFamilyTypeListFromIds
{
    [Regeneration(RegenerationOption.Manual)]
    [Transaction(TransactionMode.Manual)]
    public class App : IExternalCommand
    {

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            // Получение и запись информации о текущей модели
            CurrentModel.GetParamCurrentModel(commandData);


            MainWindow window = new MainWindow();
            window.Show();

            return Result.Succeeded;
        }
    }
}
