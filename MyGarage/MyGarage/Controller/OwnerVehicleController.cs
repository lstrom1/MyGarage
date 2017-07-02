using MyGarage.Model;
using MyGarage.DAL;

namespace MyGarage.Controller
{
    class OwnerVehicleController
    {
        public int AddOwnerVehicle(OwnerVehicle newOwnerVehicle)
        {
            return OwnerVehicleDAL.CreateOwnerVehicle(newOwnerVehicle);
        }

        public int RemoveOwnerVehicle(OwnerVehicle oldOwnerVehicle)
        {
            return OwnerVehicleDAL.RemoveOwnerVehicle(oldOwnerVehicle); 
        }
    }
}
