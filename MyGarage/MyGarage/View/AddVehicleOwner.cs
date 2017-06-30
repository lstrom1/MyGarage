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
    public partial class AddVehicleOwner : Form
    {

        VehicleController vehControl = new VehicleController();
        OwnerController ownControl = new OwnerController();
        OwnerVehicleController ownVehControl = new OwnerVehicleController(); 

        public AddVehicleOwner()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddVehicleOwner_Load(object sender, EventArgs e)
        {
            this.populateVehicleList("%");
        }

        private void populateVehicleList(string VIN)
        {
            try
            {
                List<Vehicle> vehicleList = vehControl.GetVehicleList(VIN);
                if (vehicleList == null || vehicleList.Count == 0)
                {
                    MessageBox.Show("There were no results for that search!");
                    cmbSelect.Text = null;
                }
                else
                {
                    cmbSelect.DataSource = vehicleList;
                    cmbSelect.DisplayMember = "vehicleUnique";
                    cmbSelect.ValueMember = "vehicleID";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("An error occured, please try again.");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtVinSearch.Text != null)
            {
                this.populateVehicleList(txtVinSearch.Text);
            }
            else
            {
                MessageBox.Show("Please provide a VIN to search by.");
            }
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            this.populateVehicleList("%");
        }

        private void btnCustSearch_Click(object sender, EventArgs e)
        {
            if (txtSearchFirst.Text != null && txtSearchLast.Text != null)
            {
                try
                {
                    List<Owner> ownList = ownControl.GetOwners(txtSearchFirst.Text, txtSearchLast.Text);
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
                MessageBox.Show("Please provide first and last name.");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbSelect.SelectedValue == null || cmbCustomers.SelectedValue == null)
            {
                MessageBox.Show("Please make sure to select both a vehicle and owner."); 
            } else
            {
                int vehicleID = int.Parse(cmbSelect.SelectedValue.ToString());
                int ownerID = int.Parse(cmbCustomers.SelectedValue.ToString());

                //link vehicle to owner (add entry to OwnerVehicle table)
                OwnerVehicle newOwnerVehicle = new OwnerVehicle();
                newOwnerVehicle.ownerID = ownerID;
                newOwnerVehicle.vehicleID = vehicleID;

                int status = ownVehControl.AddOwnerVehicle(newOwnerVehicle);

                if (status == 0)
                {
                    MessageBox.Show("You have successfully added a vehicle to an owner!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("There was an error while saving, please try again.");
                }
            }
        }
    }
}
