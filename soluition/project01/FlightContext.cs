using project01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project01
{
    public class FlightContext
    {
        public List<Pilot> pilots { get; set; }
        public List<Passenger> passengers { get; set; }
        public List<Flight> flights { get; set; }
        public List<Booking> bookings { get; set; }
        public List<Aircraft> aircrafts { get; set; }





    }
}
