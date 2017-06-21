using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGarage.Model
{
    class ServiceCategory
    {
        public int serviceCategoryID { get; set; }
        public string categoryName { get; set; }
        public int numberOfDays { get; set; }
        public int mileageIntervals { get; set; }
    }
}
