using MyGarage.DB;
using MyGarage.Model;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace MyGarage.DAL
{
    class ServiceRecordTypeDAL
    {
        /// <summary>
        /// Associates a ServiceRecord with a ServiceCategory
        /// </summary>
        /// <param name="newServiceRecordType"></param>
        /// <returns></returns>
        public static int CreateServiceRecordType(ServiceRecordType newServiceRecordType)
        {
            int exitStatus = 0;

            SqlConnection connection = DBConnection.GetConnection();

            string insertStatement =
                "INSERT serviceRecordType " +
                    "(serviceRecordID, serviceCategoryID)" +
                "VALUES" +
                    "(@serviceRecordID, @serviceCategoryID)";

            SqlCommand insertCommand = new SqlCommand(insertStatement, connection);

            insertCommand.Parameters.AddWithValue("@serviceRecordID", newServiceRecordType.serviceRecordID);
            insertCommand.Parameters.AddWithValue("@serviceCategoryID", newServiceRecordType.serviceCategoryID);

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

        /// <summary>
        /// Disassociates a ServiceRecord with a ServiceCategory
        /// </summary>
        /// <param name="ownerVehicle"></param>
        /// <returns></returns>
        public static int RemoveServiceRecordType(ServiceRecordType serviceRecordType)
        {
            int exitStatus = 0;

            SqlConnection connection = DBConnection.GetConnection();

            string removeStatement = "DELETE FROM serviceRecordType " +
                "WHERE (serviceRecordID = @serviceRecordID AND serviceCategoryID = @serviceCategoryID)";

            SqlCommand removeCommand = new SqlCommand(removeStatement, connection);

            removeCommand.Parameters.AddWithValue("@serviceRecordID", serviceRecordType.serviceRecordID);
            removeCommand.Parameters.AddWithValue("@serviceCategoryID", serviceRecordType.serviceCategoryID);

            try
            {
                connection.Open();
                removeCommand.ExecuteNonQuery();
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
