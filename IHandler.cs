using GarageApp.Vehicles;

namespace GarageApp
{
    internal interface IHandler
    {
        string CreateGarage(int capacity);
        string PopulateSampleData();
        IEnumerable<IVehicle> ListAll();
        Dictionary<string, int> GetCountsByType();
        (bool ok, string message) ParkVehicle(IVehicle vehicle);
        (IVehicle vehicle, string message) RetrieveVehicle(string registrationNumber);
        IVehicle FindVehicle(string registrationNumber);
        IEnumerable<IVehicle> SearchByCriteria(string color = null, int? wheels = null, string type = null);
    }
}