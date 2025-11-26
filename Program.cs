
namespace GarageApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Garage Application!");
            while (true)
            {
                Console.Clear();
                Console.WriteLine("== Garage 1.0 ===");
                Console.WriteLine("1.Park a vehicle");
                Console.WriteLine("2.Remove a vehicle\"");
                Console.WriteLine("3.List all vehicles");
                Console.WriteLine("4.Search for a vehicle");
                Console.WriteLine("5.Exit");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": AddVehicleMenu(); break;
                    case "2": RemoveVehicleMenu(); break;
                    case "3": ListVehicles(); break;
                    case "4": SearchVehicle(); break;
                    case "5": return;
                    default: Console.WriteLine("Invalid choice"); break;
                }

            }
        }

        private static void AddVehicleMenu()
        {
        }

        private static void RemoveVehicleMenu()
        {
        }

        private static void ListVehicles()
        {
        }

        private static void SearchVehicle()
        {
        }
    }
}
