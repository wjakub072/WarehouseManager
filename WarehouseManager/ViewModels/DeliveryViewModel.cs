using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WarehouseManager.Commands;
using WarehouseManager.Models;
using WarehouseManager.Services;
using WarehouseManager.Stores;

namespace WarehouseManager.ViewModels
{
    internal class DeliveryViewModel : ViewModelBase
    {
        #region binding properties
        private string _customerName;

        public string CustomerName
        {
            get { return _customerName; }
            set 
            {
                _customerName = value; 
                OnPropertyChanged(nameof(CustomerName));
            }
        }

        private string _customerOrigin;

        public string CustomerOrigin
        {
            get { return _customerOrigin; }
            set 
            {  
                _customerOrigin = value;
                OnPropertyChanged(nameof(CustomerOrigin));
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

        private List<string> _types = new List<string>() { "Przyjęcie", "Wydanie"};

        public List<string> Types
        {
            get { return _types; }
            set { _types = value; }
        }

        private string _selectedType;

        public string SelectedType
        {
            get { return _selectedType; }
            set 
            {
                _selectedType = value;
                OnPropertyChanged(nameof(SelectedType));
            }
        }

        private decimal _sumValue;

        public decimal SumValue
        {
            get { return _sumValue; }
            set 
            { 
                _sumValue = value; 
                OnPropertyChanged(nameof(SumValue));
            }
        }

        private decimal _sumAmount;

        public decimal SumAmount
        {
            get { return _sumAmount; }
            set 
            {
                _sumAmount = value; 
                OnPropertyChanged(nameof(SumAmount));
            }
        }


        #endregion
        private readonly AddressStore _addressStore;
        private readonly ElementStore _elementStore;
        private readonly DocumentStore _documentStore;

        public ICommand AddElementCommand { get; set; }
        public ICommand DeleteElementCommand { get; set; }
        public ICommand SaveDocumentCommand { get; set; }
        public ICommand SearchCustomerCommand { get; set; }
        public ICommand HomePageNavCommand{ get; set; }

        private ICommand loadPackagesCommand;

        private ObservableCollection<Address> _customerAddresses = new ObservableCollection<Address>();

        public ObservableCollection<Address> CustomerAddresses
        {
            get { return _customerAddresses; }
            set { _customerAddresses = value; }
        }

        public Address SelectedAddress
        {
            get { return _addressStore.SelectedAddress; }
            set { _addressStore.SelectedAddress = value; }
        }


        private ObservableCollection<ElementViewModel> _elements = new ObservableCollection<ElementViewModel>();


        public ObservableCollection<ElementViewModel> Elements
        {
            get { return _elements; }
            set { _elements = value; }
        }

        private ElementViewModel _selectedElement;

        public ElementViewModel SelectedElement
        {
            get { return _selectedElement; }
            set 
            { 
                _selectedElement = value; 
                OnPropertyChanged(nameof(SelectedElement));
                _elementStore.SelectedElement = value.ParentElement;
            }
        }

        private Customer _customer;

        public Customer Customer
        {
            get { return _customer; }
            set { _customer = value; }
        }


        public DeliveryViewModel(INavigationService homeNavigationService, AddressStore addressStore, ElementStore elementStore, DocumentStore documentStore, PackageStore packageStore, CustomerStore customerStore)
        {
            HomePageNavCommand = new NavCommand(homeNavigationService);
            _addressStore = addressStore;
            _elementStore = elementStore;
            _documentStore = documentStore;
            
            AddElementCommand = new AddElementCommand(_elementStore, packageStore, addressStore, this);
            loadPackagesCommand = new LoadPackagesCommand(packageStore);
            SearchCustomerCommand = new SearchCustomerCommand(customerStore, addressStore, this);
            DeleteElementCommand = new DeleteElementCommand(elementStore, this);
            SaveDocumentCommand = new SaveDocumentCommand(homeNavigationService, this, documentStore, elementStore);

            loadPackagesCommand.Execute(null);
        }
    }
}
