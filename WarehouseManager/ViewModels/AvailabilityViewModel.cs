using System.Collections.Generic;
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

        private string _importStatus;

        public string ImportStatus
        {
            get { return _importStatus; }
            set
            {
                _importStatus = value;
                OnPropertyChanged(nameof(ImportStatus));
            }
        }

        private ICommand initializeCommand;

        public AvailabilityViewModel(AvailabilityStore availabilityStore)
        {
            _availabilityStore = availabilityStore;
            //assign which store to load through parameter
            initializeCommand = new LoadingCommand(_availabilityStore);
            //execute async command
            //initializeCommand.Execute(null);
        }
    }
}
