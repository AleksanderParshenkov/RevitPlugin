using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Events;
using System.Windows.Forms;

namespace AllRevitServers
{
    [Transaction(TransactionMode.Manual)]
    public class App : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            RevitServerList revitServerList = new RevitServerList();

            string path = @"C:\ProgramData\Autodesk\Revit Server 2019\Config\RSN.ini";

            if (System.Environment.UserName == "parshenkovav")
            {
                SupportReportMethods.WriteStr(path, revitServerList.RevitServers);

                MessageBox.Show("Выполнено");
            }
            else
            {
                MessageBox.Show("Не выполнено. Отсутствуют права доступа");
            }            


            return Result.Succeeded;
        }
    }  
}
