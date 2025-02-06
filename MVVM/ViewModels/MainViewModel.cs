using DevExpress.Mvvm;
using System.Windows.Input;

namespace MVVM.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        //Поле
        private int _Clicks;

        //Свойство
        public int Clicks
        {
            get { return _Clicks; }
            set
            {
                _Clicks = value;
                RaisePropertyChanged(() => Clicks); // метод выполняет обновление нашей переменной при каждом ее сете 
                //RaisePropertyChanged(nameof(Clicks));   
            }
        }

        public ICommand ClickAdd
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    Clicks++;
                }, (obj) => Clicks < 5);
            }
        }
    }
}
