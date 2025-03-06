using AffiliationRoom.Models;
using AffiliationRoom.Services;
using DevExpress.Mvvm;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AffiliationRoom.ViewModels
{
    class MainViewModel : ViewModelBase
    {        
        public ObservableCollection<ParametersCouple> ParametersCouples { get; set; }     
        public ObservableCollection<LinkDocument> LinkDocuments { get; set; }
        public LinkDocument SelectedLinkDocument { get; set; }


        public MainViewModel()
        {
            ParametersCouples = new ObservableCollection<ParametersCouple>(DataBase.GetParametersCouple());

            LinkDocuments = new ObservableCollection<LinkDocument>(GetLinkDocumentList.GetLinkDocumentListMethod());
        }

        public ICommand Click_SetAffiliation
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    SetAffiliation.SetAffiliationMethod(SelectedLinkDocument, ParametersCouples);                    
                }, (obj) => SelectedLinkDocument != null);
            }
        }

        public ICommand Click_GetParametersCouplesFromFile
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    ParametersCouples = new ObservableCollection<ParametersCouple>(SupportJsonMethods.Deserialization());
                    RaisePropertyChanged(() => ParametersCouples);
                }, (obj) => true);
            }
        }

        public ICommand Click_SaveParametersCouplesToFile
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    SupportJsonMethods.Serialization(ParametersCouples);
                }, (obj) => true);
            }
        }
    }
}
