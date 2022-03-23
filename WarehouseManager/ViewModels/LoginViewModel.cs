using System.Windows.Input;
using WarehouseManager.Commands;
using WarehouseManager.Services;

namespace WarehouseManager.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        public ICommand LoginCommand { get; }

        public LoginViewModel(INavigationService loginNavService)
        {
            LoginCommand = new NavCommand(loginNavService);
        }
    }
}
