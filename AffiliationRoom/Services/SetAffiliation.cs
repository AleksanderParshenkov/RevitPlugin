using AffiliationRoom.Models;
using AffiliationRoom.Support;
using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AffiliationRoom.Services
{
    static class SetAffiliation
    {
        public static void SetAffiliationMethod(LinkDocument selectedLinkDocument, ObservableCollection<ParametersCouple> parametersCouples)
        {

            DateTime now = DateTime.Now;

            using (Transaction tr = new Transaction(CurrentDocument.Doc, "Принадлежность помещений"))
            {
                tr.Start();
                MessageBox.Show("Старт записи");
                tr.Commit();
            }

            DateTime over = DateTime.Now;

            MessageBox.Show($"Старт: {now}\n" +
                $"Окончание: {over}");
        }
    }
}
