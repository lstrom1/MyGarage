using MyGarage.Controller;
using MyGarage.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyGarage.View
{
    public partial class ChooseReport : Form
    {

        OwnerController ownControl = new OwnerController();
        VehicleController vehControl = new VehicleController(); 

        public ChooseReport()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            cmbCustomers.Text = "";
            cmbCustomers.DataSource = null;
            if ((txtFirstName.Text != "" && txtLastName.Text != "") || (txtPhoneAreaCode.Text != "" && txtPhoneFirstThreeDigits.Text != "" && txtPhoneLastFourDigits.Text != ""))
            {
                try
                {
                    string phoneNum = txtPhoneAreaCode.Text + "-" + txtPhoneFirstThreeDigits.Text + "-" + txtPhoneLastFourDigits.Text;
                    List<Owner> ownList = ownControl.SearchOwner(txtFirstName.Text, txtLastName.Text, phoneNum);
                    cmbCustomers.DataSource = ownList;
                    cmbCustomers.DisplayMember = "ownerUnique";
                    cmbCustomers.ValueMember = "OwnerID";

                }
                catch (Exception)
                {
                    MessageBox.Show("An error has occured, please try again");
                }
            }
            else
            {
                MessageBox.Show("Please provide first and last name or complete phone number.");
            }
        }

        private void btnSearchVehicles_Click(object sender, EventArgs e)
        {
            if (txtVin.Text == "")
            {
                MessageBox.Show("Please enter a VIN to search by.");
            }
            else
            {
                try
                {
                    List<Vehicle> vehList = vehControl.GetAllVehicleList(txtVin.Text);
                    cmbVehicles.DataSource = vehList;
                    cmbVehicles.DisplayMember = "vehicleUnique";
                    cmbVehicles.ValueMember = "vehicleID";
                    if (vehList.Count == 0)
                    {
                        MessageBox.Show("There were no results for that VIN.");
                        cmbVehicles.Text = ""; 
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("An error has occured, please try again");
                }
            }
            }

        private void btnCustomerReport_Click(object sender, EventArgs e)
        {
            if (cmbCustomers.SelectedValue != null)
            {
                AllOwnerVehicleReport allVehicle = new AllOwnerVehicleReport(Convert.ToInt32(cmbCustomers.SelectedValue.ToString()));
                allVehicle.Show(); 
            } else
            {
                MessageBox.Show("Please select a customer to run a report for."); 
            }
        }

        private void btnAllVehicles_Click(object sender, EventArgs e)
        {
            try
            {
                List<Vehicle> vehList = vehControl.GetAllVehicleList("%");
                cmbVehicles.DataSource = vehList;
                cmbVehicles.DisplayMember = "vehicleUnique";
                cmbVehicles.ValueMember = "vehicleID";
            }
            catch (Exception)
            {
                MessageBox.Show("An error has occured, please try again");
            }
        }

        private void btnVehicleReport_Click(object sender, EventArgs e)
        {
            //Needs vehicleID as parameter for the report
            VehicleReport vehicleReport = new VehicleReport();
            vehicleReport.Show();
        }

        private void btnPastDueReport_Click(object sender, EventArgs e)
        {
            PastDueVehiclesReport pastDueVehicles = new PastDueVehiclesReport();
            pastDueVehicles.Show();
        }
    }
    }

