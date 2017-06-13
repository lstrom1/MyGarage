namespace MyGarage.Model
{
    class Vehicle
    {
        // VehicleiD type int in the DB primary key
        public int vehicleID { get; set; }

        // VIN type varchar(17) in the DB
        public string VIN { get; set; }

        // Make type varchar(45) in the DB
        public string make { get; set; }

        // Model type varchar(45) in the DB
        public string model { get; set; }

        // Year type varchar(4) in the DB
        public string year { get; set; }
    }
}
