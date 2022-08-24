﻿using MVVM_Mulitview.Data;
using MVVM_Mulitview.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_Mulitview.ViewModel
{
    public class CustomersViewModel : ViewModelBase
    {
        // Providing data from dataProvider
        private readonly ICustomerDataProvider _customerDataProvider;
        private CustomerItemViewModel _selectedCustomer;

        public CustomersViewModel(ICustomerDataProvider customerDataProvider)
        {
            _customerDataProvider = customerDataProvider;
        }

        // Observes when the collection is changed and gets update
        public ObservableCollection<CustomerItemViewModel> Customers { get; } = new ObservableCollection<CustomerItemViewModel>();  //new();

        // ? can be null
        public CustomerItemViewModel SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                _selectedCustomer = value;
                // RaisePropretyChanged(nameof(SelectedCustomer));
                RaisePropretyChanged();
            }
        }

       // public bool IsCustomerSelected => SelectedCustomer ;


        /*
        public async override Task LoadAsync()
        {
            // Check if there is already anyting in customers.
            if (Customers.Any())
            {
                return;
            }
            // GetAllAsync is method of dataProvider
            var customers = await _customerDataProvider.GetAllAsync();
         //   if (customers is not null)
          //  {
                foreach (var customer in customers)
                {
                    if(customer.FirstName != null)
                        Customers.Add(new CustomerItemViewModel(customer));
                }
           // }

        }
        */
        // Adding customer 
        internal void Add()
        {
            var customer = new Customer { FirstName = "New" };
            var viewModel = new CustomerItemViewModel(customer);
            Customers.Add(viewModel);
            SelectedCustomer = viewModel;

        }



    }
}
