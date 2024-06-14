using Microsoft.Maui.Controls;
using System;
using Sekunda.Models;
using System.Collections.Generic;

namespace Sekunda
{
    public partial class OpisPage : ContentPage
    {
        private Event2 _event;

        public OpisPage(Event2 ev)
        {
            InitializeComponent();
            _event = ev;

            // Postavljanje BindingContext-a na _event objekat
            BindingContext = this;

            // Postavljanje ostalih polja
            EventNameLabel.Text = _event.Name;
            EventDateLabel.Text = _event.Date.ToString("dd.MM.yyyy");
        }

        private async void OnBackButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
