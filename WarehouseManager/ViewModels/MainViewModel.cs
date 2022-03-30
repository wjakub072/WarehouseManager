using System.Windows;
using System.Windows.Input;
using WarehouseManager.Stores;

namespace WarehouseManager.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;

        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;

        public MainViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;

            _navigationStore.CurrentViewModelChanged += OnCurrentVieModelChanged;
        }

        private void OnCurrentVieModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
