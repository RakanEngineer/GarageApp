using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApp
{
    internal class Bus : Vehicle
    {
        public int NumberOfSeats { get; set; }
        public Bus(string regNumber, string color, int wheels, int seats) : base(regNumber, color, wheels)
        {
            NumberOfSeats = seats;
        }
    }
}
