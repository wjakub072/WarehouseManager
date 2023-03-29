using WarehouseManager.Services;
using WarehouseManager.Stores;

namespace WarehouseManager.Commands
{
    internal class EditDocumentCommand : CommandBase
    {
        private readonly INavigationService _navigationService;
        private readonly DocumentStore _documentStore;

        public EditDocumentCommand(INavigationService navigationService, DocumentStore documentStore)
        {
            _navigationService = navigationService;
            _documentStore = documentStore;
        }

        public override void Execute(object parameter)
        {
            if (_documentStore.SelectedDocument == null)
            {
                return;
            }

            _documentStore.EditingMode = true;
            _navigationService.Navigate();
        }
    }
}
