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
