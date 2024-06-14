using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sekunda.Models
{
    public class Event2
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public List<Participant> Participants { get; set; } = new List<Participant>();
        public string IconPath { get; set; } // Putanja do ikone za događaj
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

