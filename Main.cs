using GarageApp.UI;
using GarageApp.Vehicles;

namespace GarageApp
{
    internal class Main
    {
        //private ConsoleUI ui;
        private GarageHandler _garageHandler = new GarageHandler();
        private static IUI _ui = new ConsoleUI();
        private Garage<IVehicle> _garage;

        //public Main(ConsoleUI ui, GarageHandler handler)
        //{
        //    this.ui = ui;
        //    this.handler = handler;
        //}

        public Main(IUI ui, GarageHandler handler)
        {
            _ui = ui;
            _garageHandler = handler;
        }

        public void Run()
        {
            //SeedData();
            bool exit = false;
            do
            {
                Console.WriteLine("Welcome to the Garage Application!");

                DisplayMainMenu();
                string choice = _ui.GetInput();
                switch (choice)
                {
                    case "1":
                        CreateGarage();
                        break;

                    case "2":
                        Populate();
                        break;

                    case "3":
                        ListAll();
                        break;

                    case "4":
                        ListCounts();
                        break;

                    case "5":
                        ParkVehicle();
                        break;

                    case "6":
                        RetrieveVehicle();
                        break;

                    case "7":
                        SearchMenu();
                        break;

                    case "8":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            } while (!exit);

        }

        private void SearchMenu()
        {
            Console.Write("Color: ");
            var color = Console.ReadLine().Trim();
            Console.Write("Number of wheels: ");
            var wheelsInput = Console.ReadLine().Trim();
            int? wheels = int.TryParse(wheelsInput, out int w) ? w : null;
            Console.Write("Type of vehicle: ");
            var type = Console.ReadLine().Trim();
            var results = _garageHandler.SearchByCriteria(color, wheels, type).ToList();
            if (!results.Any())
            {
                Console.WriteLine("No vehicles found matching the criteria.");
            }
            else
            {
                Console.WriteLine("Vehicles found:");
                foreach (var vehicle in results)
                {
                    Console.WriteLine(vehicle.ToString());
                }
            }
            Pause();

        }

        private void RetrieveVehicle()
        {
            Console.Write("Enter the registration number of the vehicle to retrieve: ");
            var regNum = Console.ReadLine().Trim();
            var (vehicle, message) = _garageHandler.RetrieveVehicle(regNum);
            Console.WriteLine(message);
            if (vehicle != null)
            {
                Console.WriteLine("Retrieved vehicle details:");
                Console.WriteLine(vehicle.ToString());
            }
            Pause();

        }

        private void ParkVehicle()
        {
            if (_garage == null) Console.WriteLine("Create garage first.");
            else
            {
                Console.WriteLine("What type of vehicle? (Car, Motorcycle, Bus, Boat, Airplane)");
                var type = Console.ReadLine()?.Trim();
                try
                {
                    IVehicle vehicle = CreateVehicleFromInput(type);
                    if (vehicle == null)
                    {
                        Console.WriteLine("Could not create vehicle - invalid type or input.");
                        Pause();
                        return;
                    }

                    var (ok, message) = _garageHandler.ParkVehicle(vehicle);
                    Console.WriteLine(message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Fel: " + ex.Message);
                }
            }

            Pause();
        }

        private IVehicle CreateVehicleFromInput(string? type)
        {
            Console.Write("Registreringsnummer: ");
            var reg = Console.ReadLine().Trim();
            Console.Write("Färg: ");
            var color = Console.ReadLine().Trim();
            Console.Write("Antal hjul: ");
            if (!int.TryParse(Console.ReadLine(), out int wheels)) wheels = 0;

            switch ((type ?? "").ToLowerInvariant())
            {
                case "car":
                    Console.Write("Number of engines: ");
                    int engines = int.TryParse(Console.ReadLine(), out engines) ? engines : 1;
                    Console.Write("Number of seats: ");
                    int seats = int.TryParse(Console.ReadLine(), out seats) ? seats : 4;
                    Console.Write("Fuel type: ");
                    var fuel = Console.ReadLine();
                    return new Car(reg, color, wheels, engines, seats, fuel);
                case "motorcycle":
                    Console.Write("Cylinder size (cc): ");
                    double cyl = double.TryParse(Console.ReadLine(), out cyl) ? cyl : 0;
                    return new Motorcycle(reg, color, wheels, cyl);
                case "bus":
                    Console.Write("Number of seats: ");
                    int bSeats = int.TryParse(Console.ReadLine(), out bSeats) ? bSeats : 20;
                    return new Bus(reg, color, wheels, bSeats);
                case "boat":
                    Console.Write("Length (m): ");
                    double len = double.TryParse(Console.ReadLine(), out len) ? len : 0;
                    return new Boat(reg, color, wheels, len);
                case "airplane":
                    Console.Write("Number of engines: ");
                    int eng = int.TryParse(Console.ReadLine(), out eng) ? eng : 1;
                    return new Airplane(reg, color, wheels, eng);
                default:
                    return null;
            }
        }

        private void ListCounts()
        {
            var dict = _garageHandler.GetCountsByType();
            if (dict.Count == 0) Console.WriteLine("No vehicles or garage created.");
            else
            {
                foreach (var kvp in dict)
                    Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
            Pause();
        }

        private void ListAll()
        {
            var all = _garageHandler.ListAll().ToList();
            if (!all.Any())
            {
                Console.WriteLine("No vehicles in the garage.");
            }
            else
            {
                foreach (var v in all)
                {
                    Console.WriteLine(v.ToString());
                }
            }
            Pause();
        }

        private void Populate()
        {
            Console.WriteLine(_garageHandler.PopulateSampleData());
            Pause();
        }

        private void CreateGarage()
        {
            Console.Write("Please choose (number of parking spaces): ");
            if (int.TryParse(Console.ReadLine(), out int capacity) && capacity > 0)
            {
                Console.WriteLine(_garageHandler.CreateGarage(capacity));
            }
            else
            {
                Console.WriteLine("Invalid capacity.");
            }
            Pause();
        }

        private void Pause()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
        }

        private void DisplayMainMenu()
        {
            _ui.DisplayMessage("=== GARAGE 1.0 ===");
            _ui.DisplayMessage("1. Create garage");
            _ui.DisplayMessage("2. Populate with example data");
            _ui.DisplayMessage("3. List all vehicles");
            _ui.DisplayMessage("4. List vehicle types & counts");
            _ui.DisplayMessage("5. Park a vehicle");
            _ui.DisplayMessage("6. Retrieve a vehicle");
            _ui.DisplayMessage("7. Search for a vehicle");
            _ui.DisplayMessage("8. Exit");
        }
    }
}