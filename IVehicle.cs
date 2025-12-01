using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApp
{
    public interface IVehicle
    {
        string RegistrationNumber { get; }
        string Color { get; set; }
        int NumberOfWheels { get; set; }
        string VehicleType { get; }
    }
}
