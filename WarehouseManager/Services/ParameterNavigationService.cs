using System;
using WarehouseManager.Stores;
using WarehouseManager.ViewModels;

namespace WarehouseManager.Services
{
    internal class ParameterNavigationService : IParameterNavigationService
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<object, ViewModelBase> _createViewModel;

        public ParameterNavigationService(NavigationStore navigationStore, Func<object, ViewModelBase> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }

        public void Navigate(object parameter)
        {
            _navigationStore.CurrentViewModel = _createViewModel(parameter);
        }
    }
}
