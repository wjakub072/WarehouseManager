using System.Linq;
using System.Threading.Tasks;
using WarehouseManager.Models;
using WarehouseManager.Stores;
using WarehouseManager.ViewModels;

namespace WarehouseManager.Commands
{
    internal class LoadCustomerCommand : AsyncCommandBase
    {
        private readonly AddressStore _addressStore;
        private readonly CustomerStore _customerStore;
        private readonly CustomerViewModel _viewModel;

        public LoadCustomerCommand(CustomerStore customerStore, AddressStore addressStore, CustomerViewModel viewModel)
        {
            _customerStore = customerStore;
            _addressStore = addressStore;
            _viewModel = viewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            if (_customerStore.SelectedCustomer == null)
            {
                throw new System.Exception("There is no customer selected to edit");
            }
            Customer editingCustomer = _customerStore.SelectedCustomer;

            _viewModel.Name = editingCustomer.Name;
            _viewModel.NIP = editingCustomer.NIP;
            _viewModel.SelectedOrigin = editingCustomer.Origin;
            _viewModel.Country = editingCustomer.Country;
            _viewModel.City = editingCustomer.City;
            _viewModel.Street = editingCustomer.Street + editingCustomer.Building;
            _viewModel.PostalCode = editingCustomer.PostalCode;

            await _addressStore.Load();

            if (_addressStore.Addresses == null || _addressStore.Addresses.Count() == 0)
            {
                return;
            }

            var customerAddresses = _addressStore.Addresses.Where(a => a.CustomerId == editingCustomer.Customer_Id && a.IsDefault == 0).ToList();

            _viewModel.Addresses.Clear();
            foreach (var address in customerAddresses)
            {
                _viewModel.Addresses.Add(address);
            }
        }
    }
}
