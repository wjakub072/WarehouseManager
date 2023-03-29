using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManager.Stores;
using WarehouseManager.ViewModels;

namespace WarehouseManager.Commands
{
    internal class DeleteDocumentCommand : AsyncCommandBase
    {
        private readonly DocumentStore _documentStore;
        private readonly DeliveryTabViewModel _viewModel;

        public DeleteDocumentCommand(DocumentStore documentStore, DeliveryTabViewModel viewModel)
        {
            _documentStore = documentStore;
            _viewModel = viewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            if (_documentStore.SelectedDocument == null)
            {
                return;
            }
            await _documentStore.DeleteDocument();

            _viewModel.Documents.Remove(_viewModel.SelectedDocument);
        }
    }
}
