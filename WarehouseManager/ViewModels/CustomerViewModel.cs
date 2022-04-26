using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WarehouseManager.Commands;
using WarehouseManager.Models;
using WarehouseManager.Services;
using WarehouseManager.Stores;

namespace WarehouseManager.ViewModels
{
    internal class CustomerViewModel : ViewModelBase
    {
        #region Binding Props
        private string _name;

        public string Name
        {
            get { return _name; }
            set 
            { 
                _name = value; 
                OnPropertyChanged(nameof(Name));
            }
        }

        private string _nip;

        public string NIP
        {
            get { return _nip; }
            set
            {
                _nip = value;
                OnPropertyChanged(nameof(NIP));
            }
        }

        private string _country;

        public string Country
        {
            get { return _country; }
            set 
            { 
                _country = value; 
                OnPropertyChanged(nameof(Country));
            }
        }

        private string _city;

        public string City
        {
            get { return _city; }
            set
            {
                _city = value;
                OnPropertyChanged(nameof(City));
            }
        }

        private string _street;

        public string Street
        {
            get { return _street; }
            set 
            { 
                _street = value; 
                OnPropertyChanged(nameof(Street));
            }
        }

        private string _postalCode;

        public string PostalCode
        {
            get { return _postalCode; }
            set
            {
                _postalCode = value;
                OnPropertyChanged(nameof(PostalCode));
            }
        }

        private bool _asDelivery;

        public bool AsDelivery
        {
            get { return _asDelivery; }
            set { _asDelivery = value; }
        }

        private List<string> _origin = new List<string>() { "Krajowy", "Unijny", "Pozaunijny" };

        public List<string> Origin
        {
            get { return _origin; }
            set { _origin = value; }
        }
        #endregion

        public ICommand HomePageNavCommand { get; set; }
        public ICommand SaveAndNavCommand { get; set; }
        public ICommand AddAddressCommand { get; set; }
        public ICommand DeleteAddressCommand { get; set; }
        private ICommand initializeCommand;


        private readonly AddressStore _addressStore;

        //public IEnumerable<Address> Addresses => _addressStore.Addresses;
        private ObservableCollection<Address> _addresses;

        public ObservableCollection<Address> Addresses
        {
            get { return _addresses; }
            set { _addresses = value; }
        }


        public CustomerViewModel(INavigationService homeNavigationService, AddressStore addressStore)
        {
            _addressStore = addressStore;
            initializeCommand = new LoadAddressesCommand(addressStore, this);

            HomePageNavCommand = new NavCommand(homeNavigationService);

            AddAddressCommand = new AddAddressCommand(_addressStore, this);
            DeleteAddressCommand = new DeleteAddressCommand(_addressStore);
            //if new customer just make new 
            _addresses = new ObservableCollection<Address>();
        }
    }
}
