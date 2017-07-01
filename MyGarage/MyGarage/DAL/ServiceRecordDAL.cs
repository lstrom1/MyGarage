using MyGarage.DB;
using MyGarage.Model;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace MyGarage.DAL
{
    class ServiceRecordDAL
    {
        /// <summary>
        /// Create a new ServiceRecord
        /// </summary>
        /// <param name="newServiceRecord"></param>
        /// <returns></returns>
        public static int CreateServiceRecord(ServiceRecord newServiceRecord)
        {
            int exitStatus = 0;

            SqlConnection connection = DBConnection.GetConnection();

            string insertStatement = "INSERT serviceRecord (vehicleID, dateOfService, mileage) " +
                "VALUES (@vehicleID, @dateOfservice, @mileage)";

            SqlCommand insertCommand = new SqlCommand(insertStatement, connection);

            insertCommand.Parameters.AddWithValue("@vehicleID", newServiceRecord.vehicleID);
            insertCommand.Parameters.AddWithValue("@dateOfService", newServiceRecord.dateOfService);
            insertCommand.Parameters.AddWithValue("@mileage", newServiceRecord.mileage);

            try
            {
                connection.Open();
                insertCommand.ExecuteNonQuery();
                exitStatus = 0;
            }
            catch (SqlException ex)
            {
                exitStatus = 1;
                StringBuilder errorDetails = new StringBuilder();
                for (int i = 0; i < ex.Errors.Count; i++)
                {
                    errorDetails.Append("Index #" + i + "\n" +
                        "Message: " + ex.Errors[i].Message + "\n" +
                        "Error Number: " + ex.Errors[i].Number + "\n" +
                        "Procedure: " + ex.Errors[i].Procedure + "\n");
                }
                MessageBox.Show(errorDetails.ToString(), "SQL Exception");
            }
            finally
            {
                connection.Close();
            }

            return exitStatus;
        }
    }
}
