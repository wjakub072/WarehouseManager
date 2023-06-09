﻿using System.Collections.Generic;
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

        private string _selectedOrigin;

        public string SelectedOrigin
        {
            get { return _selectedOrigin; }
            set 
            { 
                _selectedOrigin = value; 
                OnPropertyChanged(nameof(SelectedOrigin));
            }
        }

        #endregion

        public ICommand HomePageNavCommand { get; set; }
        public ICommand SaveAndNavCommand { get; set; }
        public ICommand AddAddressCommand { get; set; }
        public ICommand DeleteAddressCommand { get; set; }

        private ICommand initializeCommand;


        private readonly AddressStore _addressStore;

        private ObservableCollection<Address> _addresses = new System.Collections.ObjectModel.ObservableCollection<Address>();

        public ObservableCollection<Address> Addresses
        {
            get { return _addresses; }
            set { _addresses = value; }
        }

        public Address SelectedAddress
        {
            get => _addressStore.SelectedAddress;
            set { _addressStore.SelectedAddress = value; }
        }

        public CustomerViewModel(INavigationService homeNavigationService, CustomerStore customerStore,
            AddressStore addressStore)
        {
            _addressStore = addressStore;
            initializeCommand = new LoadCustomerCommand(customerStore, addressStore, this);

            HomePageNavCommand = new HomeNavCommand(homeNavigationService, customerStore);

            AddAddressCommand = new AddAddressCommand(_addressStore, this);
            DeleteAddressCommand = new DeleteAddressCommand(_addressStore, this);

            //if new customer just make new 
            if (customerStore.EditingMode == false)
            {
                _addresses = new ObservableCollection<Address>();
            } else
            {
                initializeCommand.Execute(null);
            }

            SaveAndNavCommand = new SaveCustomerCommand(homeNavigationService, customerStore, addressStore, this);
        }
    }
}
