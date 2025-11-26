using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApp
{
    internal class Vehicle
    {
        public string RegNumber { get; set; }
        public string Color { get; set; }
        public int NumberOfWheels { get; set; }
        public Vehicle(string regNumber, string color, int wheels)
        {
            RegNumber = regNumber;
            Color = color;
            NumberOfWheels = wheels;
        }
    }
}
