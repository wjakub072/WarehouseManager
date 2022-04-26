using System.Windows.Input;
using WarehouseManager.Commands;
using WarehouseManager.Services;

namespace WarehouseManager.ViewModels
{
    internal class DeliveryTabViewModel : ViewModelBase
    {
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

        public ICommand NewDeliveryNavCommand { get; set; }

        public DeliveryTabViewModel(INavigationService newDeliveryNav)
        {
            NewDeliveryNavCommand = new NavCommand(newDeliveryNav);
        }
    }
}
