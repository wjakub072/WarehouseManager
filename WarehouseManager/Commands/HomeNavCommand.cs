using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManager.Services;
using WarehouseManager.Stores;

namespace WarehouseManager.Commands
{
    internal class HomeNavCommand : CommandBase
    {
        private readonly INavigationService _viewModelNavigation;
        private readonly CustomerStore _customerStore;
        public HomeNavCommand(INavigationService viewModelNavigation, CustomerStore customerStore)
        {
            _viewModelNavigation = viewModelNavigation;
            _customerStore = customerStore;
        }

        public override void Execute(object parameter)
        {
            _customerStore.EditingMode = false;

            _viewModelNavigation.Navigate();
        }
    }
}
