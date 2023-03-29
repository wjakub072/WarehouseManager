using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WarehouseManager.Models;
using WarehouseManager.Stores;
using WarehouseManager.ViewModels;

namespace WarehouseManager.Commands
{
    internal class LoadDocumentCommand : AsyncCommandBase
    {
        private readonly AddressStore _addressStore;
        private readonly DocumentStore _documentStore;
        private readonly CustomerStore _customerStore;
        private readonly ElementStore _elementStore;
        private readonly PackageStore _packageStore;
        private readonly DeliveryViewModel _viewModel;

        public LoadDocumentCommand(DocumentStore documentStore, AddressStore addressStore, 
            CustomerStore customerStore, ElementStore elementStore, PackageStore packageStore, DeliveryViewModel viewModel)
        {
            _documentStore = documentStore;
            _addressStore = addressStore;
            _customerStore = customerStore;
            _elementStore = elementStore;
            _packageStore = packageStore;
            _viewModel = viewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            if (_documentStore.SelectedDocument == null)
            {
                MessageBox.Show("Brak wybranego dokumentu.");
                _documentStore.EditingMode = false;
                return;
            }

            await _packageStore.Load();

            Document editingDocument = _documentStore.SelectedDocument;

            _viewModel.Customer = _customerStore.Customers.Where(c => c.Customer_Id == editingDocument.CustomerId).FirstOrDefault();
            if (_viewModel.Customer == null)
            {
                MessageBox.Show("Brak kontrahenta przypisanego do dokumentu w bazie.");
                _documentStore.EditingMode = false;
                return;
            }

            _viewModel.CustomerName = _viewModel.Customer.Name;
            _viewModel.NIP = _viewModel.Customer.NIP;
            _viewModel.CustomerOrigin = _viewModel.Customer.Origin;

            await _addressStore.LoadForCustomer(_viewModel.Customer.Customer_Id);

            if (_addressStore.Addresses == null || _addressStore.Addresses.Count() == 0)
            {
                return;
            }

            var customerAddresses = _addressStore.Addresses.ToList();

            _viewModel.CustomerAddresses.Clear();
            foreach (var address in customerAddresses)
            {
                _viewModel.CustomerAddresses.Add(address);
            }

            _elementStore.DocumentId = editingDocument.Document_Id;

            await _elementStore.Load();

            if (_elementStore.Elements == null || _elementStore.Elements.Count() == 0)
            {
                return;
            }



            foreach (var element in _elementStore.Elements)
            {
                ElementViewModel elementVM = new ElementViewModel(element);
                elementVM.PackageTypes = _packageStore.Packages;
                if (elementVM.PackageTypes != null)
                {
                    elementVM.SelectedType = elementVM.PackageTypes.Where(p => p.Package_Id == element.PackageId).First();
                }
                if (_addressStore.SelectedAddress != null)
                {
                    elementVM.Address = _addressStore.Addresses.Where(a => a.Address_Id == element.AddressId).First();
                }
                else
                {
                    elementVM.Address = new Address() { City = "" };
                }
                elementVM.AmountChanged += OnAmountChanged;
                elementVM.ValueChanged += OnValueChanged;

                _viewModel.Elements.Add(elementVM);
            }
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
