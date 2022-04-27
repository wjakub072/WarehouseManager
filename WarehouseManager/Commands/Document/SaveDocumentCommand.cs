using System;
using System.Threading.Tasks;
using System.Windows;
using WarehouseManager.Models;
using WarehouseManager.Services;
using WarehouseManager.Stores;
using WarehouseManager.ViewModels;

namespace WarehouseManager.Commands
{
    internal class SaveDocumentCommand : AsyncCommandBase
    {
        private INavigationService _viewModelNavigation;
        private readonly DeliveryViewModel _viewModel;
        private readonly DocumentStore _documentStore;
        private readonly ElementStore _elementStore;

        public SaveDocumentCommand(INavigationService viewModelNavigation, DeliveryViewModel viewModel, DocumentStore documentStore, ElementStore elementStore)
        {
            _viewModelNavigation = viewModelNavigation;
            _viewModel = viewModel;
            _documentStore = documentStore;
            _elementStore = elementStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            if (_viewModel.Customer == null)
            {
                MessageBox.Show("Brak zdefiniowanego kontrahenta.");
                return;
            }
            if (_documentStore.EditingMode)
            {
                Document document = _documentStore.SelectedDocument;

                //await _elementStore.DeleteElements();

                await _elementStore.SaveRangeToDatabase(document.Document_Id).ConfigureAwait(false);

                _documentStore.EditingMode = false;
                _viewModelNavigation.Navigate();
            }
            else
            {
                string type;
                if (_viewModel.SelectedType == "Wydanie")
                {
                    type = "WZ";
                }else
                {
                    type = "PZ";
                }
                Document document = new Document();
                var date = DateTime.Now;
                document.IssueDate = date;
                document.Code = type + "/2/" + date.Date.Month.ToString() + "/" + date.Date.Year.ToString();
                document.Type = type;
                document.CustomerId = _viewModel.Customer.Customer_Id;

                await _documentStore.AddDocument(document);

                await _elementStore.SaveRangeToDatabase(document.Document_Id).ConfigureAwait(false);


                _viewModelNavigation.Navigate();
            }
        }
    }
}
