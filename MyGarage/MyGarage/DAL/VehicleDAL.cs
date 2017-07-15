using MyGarage.DB;
using MyGarage.Model;
using System;
using System.Collections.Generic;
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

        public static List<Vehicle> GetListByName(string VIN)
        {
            System.Collections.Generic.List<Vehicle> vehList = new List<Vehicle>();
            string selectStatement = "SELECT * FROM vehicle " +
                "WHERE (VIN LIKE @VIN) AND (vehicleID not in (select distinct vehicleID from ownerVehicle)) order by VIN ";
            SqlDataReader reader = null;
            SqlConnection connection = null;
            try
            {
                using (connection = DBConnection.GetConnection())
                {
                    connection.Open();
                    using (SqlCommand selectCommand = new SqlCommand(selectStatement, connection))
                    {
                        if (String.IsNullOrEmpty(VIN))
                            selectCommand.Parameters.AddWithValue("@VIN", VIN);
                        else
                            selectCommand.Parameters.AddWithValue("@VIN", VIN + "%");

                        using (reader = selectCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Vehicle vehicle = new Vehicle();
                                vehicle.vehicleID = (int)reader["vehicleID"];
                                vehicle.VIN = reader["VIN"].ToString();
                                vehicle.make = reader["make"].ToString();
                                vehicle.model = reader["model"].ToString();
                                vehicle.year = reader["vehicleYear"].ToString();
                                vehList.Add(vehicle);
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
            return vehList;
        }

        public static List<Vehicle> GetListByCustomer(int ownerID)
        {
            System.Collections.Generic.List<Vehicle> vehList = new List<Vehicle>();
            string selectStatement = "Select ownervehicle.vehicleID, vin, make, model, vehicleyear " +
                "FROM ownervehicle left outer join vehicle on ownervehicle.vehicleID = vehicle.vehicleID " +
                "WHERE ownerID = @ownerID";
            SqlDataReader reader = null;
            SqlConnection connection = null;
            try
            {
                using (connection = DBConnection.GetConnection())
                {
                    connection.Open();
                    using (SqlCommand selectCommand = new SqlCommand(selectStatement, connection))
                    {
                        selectCommand.Parameters.AddWithValue("@ownerID", ownerID);

                        using (reader = selectCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Vehicle vehicle = new Vehicle();
                                vehicle.vehicleID = (int)reader["vehicleID"];
                                vehicle.VIN = reader["VIN"].ToString();
                                vehicle.make = reader["make"].ToString();
                                vehicle.model = reader["model"].ToString();
                                vehicle.year = reader["vehicleYear"].ToString();
                                vehList.Add(vehicle);
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
            return vehList;
        }

        public static List<Vehicle> GetAllList(string VIN)
        {
            System.Collections.Generic.List<Vehicle> vehList = new List<Vehicle>();
            string selectStatement = "SELECT * FROM vehicle " +
                "WHERE (VIN LIKE @VIN) order by VIN ";
            SqlDataReader reader = null;
            SqlConnection connection = null;
            try
            {
                using (connection = DBConnection.GetConnection())
                {
                    connection.Open();
                    using (SqlCommand selectCommand = new SqlCommand(selectStatement, connection))
                    {
                        if (String.IsNullOrEmpty(VIN))
                            selectCommand.Parameters.AddWithValue("@VIN", VIN);
                        else
                            selectCommand.Parameters.AddWithValue("@VIN", VIN + "%");

                        using (reader = selectCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Vehicle vehicle = new Vehicle();
                                vehicle.vehicleID = (int)reader["vehicleID"];
                                vehicle.VIN = reader["VIN"].ToString();
                                vehicle.make = reader["make"].ToString();
                                vehicle.model = reader["model"].ToString();
                                vehicle.year = reader["vehicleYear"].ToString();
                                vehList.Add(vehicle);
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
            return vehList;
        }

    }
}
