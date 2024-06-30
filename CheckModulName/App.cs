#region Usings
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using CheckModulName.ViewModels;
#endregion

namespace CheckModulName
{
    /// <summary>
    /// Основной класс старта работы инструмента
    /// Подключается к кнопке на вкладке
    /// </summary>
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
            MainController mainController = new MainController(commandData);

            /// <summary>
            /// Плагином не предусматривается транзакций, изменяющих текущую модели
            /// </summary>
            return Result.Succeeded;
        }
    }
}
