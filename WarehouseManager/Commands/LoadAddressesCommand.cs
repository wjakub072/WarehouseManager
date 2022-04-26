using System.Threading.Tasks;
using WarehouseManager.Stores;
using WarehouseManager.ViewModels;

namespace WarehouseManager.Commands
{
    internal class LoadAddressesCommand : AsyncCommandBase
    {
        private readonly AddressStore _store;
        private readonly CustomerViewModel _viewModel;

        public LoadAddressesCommand(AddressStore store, CustomerViewModel viewModel)
        {
            _store = store;
            _viewModel = viewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            await _store.Load();

            // detect when we open existing customer and when adding new 
            _viewModel.Addresses = new System.Collections.ObjectModel.ObservableCollection<Models.Address>(_store.Addresses);
        }
    }
}
