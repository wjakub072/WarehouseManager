using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WarehouseManager.Commands;
using WarehouseManager.Models;
using WarehouseManager.Stores;

namespace WarehouseManager.ViewModels
{
    internal class AvailabilityViewModel : ViewModelBase
    {
        private readonly AvailabilityStore _availabilityStore;

        public IEnumerable<Availability> Availabilities => _availabilityStore.Availabilities;

        private ICommand initializeCommand;

        public AvailabilityViewModel(AvailabilityStore availabilityStore)
        {
            _availabilityStore = availabilityStore;
            //assign which store to load through parameter
            initializeCommand = new LoadingCommand(_availabilityStore);
            //execute async command
            initializeCommand.Execute(null);
        }
    }
}
