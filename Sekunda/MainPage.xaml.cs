using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using Sekunda.Models;
using Sekunda.ViewModels;
using System.Collections.ObjectModel;

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
            "January", new List<Takmicenje>
            {
                new Takmicenje { Name = "Zimski Maraton", Date = new DateTime(2025, 1, 10), Icon = "zimski.png", Participants = new ObservableCollection<Participant>
                {
                    new Participant { FirstName = "Ivan", LastName = "Ivic", Country = "Srbija", Club = "AK Novi Beograd" },
                    new Participant { FirstName = "Ana", LastName = "Anic", Country = "Srbija", Club = "Rekreativci" }
                }}
            }
        },
        {
            "February", new List<Takmicenje>
            {
                new Takmicenje { Name = "Trka prijateljstva kula", Date = new DateTime(2025, 2, 14), Icon = "kula.png", Participants = new ObservableCollection<Participant>
                {
                    new Participant { FirstName = "Petar", LastName = "Petrovic", Country = "Srbija", Club = "AK Novi Sad" },
                    new Participant { FirstName = "Jelena", LastName = "Jovanovic", Country = "Srbija", Club = "Rekreativci" }
                }}
            }
        },
        {
            "March", new List<Takmicenje>
            {
                new Takmicenje { Name = "Vivicita Sarajevo", Date = new DateTime(2025, 3, 21), Icon = "vivicita.png", Participants = new ObservableCollection<Participant>
                {
                    new Participant { FirstName = "Elzan", LastName = "Bibic", Country = "Srbija", Club = "AK Crvena Zvezda" },
                    new Participant { FirstName = "Belmin", LastName = "Mrkanovic", Country = "BiH", Club = "AK Doboj" }
                }}
            }
        },
        {
            "April", new List<Takmicenje>
            {
                new Takmicenje { Name = "Beogradski Polumaraton", Date = new DateTime(2025, 4, 15), Icon = "beogradpolu.png", Participants = new ObservableCollection<Participant>
                {
                    new Participant { FirstName = "Stefan", LastName = "Stefanovic", Country = "Srbija", Club = "AK Beograd" },
                    new Participant { FirstName = "Ana", LastName = "Anic", Country = "Srbija", Club = "Rekreativci" }
                }}
            }
        },
        {
            "May", new List<Takmicenje>
            {
                new Takmicenje { Name = "Stolacki cener", Date = new DateTime(2025, 5, 5), Icon = "stolac.png", Participants = new ObservableCollection<Participant>
                {
                    new Participant { FirstName = "Ivan", LastName = "Ivic", Country = "Srbija", Club = "AK Novi Beograd" },
                    new Participant { FirstName = "Haris", LastName = "Hadovic", Country = "Srbija", Club = "Rekreativci" }
                }}
            }
        },
        {
            "June", new List<Takmicenje>
            {
                new Takmicenje { Name = "Maraton Beograd", Date = new DateTime(2024, 6, 29), Icon = "beograd.png", Participants = new ObservableCollection<Participant>
                {
                    new Participant { FirstName = "Marko", LastName = "Markovic", Country = "Srbija", Club = "AK Beograd" },
                    new Participant { FirstName = "Jelena", LastName = "Jovanovic", Country = "Srbija", Club = "Rekreativci" },
                    new Participant { FirstName = "Petar", LastName = "Petrovic", Country = "Srbija", Club = "AK Novi Sad" }
                }},
                new Takmicenje { Name = "Mostarski Polumaraton", Date = new DateTime(2024, 6, 30), Icon = "mostar.png", Participants = new ObservableCollection<Participant>
                {
                    new Participant { FirstName = "Milan", LastName = "Milanovic", Country = "Srbija", Club = "AK Prolet Prijepolje" },
                    new Participant { FirstName = "Milica", LastName = "Milic", Country = "Srbija", Club = "Rekreativci" }
                }}
            }
        },
        {
            "July", new List<Takmicenje>
            {
                new Takmicenje { Name = "Polumaraton Novi Sad", Date = new DateTime(2024, 7, 20), Icon = "novisad.png", Participants = new ObservableCollection<Participant>
                {
                    new Participant { FirstName = "Mujo", LastName = "Mujic", Country = "Srbija", Club = "AK Prolet Prijepolje" },
                    new Participant { FirstName = "Milica", LastName = "Milic", Country = "Srbija", Club = "Rekreativci" },
                    new Participant { FirstName = "Stefan", LastName = "Stefanovic", Country = "Srbija", Club = "AK Subotica" }
                }}
            }
        },
        {
            "August", new List<Takmicenje>
            {
                new Takmicenje { Name = "Neumska desetka", Date = new DateTime(2024, 8, 10), Icon = "neum.png", Participants = new ObservableCollection<Participant>
                {
                    new Participant { FirstName = "Luka", LastName = "Lukic", Country = "BiH", Club = "AK Leotar" },
                    new Participant { FirstName = "Marija", LastName = "Maric", Country = "Crna Gora", Club = "Rekreativci" }
                }}
            }
        },
        {
            "September", new List<Takmicenje>
            {
                new Takmicenje { Name = "Tirana 5k", Date = new DateTime(2024, 9, 28), Icon = "tirana.png", Participants = new ObservableCollection<Participant>
                {
                    new Participant { FirstName = "Arben", LastName = "Arbani", Country = "Albanija", Club = "AK Tirana" },
                    new Participant { FirstName = "Elena", LastName = "Elena", Country = "Albanija", Club = "Rekreativci" },
                    new Participant { FirstName = "Goran", LastName = "Goranovic", Country = "Albanija", Club = "AK Durres" }
                }}
            }
        },
        {
            "October", new List<Takmicenje>
            {
                new Takmicenje { Name = "Maraton Sarajevo", Date = new DateTime(2024, 10, 15), Icon = "sarajevo.png", Participants = new ObservableCollection<Participant>
                {
                    new Participant { FirstName = "Ivan", LastName = "Ivic", Country = "BiH", Club = "AK Borac Banja Luka" },
                    new Participant { FirstName = "Ana", LastName = "Anic", Country = "BiH", Club = "Rekreativci" },
                    new Participant { FirstName = "Tarik", LastName = "Musinovic", Country = "BiH", Club = "AK Sarajevo" }
                }},
                new Takmicenje { Name = "Vogosca 5k", Date = new DateTime(2024, 10, 25), Icon = "vogosca.png", Participants = new ObservableCollection<Participant>
                {
                    new Participant { FirstName = "Miroslav", LastName = "Mirkovic", Country = "BiH", Club = "AK Sloboda" },
                    new Participant { FirstName = "Emina", LastName = "Emirovic", Country = "BiH", Club = "Rekreativci" }
                }}
            }
        },
        {
            "November", new List<Takmicenje>
            {
                new Takmicenje { Name = "Skopje Maraton", Date = new DateTime(2024, 11, 10), Icon = "skopje.png", Participants = new ObservableCollection<Participant>
                {
                    new Participant { FirstName = "Svetlana", LastName = "Svetlanic", Country = "Makedonija", Club = "AK Skopje" },
                    new Participant { FirstName = "Vladimir", LastName = "Vladic", Country = "Makedonija", Club = "Rekreativci" }
                }}
            }
        },
        {
            "December", new List<Takmicenje>
            {
                new Takmicenje { Name = "Advent Run Sarajevo", Date = new DateTime(2024, 12, 31), Icon = "advent.png", Participants = new ObservableCollection<Participant>
                {
                    new Participant { FirstName = "Uros", LastName = "Gutic", Country = "BiH", Club = "AK Borac" },
                    new Participant { FirstName = "Berin", LastName = "Musanovic", Country = "BiH", Club = "AK Bosna" }
                }}
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
            // Convert Takmicenje to Event2
            Event2 event2 = new Event2
            {
                Name = ev.Name,
                Date = ev.Date,
                IconPath = ev.Icon, // Assuming this is the correct path
                Participants = new List<Participant>(ev.Participants) // Use the actual participants from Takmicenje
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
        public ObservableCollection<Participant> Participants { get; set; }
    }
}
