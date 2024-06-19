using Microsoft.Maui.Controls;
using System;
using Sekunda.Models;

namespace Sekunda
{
    public partial class OpisPage : ContentPage
    {
        private Event2 _event;

        public OpisPage(Event2 ev)
        {
            InitializeComponent();

            _event = ev ?? throw new ArgumentNullException(nameof(ev));
            BindingContext = _event;

            LoadEventIcon();
            SetEventDetails();
        }

        private void LoadEventIcon()
        {
            Console.WriteLine($"Loading Event Icon from path: {_event.IconPath}");
            if (!string.IsNullOrEmpty(_event.IconPath))
            {
                if (_event.IconPath.StartsWith("http"))
                {
                    // If the path is a URL
                    EventIcon.Source = new UriImageSource
                    {
                        Uri = new Uri(_event.IconPath),
                        CachingEnabled = true,
                        CacheValidity = TimeSpan.FromDays(1)
                    };
                }
                else
                {
                    // If the path is a local file
                    EventIcon.Source = ImageSource.FromFile(_event.IconPath);
                }
            }
        }

        private void SetEventDetails()
        {
            EventNameLabel.Text = _event.Name;
            EventDateLabel.Text = _event.Date.ToString("dd.MM.yyyy");
        }

        private async void OnBackButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void OnMapButtonClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(MapPage));
        }
    }
}
