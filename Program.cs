
using GarageApp;
using GarageApp.UI;

namespace GarageApp.Vehicles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GarageHandler _garageHandler = new GarageHandler();
            IUI _ui = new ConsoleUI();
            Main main = new Main(_ui, _garageHandler);
            try
            {
                main.Run();
            }
            catch (ArgumentException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }                       
        }       
    }
}
