using System.Linq;
using System.Threading.Tasks;
using WarehouseManager.Stores;
using WarehouseManager.ViewModels;

namespace WarehouseManager.Commands
{
    internal class LoadDocumentsCommand : AsyncCommandBase
    {
        private readonly CustomerStore _customerStore;
        private readonly DocumentStore _documentStore;
        private readonly DeliveryTabViewModel _viewModel;

        public LoadDocumentsCommand(CustomerStore customerStore, DocumentStore documentStore, DeliveryTabViewModel viewModel)
        {
            _customerStore = customerStore;
            _documentStore = documentStore;
            _viewModel = viewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            await _documentStore.Load();

            _viewModel.Documents.Clear();
            foreach (var document in _documentStore.Documents)
            {
                document.CustomerName = _customerStore.Customers.Where(c => c.Customer_Id == document.CustomerId).Select(c => c.Name).FirstOrDefault();
                _viewModel.Documents.Add(document);
            }
        }
    }
}
