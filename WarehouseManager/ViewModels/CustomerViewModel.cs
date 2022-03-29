using System.Windows.Input;
using WarehouseManager.Commands;
using WarehouseManager.Services;

namespace WarehouseManager.ViewModels
{
    internal class CustomerViewModel : ViewModelBase
    {
        public ICommand HomePageNavCommand { get; set; }

        public CustomerViewModel(INavigationService homeNavigationService)
        {
            HomePageNavCommand = new NavCommand(homeNavigationService);
        }
    }
}
