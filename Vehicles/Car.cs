using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApp.Vehicles
{
    public class Car : Vehicle
    {
        public Car(string regNumber, string color, int wheels, int engines, int seats, string fuelType) : base(regNumber, color, wheels)
        {
            NumberOfEngines = engines;
            NumberOfSeats = seats;
            FuelType = fuelType;
        }

        public int NumberOfEngines { get; set; }
        public string FuelType { get; set; }
        public int NumberOfSeats { get; set; }
        public override string VehicleType => "Car";

        public override string ToString()
        {
            return base.ToString() + $" | Seats: {NumberOfSeats} | Fuel: {FuelType}";
        }
    }
}
