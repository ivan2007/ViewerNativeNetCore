using Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT;
using Microsoft.Toolkit.Wpf.UI.Controls;
using System.Windows;
using System.Windows.Controls;

namespace ViewerWpf
{
    /// <summary>
    /// Interaction logic for UserControlWpf.xaml
    /// </summary>
    public partial class UserControlWpf : UserControl
    {
        public UserControlWpf()
        {
            InitializeComponent();
        }

        private async void MapControl_Loaded(object sender, RoutedEventArgs e)
        {
            // Specify a known location.
            BasicGeoposition cityPosition = new BasicGeoposition() { Latitude = 47.604, Longitude = -122.329 };
            var cityCenter = new Geopoint(cityPosition);

            // Set the map location.
            await (sender as MapControl).TrySetViewAsync(cityCenter, 12);
        }
    }
}