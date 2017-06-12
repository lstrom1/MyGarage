using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyGarageData.Model;
using System.Data.SqlClient;
using MyGarageData.DB;
using System.Windows.Forms;
using System.Data;

namespace MyGarageData.DAL
{
    public class OwnerDAL
    {   
        /// <summary>
        /// Creates a new Owner 
        /// </summary>
        /// <param name="newOwner"></param>
        /// <returns></returns>
        public static int CreateOwner(Owner newOwner)
        {
            int exitStatus = 0;

            SqlConnection connection = DBConnection.GetConnection();

            string insertStatement =
                "INSERT owner " +
                    "(lastName, firstName, streetAddress, city, state, zip, phoneNumber, emailAddress)" +
                "VALUES" +
                    "(@lastName, @firstName, @streetAddress, @city, @state, @zip, @phoneNumber, @emailAddress)";

            SqlCommand insertCommand = new SqlCommand(insertStatement, connection);

            insertCommand.Parameters.AddWithValue("@lastName", newOwner.lastName);
            insertCommand.Parameters.AddWithValue("@firstName", newOwner.firstName);
            insertCommand.Parameters.AddWithValue("@streetAddress", newOwner.streetAddress);
            insertCommand.Parameters.AddWithValue("@city", newOwner.city);
            insertCommand.Parameters.AddWithValue("@state", newOwner.state);
            insertCommand.Parameters.AddWithValue("@zip", newOwner.zip);
            insertCommand.Parameters.AddWithValue("@phoneNumber", newOwner.phoneNumber);
            insertCommand.Parameters.AddWithValue("@emailAddress", newOwner.emailAddress);

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
        /// Edit Owner 
        /// </summary>
        /// <param name="existingOwner">Owner existing information</param>
        /// <param name="updatedOwner">Owner updated information</param>
        /// <returns></returns>
        public static int EditOwner(Owner existingOwner, Owner updatedOwner)
        {
            int exitStatus = 1;
            SqlConnection connection = DBConnection.GetConnection();
            SqlTransaction updateTran = null;
            SqlCommand updateCommand = new SqlCommand();
            updateCommand.Connection = connection;

            updateCommand.CommandText = "UPDATE owner " +
                "SET lastname = @updateLastName, " +
                    "firstname = @updatedFirstName, " +
                    "streetAddress = @updatedStreetAddress, " +
                    "city = @updatedCity, " +
                    "state = @updatedState, " +
                    "zip = @updatedZip, " +
                    "phoneNumber = @updatedPhoneNumber, " +
                    "emailAddress = @updatedEmailAddress, " +
                "WHERE ownerID = @ownerID";

            updateCommand.Parameters.AddWithValue("@updatedLastName", updatedOwner.lastName);
            updateCommand.Parameters.AddWithValue("@updatedFirstName", updatedOwner.firstName);
            updateCommand.Parameters.AddWithValue("@updatedStreetAddress", updatedOwner.streetAddress);
            updateCommand.Parameters.AddWithValue("@updatedCity", updatedOwner.streetAddress);
            updateCommand.Parameters.AddWithValue("@updatedState", updatedOwner.state);
            updateCommand.Parameters.AddWithValue("@updatedZip", updatedOwner.zip);
            updateCommand.Parameters.AddWithValue("@updatedPhoneNumber", updatedOwner.phoneNumber);
            updateCommand.Parameters.AddWithValue("@updatedEmailAddress", updatedOwner.emailAddress);

            try
            {
                connection.Open();
                updateTran = connection.BeginTransaction(IsolationLevel.Serializable);
                updateCommand.Transaction = updateTran;

                int successfulUpdatesCount = updateCommand.ExecuteNonQuery();

                if (successfulUpdatesCount > 0)
                {
                    updateTran.Commit();
                    exitStatus = 0;
                }
                else
                {
                    updateTran.Rollback();
                    exitStatus = 1;
                }
            }
            catch (SqlException ex)
            {
                exitStatus = 2;
                if (updateTran != null)
                {
                    updateTran.Rollback();
                }

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

        public static Owner GetOwner(int ownerID)
        {
            Owner owner = new Owner();
            string selectStatement = "SELECT * FROM owner " +
                "WHERE ownerID = @ownerID";

            try
            {
                using (SqlConnection connection = DBConnection.GetConnection())
                {
                    connection.Open();
                    using (SqlCommand selectCommand = new SqlCommand(selectStatement, connection))
                    {
                        selectCommand.Parameters.AddWithValue("@ownerID", ownerID);
                        using (SqlDataReader reader = selectCommand.ExecuteReader())
                        {
                            int ownLastName = reader.GetOrdinal("lastName");
                            int ownFirstName = reader.GetOrdinal("firstName");
                            int ownStreetAddress = reader.GetOrdinal("streetAddress");
                            int ownCity = reader.GetOrdinal("city");
                            int ownState = reader.GetOrdinal("state");
                            int ownZip = reader.GetOrdinal("zip");
                            int ownPhoneNumber = reader.GetOrdinal("phoneNumber");
                            int ownEmailAddress = reader.GetOrdinal("emailAddress");

                            if(reader.Read())
                            {
                                owner.ownerID = (int)reader["ownerID"];
                                owner.lastName = reader.GetString(ownLastName);
                                owner.firstName = reader.GetString(ownFirstName);
                                owner.streetAddress = reader.GetString(ownStreetAddress);
                                owner.city = reader.GetString(ownCity);
                                owner.state = reader.GetString(ownState);
                                owner.zip = reader.GetString(ownZip);
                                owner.phoneNumber = reader.GetString(ownPhoneNumber);
                                owner.emailAddress = reader.GetString(ownEmailAddress);
                            }
                            else
                            {
                                owner = null;
                            }
                            connection.Close();
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
            return owner;
        }
    }
}
