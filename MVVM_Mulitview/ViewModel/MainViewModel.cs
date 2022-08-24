﻿using MVVM_Mulitview.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_Mulitview.ViewModel
{
   public class MainViewModel: ViewModelBase
    {
        private ViewModelBase _selectedViewModel;

        public MainViewModel(CustomersViewModel customersViewModel, ProductsViewModel productsViewModel)
        {
            CustomersViewModel = customersViewModel;
            ProductsViewModel = productsViewModel;
            SelectedViewModel = customersViewModel;

            SelectViewModelCommand = new DelegateCommand(SelectViewModel);
        
        }

        private async void SelectViewModel(object parameter)
        {
            SelectedViewModel = parameter as ViewModelBase;
            await LoadAsync();
        }

        public ProductsViewModel ProductsViewModel { get;  }
        public CustomersViewModel CustomersViewModel { get; }

        public ViewModelBase SelectedViewModel
        {
            get => _selectedViewModel;

            set
            {
                _selectedViewModel = value;
                RaisePropretyChanged();
            }
        }

        public DelegateCommand SelectViewModelCommand { get; }
        public async override Task LoadAsync()
        {
            if(SelectedViewModel != null)
            {
                await SelectedViewModel.LoadAsync();
            }
        }


    }
}