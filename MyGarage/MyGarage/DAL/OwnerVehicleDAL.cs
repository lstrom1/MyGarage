﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyGarage.Model;
using System.Data.SqlClient;
using MyGarage.DB;
using System.Windows.Forms;

namespace MyGarage.DAL
{
    class OwnerVehicleDAL
    {
        public static int CreateOwnerVehicle(OwnerVehicle newOwnerVehicle)
        {
            int exitStatus = 0;

            SqlConnection connection = DBConnection.GetConnection();

            string insertStatement = "INSERT ownerVehicle (ownerID, vehicleID) VALUES (@ownerID, @vehicleID)";

            SqlCommand insertCommand = new SqlCommand(insertStatement, connection);

            insertCommand.Parameters.AddWithValue("@ownerID", newOwnerVehicle.ownerID);
            insertCommand.Parameters.AddWithValue("@vehicleID", newOwnerVehicle.vehicleID);

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