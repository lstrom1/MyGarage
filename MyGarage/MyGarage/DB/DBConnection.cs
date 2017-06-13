using System.Data.SqlClient;

namespace MyGarage.DB
{
    class DBConnection
    {
        public static SqlConnection GetConnection()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "localhost";
            builder.InitialCatalog = "CS6920-team5";
            builder.IntegratedSecurity = true;
            SqlConnection connection = new SqlConnection(builder.ConnectionString);
            return connection;
        }
    }
}
