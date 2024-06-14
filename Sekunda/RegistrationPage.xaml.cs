using Microsoft.Maui.Controls;
using System;
using Sekunda.Models;

namespace Sekunda
{
    public partial class RegistrationPage : ContentPage
    {
        private Event2 _event;
        private Action<Participant> _addParticipantToList;

        public RegistrationPage(Event2 ev, Action<Participant> addParticipantToList)
        {
            InitializeComponent();
            _event = ev;
            _addParticipantToList = addParticipantToList;
        }

        private async void OnBackButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void OnPrijavaButtonClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ImeEntry.Text) ||
                string.IsNullOrWhiteSpace(PrezimeEntry.Text) ||
                string.IsNullOrWhiteSpace(DrzavaEntry.Text) ||
                string.IsNullOrWhiteSpace(GodRodjEntry.Text) ||
                string.IsNullOrWhiteSpace(EmailEntry.Text) ||
                string.IsNullOrWhiteSpace(BrTelefonaEntry.Text))
            {
                await DisplayAlert("Greška", "Molimo popunite sva polja označena sa *.", "OK");
                return;
            }

            var participant = new Participant
            {
                FirstName = ImeEntry.Text,
                LastName = PrezimeEntry.Text,
                Country = DrzavaEntry.Text,
                Club = string.IsNullOrWhiteSpace(KlubEntry.Text) ? "Individualac" : KlubEntry.Text,
                YearOfBirth = GodRodjEntry.Text,
                Email = EmailEntry.Text,
                PhoneNumber = BrTelefonaEntry.Text
            };

            _addParticipantToList(participant);

            await DisplayAlert("Uspjeh", "Uspješno ste se prijavili.", "OK");
            await Navigation.PopAsync();
        }
    }
}
