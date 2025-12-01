using System.Reflection.Metadata;

namespace GarageApp
{
    internal class GarageHandler : IHandler
    {
        private Garage<IVehicle> _garage;
        public GarageHandler()
        {
        }
        public string CreateGarage(int capacity)
        {
            _garage = new Garage<IVehicle>(capacity);
            return $"New garage created with capacity {capacity}.";
        }


        public IEnumerable<IVehicle> ListAll()
        {
            if (_garage == null) return Enumerable.Empty<IVehicle>();
            return _garage.GetAll();
        }

        public Dictionary<string, int> GetCountsByType()
        {
            if (_garage == null) return new Dictionary<string, int>();
            return _garage.CountByType();
        }

        public (bool ok, string message) ParkVehicle(IVehicle vehicle)
        {
            if (_garage == null) return (false, "Create garage first.");
            var ok = _garage.Add(vehicle, out var message);
            return (ok, message);
        }

        public (IVehicle vehicle, string message) RetrieveVehicle(string registrationNumber)
        {
            if (_garage == null) return (null, "Create garage first.");
            var v = _garage.Remove(registrationNumber, out var message);
            return (v, message);
        }

        public string PopulateSampleData()
        {
            if (_garage == null) return "Create garage first.";
            var samples = new List<IVehicle>
            {
                new Car("ABC123", "Red", 4, 5, 5, "Gasoline"),
                new Car("XYZ987", "Blue", 4, 5, 5, "Diesel"),
                new Motorcycle("MOTO1", "Pink", 3, 250),
                new Bus("BUS01", "White", 6, 40),
                new Boat("BOAT9", "White", 0, 8.5),
                new Airplane("PLN100", "White", 6, 2)
            };
            _garage.Populate(samples);
            return "The garage has been filled with sample data (as far as capacity allows).";
        }

        public IVehicle FindVehicle(string registrationNumber)
        {
            if (_garage == null) return null;
            return _garage.FindByRegistration(registrationNumber);
        }

        public IEnumerable<IVehicle> SearchByCriteria(string color = null, int? wheels = null, string type = null)
        {
            if (_garage == null) return Enumerable.Empty<IVehicle>();
            return _garage.Search(v =>
            {
                bool match = true;
                if (!string.IsNullOrWhiteSpace(color))
                    match &= string.Equals(v.Color, color, StringComparison.OrdinalIgnoreCase);
                if (wheels.HasValue)
                    match &= v.NumberOfWheels == wheels.Value;
                if (!string.IsNullOrWhiteSpace(type))
                    match &= string.Equals(v.VehicleType, type, StringComparison.OrdinalIgnoreCase);
                return match;
            });
        }
    }
}