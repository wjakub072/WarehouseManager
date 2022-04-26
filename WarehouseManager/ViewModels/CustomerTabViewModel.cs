using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        private ObservableCollection<Customer> _customers = new ObservableCollection<Customer>();

        public ObservableCollection<Customer> Customers
        {
            get { return _customers; }
            set { _customers = value; }

        }

        public Customer SelectedCustomer
        {
            get => _customerStore.SelectedCustomer;
            set => _customerStore.SelectedCustomer = value;
        }

        private string _importStatus;

        public string ImportStatus
        {
            get { return _importStatus; }
            set 
            { 
                _importStatus = value; 
            OnPropertyChanged(nameof(ImportStatus));
            }
        }


        public ICommand NewCustomerCommand { get; set; }
        public ICommand EditCustomerCommand { get; set; }
        public ICommand DeleteCustomerCommand { get; set; }

        public LoadCustomersListCommand InitializeCommand { get; }

        public CustomerTabViewModel(INavigationService customerNavigationService, CustomerStore customerStore)
        {
            NewCustomerCommand = new NavCommand(customerNavigationService);
            EditCustomerCommand = new EditCustomerCommand(customerNavigationService, customerStore);
            DeleteCustomerCommand = new DeleteCustomerCommand(customerStore, this);


            InitializeCommand = new LoadCustomersListCommand(customerStore, this);
            //InitializeCommand.Execute(null);

            _customerStore = customerStore;
        }
    }
}
