using System.Threading.Tasks;
using WarehouseManager.Stores;

namespace WarehouseManager.Commands
{
    internal class LoadPackagesCommand : AsyncCommandBase
    {
        private readonly PackageStore _store;

        public LoadPackagesCommand(PackageStore store)
        {
            _store = store;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            await _store.Load();
        }
    }
}
