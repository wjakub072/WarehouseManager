using System;
using WarehouseManager.ViewModels;

namespace WarehouseManager.Stores
{
    public class NavigationStore
    {
        private ViewModelBase _currentViewModel;

        public ViewModelBase CurrentViewModel
        {
            get { return _currentViewModel; }
            set
            {
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        public NavigationStore()
        {
            _currentViewModel = new AddCollectiveOrderViewModel(dbContext);
        }

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }

        public event Action? CurrentViewModelChanged;
    }
}
