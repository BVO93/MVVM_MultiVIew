﻿using MVVM_Mulitview.Data;
using MVVM_Mulitview.ViewModel;
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

namespace MVVM_Mulitview.View
{
    /// <summary>
    /// Interaction logic for CustomersView.xaml
    /// </summary>
    public partial class CustomersView : UserControl
    {
        //private CustomersViewModel _viewModel;
        public CustomersView()
        {
            InitializeComponent();
          //  _viewModel = new CustomersViewModel(new CustomerDataProvider());
            // set dataContect to the VM
           // DataContext = _viewModel;
            // Make event for Loaded
           // Loaded += CustomersView_Loaded;
        }

        /*

        // Fire event when there
        private async void CustomersView_Loaded(object sender, RoutedEventArgs e)
        {
            await _viewModel.LoadAsync();
        }

        */
        private void ButtonMoveNavigation_Click(object sender, RoutedEventArgs e)
        {
            //var column = (int)customerListGrid.GetValue(Grid.ColumnProperty);

            //var newColumn = column == 0 ? 2 : 0;
            //customerListGrid.SetValue(Grid.ColumnProperty, newColumn);

         //   var column = Grid.GetColumn(customerListGrid);

            //var newColumn = column == 0 ? 2 : 0;
            //Grid.SetColumn(customerListGrid, newColumn);
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            // Just call the viewmodel and make a method 
        //    _viewModel.Add();
        }
        

    }
}
