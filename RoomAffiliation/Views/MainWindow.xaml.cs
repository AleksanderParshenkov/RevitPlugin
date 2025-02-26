using Autodesk.Revit.DB;
using RoomAffiliation.Controllers;
using RoomAffiliation.Models;
using RoomAffiliation.Support;
using System.Collections.Generic;
using System.Windows;

namespace RoomAffiliation.Views
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();            
        }

        private void btn_WriteAffiliation_Click(object sender, RoutedEventArgs e)
        {
            if (this.cmb_LinkedModels.SelectedItem != null)
            {
                GetLinkController getLinkController = new GetLinkController(this.cmb_LinkedModels.SelectedItem as RevitLinkInstance);

                MainConfigParameters.ParametersCouple = SupportMethods.GetCoupleParametersList(this);

                this.Close();
            }
        }

        private void btn_SaveConfigJson_Click(object sender, RoutedEventArgs e)
        {
            List<ParametersCouple> ParametersCoupleList = new List<ParametersCouple>()
            {
                new ParametersCouple {RoomParameter = this.tb_ParameterRoom_1.Text,ElementParameter =  this.tb_ParameterElement_1.Text },
                new ParametersCouple {RoomParameter = this.tb_ParameterRoom_2.Text,ElementParameter =  this.tb_ParameterElement_2.Text },
                new ParametersCouple {RoomParameter = this.tb_ParameterRoom_3.Text,ElementParameter =  this.tb_ParameterElement_3.Text },
                new ParametersCouple {RoomParameter = this.tb_ParameterRoom_4.Text,ElementParameter =  this.tb_ParameterElement_4.Text },
                new ParametersCouple {RoomParameter = this.tb_ParameterRoom_5.Text,ElementParameter =  this.tb_ParameterElement_5.Text },
            };

            SupportJsonMethods.Serialization(ParametersCoupleList);
        }

        private void btn_GetConfigJson_Click(object sender, RoutedEventArgs e)
        {
            // Получаем список пар параметров из json файла
            List<ParametersCouple> ParametersCoupleList = SupportJsonMethods.Deserialization();
            
            if (ParametersCoupleList.Count < 1 || ParametersCoupleList.Count > 5) { MessageBox.Show("Файл json содержит ошибку"); return; }


            // Записываем значения в текстовые поля интерфейса
            // Строка 1
            tb_ParameterRoom_1.Text = ParametersCoupleList[0].RoomParameter;
            tb_ParameterElement_1.Text = ParametersCoupleList[0].ElementParameter;

            // Строка 2
            tb_ParameterRoom_2.Text = ParametersCoupleList[1].RoomParameter;
            tb_ParameterElement_2.Text = ParametersCoupleList[1].ElementParameter;

            // Строка 3
            tb_ParameterRoom_3.Text = ParametersCoupleList[2].RoomParameter;
            tb_ParameterElement_3.Text = ParametersCoupleList[2].ElementParameter;

            // Строка 4
            tb_ParameterRoom_4.Text = ParametersCoupleList[3].RoomParameter;
            tb_ParameterElement_4.Text = ParametersCoupleList[3].ElementParameter;

            // Строка 5
            tb_ParameterRoom_5.Text = ParametersCoupleList[4].RoomParameter;
            tb_ParameterElement_5.Text = ParametersCoupleList[4].ElementParameter;
        }
    }
}
