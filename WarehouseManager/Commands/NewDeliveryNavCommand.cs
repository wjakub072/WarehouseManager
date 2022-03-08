using WarehouseManager.Services;

namespace WarehouseManager.Commands
{
    public class NewDeliveryNavCommand : CommandBase
    {
        private readonly INavigationService _navigationToNewDelivery;

        public NewDeliveryNavCommand(INavigationService navigationToNewDelivery)
        {
            _navigationToNewDelivery = navigationToNewDelivery;
        }

        public override void Execute(object parameter)
        {
            _navigationToNewDelivery.Navigate();
        }
    }
}
