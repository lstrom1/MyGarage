using System;

namespace MyGarage.Model
{
    class ServiceRecord
    {
        // serviceRecordID type int in the DB primary key
        public int serviceRecordID { get; set; }

        // vehicleID type int in the DB
        public int vehicleID { get; set; }

        // dateOfService type date in the DB
        public DateTime dateOfService { get; set; }

        // mileage type int in the DB
        public int mileage { get; set; }
    }
}
