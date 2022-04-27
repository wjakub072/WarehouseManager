using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManager.Stores;
using WarehouseManager.ViewModels;

namespace WarehouseManager.Commands
{
    internal class DeleteCustomerCommand : AsyncCommandBase
    {
        private readonly CustomerStore _customerStore;
        private readonly CustomerTabViewModel _viewModel;

        public DeleteCustomerCommand(CustomerStore customerStore, CustomerTabViewModel viewModel)
        {
            _customerStore = customerStore;
            _viewModel = viewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            await _customerStore.DeleteCustomer();
            
            _viewModel.Customers.Remove(_customerStore.SelectedCustomer);
        }
    }
}
