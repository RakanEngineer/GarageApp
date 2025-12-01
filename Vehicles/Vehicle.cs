using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GarageApp.Vehicles
{
    public abstract class Vehicle : IVehicle
    {
        public string RegistrationNumber { get; set; }
        public string Color { get; set; }
        public int NumberOfWheels { get; set; }
        public abstract string VehicleType { get; }

        public string vehicleType => throw new NotImplementedException();

        public Vehicle(string regNumber, string color, int wheels)
        {
            if (string.IsNullOrWhiteSpace(regNumber))
                throw new ArgumentException("Registreringsnummer får inte vara tomt", nameof(regNumber));
            RegistrationNumber = regNumber;
            Color = color;
            NumberOfWheels = wheels;
        }

        internal bool GetInfo()
        {
            Console.WriteLine($"RegNumber: {RegistrationNumber}, Color: {Color}, Number of Wheels: {NumberOfWheels}");
            return true;
        }
        public override string ToString()
        {
            return $"{VehicleType} | RegNr: {RegistrationNumber} | Color: {Color} | Wheels: {NumberOfWheels}";
        }
    }
}
