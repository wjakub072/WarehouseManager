using WarehouseManager.Stores;

namespace WarehouseManager.Commands
{
    internal class DeleteAddressCommand : CommandBase
    {
        private readonly AddressStore _store;

        public DeleteAddressCommand(AddressStore store)
        {
            _store = store;
        }

        public override void Execute(object parameter)
        {
            _store.DeleteAddress();
        }
    }
}
