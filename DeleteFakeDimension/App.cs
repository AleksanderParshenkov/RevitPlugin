using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Collections.Generic;
using System.Linq;
using System;

namespace DeleteFakeDimension
{
    [Transaction(TransactionMode.Manual)]
    public class App : IExternalCommand
    {     
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Autodesk.Revit.ApplicationServices.Application app = uiapp.Application;
            Autodesk.Revit.DB.Document doc = uidoc.Document;




            // Транзакция            
            using (Transaction tr = new Transaction(doc, "Контроль размеров. Удаление указателей"))
            {
                tr.Start();

                // Удаление указателей размеров
                FilteredElementCollector elementCollector2 = new FilteredElementCollector(doc).WhereElementIsNotElementType().OfCategory(BuiltInCategory.OST_DetailComponents);
                List<Element> elementToDeleteList = elementCollector2.Where(x => x.get_Parameter(BuiltInParameter.ELEM_FAMILY_PARAM).AsValueString() == "DC_Указатель контроля размеров").ToList();
                foreach (Element elementToDelete in elementToDeleteList)
                {
                    ElementId elementId = elementToDelete.Id;
                    doc.Delete(elementId);
                }

                tr.Commit();         
            }


            return Result.Succeeded;
        }
    }
}
