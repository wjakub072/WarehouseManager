using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WarehouseManager.Commands;
using WarehouseManager.Models;
using WarehouseManager.Stores;

namespace WarehouseManager.ViewModels
{
    internal class AvailabilityViewModel : ViewModelBase
    {
        private readonly AvailabilityStore _availabilityStore;


        private ObservableCollection<Availability> _availabilities = new ObservableCollection<Availability>();

        public ObservableCollection<Availability> Availabilities
        {
            get { return _availabilities; }
            set { _availabilities= value; }
        }


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

        public LoadAvailabilityCommand initializeCommand { get; set; }

        public AvailabilityViewModel(AvailabilityStore availabilityStore)
        {
            _availabilityStore = availabilityStore;
            //assign which store to load through parameter
            initializeCommand = new LoadAvailabilityCommand(_availabilityStore, this);
            //execute async command
        }
    }
}
