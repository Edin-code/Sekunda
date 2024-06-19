using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using Sekunda.Models;
using System;
using System.Collections.Generic;

namespace Sekunda
{
    public partial class DetailPage : ContentPage
    {
        private Event2 _event;
        private List<Participant> _participants;

        public DetailPage(Event2 ev)
        {
            InitializeComponent();

            _event = ev ?? throw new ArgumentNullException(nameof(ev));
            _participants = _event.Participants ?? new List<Participant>();

            BindingContext = _event;

            LoadEventIcon();
            LoadParticipants();
        }

        private void LoadParticipants()
        {
            if (_participants != null)
            {
                foreach (var participant in _participants)
                {
                    AddParticipantToView(participant);
                }
            }
        }

        private void AddParticipantToView(Participant participant)
        {
            var participantLayout = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                BackgroundColor = Colors.White,
                Padding = new Thickness(10),
                Margin = new Thickness(0, 0, 0, 1)
            };

            participantLayout.Children.Add(new Label { Text = participant.FirstName, FontSize = 14, TextColor = Colors.Black });
            participantLayout.Children.Add(new Label { Text = participant.LastName, FontSize = 14, TextColor = Colors.Black });
            participantLayout.Children.Add(new Label { Text = participant.Country, FontSize = 14, TextColor = Colors.Black });
            participantLayout.Children.Add(new Label { Text = participant.Club, FontSize = 14, TextColor = Colors.Black });

            ParticipantsContainer.Children.Add(participantLayout);
        }

        private async void OnOpisButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new OpisPage(_event));
        }


        private async void OnPrijavaButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistrationPage(_event, AddParticipantToList));
        }

        private void AddParticipantToList(Participant participant)
        {
            _participants.Add(participant);
            AddParticipantToView(participant);
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
    }
}
