using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyGarageData.Model;
using MyGarageData.DAL; 

namespace MyGarage.Controller
{
    class OwnerController
    {
        public int AddOwner(Owner newOwner)
        {
            return OwnerDAL.CreateOwner(newOwner); 
        }
    }
}
