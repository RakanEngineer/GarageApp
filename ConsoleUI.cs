namespace GarageApp.Abstractions
{
    public class ConsoleUI: IUI
    {
        public void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        public string GetInput()
        {
            return Console.ReadLine() ?? string.Empty;
        }
    }
}
