using System.Threading.Tasks;
using WarehouseManager.Models;
using WarehouseManager.Services;
using WarehouseManager.Stores;
using WarehouseManager.ViewModels;

namespace WarehouseManager.Commands
{
    internal class SaveCustomerCommand : AsyncCommandBase
    {
        private readonly INavigationService _viewModelNavigation;
        private readonly CustomerStore _customerStore;
        private readonly AddressStore _addressStore;
        private readonly CustomerViewModel _viewModel;


        public SaveCustomerCommand(INavigationService navigationService, CustomerStore customerStore, AddressStore addressStore, CustomerViewModel viewModel)
        {
            _viewModelNavigation = navigationService;
            _customerStore = customerStore;
            _addressStore = addressStore;
            _viewModel = viewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            Customer customer = new Customer();
            customer.Name = _viewModel.Name;
            customer.NIP = _viewModel.NIP;
            customer.Origin = _viewModel.SelectedOrigin;
            customer.Country = _viewModel.Country;
            customer.City = _viewModel.City;
            customer.PostalCode = _viewModel.PostalCode;
            var split = _viewModel.Street.Split(" ");
            customer.Street = split[0];
            customer.Building = split[1];
            
            await _customerStore.AddCustomer(customer);

            if (_viewModel.AsDelivery)
            {
                Address main = new Address();
                main.CustomerId = customer.Customer_Id;
                main.Country = _viewModel.Country;
                main.City = _viewModel.City;
                main.PostalCode = _viewModel.PostalCode;
                main.Street = split[0];
                main.Building = split[1];

                _addressStore.AddAddress(main);
            }

            await _addressStore.SaveRangeToDatabase(customer.Customer_Id).ConfigureAwait(false);

            _viewModelNavigation.Navigate();
        }
    }
}
