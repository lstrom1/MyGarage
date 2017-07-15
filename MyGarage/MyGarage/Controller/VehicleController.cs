using MyGarage.Model;
using MyGarage.DAL;
using System.Collections.Generic;

namespace MyGarage.Controller
{
    class VehicleController
    {
        public int AddVehicle(Vehicle newVehicle)
        {
            return VehicleDAL.CreateVehicle(newVehicle);
        }

        public List<Vehicle> GetVehicleList(string VIN)
        {
            return VehicleDAL.GetListByName(VIN); 
        }

        public List<Vehicle> GetCustVehicleList(int ownerID)
        {
            return VehicleDAL.GetListByCustomer(ownerID); 
        }

        public List<Vehicle> GetAllVehicleList(string VIN)
        {
            return VehicleDAL.GetAllList(VIN);
        }

        public List<Vehicle> GetCompleteVehicleList()
        {
            return VehicleDAL.GetAllVehiclesList(); 
        }


    }
}
