using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyGarage.Model;
using MyGarage.DAL; 

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
