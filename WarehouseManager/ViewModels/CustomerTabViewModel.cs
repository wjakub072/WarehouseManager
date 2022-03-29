using System.Windows.Input;
using WarehouseManager.Commands;
using WarehouseManager.Services;

namespace WarehouseManager.ViewModels
{
    internal class CustomerTabViewModel : ViewModelBase
    {
        public ICommand NewCustomerCommand { get; set; }

        public CustomerTabViewModel(INavigationService customerNavigationService)
        {
            NewCustomerCommand = new NavCommand(customerNavigationService);
        }
    }
}
