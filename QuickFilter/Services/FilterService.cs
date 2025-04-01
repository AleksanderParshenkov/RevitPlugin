using QuickFilter.Models;
using System.Windows;

namespace QuickFilter.Services
{
    static class FilterService
    {
        public static void UseFilter()
        {
            MessageBox.Show(CurrentModel.getDocument().Title);
        }
    }
}
