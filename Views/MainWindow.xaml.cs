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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace testtask1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly StockPriceViewModel View = new StockPriceViewModel();
        public MainWindow()
        {
            this.DataContext = View;

            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            View.LoadPrices();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            View.Amount = (int)Combo.SelectedItem;
        }
    }
}
