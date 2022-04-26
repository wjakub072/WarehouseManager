using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WarehouseManager.Commands;
using WarehouseManager.Services;

namespace WarehouseManager.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        public ICommand LoginCommand { get; }

        private string _warehouseCode;

        public string WarehouseCode
        {
            get { return _warehouseCode; }
            set 
            { 
                _warehouseCode = value; 
                OnPropertyChanged(nameof(WarehouseCode));
            }
        }

        private string _login;

        public string Login
        {
            get { return _login; }
            set
            {
                _login = value;
                OnPropertyChanged(nameof(Login));
            }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set 
            { 
                _password = value; 
                OnPropertyChanged(nameof(Password));
            }
        }

        private System.Windows.Visibility _warehouseHint = Visibility.Visible;

        public System.Windows.Visibility WarehouseHint
        {
            get { return _warehouseHint; }
            set
            {
                _warehouseHint = value;
                OnPropertyChanged(nameof(WarehouseHint));
            }
        }

        private System.Windows.Visibility _loginHint = Visibility.Visible;

        public System.Windows.Visibility LoginHint
        {
            get { return _loginHint; }
            set 
            {
                _loginHint = value; 
                OnPropertyChanged(nameof(LoginHint));
            }
        }

        private System.Windows.Visibility _passwordHint = Visibility.Visible;

        public System.Windows.Visibility PasswordHint
        {
            get { return _passwordHint; }
            set 
            { 
                _passwordHint = value; 
                OnPropertyChanged(nameof(PasswordHint));
            }
        }


        public LoginViewModel(INavigationService loginNavService)
        {
            LoginCommand = new NavCommand(loginNavService);
        }
    }
}
