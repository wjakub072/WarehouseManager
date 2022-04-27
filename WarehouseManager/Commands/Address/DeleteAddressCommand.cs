using WarehouseManager.Stores;
using WarehouseManager.ViewModels;

namespace WarehouseManager.Commands
{
    internal class DeleteAddressCommand : CommandBase
    {
        private readonly AddressStore _store;
        private readonly CustomerViewModel _viewModel;

        public DeleteAddressCommand(AddressStore store, CustomerViewModel viewModel)
        {
            _store = store;
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            _store.DeleteAddress();

            _viewModel.Addresses.Remove(_store.SelectedAddress);
        }
    }
}
