﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyGarage.Model;
using MyGarage.DAL;

namespace MyGarage.Controller
{
    class ServiceController
    {
        public int AddServiceCat(ServiceCategory serviceCat)
        {
            return ServiceCategoryDAL.CreateServiceCategory(serviceCat); 
        }
    }
}
