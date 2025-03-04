using AffiliationRoom.Models;
using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AffiliationRoom.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        // Свойство
        public ObservableCollection<ParametersCouple> ParametersCouples { get; set; } // Коллекция которая сама реализует INotifyCollectionChanged (НЕ ЛИСТ!!!)
        // При изменении коллекция оповещает что она изменилась

        // Дополнительное свойство выбранного элемента в окне
        public ParametersCouple SelectedParametersCouple { get; set; }

        //Конструктор
        public MainViewModel()
        {
            ParametersCouples = new ObservableCollection<ParametersCouple>(DataBase.GetParametersCouple());
        }
    }
}
