using WarehouseManager.Stores;
using WarehouseManager.ViewModels;

namespace WarehouseManager.Commands
{
    internal class DeleteElementCommand : CommandBase
    {
        private readonly ElementStore _store;
        private readonly DeliveryViewModel _viewModel;

        public DeleteElementCommand(ElementStore store, DeliveryViewModel customerViewModel)
        {
            _store = store;
            _viewModel = customerViewModel;
        }

        public override void Execute(object parameter)
        {
            _store.DeleteElement();

            _viewModel.Elements.Remove(_viewModel.SelectedElement);
        }
    }
}
