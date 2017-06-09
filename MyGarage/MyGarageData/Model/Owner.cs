namespace MyGarageData.Model
{

    class Owner
    {
        // OwnerID type int in the DB primary key
        public int ownerID { get; set; }

        // firstName type varchar(45) in the DB
        public string firstName { get; set; }

        // lastName type varchar(45) in the DB
        public string lastName { get; set; }

        // streetAddress type varchar(75) in the DB
        public string streetAddress { get; set; }

        // city type varchar(65) in the DB
        public string city { get; set; }

        // state type varchar(2)  in the DB
        public string state { get; set; }

        // zip type varchar(5)  in the DB
        public string zip { get; set; }

        // phoneNumber type varchar(12) in the DB
        public string phoneNumber { get; set; }

        // emailAddress type varchar(150) in the DB
        public string emailAddress { get; set; }
    }
}
