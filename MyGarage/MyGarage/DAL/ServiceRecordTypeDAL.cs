using MyGarage.DB;
using MyGarage.Model;
using System;
using System.Collections.Generic;
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
        /// <summary>
        /// Returns a list of services performed based on vehicleID
        /// </summary>
        /// <param name="vehicleID"></param>
        /// <returns></returns>
        public static List<ServiceRecordType> GetListServicesPerformedByVehicle(int vehicleID)
        {
            List<ServiceRecordType> servicesPerformedList = new List<ServiceRecordType>();
            string selectStatement = "SELECT SC.categoryName, SR.dateOfService, SR.mileage " +
                                     "FROM serviceRecordType SRC " +
                                     "JOIN serviceCategory SC ON SRC.serviceCategoryID = SC.serviceCategoryID " +
                                     "JOIN serviceRecord SR ON SRC.serviceRecordID = SR.serviceRecordID " +
                                     "WHERE SR.vehicleID = @vehicleID " +
                                     "ORDER BY SR.dateOfService DESC";
            SqlDataReader reader = null;
            SqlConnection connection = null;
            try
            {
                using (connection = DBConnection.GetConnection())
                {
                    connection.Open();
                    using (SqlCommand selectCommand = new SqlCommand(selectStatement, connection))
                    {
                        selectCommand.Parameters.AddWithValue("@vehicleID", vehicleID);

                        using (reader = selectCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ServiceRecordType src = new ServiceRecordType();
                                src.categoryName = reader["categoryName"].ToString();
                                src.dateOfService = (DateTime)reader["dateOfService"];
                                src.mileage = (int)reader["mileage"];
                                servicesPerformedList.Add(src);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connection != null)
                    connection.Close();
                if (reader != null)
                    reader.Close();
            }
            return servicesPerformedList;
        }
        /// <summary>
        /// Method checks to see if this Mileage for the specified vehicleID and categoryName is higher than the previous
        /// </summary>
        /// <param name="vehicleID"></param>
        /// <param name="categoryName"></param>
        /// <param name="mileage"></param>
        /// <returns>True if mileage is higher and False if mileage is lower</returns>
        public static bool checkMileageWhenAddingSRTAssociation(int vehicleID, string categoryName, int mileage)
        {
            int previousMileage = 0;
            
            SqlConnection connection = DBConnection.GetConnection();
            SqlCommand selectCommand = new SqlCommand();
            selectCommand.Connection = connection;
            selectCommand.CommandText = "SELECT MAX(sr.mileage) " +
                "FROM dbo.vehicle AS v " +
                "JOIN dbo.serviceRecord AS sr ON v.vehicleID = sr.vehicleID " +
                "JOIN dbo.serviceRecordType AS srt ON sr.serviceRecordID = srt.serviceRecordID " +
                "JOIN dbo.serviceCategory AS sc ON srt.serviceCategoryID = sc.serviceCategoryID " +
                "WHERE V.vehicleID = @vehicleID AND SC.categoryName = @categoryName";

            try
            {
                connection.Open();
                previousMileage = Convert.ToInt32(selectCommand.ExecuteScalar());

            }
            catch (SqlException ex)
            {
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
            if ( mileage > previousMileage)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
