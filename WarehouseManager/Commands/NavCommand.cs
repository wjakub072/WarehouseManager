using System;
using WarehouseManager.Services;

namespace WarehouseManager.Commands
{
    internal class NavCommand : CommandBase
    {
        private readonly INavigationService _viewModelNavigation;

        public NavCommand(INavigationService viewModelNavigation)
        {
            _viewModelNavigation = viewModelNavigation;
        }

        public override void Execute(object parameter)
        {
            _viewModelNavigation.Navigate();
        }
    }
}
