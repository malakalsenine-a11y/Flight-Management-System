using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project01.Models
{
    public class Booking
    {
        public int bookingId { get; set; } //Generated
        public int passengerId { get; set; } //User Input
        public int flightId { get; set; } //User Input
        public string seatNumber { get; set; } //User Input
        public string bookingDate { get; set; } //User Input
        public decimal totalPrice { get; set; } //Calculated
        public string status { get; set; } // Default Value
    }
}
