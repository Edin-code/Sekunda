using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Maps;

namespace Sekunda
{
    public partial class MapPage : ContentPage
    {
        public MapPage()
        {
            InitializeComponent();

            // Optional: Add a pin to the map
            var location = new Location(37.7749, -122.4194); // Example: San Francisco
            var pin = new Pin
            {
                Label = "San Francisco",
                Address = "USA",
                Type = PinType.Place,
                Location = location
            };

            MyMap.Pins.Add(pin);
            MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(location, Distance.FromMiles(10)));
        }
    }
}
