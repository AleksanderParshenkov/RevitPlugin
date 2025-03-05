using AffiliationRoom.Models;
using AffiliationRoom.Services;
using DevExpress.Mvvm;
using System.Collections.ObjectModel;
using Autodesk.Revit.DB;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows;
using System;

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
                    SetAffiliation.SetAffiliationMethod(SelectedLinkDocument);                    
                }, (obj) => SelectedLinkDocument != null);
            }
        }
    }
}
