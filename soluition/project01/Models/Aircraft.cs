using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project01.Models
{
    public class Aircraft
    {

        public int aircraftId { get; set; } //Generated
        public string model { get; set; } // Default Value
        public int totalSeats { get; set; } //Calculated
        public bool isOperational { get; set; } //Default Value


    }

}

