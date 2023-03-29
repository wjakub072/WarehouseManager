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
        private readonly LoadAvailabilityCommand _availability;

        public LoadAllDataCommand(LoadCustomersListCommand customers, LoadSectorsCommand sectors, LoadDocumentsCommand documents, LoadAvailabilityCommand availability)
        {
            _customers = customers;
            _sectors = sectors;
            _documents = documents;
            _availability = availability;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            await _customers.ExecuteAsync(parameter);

            await _sectors.ExecuteAsync(parameter);

            await _documents.ExecuteAsync(parameter);

            await _availability.ExecuteAsync(parameter);
        }
    }
}
