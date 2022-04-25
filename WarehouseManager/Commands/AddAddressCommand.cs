using WarehouseManager.Stores;

namespace WarehouseManager.Commands
{
    internal class AddAddressCommand : CommandBase
    {
        private readonly AddressStore _store;

        public AddAddressCommand(AddressStore store)
        {
            _store = store;
        }

        public override void Execute(object parameter)
        {
            _store.AddAddress(new Models.Address() { Name = "Nowy" });
        }
    }
}
