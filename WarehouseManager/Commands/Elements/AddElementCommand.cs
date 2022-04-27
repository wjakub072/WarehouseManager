using System.Linq;
using WarehouseManager.Models;
using WarehouseManager.Stores;
using WarehouseManager.ViewModels;

namespace WarehouseManager.Commands
{
    internal class AddElementCommand : CommandBase
    {
        private readonly ElementStore _store;
        private readonly PackageStore _packageStore;
        private readonly AddressStore _addressStore;
        private readonly DeliveryViewModel _viewModel;

        public AddElementCommand(ElementStore store, PackageStore packageStore, AddressStore addressStore, DeliveryViewModel customerViewModel)
        {
            _store = store;
            _packageStore = packageStore;
            _addressStore = addressStore;
            _viewModel = customerViewModel;
        }

        public override void Execute(object parameter)
        {
            Element element = new Element() { Amount = 1 };

            //add to store container to keep tracking
            _store.AddElement(element);

            //add to view representation
            ElementViewModel elementVM = new ElementViewModel(element);
            elementVM.PackageTypes = _packageStore.Packages;
            if (elementVM.PackageTypes != null)
            {
                elementVM.SelectedType = elementVM.PackageTypes.First();
            }
            if (_addressStore.SelectedAddress != null)
            {
               elementVM.Address = _addressStore.SelectedAddress;
            } else
            {
                elementVM.Address = new Address() { City = ""};
            }
            elementVM.AmountChanged += OnAmountChanged;
            elementVM.ValueChanged += OnValueChanged;

            _viewModel.Elements.Add(elementVM);
        }

        private void OnAmountChanged()
        {
            _viewModel.SumAmount = 0;
            foreach (var elem in _viewModel.Elements)
            {
                _viewModel.SumAmount += elem.Amount;
            }
        }

        private void OnValueChanged()
        {
            _viewModel.SumValue = 0;
            foreach (var elem in _viewModel.Elements)
            {
                _viewModel.SumValue += elem.Value;
            }
        }
    }
}
