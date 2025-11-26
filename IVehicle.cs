using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApp
{
    internal interface IVehicle
    {
        string RegNumber { get; }
        string Color { get; }
        int NumberOfWheels { get; }       
    }
}
