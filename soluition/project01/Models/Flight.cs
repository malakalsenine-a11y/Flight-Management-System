using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project01.Models
{
    public class Flight
    {
        public int flightId { get; set; } //Generated
        public string flightCode { get; set; } // Default Value
        public int aircraftId { get; set; } //User Input
        public int pilotId { get; set; } //User Input
        public string origin { get; set; } //User Input
        public string destination { get; set; } //User Input
        public string departureDate { get; set; } //User Input
        public string departureTime { get; set; } //User Input
        public decimal ticketPrice { get; set; } //User Input
        public int availableSeats { get; set; } //Default Value
        public string status { get; set; } // Default Value
        public string flightDuration { get; set; } //Calculated
    }
}
