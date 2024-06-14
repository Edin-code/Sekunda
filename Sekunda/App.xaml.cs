using Microsoft.Maui.Controls;
using Sekunda.Models;
using Sekunda.ViewModels;


namespace Sekunda
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var eventsViewModel = new EventsViewModel();
            MainPage = new AppShell();
            BindingContext = eventsViewModel;
        }
    }
}


