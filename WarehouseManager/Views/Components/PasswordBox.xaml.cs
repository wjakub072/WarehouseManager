using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WarehouseManager.Views.Components
{
    /// <summary>
    /// Interaction logic for PasswordBox.xaml
    /// </summary>
    public partial class PasswordBox : UserControl
    {
        public string PasswordProperty
        {
            get { return (string)GetValue(PasswordPropertyProperty); }
            set { SetValue(PasswordPropertyProperty, value); }
        }

       

        public static readonly DependencyProperty PasswordPropertyProperty =
            DependencyProperty.Register("PasswordProperty", typeof(string), typeof(PasswordBox), new PropertyMetadata(string.Empty));



        public PasswordBox()
        {
            InitializeComponent();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs eventArgs)
        {
            PasswordProperty = passwordBox.Password;
        }
    }
}
