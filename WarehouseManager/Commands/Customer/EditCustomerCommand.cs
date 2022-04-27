using WarehouseManager.Services;
using WarehouseManager.Stores;

namespace WarehouseManager.Commands
{
    internal class EditCustomerCommand : CommandBase
    {
        private readonly INavigationService _navigationService;
        private readonly CustomerStore _customerStore;

        public EditCustomerCommand(INavigationService navigationService, CustomerStore customerStore)
        {
            _navigationService = navigationService;
            _customerStore = customerStore;
        }

        public override void Execute(object parameter)
        {
            if (_customerStore.SelectedCustomer == null)
            {
                return;
            }
            _customerStore.EditingMode = true;
            _navigationService.Navigate();
        }
    }
}
