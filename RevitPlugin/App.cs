#region Namespaces
using Autodesk.Revit.UI;
using System.Reflection;
#endregion

namespace RevitPlugin
{
    internal class App : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication application)
        {
            string tabName = "Plugins";
            string panelName = "Инструменты";
            string assemblyName = Assembly.GetExecutingAssembly().Location;

            application.CreateRibbonTab(tabName);
            var panel = application.CreateRibbonPanel(tabName, panelName);

            var newButtonData1 = new PushButtonData("Фильтр\nстрочный", "Фильтр\nстрочный", assemblyName: assemblyName, "RevitPlugin.SelectAll");            
            ImageMethods.AddImageToButtonData(newButtonData1, Properties.Resources.logo_selectAll);
            PushButton newButton1 = panel.AddItem(newButtonData1) as PushButton;
            

            var newButtonData2 = new PushButtonData("Проверка\nимени модуля", "Проверка\nимени модуля", assemblyName: assemblyName, "RevitPlugin.CheckModulName");
            ImageMethods.AddImageToButtonData(newButtonData2, Properties.Resources.logo_checkModulName);
            PushButton newButton2 = panel.AddItem(newButtonData2) as PushButton;

            return Result.Succeeded;
        }
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }
    }
}
