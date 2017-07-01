using MyGarage.Model;
using MyGarage.DAL;

namespace MyGarage.Controller
{
    class ServiceCategoryController
    {
        public int AddServiceCategory(ServiceCategory serviceCategory)
        {
            return ServiceCategoryDAL.CreateServiceCategory(serviceCategory); 
        }
    }
}
