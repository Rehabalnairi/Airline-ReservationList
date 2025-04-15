namespace Airline_ReservationList
{
    internal class Program
    {
        static string[] flightCodeArray = new string[100];
        static string[] fromCityArray = new string[100];
        static string[] toCityArray = new string[100];
        static DateTime[] departureTimeArray = new DateTime[100];
        static int[] durationArray = new int[100];
        static int FlightCounter = 0;
        static string[] passengerNameArray = new string[100];
        static string[] GenerateBookingIDArray = new string[100];

        List<string> flightCodeList = new List<string>();
        List<string> fromCityList = new List<string>();
        List<string> toCityList = new List<string>();
        List<DateTime> departureTimeList = new List<DateTime>();
        List<int> durationList = new List<int>();
        List<string> passengerNameList = new List<string>();
        List<string> GenerateBookingIDList = new List<string>();

        //List ----
        //List<string> flightCodeList = new List<string>();
        //List<string> fromCityList = new List<string>();
        //List<string> toCityList = new List<string>();
        //List<DateTime> departureTimeList = new List<DateTime>();
        //List<int> durationList = new List<int>();
        //List<string> passengerNameList = new List<string>();
        //List<string> GenerateBookingIDList = new List<string>();




        static void Main(string[] args)
        {

            DisplayWelcomeMessage();

            while (true)
            {
                Console.WriteLine("Select Role:");
                Console.WriteLine("1. Admin");
                Console.WriteLine("2. User");
                Console.WriteLine("3. Exit");
                int roleChoice = int.Parse(Console.ReadLine());

                switch (roleChoice)
                {
                    case 1:
                        ShowAdminMenu();
                        break;
                    case 2:
                        ShowUserMenu();
                        break;
                    case 3:
                        ExitApplication();
                        return;
                    default:
                        Console.WriteLine("Invalid Option. Please try again.");
                        break;
                }
            }
        }

        public static void ShowAdminMenu()
        {
            Console.WriteLine("Welcome Admin");
            while (true)
            {
                Console.WriteLine("\nAdmin Menu:");
                Console.WriteLine("1. Add Flight");
                Console.WriteLine("2. View All Flights");
                Console.WriteLine("3. Update Flight Departure Time");
                Console.WriteLine("4. Exit to Main Menu");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Add Flight code:");
                        string flightCode = Console.ReadLine();
                        Console.WriteLine("Add From city:");
                        string fromCity = Console.ReadLine();
                        Console.WriteLine("Add To city:");
                        string toCity = Console.ReadLine();
                        Console.WriteLine("Add Departure Time (e.g., 2024-04-10 12:03):");
                        DateTime departureTime = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("Add Duration (in hours):");
                        int duration = int.Parse(Console.ReadLine());
                        AddFlight(flightCode, fromCity, toCity, departureTime, duration);
                        break;
                    case 2:
                        DisplayAllFlights();
                        break;
                    case 3:
                        Console.WriteLine("Enter Flight Code to Update:");
                        string updateFlightCode = Console.ReadLine();
                        if (ValidateFlightCode(updateFlightCode))
                        {
                            for (int i = 0; i < FlightCounter; i++)
                            {
                                if (flightCodeArray[i] == updateFlightCode)
                                {
                                    UpdateFlightDepature(ref departureTimeArray[i]);
                                    Console.WriteLine("Departure time updated successfully.");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Flight not found.");
                        }
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("Invalid Option. Please try again.");
                        break;
                }
            }
        }

        public static void ShowUserMenu()
        {
            Console.WriteLine("Welcome User");
            while (true)
            {
                Console.WriteLine("\nUser Menu:");
                Console.WriteLine("1. Book Flight");
                Console.WriteLine("2. Cancel Flight Booking");
                Console.WriteLine("3. View Flights");
                Console.WriteLine("4. Search Bookings by Destination");
                Console.WriteLine("5. Exit to Main Menu");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter Passenger Name:");
                        string passengerName = Console.ReadLine();
                        string generatedPassengerNamed = GenerateBookingID(passengerName);
                        BookFlight(generatedPassengerNamed);
                        break;
                    case 2:
                        string passengerToCancel;
                        CancelFlightBooking(out passengerToCancel);
                        Console.WriteLine($"Booking for {passengerToCancel} has been canceled.");
                        break;
                    case 3:
                        DisplayAllFlights();
                        break;
                    case 4:
                        Console.WriteLine("Enter Destination City:");
                        string toCity = Console.ReadLine();
                        SearchBookingsByDestination(toCity);

                        return;
                    default:
                        Console.WriteLine("Invalid Option. Please try again.");
                        break;
                }
            }
        }
        public static void DisplayWelcomeMessage()
        {
            Console.WriteLine("Welcome to Airline Reservation System");
            Console.WriteLine("Please select your role:");
        }
        public static void ExitApplication()
        {
            Console.WriteLine("Thank you for using Airline Reservation");
        }

        public static void AddFlight(string flightCode, string fromCity, string toCity, DateTime departureTime, int duration)
        {
            if (FlightCounter < 100)
            {
                flightCodeArray[FlightCounter] = flightCode;
                fromCityArray[FlightCounter] = fromCity;
                toCityArray[FlightCounter] = toCity;
                departureTimeArray[FlightCounter] = departureTime;
                durationArray[FlightCounter] = duration;
                FlightCounter++;
                Console.WriteLine("Flight added successfully.");
            }
            else
            {
                Console.WriteLine("There is not space for add more flight ");
            }
        }

        //add flight to list
        public static void AddFlightToList(string flightCode2, string fromCity2, string toCity2, DateTime departureTime2, int duration2)
        {
            List<string> flightCodeList = new List<string>();
            List<string> fromCityList = new List<string>();
            List<string> toCityList = new List<string>();
            List<DateTime> departureTimeList = new List<DateTime>();
            List<int> durationList = new List<int>();
            List<string> passengerNameList = new List<string>();
            List<string> GenerateBookingIDList = new List<string>();


            flightCodeList.Add(flightCode2);
            fromCityList.Add(fromCity2);
            toCityList.Add(toCity2);
            departureTimeList.Add(departureTime2);
            durationList.Add(duration2);
        }

        //Disply all flights list
        public static void DisplayAllFlightsList()
        {
            List<string> flightCodeList = new List<string>();
            List<string> fromCityList = new List<string>();
            List<string> toCityList = new List<string>();
            List<DateTime> departureTimeList = new List<DateTime>();
            List<int> durationList = new List<int>();
            List<string> passengerNameList = new List<string>();
            List<string> GenerateBookingIDList = new List<string>();

            if (flightCodeList.Count == 0)
            {
                Console.WriteLine("No flights available.");
                return;
            }
            for (int i = 0; i < flightCodeList.Count; i++)
            {
                Console.WriteLine($"Flight Code {flightCodeList[i]}, From {fromCityList[i]}, To {toCityList[i]}, Departure Time is {departureTimeList[i]}, Duration time is {durationList[i]} ");
                Console.WriteLine("-------------------------------------------------");
            }
        }
        
        public static void DisplayAllFlights()
        {
            if (FlightCounter == 0)
            {
                Console.WriteLine("No flights available.");
                return;
            }
            for (int i = 0; i<FlightCounter; i++)
            {
                Console.WriteLine($"Flight Code {flightCodeArray[i]}, From {fromCityArray[i]}, To {toCityArray[i]}, Departure Time is {departureTimeArray[i]}, Duration time is {durationArray[i]} ");
                Console.WriteLine("-------------------------------------------------");
            }
        }
        //display all flights list
        public static void DisplayAllFlightsList2()
        {
            List<string> flightCodeList = new List<string>();
            List<string> fromCityList = new List<string>();
            List<string> toCityList = new List<string>();
            List<DateTime> departureTimeList = new List<DateTime>();
            List<int> durationList = new List<int>();
            List<string> passengerNameList = new List<string>();
            List<string> GenerateBookingIDList = new List<string>();
            if (flightCodeList.Count == 0)
            {
                Console.WriteLine("No flights available.");
                return;
            }
            for (int i = 0; i < flightCodeList.Count; i++)
            {
                Console.WriteLine($"Flight Code {flightCodeList[i]}, From {fromCityList[i]}, To {toCityList[i]}, Departure Time is {departureTimeList[i]}, Duration time is {durationList[i]} ");
                Console.WriteLine("-------------------------------------------------");
            }
        }


        public static bool FindFilghtByCode(string flightCode)
        {
            for (int i = 0; i < FlightCounter; i++)
            {
                if (flightCodeArray[i] == flightCode)
                {
                    return true;
                }
            }
            return false;
        }

        // FindFilghtByCode List
        public static bool FindFilghtByCodeList(string flightCode)
        {
            List<string> flightCodeList = new List<string>();
            for (int i = 0; i < flightCodeList.Count; i++)
            {
                if (flightCodeList[i] == flightCode)
                {
                    return true;
                }
            }
            return false;
        }

        public static DateTime UpdateFlightDepature(ref DateTime departureTime)
        {
            Console.WriteLine("Enter new departure time:");
            string newDepartureTime = Console.ReadLine();
            DateTime newDeparture = DateTime.Parse(newDepartureTime);
            departureTime = newDeparture;
            return departureTime;
        }

        // UpdateFlightDepature List
        public static string UpdateFlightDepatureList(ref DateTime departureTime)
        {
            Console.WriteLine("Enter new departure time:");
            string newDepartureTime = Console.ReadLine();
            DateTime newDeparture = DateTime.Parse(newDepartureTime);
            departureTime = newDeparture;
            return newDeparture.ToString();
        }


        public static string CancelFlightBooking(out string passengerName)
        {
            if (ConfirmAction("Cancel Booking"))
            {
                Console.WriteLine("Enter Booking ID:");
                string bookingID = Console.ReadLine();

                for (int i = 0; i < FlightCounter; i++)
                {
                    // Check if the booking ID matches the generated ID for the passenger
                    if (passengerNameArray[i] != null && GenerateBookingIDArray[i].Contains(bookingID))
                    {
                        passengerName = passengerNameArray[i];
                        passengerNameArray[i] = null; // Remove the booking
                        Console.WriteLine("Booking canceled successfully.");
                        return passengerName;
                    }
                }
                Console.WriteLine("Booking ID not found.");

            }
            else
            {
                Console.WriteLine("No Cancelation");
            }
            passengerName = null;
            return null;

        }
        // CancelFlightBooking List
        public static string CancelFlightBookingList(out string passengerName)
        {
            if (ConfirmAction("Cancel Booking"))
            {

                Console.WriteLine("Enter Booking ID:");
                string bookingID = Console.ReadLine();
                for (int i = 0; i < FlightCounter; i++)
                {
                    // Check if the booking ID matches the generated ID for the passenger
                    if (passengerNameArray[i] != null && GenerateBookingIDArray[i].Contains(bookingID))
                    {
                        passengerName = passengerNameArray[i];
                        passengerNameArray[i] = null; // Remove the booking
                        Console.WriteLine("Booking canceled successfully.");
                        return passengerName;
                    }
                }
                Console.WriteLine("Booking ID not found.");
            }
            else
            {
                Console.WriteLine("No Cancelation");
            }
            passengerName = null;
            return null;
        }

        public static void BookFlight(string passengerName, string flightCode = "Default001")
        {
            Console.WriteLine("Enter Fight code:");
            flightCode = Console.ReadLine();
            for (int i = 0; i<FlightCounter; i++)
            {
                if (flightCodeArray[i] == flightCode)
                {
                    passengerNameArray[i] = passengerName;
                    GenerateBookingIDArray[i] = GenerateBookingID(passengerName);
        Console.WriteLine("Booking ID: " + GenerateBookingIDArray[i]);
                    Console.WriteLine("Flight booked successfully");
                    return;
                }
}
Console.WriteLine("Flight not found");
        }
        // BookFlight List
        public static void BookFlightList(string passengerName, string flightCode = "Default001")
        {
            Console.WriteLine("Enter Fight code:");
            flightCode = Console.ReadLine();
            List<string> flightCodeList = new List<string>();
            for (int i = 0; i < flightCodeList.Count; i++)
            {
                if (flightCodeList[i] == flightCode)
                {
                    passengerNameArray[i] = passengerName;
                    GenerateBookingIDArray[i] = GenerateBookingID(passengerName);
                    Console.WriteLine("Booking ID: " + GenerateBookingIDArray[i]);
                    Console.WriteLine("Flight booked successfully");
                    return;
                }
            }
            Console.WriteLine("Flight not found");
        }

        // Validate flight code
        public static bool ValidateFlightCode(string flightCode)
        {
            for (int i = 0; i < FlightCounter; i++)
            {
                if (flightCodeArray[i] == flightCode)
                {
                    return true;
                }
            }
            return false;
        }
        // Validate flight code List
        public static bool ValidateFlightCodeList(string flightCode)
        {
            List<string> flightCodeList = new List<string>();
            for (int i = 0; i < flightCodeList.Count; i++) //.Count 
            {
                if (flightCodeList[i] == flightCode)
                {
                    return true;
                }
            }
            return false;
        }
        public static string GenerateBookingID(string passengerName)
        {
            Random random = new Random();
            int bookingIDrandom = random.Next(1000, 9999);
            string bookingID = passengerName + bookingIDrandom.ToString();
            return bookingID;
        }

        // GenerateBookingID List
        public static string GenerateBookingIDList2(string passengerName)
        {
            List<string> bookingIDList = new List<string>();
            Random random = new Random();
            string bookingID;

         
            do
            {
                int bookingIDrandom = random.Next(1000, 9999);
                bookingID = passengerName + bookingIDrandom.ToString();
            }
            while (bookingIDList.Contains(bookingID)); 

            bookingIDList.Add(bookingID);

            return bookingID;
        }
        // Display flight details
        public static void DisplayFlightDetails(string flightCode)
        {
            for (int i = 0; i < FlightCounter; i++)
            {
                if (flightCodeArray[i] == flightCode)
                {
                    Console.WriteLine("Flight code " + flightCodeArray[i]);
                    Console.WriteLine("The Rout From City " + fromCityArray[i] + " To City " + toCityArray[i]);
                    Console.WriteLine("Duration time is " + durationArray[i]);
                }
            }
        }
        // Display flight details List
        public static void DisplayFlightDetailsList(string flightCode)
        {
            List<string> flightCodeList = new List<string>();
            for (int i = 0; i < flightCodeList.Count; i++)
            {
                if (flightCodeList[i] == flightCode)
                {
                    Console.WriteLine("Flight code " + flightCodeList[i]);
                    Console.WriteLine("The Rout From City " + fromCityArray[i] + " To City " + toCityArray[i]);
                    Console.WriteLine("Duration time is " + durationArray[i]);
                }
            }
        }

        public static string SearchBookingsByDestination(string toCity)
        {
            Console.WriteLine("Enter the destination city:");
            toCity = Console.ReadLine();
            for (int i = 0; i < FlightCounter; i++)
            {
                if (toCityArray[i] == toCity)
                {
                    return toCity;
                }
            }
            return null;
        }
        // SearchBookingsByDestination List
        public static string SearchBookingsByDestinationList(string toCity)
        {
            Console.WriteLine("Enter the destination city:");
            toCity = Console.ReadLine();
            List<string> flightCodeList = new List<string>();
            for (int i = 0; i < flightCodeList.Count; i++)
            {
                if (toCityArray[i] == toCity)
                {
                    return toCity;
                }
            }
            return null;
        }
        public static int CalculateFare(int basePrice, int numTickets)
        {
            int totalFare = basePrice * numTickets;
            return totalFare;
        }
       
       
        public static double CalculateFare(double basePrice, int numTickets)
        {
            double totalFare = basePrice * numTickets;
            return totalFare;
        }
        public static double CalculateFare(int basePrice, int numTickets, int discount)
        {
            double totalFare = basePrice * numTickets;
            double discountAmount = (totalFare * discount) / 100;
            return discountAmount;
        }
        public static bool ConfirmAction(string action)
        {
            Console.WriteLine("Are you sure you want to " + action + "? (yes/no)");
            string response = Console.ReadLine();
            if (response.ToLower() == "yes")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // ConfirmAction List
        public static bool ConfirmActionList(string action)
        {
            Console.WriteLine("Are you sure you want to " + action + "? (yes/no)");
            string response = Console.ReadLine();
            if (response.ToLower() == "yes")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }


}
