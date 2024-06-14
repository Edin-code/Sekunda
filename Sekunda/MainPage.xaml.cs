using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using Sekunda.Models;

namespace Sekunda
{
    public partial class MainPage : ContentPage
    {
        private Dictionary<string, List<Takmicenje>> _eventsByMonth;

        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeEvents();
            PopulateMonthPicker();
        }

        private void InitializeEvents()
        {
            _eventsByMonth = new Dictionary<string, List<Takmicenje>>
            {
                {
                    "June", new List<Takmicenje>
                    {
                        new Takmicenje { Name = "Maraton Beograd", Date = new DateTime(2024, 6, 15), Icon = "beograd.png" }
                    }
                },
                {
                    "July", new List<Takmicenje>
                    {
                        new Takmicenje { Name = "Polumaraton Novi Sad", Date = new DateTime(2024, 7, 20), Icon = "novisad.png" }
                    }
                },
                {
                    "September", new List<Takmicenje>
                    {
                        new Takmicenje { Name = "Tirana 5k", Date = new DateTime(2024, 9, 28), Icon = "tirana.png" }
                    }
                },
                {
                    "October", new List<Takmicenje>
                    {
                        new Takmicenje { Name = "Maraton Sarajevo", Date = new DateTime(2024, 10, 15), Icon = "sarajevo.png" }
                    }
                }
            };
        }

        private void PopulateMonthPicker()
        {
            MonthPicker.Items.Add("January");
            MonthPicker.Items.Add("February");
            MonthPicker.Items.Add("March");
            MonthPicker.Items.Add("April");
            MonthPicker.Items.Add("May");
            MonthPicker.Items.Add("June");
            MonthPicker.Items.Add("July");
            MonthPicker.Items.Add("August");
            MonthPicker.Items.Add("September");
            MonthPicker.Items.Add("October");
            MonthPicker.Items.Add("November");
            MonthPicker.Items.Add("December");
        }

        private void OnMonthSelected(object sender, EventArgs e)
        {
            if (MonthPicker.SelectedIndex == -1) return;

            string selectedMonth = MonthPicker.Items[MonthPicker.SelectedIndex];
            DisplayEventsForMonth(selectedMonth);
        }

        private void DisplayEventsForMonth(string month)
        {
            EventList.Children.Clear();

            if (!_eventsByMonth.TryGetValue(month, out List<Takmicenje> events)) return;

            foreach (var ev in events)
            {
                var frame = new Frame
                {
                    BackgroundColor = Color.FromHex("#B2DFDB"),
                    CornerRadius = 10,
                    Content = new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        Children =
                        {
                            new Image { Source = ev.Icon, WidthRequest = 50, HeightRequest = 50 },
                            new Label { Text = $"{ev.Name}\n{ev.Date:dd.MM.yyyy}", FontSize = 16, TextColor = Colors.Black }
                        }
                    },
                    GestureRecognizers = { new TapGestureRecognizer { Command = new Command(() => OnEventTapped(ev)) } }
                };

                EventList.Children.Add(frame);
            }
        }

        private async void OnEventTapped(Takmicenje ev)
        {
            // Convert Takmicenje to Event2 if needed, assuming they are different types
            Event2 event2 = new Event2
            {
                Name = ev.Name,
                Date = ev.Date,
                IconPath = "Sekunda.Resources.Images." + ev.Icon,
                Participants = new List<Participant>
        {
            new Participant { FirstName = "Dummy", LastName = "Participant", Country = "Country", Club = "Club" }
        }
            };

            // Navigate to DetailPage with the converted Event2 object
            await Navigation.PushAsync(new DetailPage(event2));
        }

    }

    public class Takmicenje
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Icon { get; set; }
    }
}
