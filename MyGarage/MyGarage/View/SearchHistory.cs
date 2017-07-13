using MyGarage.Controller;
using MyGarage.Model;
using System;
using System.Collections;
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
    public partial class SearchHistory : Form
    {

        OwnerController ownControl = new OwnerController();
        VehicleController vehControl = new VehicleController();
        ServiceRecordTypeController recordControl = new ServiceRecordTypeController(); 

        public SearchHistory()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            cmbCustomers.Text = "";
            cmbCustomers.DataSource = null;
            lstService.Items.Clear(); 
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

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (cmbCustomers.SelectedValue != null)
            {
               try
                {
                    List<Vehicle> vehList = vehControl.GetCustVehicleList(Convert.ToInt32(cmbCustomers.SelectedValue.ToString()));
                    cmbVehicles.DataSource = vehList;
                    cmbVehicles.DisplayMember = "vehicleUnique";
                    cmbVehicles.ValueMember = "VehicleID";
                }
                catch (Exception)
                {
                    MessageBox.Show("An error has occured, please try again");
                }
            }
            else
            {
                MessageBox.Show("Please select an owner to view vehicles for.");
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (cmbVehicles.SelectedValue != null)
            {
                try
                {
                    List<ServiceRecordType> serviceList = recordControl.GetRecordByVehicle(Convert.ToInt32(cmbVehicles.SelectedValue.ToString()));
                    if (serviceList.Count > 0)
                    {
                        ServiceRecordType recordType;
                        for (int i = 0; i < serviceList.Count; i++)
                        {
                            recordType = serviceList[i];
                            lstService.Items.Add(recordType.categoryName.ToString());
                            lstService.Items[i].SubItems.Add(recordType.dateOfService.ToString());
                            lstService.Items[i].SubItems.Add(recordType.mileage.ToString());
                        }
                    } else
                    {
                        MessageBox.Show("There is no service history for this vehicle.");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("An error has occured, please try again");
                }
            }
            else
            {
                MessageBox.Show("Please select a vehicle to show history for.");
            }
        }

        private void cmbCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbVehicles.Text = "";
            cmbVehicles.DataSource = null; 
            lstService.Items.Clear(); 
        }
    }
}
