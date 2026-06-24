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

            Console.WriteLine($"register pilot successfully with Pilot ID: {idPilot}");

        }

        //// =======================================================
        ////              **** Add Flights (CRUD) ****
        //// =======================================================

        public static void AddFlights()
        {
            Console.WriteLine("\n=== Add flights ===");

            Console.WriteLine("Enter flight code: ");
            string codeFlight = Console.ReadLine();
            Console.WriteLine("Enter aircraft id: ");
            int idAircraft = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter pilot id: ");
            int idPilot = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter origin: ");
            string origin = Console.ReadLine();
            Console.WriteLine("Enter destination: ");
            string destination = Console.ReadLine();
            Console.WriteLine("Enter departureDate: ");
            string dateDeparture = Console.ReadLine();
            Console.WriteLine("Enter departureTime: ");
            string timeDeparture = Console.ReadLine();
            Console.WriteLine("Enter ticketPrice: ");
            decimal priceTicket = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Enter available Seats: ");
            int seatsAvailable = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter flightDuration: ");
            string durationFlight = Console.ReadLine();

            int idFlight = context.flights.Count + 1;

            context.flights.Add(new Flight
            {
                flightId = idFlight,
                flightCode = codeFlight,
                aircraftId = idAircraft,
                pilotId = idPilot,
                origin = origin,
                destination = destination,
                departureDate = dateDeparture,
                departureTime = timeDeparture,
                ticketPrice = priceTicket,
                availableSeats = seatsAvailable,
                flightDuration = durationFlight,
                status = "Scheduled"
            });

            Console.WriteLine($" add flights successfully with flight ID: {idFlight}");


        }

        //// =======================================================
        ////              **** View All Flights (CRUD) ****
        //// =======================================================
        public static void ViewAllFlights()
        {

            Console.WriteLine("\n=== View all flights ===");

            foreach(Flight F in context.flights)
            {
                Console.WriteLine($" Flight ID: {F.flightId}  |  Code: {F.flightCode}  |  Aircraft ID: {F.aircraftId}"  +
                                  $" | Pilot ID: {F.pilotId}  |  Origin: {F.origin}  |  Destination: {F.destination} "  +
                                  $" | DepartureDate: {F.departureDate}  | DepartureTime: {F.departureTime}  |  TicketPrice: {F.ticketPrice}   " +
                                  $" | AvailableSeats:{F.availableSeats}  |  FlightDuration: {F.flightDuration}  |  Status: {F.status}");
            }
        }





        static void Main(string[] args)
        {
        }
    }
}


