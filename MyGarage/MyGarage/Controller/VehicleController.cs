using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyGarage.Model;
using MyGarage.DAL;

namespace MyGarage.Controller
{
    class VehicleController
    {
        public int AddVehicle(Vehicle newVehicle)
        {
            return VehicleDAL.CreateVehicle(newVehicle);
        }
    }
}
