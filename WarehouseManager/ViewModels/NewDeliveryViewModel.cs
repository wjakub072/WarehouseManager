using System.Windows.Media;
using System.Windows.Media.Imaging;

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

        public NewDeliveryViewModel()
        {
            _label = new BitmapImage(new System.Uri("C:\\Users\\wjaku\\Desktop\\example.png"));

        }

    }
}
