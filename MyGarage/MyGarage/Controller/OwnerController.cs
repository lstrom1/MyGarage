using System.Collections.Generic;
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

        public List<Owner> GetOwners(string first, string last)
        {
            return OwnerDAL.GetListByName(first, last); 
        }

        public List<Owner> SearchOwner(string first, string last, string phoneNumber)
        {
            return OwnerDAL.GetListByNameOrPhone(first, last, phoneNumber); 
        }

        public Owner GetOwner(int id)
        {
            return OwnerDAL.GetOwner(id); 
        }

        public int UpdateOwner(Owner existingOwner, Owner updatedOwner)
        {
            return OwnerDAL.EditOwner(existingOwner, updatedOwner);
        }


    }
}
