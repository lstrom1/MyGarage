using MyGarage.DAL;
using MyGarage.Model;

namespace MyGarage.Controller
{
    class ServiceRecordController
    {
        public int AddServiceRecord(ServiceRecord serviceRecord)
        {
            return ServiceRecordDAL.CreateServiceRecord(serviceRecord);
        }
    }
}
