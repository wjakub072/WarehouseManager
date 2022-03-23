using System.Collections.ObjectModel;

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

        public HomePageViewModel(CustomerTabViewModel customerTabViewModel, AvailabilityViewModel availabilityViewModel, DeliveryTabViewModel deliveryTabViewModel, WarehouseInfoTabViewModel infoTabViewModel)
        {
            _tabElements = new Collection<ViewModelBase>()
            {
                customerTabViewModel, availabilityViewModel, deliveryTabViewModel, infoTabViewModel
            };
        }

    }
}
