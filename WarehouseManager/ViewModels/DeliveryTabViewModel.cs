using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using WarehouseManager.Commands;
using WarehouseManager.Services;

namespace WarehouseManager.ViewModels
{
    internal class DeliveryTabViewModel : ViewModelBase
    {
        

        public ICommand NewDeliveryNavCommand { get; set; }

        public DeliveryTabViewModel(INavigationService newDeliveryNav)
        {
            NewDeliveryNavCommand = new NewDeliveryNavCommand(newDeliveryNav);
        }
    }
}
