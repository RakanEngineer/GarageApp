using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApp.Vehicles
{
    internal class Boat : Vehicle
    {
        public Boat(string regNumber, string color, int wheels, double length) : base(regNumber, color, wheels)
        {
            Length = length;
        }

        public double Length { get; set; }

        public override string VehicleType => "Boat";
    }
}
