using System.Collections.ObjectModel;
using System.Windows.Input;
using WarehouseManager.Commands;

namespace WarehouseManager.ViewModels
{
    internal class HomePageViewModel : ViewModelBase
    {
        private Collection<ViewModelBase> _tabElements;

        public Collection<ViewModelBase> TabElements
        {
            get { return _tabElements; }
            set 
            { 
                _tabElements = value; 
                OnPropertyChanged(nameof(TabElements));
            }
        }
        private int _selectedIndex;

        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set 
            { 
                _selectedIndex = value; 
                OnPropertyChanged(nameof(SelectedIndex));
            }
        }

        private ICommand LoadAllDataCommand;

        public HomePageViewModel(CustomerTabViewModel customerTabViewModel, AvailabilityViewModel availabilityViewModel, DeliveryTabViewModel deliveryTabViewModel, WarehouseInfoTabViewModel infoTabViewModel)
        {
            _tabElements = new Collection<ViewModelBase>()
            {
                customerTabViewModel, availabilityViewModel, deliveryTabViewModel, infoTabViewModel
            };
            LoadAllDataCommand = new LoadAllDataCommand(
                customerTabViewModel.InitializeCommand,
                infoTabViewModel.InitializeCommand, 
                deliveryTabViewModel.LoadDocumentsCommand,
                availabilityViewModel.initializeCommand);

            LoadAllDataCommand.Execute(null);
        }

    }
}
