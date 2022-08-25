#nullable enable 

using MVVM_Mulitview.Command;
using MVVM_Mulitview.Data;
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
        private CustomerItemViewModel? _selectedCustomer;


        public DelegateCommand AddCommand { get; }
        public DelegateCommand DeleteCommand { get; }



        public CustomersViewModel(ICustomerDataProvider customerDataProvider)
        {
            _customerDataProvider = customerDataProvider;
            AddCommand = new DelegateCommand(Add);
            DeleteCommand = new DelegateCommand(Delete, CanDelete);
        }

        // Observes when the collection is changed and gets update
        public ObservableCollection<CustomerItemViewModel> Customers { get; } = new(); //ObservableCollection<CustomerItemViewModel>();  //new();

        // ? can be null
        public CustomerItemViewModel? SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                _selectedCustomer = value;
                // RaisePropretyChanged(nameof(SelectedCustomer));
                RaisePropretyChanged();
               // RaisePropretyChanged(nameof(IsCustomerSelected));
                DeleteCommand.RaiseCanExecuteChanged();

            }
        }

        //public bool IsCustomerSelected => SelectedtuCustomer;


        
        public async override Task LoadAsync()
        {
            // Check if there is already anyting in customers.
            if (Customers.Any())
            {
                return;
            }
            // GetAllAsync is method of dataProvider
            var customers = await _customerDataProvider.GetAllAsync();
           if (customers is not null)
          //  {
                foreach (var customer in customers)
                {
                    if(customer.FirstName != null)
                        Customers.Add(new CustomerItemViewModel(customer));
                }
           // }

        }
        
        // Adding customer 



        private void Delete(object? parameter)
        {
            if (SelectedCustomer is not null)
            {
                Customers.Remove(SelectedCustomer);
                SelectedCustomer = null;
            }
        }


        private bool CanDelete(object? parameter)
        {
            return SelectedCustomer is not null; 
        }


        // yes here 
        internal void Add(object? parameter)
        {
            var customer = new Customer { FirstName = "New" };
            var viewModel = new CustomerItemViewModel(customer);
            Customers.Add(viewModel);
            SelectedCustomer = viewModel;

        }



    }
}
