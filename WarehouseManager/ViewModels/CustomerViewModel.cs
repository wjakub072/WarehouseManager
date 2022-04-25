using System.Collections.Generic;
using System.Windows.Input;
using WarehouseManager.Commands;
using WarehouseManager.Models;
using WarehouseManager.Services;
using WarehouseManager.Stores;

namespace WarehouseManager.ViewModels
{
    internal class CustomerViewModel : ViewModelBase
    {
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

        public List<string> Origin = new List<string>() { "Krajowy", "Unijny", "Pozaunijny" };

        public ICommand HomePageNavCommand { get; set; }
        public ICommand SaveAndNavCommand { get; set; }
        public ICommand AddAddressCommand { get; set; }
        public ICommand DeleteAddressCommand { get; set; }

        private readonly AddressStore _addressStore;

        public IEnumerable<Address> Addresses => _addressStore.Addresses;

        public CustomerViewModel(INavigationService homeNavigationService, AddressStore addressStore)
        {
            _addressStore = addressStore;

            HomePageNavCommand = new NavCommand(homeNavigationService);

            AddAddressCommand = new AddAddressCommand(_addressStore);
            DeleteAddressCommand = new DeleteAddressCommand(_addressStore);

        }
    }
}
