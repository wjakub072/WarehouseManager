using System.Windows.Input;
using WarehouseManager.Commands;
using WarehouseManager.Services;

namespace WarehouseManager.ViewModels
{
    internal class DeliveryTabViewModel : ViewModelBase
    {
        public ICommand NewDeliveryNavCommand { get; set; }

        public DeliveryTabViewModel(INavigationService newDeliveryNav)
        {
            NewDeliveryNavCommand = new NavCommand(newDeliveryNav);
        }
    }
}
