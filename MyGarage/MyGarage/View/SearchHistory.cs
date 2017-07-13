﻿using MyGarage.Controller;
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

        public SearchHistory()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            cmbCustomers.Text = "";
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
    }
}
