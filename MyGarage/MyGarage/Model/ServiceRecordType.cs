using System;

namespace MyGarage.Model
{
    class ServiceRecordType
    {
        public int serviceRecordType { get; set; }

        public int serviceRecordID { get; set; }

        public int serviceCategoryID { get; set; }

        public DateTime dateOfService { get; set; }

        public int mileage { get; set; }

        public string categoryName { get; set; }
    }
}
