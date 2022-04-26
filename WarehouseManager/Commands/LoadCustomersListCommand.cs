using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManager.Stores;
using WarehouseManager.ViewModels;

namespace WarehouseManager.Commands
{
    internal class LoadCustomersListCommand : AsyncCommandBase
    {
        private readonly CustomerStore _customerStore;
        private readonly CustomerTabViewModel _viewModel;

        public LoadCustomersListCommand(CustomerStore customerStore, CustomerTabViewModel viewModel)
        {
            _customerStore = customerStore;
            _viewModel = viewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            await _customerStore.Load();

            //_viewModel.Customers = new System.Collections.ObjectModel.ObservableCollection<Models.Customer>(_customerStore.Customers);
            _viewModel.Customers.Clear();
            foreach (var customer in _customerStore.Customers)
            {
                _viewModel.Customers.Add(customer);
            }
        }
    }
}
