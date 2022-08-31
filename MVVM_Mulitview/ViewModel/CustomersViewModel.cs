#nullable enable 

using MVVM_Mulitview.Command;
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
        // Observes when the collection is changed and gets update
        public ObservableCollection<CustomerItemViewModel> Customers { get; } = new();

        private CustomerItemViewModel? _selectedCustomer;
        private NavigationSide _navigationSide;

        public CustomersViewModel()
        {
        
            AddCommand = new DelegateCommand(Add);
            MoveNavigationCommand = new DelegateCommand(MoveNavigation);
            DeleteCommand = new DelegateCommand(Delete, CanDelete);
            SaveCustomersCommand = new DelegateCommand(SaveCustomers);


            var customer = new Customer { FirstName = "Bjorn", LastName = "VO", IsDeveloper = false };
            var viewModel = new CustomerItemViewModel(customer);
            Customers.Add(viewModel);
             customer = new Customer { FirstName = "John", LastName = "Do", IsDeveloper = true };
             viewModel = new CustomerItemViewModel(customer);
            Customers.Add(viewModel);

        }



        // ? can be null
        public CustomerItemViewModel? SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                _selectedCustomer = value;
                // RaisePropretyChanged(nameof(SelectedCustomer));
                RaisePropretyChanged();

                RaisePropretyChanged(nameof(IsCustomerSelected));
                DeleteCommand.RaiseCanExecuteChanged();
            }
        }

        // We want to check if there is a cusomter selected. If not we want details like name to be invisible. 
        // We check if customer is selected. Ans also raise the raisepropertyChanged event when a custoemr gets selected or deselected.
        public bool IsCustomerSelected => SelectedCustomer is not null;

        public NavigationSide navigationSide
        {
            get => _navigationSide;
            private set
            {
                _navigationSide = value;
                RaisePropretyChanged();
            }
        }


        public DelegateCommand AddCommand { get; }
        public DelegateCommand MoveNavigationCommand { get; }
        public DelegateCommand DeleteCommand { get; }

        public DelegateCommand SaveCustomersCommand { get;  }

        public async override Task LoadAsync()
        {

            return;
        }



        // Adding customer 
        private void Add(object? parameter)
        {
            var customer = new Customer { FirstName = "New" };
            var viewModel = new CustomerItemViewModel(customer);
            Customers.Add(viewModel);
            SelectedCustomer = viewModel;

        }

        private void MoveNavigation(object? parameter)
        {

            if (_navigationSide == NavigationSide.Left)
            {
                navigationSide = NavigationSide.Right;
            }
            else
            {
                navigationSide = NavigationSide.Left;
            }

        }



        private void Delete(object? parameter)
        {
            if (SelectedCustomer is not null)
            {
                Customers.Remove(SelectedCustomer);
                SelectedCustomer = null;
            }
        }

        private void SaveCustomers(object? parameter)
        {
            
            // HERE I SHOULD GET THE LOCATION TO SAVE TO. So i can save all the customers in the collection.


            return;

        }

        private bool CanDelete(object? parameter)
        {
            return SelectedCustomer is not null;
        }



        public enum NavigationSide
        {
            Left,
            Right
        }


    }
}
