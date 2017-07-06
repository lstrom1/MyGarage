using System;
using System.Text;
using MyGarage.Model;
using System.Data.SqlClient;
using MyGarage.DB;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;

namespace MyGarage.DAL
{
    public class OwnerDAL
    {   
        /// <summary>
        /// Creates a new Owner 
        /// </summary>
        /// <param name="newOwner"></param>
        /// <returns>OwnerID of new owner</returns>
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
                string selectStatement = "SELECT IDENT_CURRENT('owner') FROM owner";
                SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
                int ownerID = Convert.ToInt32(selectCommand.ExecuteScalar());
                return ownerID;
                // exitStatus = 0;
            }
            catch (SqlException ex)
            {
                exitStatus = 0;
                
                StringBuilder errorDetails = new StringBuilder();
                for (int i = 0; i < ex.Errors.Count; i++)
                {
                    errorDetails.Append("Index #" + i + "\n" +
                        "Message: " + ex.Errors[i].Message + "\n" +
                        "Error Number: " + ex.Errors[i].Number + "\n" +
                        "Procedure: " + ex.Errors[i].Procedure + "\n");
                }
                MessageBox.Show(errorDetails.ToString(), "SQL Exception");
                return exitStatus;
            }
            finally
            {
                connection.Close();
            }

            //return exitStatus;
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
                "SET lastname = @updatedLastName, " +
                    "firstname = @updatedFirstName, " +
                    "streetAddress = @updatedStreetAddress, " +
                    "city = @updatedCity, " +
                    "state = @updatedState, " +
                    "zip = @updatedZip, " +
                    "phoneNumber = @updatedPhoneNumber, " +
                    "emailAddress = @updatedEmailAddress " +
                "WHERE ownerID = @ownerID";

            updateCommand.Parameters.AddWithValue("@updatedLastName", updatedOwner.lastName);
            updateCommand.Parameters.AddWithValue("@updatedFirstName", updatedOwner.firstName);
            updateCommand.Parameters.AddWithValue("@updatedStreetAddress", updatedOwner.streetAddress);
            updateCommand.Parameters.AddWithValue("@updatedCity", updatedOwner.streetAddress);
            updateCommand.Parameters.AddWithValue("@updatedState", updatedOwner.state);
            updateCommand.Parameters.AddWithValue("@updatedZip", updatedOwner.zip);
            updateCommand.Parameters.AddWithValue("@updatedPhoneNumber", updatedOwner.phoneNumber);
            updateCommand.Parameters.AddWithValue("@updatedEmailAddress", updatedOwner.emailAddress);
            updateCommand.Parameters.AddWithValue("@ownerID", existingOwner.ownerID);
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
        /// <summary>
        /// Get Owner 
        /// </summary>
        /// <param name="ownerID"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Retrieves a list of Owners based on input of First or Last Name 
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns>List of Owners</returns>
        public static List<Owner> GetListByName(string firstName, string lastName)
        {
            System.Collections.Generic.List<Owner> ownerList = new List<Owner>();
            string selectStatement = "SELECT * FROM owner " +
                "WHERE (firstName LIKE @firstName OR lastName LIKE @lastname) " +
                "ORDER BY lastName";
            SqlDataReader reader = null;
            SqlConnection connection = null;
            try
            {
                using (connection = DBConnection.GetConnection())
                {
                    connection.Open();
                    using (SqlCommand selectCommand = new SqlCommand(selectStatement, connection))
                    {
                        if (String.IsNullOrEmpty(firstName))
                            selectCommand.Parameters.AddWithValue("@firstName", firstName);
                        else
                            selectCommand.Parameters.AddWithValue("@firstName", firstName + "%");

                        if (String.IsNullOrEmpty(lastName))
                            selectCommand.Parameters.AddWithValue("@lastName", lastName);
                        else
                            selectCommand.Parameters.AddWithValue("@lastName", lastName + "%");

                        using (reader = selectCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Owner owner = new Owner();
                                owner.ownerID = (int)reader["ownerID"];
                                owner.firstName = reader["firstName"].ToString();
                                owner.lastName = reader["lastName"].ToString();
                                owner.streetAddress = reader["streetAddress"].ToString();
                                owner.city = reader["city"].ToString();
                                owner.state = reader["state"].ToString();
                                owner.zip = reader["zip"].ToString();
                                owner.phoneNumber = reader["phoneNumber"].ToString();
                                owner.emailAddress = reader["emailAddress"].ToString();
                                ownerList.Add(owner);
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
            return ownerList;
        }
        /// <summary>
        /// Retrieves a list of Owners based on FirstName, lastName, or phoneNumber
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="phoneNumber"></param>
        /// <returns>List of Owners</returns>
        public static List<Owner> GetListByNameOrPhone(string firstName, string lastName, string phoneNumber)
        {
            System.Collections.Generic.List<Owner> ownerList = new List<Owner>();
            string selectStatement = "SELECT * FROM owner " +
                "WHERE (firstName LIKE @firstName OR lastName LIKE @lastName OR phoneNumber LIKE @phoneNumber) " +
                "ORDER BY lastName";
            SqlDataReader reader = null;
            SqlConnection connection = null;
            try
            {
                using (connection = DBConnection.GetConnection())
                {
                    connection.Open();
                    using (SqlCommand selectCommand = new SqlCommand(selectStatement, connection))
                    {
                        if (String.IsNullOrEmpty(firstName))
                            selectCommand.Parameters.AddWithValue("@firstName", firstName);
                        else
                            selectCommand.Parameters.AddWithValue("@firstName", firstName + "%");

                        if (String.IsNullOrEmpty(lastName))
                            selectCommand.Parameters.AddWithValue("@lastName", lastName);
                        else
                            selectCommand.Parameters.AddWithValue("@lastName", lastName + "%");

                        if (String.IsNullOrEmpty(lastName))
                            selectCommand.Parameters.AddWithValue("@phoneNumber", phoneNumber);
                        else
                            selectCommand.Parameters.AddWithValue("@phoneNumber", phoneNumber + "%");

                        using (reader = selectCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Owner owner = new Owner();
                                owner.ownerID = (int)reader["ownerID"];
                                owner.firstName = reader["firstName"].ToString();
                                owner.lastName = reader["lastName"].ToString();
                                owner.streetAddress = reader["streetAddress"].ToString();
                                owner.city = reader["city"].ToString();
                                owner.state = reader["state"].ToString();
                                owner.zip = reader["zip"].ToString();
                                owner.phoneNumber = reader["phoneNumber"].ToString();
                                owner.emailAddress = reader["emailAddress"].ToString();
                                ownerList.Add(owner);
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
            return ownerList;
        }
    }
}
