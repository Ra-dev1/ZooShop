﻿using System;
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
using System.Windows.Shapes;
using ZooShop.Data;
using ZooShop.Data.Validators;

namespace ZooShop.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для SetAmountWindow.xaml
    /// </summary>
    public partial class SetAmountWindow : Window
    {
        public SetAmountWindow()
        {
            InitializeComponent();
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
        public string Amount 
        {
            get { return AmountTB.Text; }
        }
    }
}
