using DevExpress.Mvvm;
using QuickFilter.Models;
using QuickFilter.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace QuickFilter.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        public ObservableCollection<FilterPack> FilterPackCollection { get; set; }

        public MainViewModel()
        {
            FilterPackCollection = new ObservableCollection<FilterPack>();
        }

        public ICommand Click_UseFilter
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    FilterService.UseFilter();
                }, (obj) => true);
            }
        }
    }
}
