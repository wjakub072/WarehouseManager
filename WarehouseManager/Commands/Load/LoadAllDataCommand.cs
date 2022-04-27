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
        private readonly LoadDocumentsCommand _documents;

        public LoadAllDataCommand(LoadCustomersListCommand customers, LoadSectorsCommand sectors, LoadDocumentsCommand documents)
        {
            _customers = customers;
            _sectors = sectors;
            _documents = documents;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            await _customers.ExecuteAsync(parameter);

            await _sectors.ExecuteAsync(parameter);

            await _documents.ExecuteAsync(parameter);   
        }
    }
}
