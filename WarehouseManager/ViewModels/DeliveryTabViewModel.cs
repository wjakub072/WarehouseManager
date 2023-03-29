using System.Collections.ObjectModel;
using System.Windows.Input;
using WarehouseManager.Commands;
using WarehouseManager.Models;
using WarehouseManager.Services;
using WarehouseManager.Stores;

namespace WarehouseManager.ViewModels
{
    internal class DeliveryTabViewModel : ViewModelBase
    {
        private string _importStatus;

        public string ImportStatus
        {
            get { return _importStatus; }
            set
            {
                _importStatus = value;
                OnPropertyChanged(nameof(ImportStatus));
            }
        }

        private readonly DocumentStore _documentStore;

        public ICommand NewDeliveryNavCommand { get; set; }
        public ICommand DeleteDocumentCommand { get; set; }
        public ICommand EditDocumentCommand { get; set; }


        public LoadDocumentsCommand LoadDocumentsCommand { get; set; }


        private ObservableCollection<Document> _documents = new ObservableCollection<Document>();

        public ObservableCollection<Document> Documents
        {
            get { return _documents; }
            set { _documents = value; }

        }

        public Document SelectedDocument
        {
            get => _documentStore.SelectedDocument;
            set => _documentStore.SelectedDocument = value;
        }

        public DeliveryTabViewModel(INavigationService newDeliveryNav, DocumentStore documentStore, CustomerStore customerStore)
        {
            NewDeliveryNavCommand = new NavCommand(newDeliveryNav);
            EditDocumentCommand = new EditDocumentCommand(newDeliveryNav, documentStore);
            DeleteDocumentCommand = new DeleteDocumentCommand(documentStore, this);

            _documentStore = documentStore;

            LoadDocumentsCommand = new LoadDocumentsCommand(customerStore, documentStore, this);
        }
    }
}
