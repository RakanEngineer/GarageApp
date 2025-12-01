using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApp.Vehicles
{
    internal class Airplane : Vehicle
    {
        public Airplane(string regNumber, string color, int wheels, int engines) : base(regNumber, color, wheels)
        {
            NumberOfEngines = engines;
        }

        public int NumberOfEngines { get; set; }

        public override string VehicleType => throw new NotImplementedException();
    }
}
