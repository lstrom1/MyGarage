using MyGarage.DB;
using MyGarage.Model;
using System;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace MyGarage.DAL
{
    class VehicleDAL
    {

        /// <summary>
        /// Creates a new Vehicle 
        /// </summary>
        /// <param name="newVehicle"></param>
        /// <returns></returns>
        public static int CreateVehicle(Vehicle newVehicle)
        {
            int exitStatus = 0;

            SqlConnection connection = DBConnection.GetConnection();

            string insertStatement =
                "INSERT vehicle " +
                    "(make, model, vehicleYear, VIN)" +
                "VALUES" +
                    "(@make, @model, @year, @VIN)";

            SqlCommand insertCommand = new SqlCommand(insertStatement, connection);

            insertCommand.Parameters.AddWithValue("@make", newVehicle.make);
            insertCommand.Parameters.AddWithValue("@model", newVehicle.model);
            insertCommand.Parameters.AddWithValue("@year", newVehicle.year);
            insertCommand.Parameters.AddWithValue("@VIN", newVehicle.VIN);

            try
            {
                connection.Open();
                insertCommand.ExecuteNonQuery();
                string selectStatement = "SELECT IDENT_CURRENT('vehicle') FROM vehicle";
                SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
                int vehicleID = Convert.ToInt32(selectCommand.ExecuteScalar());
                return vehicleID;
                //exitStatus = 0;
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
    }
}
