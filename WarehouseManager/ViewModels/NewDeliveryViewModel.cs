using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using WarehouseManager.Commands;
using WarehouseManager.Services;

namespace WarehouseManager.ViewModels
{
    internal class NewDeliveryViewModel : ViewModelBase
    {
        private ImageSource _label;

        public ImageSource Label
        {
            get { return _label; }
            set
            {
                _label = value;
                OnPropertyChanged(nameof(Label));
            }
        }

        public ICommand HomePageNavCommand{ get; set; }

        public NewDeliveryViewModel(INavigationService homeNavigationService)
        {
            _label = new BitmapImage(new System.Uri("C:\\Users\\wjaku\\Desktop\\example.png"));
            HomePageNavCommand = new NavCommand(homeNavigationService);
        }

    }
}
