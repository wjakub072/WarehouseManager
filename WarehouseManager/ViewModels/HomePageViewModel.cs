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

        public HomePageViewModel(ProductsTabViewModel productsTabViewModel, AvailabilityViewModel availabilityViewModel, DeliveryTabViewModel deliveryTabViewModel)
        {
            _tabElements = new Collection<ViewModelBase>()
            {
                productsTabViewModel, availabilityViewModel, deliveryTabViewModel
            };
        }

    }
}
