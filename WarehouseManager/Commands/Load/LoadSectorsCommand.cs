using System.Threading.Tasks;
using WarehouseManager.Stores;
using WarehouseManager.ViewModels;

namespace WarehouseManager.Commands
{
    internal class LoadSectorsCommand : AsyncCommandBase
    {
        private readonly SectorStore _sectorStore;
        private readonly WarehouseInfoTabViewModel _viewModel;

        public LoadSectorsCommand(SectorStore sectorStore, WarehouseInfoTabViewModel viewModel)
        {
            _sectorStore = sectorStore;
            _viewModel = viewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            await _sectorStore.Load();

            _viewModel.Sectors.Clear();
            foreach (var sector in _sectorStore.Sectors)
            {
                _viewModel.Sectors.Add(sector);
            }
        }
    }
}
