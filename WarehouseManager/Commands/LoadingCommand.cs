using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManager.Stores;

namespace WarehouseManager.Commands
{
    internal class LoadingCommand : AsyncCommandBase
    {
        private readonly StoreBase store;

        public LoadingCommand(StoreBase store)
        {
            this.store = store;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            await store.Load();
        }
    }
}
