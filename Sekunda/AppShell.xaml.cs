using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;

namespace Sekunda
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            RegisterRoutes();
        }

        private void RegisterRoutes()
        {
            Routing.RegisterRoute(nameof(DetailPage), typeof(DetailPage));
            Routing.RegisterRoute(nameof(OpisPage), typeof(OpisPage));
            Routing.RegisterRoute(nameof(RegistrationPage), typeof(RegistrationPage));
            Routing.RegisterRoute(nameof(MapPage), typeof(MapPage)); // Register MapPage route
        }
    }
}
