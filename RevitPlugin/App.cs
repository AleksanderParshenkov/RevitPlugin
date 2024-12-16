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

            //application.CreateRibbonTab(tabName);
            //var panel = application.CreateRibbonPanel(tabName, panelName);

            //var newButtonData1 = new PushButtonData("Фильтр\nстрочный", "Фильтр\nстрочный", assemblyName: assemblyName, "RevitPlugin.SelectAll");
            //ImageMethods.AddImageToButtonData(newButtonData1, Properties.Resources.logo_selectAll);
            //PushButton newButton1 = panel.AddItem(newButtonData1) as PushButton;

            //var newButtonData2 = new PushButtonData("Проверка\nимени модуля", "Проверка\nимени модуля", assemblyName: assemblyName, "RevitPlugin.CheckModulName");
            //ImageMethods.AddImageToButtonData(newButtonData2, Properties.Resources.logo_checkModulName);
            //PushButton newButton2 = panel.AddItem(newButtonData2) as PushButton;

            //var newButtonData3 = new PushButtonData("Записать\nразмеры", "Записать\nразмеры", assemblyName: assemblyName, "RevitPlugin.WriteDimensions");
            //ImageMethods.AddImageToButtonData(newButtonData3, Properties.Resources.logo_checkModulName);
            //PushButton newButton3 = panel.AddItem(newButtonData3) as PushButton;

            //var newButtonData4 = new PushButtonData("Проверить\nразмеры", "Проверить\nразмеры", assemblyName: assemblyName, "RevitPlugin.CheckDimensions");
            //ImageMethods.AddImageToButtonData(newButtonData4, Properties.Resources.logo_checkModulName);
            //PushButton newButton4 = panel.AddItem(newButtonData4) as PushButton;

            //var newButtonData5 = new PushButtonData("Удалить\nуказатели", "Удалить\nуказатели", assemblyName: assemblyName, "RevitPlugin.DeleteFakeDimension");
            //ImageMethods.AddImageToButtonData(newButtonData5, Properties.Resources.logo_checkModulName);
            //PushButton newButton5 = panel.AddItem(newButtonData5) as PushButton;

            return Result.Succeeded;
        }
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }
    }
}
