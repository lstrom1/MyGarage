using MyGarage.DAL;
using MyGarage.Model;

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
    }
}
