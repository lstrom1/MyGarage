﻿using System;
using System.Collections.Generic;
using System.Text;
using MyGarage.Model;
using System.Data.SqlClient;
using MyGarage.DB;
using System.Windows.Forms;
using System.Data;

namespace MyGarage.DAL
{

    class ServiceCategoryDAL
    {
        /// <summary>
        /// Create a new ServiceCategory 
        /// </summary>
        /// <param name="newServiceCategory"></param>
        /// <returns></returns>
        public static int CreateServiceCategory(ServiceCategory newServiceCategory)
        {
            int exitStatus = 0;

            SqlConnection connection = DBConnection.GetConnection();

            string insertStatement = "INSERT serviceCategory (categoryName, numberOfDays, mileageInterval) " +
                "VALUES (@categoryName, @numberOfDays, @mileageIntervals)";

            SqlCommand insertCommand = new SqlCommand(insertStatement, connection);

            insertCommand.Parameters.AddWithValue("@categoryName", newServiceCategory.categoryName);
            insertCommand.Parameters.AddWithValue("@numberOfDays", newServiceCategory.numberOfDays);
            insertCommand.Parameters.AddWithValue("@mileageIntervals", newServiceCategory.mileageIntervals);

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
        /// Edit Service Category
        /// </summary>
        /// <param name="existingServiceCategory"></param>
        /// <param name="updateServiceCategory"></param>
        /// <returns></returns>
        public static int EditServiceCategory(ServiceCategory existingServiceCategory, ServiceCategory updateServiceCategory)
        {
            int exitStatus = 1;
            SqlConnection connection = DBConnection.GetConnection();
            SqlTransaction updateTran = null;
            SqlCommand updateCommand = new SqlCommand();
            updateCommand.Connection = connection;

            updateCommand.CommandText = "UPDATE serviceCategory " +
                "SET categoryName = @updatedCategoryName, " +
                    "numberOfDays = @updatedNumberOfDays, " +
                    "mileageInterval = @updatedMileageIntervals " +
                "WHERE serviceCategoryID = @serviceCategoryID";

            updateCommand.Parameters.AddWithValue("@updatedCategoryName", updateServiceCategory.categoryName);
            updateCommand.Parameters.AddWithValue("@updatedNumberOfDays", updateServiceCategory.numberOfDays);
            updateCommand.Parameters.AddWithValue("@updatedMileageIntervals", updateServiceCategory.mileageIntervals);
            updateCommand.Parameters.AddWithValue("@serviceCategoryID", existingServiceCategory.serviceCategoryID);
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
        /// Get service category based on serviceCategoryID
        /// </summary>
        /// <param name="serviceCategoryID"></param>
        /// <returns></returns>
        public static ServiceCategory GetServiceCategory(int serviceCategoryID)
        {
            ServiceCategory serviceCategory = new ServiceCategory();
            string selectStatement = "SELECT * FROM serviceCategory " +
                "WHERE serviceCategoryID = @serviceCategoryID";

            try
            {
                using (SqlConnection connection = DBConnection.GetConnection())
                {
                    connection.Open();
                    using (SqlCommand selectCommand = new SqlCommand(selectStatement, connection))
                    {
                        selectCommand.Parameters.AddWithValue("@serviceCategoryID", serviceCategory);
                        using (SqlDataReader reader = selectCommand.ExecuteReader())
                        {
                            int serviceCategoryName = reader.GetOrdinal("categoryName");

                            if(reader.Read())
                            {
                                serviceCategory.serviceCategoryID = (int)reader["serviceCategoryID"];
                                serviceCategory.categoryName = reader.GetString(serviceCategoryName);
                                serviceCategory.numberOfDays = (int)reader["numberOfDays"];
                                serviceCategory.mileageIntervals = (int)reader["mileageInterval"];
                            }
                            else
                            {
                                serviceCategory = null;
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
            return serviceCategory;
        }
        /// <summary>
        /// List of serviceCategory records
        /// </summary>
        /// <returns></returns>
        public static List<ServiceCategory> GetServiceCategoryList()
        {
            System.Collections.Generic.List<ServiceCategory> serviceCategoryList = new List<ServiceCategory>();
            string selectStatement = "SELECT serviceCategoryID, categoryName, numberOfDays, mileageInterval FROM serviceCategory ";
            SqlDataReader reader = null;
            SqlConnection connection = null;
            try
            {
                using (connection = DBConnection.GetConnection())
                {
                    connection.Open(); 
                    using (SqlCommand selectCommand = new SqlCommand(selectStatement, connection))
                    {
                        using (reader = selectCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ServiceCategory serviceCategory = new ServiceCategory();
                                serviceCategory.serviceCategoryID = (int)reader["serviceCategoryID"];
                                serviceCategory.categoryName = reader["categoryName"].ToString();
                                serviceCategory.numberOfDays = (int)reader["numberOfDays"];
                                serviceCategory.mileageIntervals = (int)reader["mileageInterval"];
                                serviceCategoryList.Add(serviceCategory);
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
            return serviceCategoryList;
        }
    }
}
