using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApp.Vehicles
{
    internal class Bus : Vehicle
    {
        public int NumberOfSeats { get; set; }

        public override string VehicleType => throw new NotImplementedException();

        public Bus(string regNumber, string color, int wheels, int seats) : base(regNumber, color, wheels)
        {
            NumberOfSeats = seats;
        }
    }
}
