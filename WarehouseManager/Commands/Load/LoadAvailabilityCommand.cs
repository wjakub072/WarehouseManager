using System.Threading.Tasks;
using WarehouseManager.Stores;
using WarehouseManager.ViewModels;

namespace WarehouseManager.Commands
{
    internal class LoadAvailabilityCommand : AsyncCommandBase
    {
        private readonly AvailabilityStore store;
        private readonly AvailabilityViewModel _viewModel;

        public LoadAvailabilityCommand(AvailabilityStore store, AvailabilityViewModel viewModel)
        {
            this.store = store;
            _viewModel = viewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            await store.Load();

            _viewModel.Availabilities.Clear();
            foreach (var ava in store.Availabilities)
            {
                _viewModel.Availabilities.Add(ava);
            }
        }
    }
}
