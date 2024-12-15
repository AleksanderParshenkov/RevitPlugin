﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.VisualStyles;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DimensionsControl.Views
{
    /// <summary>
    /// Логика взаимодействия для ReportMessageWindow.xaml
    /// </summary>
    public partial class ReportMessageWindow : Window
    {
        public ReportMessageWindow()
        {
            InitializeComponent();
            this.Show();
        }

        private void btn_AproveWrite_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
