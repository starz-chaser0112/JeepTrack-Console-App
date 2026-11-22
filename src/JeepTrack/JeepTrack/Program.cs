using System;
class Jeeptrack
{
    // Methods

    // Welcoming Message
    static void WelcomeMessage()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine();
        Console.WriteLine("===================== Welcome to JeepTrack! =====================");
        Console.ResetColor();
    }

    // Available Locations
    static void DisplayLocations()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("                 ----- Available Locations -----\n");
        Console.WriteLine("\t> Lalakay\t\t\t > Bambang Highway");
        Console.WriteLine("\t> Maahas \t\t\t > Batong Malaki");
        Console.WriteLine("\t> Anos   \t\t\t > San Antonio");
        Console.WriteLine("\t> UPLB   \t\t\t > Timugan");
        Console.ResetColor();
    }

    // Passenger Type
    static void PassengerTypes()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("                 ----- Passenger Type -----\n");
        Console.WriteLine("\t > Regular \t\t\t\t > Student");
        Console.WriteLine("\t > PWD \t\t\t\t\t > Senior Citizen");
        Console.WriteLine();
        Console.ResetColor();
    }

    static void LocationMissing()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\t\t ----- LOCATION NOT FOUND! -----");
        Console.WriteLine();
        Console.ResetColor();
    }

    static bool RouteValidation(string origin, string destination, ref double travelDistance, ref double travelTime)
    {
        string[] fromLocations = {"MAAHAS", "SAN ANTONIO", "BATONG MALAKI", "BATONG MALAKI", "ANOS", "TIMUGAN", "BAMBANG HIGHWAY"};
        string[] toLocations = { "SAN ANTONIO", "BATONG MALAKI", "UPLB", "ANOS", "TIMUGAN", "BAMBANG HIGHWAY", "LALAKAY"};
        double[] mainDistances = { 4.7, 4.0, 2.2, 6.8, 1.7, 3.2, 6.3};
        double[] reverseDistances = { 1.3, 4.0, 2.2, 6.8, 1.7, 3.2, 4.4};
        double[] maintravelTime = {9.0, 15.0, 6.0, 15.0, 5.0, 5.0, 16.0};
        double[] reversetravelTime = { 3.0, 15.0, 9.0, 15.0, 5.0, 5.0, 9.0 };

        for (int i = 0; i < fromLocations.Length; i++)
        {
            if (fromLocations[i] == origin && toLocations[i] == destination) {
                travelDistance = mainDistances[i];
                travelTime = maintravelTime[i];
                return true;
            }
            else if (fromLocations[i] == destination && toLocations[i] == origin){
                travelDistance = reverseDistances[i];
                travelTime = reversetravelTime[i];
                return true;
            }

        }
        return false;
    }
    

    // Main Program
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        string[] locations = { "LALAKAY", "MAAHAS", "ANOS", "UPLB", "BAMBANG HIGHWAY", "BATONG MALAKI", "SAN ANTONIO", "TIMUGAN" };

        while (true)
        {
            // Display Welcome Message
            WelcomeMessage();

            
            string origin;
            string destination;

            // Current Location 


            while (true)
            {
                // Display Available Locations
                Console.WriteLine();
                DisplayLocations();
                Console.WriteLine();

                // Input Current Location
                Console.Write("Enter your current location: ");
                origin = (Console.ReadLine() ?? "").Trim().ToUpper();
                Console.WriteLine();

                // Location Validation
                bool locationFound = false;

                for (int i = 0; i < locations.Length; i++)
                {
                    if (origin == locations[i])
                    {
                        locationFound = true;
                        break;
                    }

                }


                if (locationFound)
                {
                    break;
                }
                LocationMissing();
            }

            //Destination
            while (true)
            {
                // Display Available Locations
                DisplayLocations();
                Console.WriteLine();

                // Input Destination
                Console.Write("Enter your destination: ");
                destination = (Console.ReadLine() ?? "").Trim().ToUpper();
                Console.WriteLine();

                // Location Validation

                bool locationFound = false;

                if (destination == origin)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("----- DESTINATION AND CURRENT LOCATION MUST BE DIFFERENT! -----");
                    Console.WriteLine();
                    Console.ResetColor();
                    continue;
                }

                for (int i = 0; i < locations.Length; i++)
                {
                    if (destination == locations[i])
                    {
                        locationFound = true;
                        break;
                    }

                }

                if (locationFound)
                {
                    break;
                }
                LocationMissing();
            }

            // Validating Route

            double travelDistance = 0;
            double travelTime = 0;

            if (!RouteValidation(origin, destination, ref travelDistance, ref travelTime))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\t\t ----- ROUTE NOT FOUND! -----");
                Console.WriteLine();
                Console.ResetColor();
                continue;
            }

            // Passenger Type
            string[] passengerTypes = { "REGULAR", "SENIOR CITIZEN", "PWD", "STUDENT" };
            string passengerType;

            while (true)
            {
                PassengerTypes();

                Console.Write("Enter passenger type: ");
                passengerType = (Console.ReadLine() ?? "").Trim().ToUpper();

                bool validPassenger = false;

                for (int i = 0; i < passengerTypes.Length; i++)
                {
                    if (passengerType == passengerTypes[i])
                    {
                        validPassenger = true;
                        break;
                    }
                }

                if (validPassenger)
                {
                    break;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();
                Console.WriteLine("\t     ----- INVALID PASSENGER TYPE! -----");
                Console.WriteLine();
                Console.ResetColor();

            }

            // Fare Calculation

            double initialDistance = 4.00;
            double initialRate = 14.00;
            double succeedingRate = 2.00;
            double discount = 0.20;
            double fare;
            double finalFare;

            if (travelDistance <= initialDistance)
            {
                fare = initialRate;
            }

            else
            {
                fare = (travelDistance - initialDistance) * succeedingRate + initialRate;
            }

            if (passengerType == "REGULAR")
            {
                discount = 0;
                finalFare = fare;
            }

            else
            {
                finalFare = fare - (fare * discount);
            }

            //Travel Information

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            Console.WriteLine("=========================== JEEPTRACK ===========================");
            Console.WriteLine("\t\t\t----- ROUTE -----");
            Console.WriteLine($"[ {origin} > {destination} ]");
            Console.WriteLine($"DISTANCE \t\t\t\t\t EST TRAVEL TIME");
            Console.WriteLine($"> {travelDistance:F1} km < \t\t\t\t\t > {travelTime} minutes <");
            Console.WriteLine("_________________________________________________________________");
            Console.WriteLine("\t\t    ----- PASSENGER TYPE -----");
            Console.WriteLine($"PASSENGER TYPE \t\t\t\t\t DISCOUNT");
            Console.WriteLine($"> {passengerType} <\t\t\t\t\t > {discount:P1} < ");
            Console.WriteLine("_________________________________________________________________");
            Console.WriteLine("\t\t\t----- FARE -----");
            Console.WriteLine($"BOUND TO: {origin} > {destination}\nFARE AMOUNT: ₱ {finalFare:F2}");
            Console.WriteLine("===================== HAVE A SAFE TRAVEL! =======================");
            Console.WriteLine();
            Console.ResetColor();

            // Returns
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("> Press any key to return... \t > Enter \"exit\" to terminate program...");
            string choice = (Console.ReadLine() ?? "").ToLower();
            Console.WriteLine();
            Console.ResetColor();

            if (choice == "exit")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Exiting the program...\n");
                Console.ResetColor();
                return;
            }
        }

    }
}
