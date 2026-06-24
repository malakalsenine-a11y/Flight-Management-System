using Microsoft.Win32;
using project01.Models;

namespace project01
{
    public class Program
    {
        // =======================================================
        //              **** system storage ****
        // =======================================================

        public static FlightContext context = new FlightContext
        {
            pilots = new List<Pilot>(),
            passengers = new List<Passenger>(),
            flights = new List<Flight>(),
            bookings = new List<Booking>(),
            aircrafts = new List<Aircraft>()

        };

        // =======================================================
        //              **** Register Passenger (CRUD) ****
        // =======================================================
        public static void RegisterPassenger()
        {
            Console.WriteLine("\n=== Register New Passenger ===");

            Console.Write("Enter Passenger name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Passenger Email : ");
            string email = Console.ReadLine();
            Console.Write("Enter Passenger Phone: ");
            string phone = Console.ReadLine();
            Console.Write("Enter Passport Number: ");
            string passportNumber = Console.ReadLine();
            Console.Write("Enter Nationality: ");
            string nationality = Console.ReadLine();


            int passengerId = context.passengers.Count + 1;

            context.passengers.Add(
                new Passenger
                {
                    passengerId = passengerId,
                    passengerName = name,
                    passengerEmail = email,
                    passengerPhone = phone,
                    passportNumber = passportNumber,
                    nationality = nationality

                });

            Console.WriteLine($" Passenger register successfully. Assigned ID: {passengerId}");

        }

        // =======================================================
        //              **** Add an Aircraft (CRUD) ****
        // =======================================================
        public static void AddAircraft()
        {
            Console.WriteLine("\n=== Add an Aircraft ===");

            Console.WriteLine("Enter Aircraft Model: ");
            string model = Console.ReadLine();

            Console.WriteLine("Enter Total Seats: ");
            int totalSeats = int.Parse(Console.ReadLine());

            int idAircraft = context.aircrafts.Count + 1;

            context.aircrafts.Add(new Aircraft
            {
                aircraftId = idAircraft,
                model = model,
                totalSeats = totalSeats,
                isOperational = true
            });

            Console.WriteLine($"Aircraft add successfully with aircraftId: {idAircraft}");


        }

        // =======================================================
        //              **** Register a Pilot (CRUD) ****
        // =======================================================
        public static void RegisterPilot()
        {
            Console.WriteLine("\n=== Register a pilot: ===");


            Console.Write("Enter Pilot Name: ");
            string namePilot = Console.ReadLine();
            Console.Write("Enter Pilot Phone : ");
            string phonePilot = Console.ReadLine();
            Console.Write("Enter License Number: ");
            string numberLicense = Console.ReadLine();
            Console.WriteLine("Enter flight Hours: ");
            int hoursFlight = int.Parse(Console.ReadLine());

            int idPilot = context.pilots.Count + 1;

            context.pilots.Add(new Pilot
            {
                pilotId = idPilot,
                pilotName = namePilot,
                pilotPhone = phonePilot,
                licenseNumber = numberLicense,
                isAvailable = true
            });
        }

        //// =======================================================
        ////              **** View All Flights (CRUD) ****
        //// =======================================================
        //public static void ViewAllFlights()
        //{
        //    Console.WriteLine("\n=== View all flights ===");

        //}










        static void Main(string[] args)
        {
        }
    }
}


