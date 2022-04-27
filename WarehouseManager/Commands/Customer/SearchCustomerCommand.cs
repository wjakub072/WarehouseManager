using System.Linq;
using System.Windows;
using WarehouseManager.Stores;
using WarehouseManager.ViewModels;

namespace WarehouseManager.Commands
{
    internal class SearchCustomerCommand : CommandBase
    {
        private readonly CustomerStore _customerStore;
        private readonly AddressStore _addressStore;
        private DeliveryViewModel _viewModel;

        public SearchCustomerCommand(CustomerStore store, AddressStore addressStore, DeliveryViewModel viewModel)
        {
            _customerStore = store;
            _addressStore = addressStore;
            _viewModel = viewModel;
        }

        public override async void Execute(object parameter)
        {
            string nip = _viewModel.NIP;
            if (string.IsNullOrEmpty(nip))
            {
                return;
            }

            var selected = _customerStore.Customers.Where(c => c.NIP == nip).FirstOrDefault();
            if (selected == null)
            {
                MessageBox.Show("Kontrahent o podanym nipie nie został odnaleziony.");
                return;
            }

            _viewModel.Customer = selected;
            _viewModel.CustomerName = selected.Name;
            _viewModel.NIP = nip;
            _viewModel.CustomerOrigin = selected.Origin;

            await _addressStore.LoadForCustomer(selected.Customer_Id);

            _viewModel.CustomerAddresses.Clear();
            foreach (var address in _addressStore.Addresses)
            {
                _viewModel.CustomerAddresses.Add(address);
            }
        }
    }
}
