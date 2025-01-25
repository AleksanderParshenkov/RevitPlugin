﻿using Autodesk.Revit.DB;
using RoomAffiliation.Controllers;
using RoomAffiliation.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
    }
}
