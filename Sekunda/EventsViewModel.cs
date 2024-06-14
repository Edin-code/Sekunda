using System;
using System.Collections.ObjectModel;
using Sekunda.Models;

namespace Sekunda.ViewModels
{
    public class EventsViewModel
    {
        private ObservableCollection<Takmicenje> _events;

        public ObservableCollection<Takmicenje> Events
        {
            get { return _events; }
            set { _events = value; }
        }

        public EventsViewModel()
        {
            InitializeEvents();
        }

        private void InitializeEvents()
        {
            Events = new ObservableCollection<Takmicenje>
            {
                new Takmicenje
                {
                    Name = "Maraton Beograd",
                    Date = new DateTime(2024, 6, 15),
                    Icon = "beograd.png",
                    Participants = new ObservableCollection<Participant>
                    {
                        new Participant { FirstName = "Marko", LastName = "Markovic", Country = "Srbija", Club = "AK Beograd" },
                        new Participant { FirstName = "Jelena", LastName = "Jovanovic", Country = "Srbija", Club = "Rekreativci" },
                        new Participant { FirstName = "Petar", LastName = "Petrovic", Country = "Srbija", Club = "AK Novi Sad" }
                    }
                },
                new Takmicenje
                {
                    Name = "Maraton Sarajevo",
                    Date = new DateTime(2024, 8, 20),
                    Icon = "sarajevo.png",
                    Participants = new ObservableCollection<Participant>
                    {
                        new Participant { FirstName = "Ivan", LastName = "Ivic", Country = "BiH", Club = "AK Borac Banja Luka" },
                        new Participant { FirstName = "Ana", LastName = "Anic", Country = "BiH", Club = "Rekreativci" },
                        new Participant { FirstName = "Tarik", LastName = "Musinovic", Country = "BiH", Club = "AK Sarajevo" }
                    }
                },
                new Takmicenje
                {
                    Name = "Tirana 5k",
                    Date = new DateTime(2024, 9, 28),
                    Icon = "tirana.png",
                    Participants = new ObservableCollection<Participant>
                    {
                        new Participant { FirstName = "Arben", LastName = "Arbani", Country = "Albanija", Club = "AK Tirana" },
                        new Participant { FirstName = "Elena", LastName = "Elena", Country = "Albanija", Club = "Rekreativci" },
                        new Participant { FirstName = "Goran", LastName = "Goranovic", Country = "Albanija", Club = "AK Durres" }
                    }
                },
                new Takmicenje
                {
                    Name = "Polumaraton Novi Sad",
                    Date = new DateTime(2024, 7, 20),
                    Icon = "novisad.png",
                    Participants = new ObservableCollection<Participant>
                    {
                        new Participant { FirstName = "Mujo", LastName = "Mujic", Country = "Srbija", Club = "AK Prolet Prijepolje" },
                        new Participant { FirstName = "Milica", LastName = "Milic", Country = "Srbija", Club = "Rekreativci" },
                        new Participant { FirstName = "Stefan", LastName = "Stefanovic", Country = "Srbija", Club = "AK Subotica" }
                    }
                }
            };
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
