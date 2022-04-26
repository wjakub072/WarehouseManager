using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManager.Commands
{
    internal class LoadAllDataCommand : AsyncCommandBase
    {
        private readonly LoadCustomersListCommand _customers;
        private readonly LoadSectorsCommand _sectors;

        public LoadAllDataCommand(LoadCustomersListCommand customers, LoadSectorsCommand sectors)
        {
            _customers = customers;
            _sectors = sectors;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            await _customers.ExecuteAsync(parameter);

            await _sectors.ExecuteAsync(parameter);
        }
    }
}
