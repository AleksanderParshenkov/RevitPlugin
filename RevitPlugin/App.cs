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
            //string tabName = "Plugins";
            //string panelName = "�����������";
            //string assemblyName = Assembly.GetExecutingAssembly().Location;

            //application.CreateRibbonTab(tabName);
            //var panel = application.CreateRibbonPanel(tabName, panelName);

            //var newButtonData1 = new PushButtonData("�������\n��� ��������", "�������\n��� ��������", assemblyName: assemblyName, "RevitPlugin.SelectAll");
            //ImageMethods.AddImageToButtonData(newButtonData1, Properties.Resources.SelectAll);
            //PushButton newButton1 = panel.AddItem(newButtonData1) as PushButton;

            //var newButtonData2 = new PushButtonData("��������\n����� ������", "��������\n����� ������", assemblyName: assemblyName, "RevitPlugin.CheckModulName");
            //ImageMethods.AddImageToButtonData(newButtonData2, Properties.Resources.CheckModulName);
            //PushButton newButton2 = panel.AddItem(newButtonData2) as PushButton;

            //var newButtonData3 = new PushButtonData("��������\n�������", "��������\n�������", assemblyName: assemblyName, "RevitPlugin.WriteDimensions");
            //ImageMethods.AddImageToButtonData(newButtonData3, Properties.Resources.WriteDimensions);
            //PushButton newButton3 = panel.AddItem(newButtonData3) as PushButton;

            //var newButtonData4 = new PushButtonData("���������\n�������", "���������\n�������", assemblyName: assemblyName, "RevitPlugin.CheckDimensions");
            //ImageMethods.AddImageToButtonData(newButtonData4, Properties.Resources.CheckDimensions);
            //PushButton newButton4 = panel.AddItem(newButtonData4) as PushButton;

            //var newButtonData5 = new PushButtonData("�������\n���������", "�������\n���������", assemblyName: assemblyName, "RevitPlugin.DeleteFakeDimension");
            //ImageMethods.AddImageToButtonData(newButtonData5, Properties.Resources.DeleteFakeDimensions);
            //PushButton newButton5 = panel.AddItem(newButtonData5) as PushButton;

            //var newButtonData6 = new PushButtonData("Revit\n�������", "Revit\n�������", assemblyName: assemblyName, "RevitPlugin.AllRevitServers");
            //ImageMethods.AddImageToButtonData(newButtonData6, Properties.Resources.AllRevitServers);
            //PushButton newButton6 = panel.AddItem(newButtonData6) as PushButton;

            //var newButtonData7 = new PushButtonData("��������������\n���������", "��������������\n���������", assemblyName: assemblyName, "RevitPlugin.AffiliationRoom");
            //ImageMethods.AddImageToButtonData(newButtonData7, Properties.Resources.AllRevitServers);
            //PushButton newButton7 = panel.AddItem(newButtonData7) as PushButton;

            return Result.Succeeded;
        }
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }
    }
}
