using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyGarageData.Model;
using System.Data.SqlClient;
using MyGarageData.DB;
using System.Windows.Forms;

namespace MyGarageData.DAL
{
    class OwnerDAL
    {
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

            return exitStatus;
        }
    }
}
