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

            _event = ev;
            _participants = _event.Participants;

            BindingContext = _event;

            LoadEventIcon();
            LoadParticipants();
        }

        private void LoadParticipants()
        {
            foreach (var participant in _participants)
            {
                AddParticipantToView(participant);
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
            if (!string.IsNullOrEmpty(_event.IconPath))
            {
                EventIcon.Source = ImageSource.FromResource(_event.IconPath, typeof(App).Assembly);
            }
        }
    }

    public class Event2
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public List<Participant> Participants { get; set; } = new List<Participant>();
        public string IconPath { get; set; }
    }

    public class Participant
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string Club { get; set; }
        public string YearOfBirth { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
