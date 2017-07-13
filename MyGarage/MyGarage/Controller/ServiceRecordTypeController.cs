using MyGarage.DAL;
using MyGarage.Model;
using System.Collections.Generic;

namespace MyGarage.Controller
{
    class ServiceRecordTypeController
    {
        public int AddServiceRecordType(ServiceRecordType newServiceRecordType)
        {
            return ServiceRecordTypeDAL.CreateServiceRecordType(newServiceRecordType);
        }

        public int RemoveServiceRecordType(ServiceRecordType oldServiceRecordType)
        {
            return ServiceRecordTypeDAL.RemoveServiceRecordType(oldServiceRecordType);
        }

        public List<ServiceRecordType> GetRecordByVehicle(int vehicleID)
        {
            return ServiceRecordTypeDAL.GetListServicesPerformedByVehicle(vehicleID); 
        }

    }
}
