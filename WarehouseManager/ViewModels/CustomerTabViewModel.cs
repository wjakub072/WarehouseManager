using System.Collections.Generic;
using System.Windows.Input;
using WarehouseManager.Commands;
using WarehouseManager.Models;
using WarehouseManager.Services;
using WarehouseManager.Stores;

namespace WarehouseManager.ViewModels
{
    internal class CustomerTabViewModel : ViewModelBase
    {
        private readonly CustomerStore _customerStore;

        public IEnumerable<Customer> Customers => _customerStore.Customers;
        public Customer SelectedCustomer => _customerStore.SelectedCustomer;

        public ICommand NewCustomerCommand { get; set; }
        public ICommand EditCustomerCommand { get; set; }
        public ICommand DeleteCustomerCommand { get; set; }

        private ICommand initializeCommand;

        public CustomerTabViewModel(INavigationService customerNavigationService, CustomerStore customerStore)
        {
            NewCustomerCommand = new NavCommand(customerNavigationService);
            _customerStore = customerStore;

            initializeCommand = new LoadingCommand(_customerStore);
            initializeCommand.Execute(null);
        }
    }
}
