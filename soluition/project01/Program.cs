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

        //// =======================----------=====================
        ////              **** Easy — Straightforward CRUD ****
        //// =======================----------=====================


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

        public static void ViewAllFlights()
        {
            
            Console.WriteLine("\n=== View all flights ===");

            foreach (Flight F in context.flights)
            {
                Console.WriteLine($" Flight ID: {F.flightId}  |  Code: {F.flightCode}  |  Aircraft ID: {F.aircraftId}" +
                                  $" | Pilot ID: {F.pilotId}  |  Origin: {F.origin}  |  Destination: {F.destination} " +
                                  $" | DepartureDate: {F.departureDate}  | DepartureTime: {F.departureTime}  |  TicketPrice: {F.ticketPrice}   " +
                                  $" | AvailableSeats:{F.availableSeats}  |  FlightDuration: {F.flightDuration}  |  Status: {F.status}");
            }

        }


        //// =======================----------=====================
        ////             Medium — Logic & Cross-Entity Operations
        //// =======================----------=====================
        



        //// =======================================================
        ////              **** Schedule Flights ****
        //// =======================================================

        public static void ScheduleFlight()
        {
            Console.WriteLine("\n=== Add Schedule flights ===");

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

            // ---- Automatically generate flight number & Code: -----
            int idFlight = context.flights.Count + 1;
            string codeFlight = "OA - " + idFlight;

            // ---- Show all Aircraft in system: -----

            Console.WriteLine("\n ==== Available Aircrafts: === ");

            foreach (Aircraft a in context.aircrafts)
            {
                if (a.isOperational)
                {
                    Console.WriteLine($"ID: {a.aircraftId} | Model: {a.model}");
                }
            }

            // ---- choose aircraft id: -----
            Console.WriteLine("Enter aircraft id: ");
            int idAircraft = int.Parse(Console.ReadLine());

        

            // ---- Show all pilot in system: -----

            foreach (Pilot P in context.pilots)
                //.Where(P => P.isAvailable )) 
            {
                if (P.isAvailable)
                {
                    Console.WriteLine($"ID: {P.pilotId} ");

                }
            }

            // ---- choose pilot id: -----

            Console.WriteLine("Enter pilot id: ");
            int idPilot = int.Parse(Console.ReadLine());

            // للتحقق من وجود الطيار  وهل فاضي او لا 
            Pilot pilot = context.pilots
                .FirstOrDefault(P => P.pilotId == idPilot);

            if (pilot == null || !pilot.isAvailable)
            {
                Console.WriteLine("Invalid  Pilot");
                return;
            }

            // للتحقق من وجود الطائرة 

            Aircraft aircraft = context.aircrafts
                .FirstOrDefault(a => a.aircraftId == idAircraft);

            if (aircraft == null || !aircraft.isOperational)
            {
                Console.WriteLine("Invalid  Aircraft");
                return;
            }

            
        // المقاعد تجي من الطائرة مباشرة
            int seatsAvailable = aircraft.totalSeats;


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
                status = "Scheduled"
            });


            pilot.isAvailable = false;

            Console.WriteLine($" add flights successfully with flight ID: {idFlight}");


        }

        //// =======================================================
        ////              **** Book a Flights ****
        //// =======================================================

        public static void BookFlight()
        {
            Console.WriteLine("Enter Passenger ID:");
            int idPassenger = int.Parse(Console.ReadLine());


            // اتاكد من ID 
            Passenger passenger = context.passengers
                .FirstOrDefault(p => p.passengerId == idPassenger);

            if (passenger == null ) 
            {
                Console.WriteLine("Invalid Passenger.");
                return;
            }

            // Choose destination:
            Console.WriteLine(" Choose destination:");
            string selectedDestination = Console.ReadLine();


            //View all destination is available:

            Console.WriteLine("\n ==== Available destination: === ");


            foreach (Flight d in context.flights)
            {
                if (d.status == "Scheduled" && 
                    d.destination == selectedDestination &&
                    d.availableSeats > 0)
                {
                    Console.WriteLine($" Flights ID: {d.flightId}    |    Code: {d.flightCode} " +
                                 $"The Status: {d.status}    |   Destination: {d.destination} " +
                                 $"Available Seat: {d.availableSeats} ");
                }
            
            }


            Console.WriteLine(" Select flight: ");
            int idFlight = int.Parse (Console.ReadLine());

            Flight flight = context.flights
                    .FirstOrDefault(F => F.flightId == idFlight);


            if (flight == null ||
                flight.status != "Scheduled" ||
                flight.availableSeats <= 0)
            {
                Console.WriteLine("Invalid Flight");
                return;
            }

            Console.WriteLine("Enter Booking data:");
            string dateBooking = Console.ReadLine();


            int idBooking = context.bookings.Count + 1;

            context.bookings.Add(new Booking
            {
                bookingId = idBooking,
                passengerId = idPassenger,
                flightId = idFlight,
                seatNumber =  flight.availableSeats + "A" ,
                bookingDate = dateBooking,
                totalPrice = flight.ticketPrice,
                status = "Confirmed"
            });

            flight.availableSeats--;

            Console.WriteLine($"Booking created successfully. Booking ID: {idBooking}");
        }

        //// =======================================================
        ////              **** Cancel a Booking ****
        //// =======================================================


        public static void CancelBooking()
        {
            Console.WriteLine("\n=== Cancel Booking ===");


            // Enter id for cancelled
            Console.WriteLine("Enter booking id:");
            int bookingId = int.Parse(Console.ReadLine());

            //check
            Booking booking = context.bookings
                  .FirstOrDefault(b => b.bookingId == bookingId);

            if ( booking == null)
            {
                Console.WriteLine("Booking not found.");
                return;

            }



            // Check and returned seat 
            Flight flight = context.flights
                            .FirstOrDefault(x => x.flightId == booking.flightId);
                             flight.availableSeats++;


            // now booking is cancelled 
            booking.status = "Cancelled";

            Console.WriteLine($" Booking {bookingId} has been cancelled and the time booking is now available again.");

        }


        //// =======================================================
        ////              **** Depart a Flight ****
        //// =======================================================

        public static void DepartFlight()
        {

            //Enter flight id:
            Console.WriteLine("Enter flight id: ");
            int id = int.Parse(Console.ReadLine());


            Flight flight = context.flights
                         .FirstOrDefault(Y => Y.flightId == id);

            if(flight == null)
            {
                Console.WriteLine("Invalid flight");
                return;
            }

            flight.status = "Departed";

         
            Pilot pilot = context.pilots
                .FirstOrDefault(f => f.pilotId == flight.pilotId);


            if (pilot == null)
            {
                Console.WriteLine("Pilot not found");
                return;
            }

            pilot.flightHours += flight.flightDuration;

            Console.WriteLine("Flight departed successfully.");
        }

        




        static void Main(string[] args)
        {
        }
    }
}


