using WarehouseManager.Models;
using WarehouseManager.Stores;
using WarehouseManager.ViewModels;

namespace WarehouseManager.Commands
{
    internal class AddAddressCommand : CommandBase
    {
        private readonly AddressStore _store;
        private readonly CustomerViewModel _viewModel;

        public AddAddressCommand(AddressStore store, CustomerViewModel customerViewModel)
        {
            _store = store;
            _viewModel = customerViewModel;
        }

        public override void Execute(object parameter)
        {
            Address address = new Models.Address() { Country = "PL" };

            //add to store container to keep tracking
            _store.AddAddress(address);

            //add to view representation
            _viewModel.Addresses.Add(address);
        }
    }
}
