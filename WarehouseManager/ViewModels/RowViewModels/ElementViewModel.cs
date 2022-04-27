using System;
using System.Collections.Generic;
using WarehouseManager.Models;

namespace WarehouseManager.ViewModels
{
    internal class ElementViewModel : ViewModelBase
    {
        private Element parentElement;
        public Element ParentElement => parentElement;

        private void OnAmountChanged()
        {
            AmountChanged?.Invoke();
        }

        public event Action? AmountChanged;

        private void OnValueChanged()
        {
            ValueChanged?.Invoke();
        }

        public event Action? ValueChanged;


        public ElementViewModel(Element parentElement)
        {
            this.parentElement = parentElement;
            Amount = parentElement.Amount;
            Value = parentElement.Value;
            SerialCode = parentElement.SerialCode;
        }

        public IEnumerable<Package> PackageTypes { get; set; }
        private Package _selectedType;

        public Package SelectedType
        {
            get { return _selectedType; }
            set 
            { 
                _selectedType = value; 
                OnPropertyChanged(nameof(SelectedType));

                parentElement.PackageId = value.Package_Id;
            }
        }

        private decimal _amount;

        public decimal Amount
        {
            get { return _amount; }
            set 
            { 
                _amount = value; 
                OnPropertyChanged(nameof(Amount));
                parentElement.Amount = value;
                OnAmountChanged();
            }
        }

        private decimal _value;
            
        public decimal Value
        {
            get { return _value; }
            set
            {
                _value = value;
                OnPropertyChanged(nameof(Value));
                parentElement.Value = value;
                OnValueChanged();
            }
        }

        private string _serialCode;

        public string SerialCode
        {
            get { return _serialCode; }
            set
            {
                _serialCode = value;
                OnPropertyChanged(nameof(SerialCode));
                parentElement.SerialCode = value;
            }
        }

        private Address _address;

        public Address Address
        {
            get { return _address; }
            set 
            {
                _address = value;
                OnPropertyChanged(nameof(Address));
                parentElement.AddressId = value.Address_Id;
            }
        }
    }
}
