using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using WarehouseManager.Commands;
using WarehouseManager.Services;

namespace WarehouseManager.ViewModels
{
    internal class NewDeliveryViewModel : ViewModelBase
    {
        

        public ICommand HomePageNavCommand{ get; set; }

        public NewDeliveryViewModel(INavigationService homeNavigationService)
        {
            HomePageNavCommand = new NavCommand(homeNavigationService);
        }

    }
}
