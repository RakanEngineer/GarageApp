using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApp
{
    internal class Motorcycle : Vehicle
    {
        public Motorcycle(string regNumber, string color, int wheels, int EngineCapacity) : base(regNumber, color, wheels)
        {
            this.EngineCapacity = EngineCapacity;
        }
        public int EngineCapacity { get; set; }
    }
}
