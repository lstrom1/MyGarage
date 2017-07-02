using MyGarage.Model;
using MyGarage.DAL;
using System.Collections.Generic;

namespace MyGarage.Controller
{
    class ServiceCategoryController
    {
        public int AddServiceCategory(ServiceCategory serviceCategory)
        {
            return ServiceCategoryDAL.CreateServiceCategory(serviceCategory); 
        }

        public List<ServiceCategory> GetCategoryList()
        {
            return ServiceCategoryDAL.GetServiceCategoryList(); 
        }
    }
}
