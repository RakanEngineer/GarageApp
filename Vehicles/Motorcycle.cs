using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApp.Vehicles
{
    public class Motorcycle : Vehicle
    {
        public double CylinderVolume { get; set; } // t.ex. 600.0

        public Motorcycle(string regNr, string color, int wheels, double cylinderVolume)
            : base(regNr, color, wheels)
        {
            CylinderVolume = cylinderVolume;
        }

        public override string VehicleType => "Motorcycle";

        public override string ToString()
        {
            return base.ToString() + $" | Cylinder: {CylinderVolume}cc";
        }
    }
}
