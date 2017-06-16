using System.Data.SqlClient;

namespace MyGarage.DB
{
    class DBConnection
    {
        public static SqlConnection GetConnection()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "mygarage.cezil3uadcim.us-east-2.rds.amazonaws.com,1433";
            builder.UserID = "mygarage";
            builder.Password = "8923dfahuweiQUWI";
            builder.InitialCatalog = "CS6920-team5";
            builder.IntegratedSecurity = false;
            SqlConnection connection = new SqlConnection(builder.ConnectionString);
            return connection;
        }
    }
}
