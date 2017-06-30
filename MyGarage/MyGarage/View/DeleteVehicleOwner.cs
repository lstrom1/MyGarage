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
    public partial class DeleteVehicleOwner : Form
    {

        VehicleController vehControl = new VehicleController();
        OwnerController ownControl = new OwnerController();
        OwnerVehicleController ownVehControl = new OwnerVehicleController();

        public DeleteVehicleOwner()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCustSearch_Click(object sender, EventArgs e)
        {
            if (txtSearchFirst.Text != null && txtSearchLast.Text != null)
            {
                try
                {
                    cmbSelect.DataSource = null;
                    cmbSelect.Text = "";
                    List<Owner> ownList = ownControl.GetOwners(txtSearchFirst.Text, txtSearchLast.Text);
                    cmbCustomers.DataSource = ownList;
                    cmbCustomers.DisplayMember = "ownerUnique";
                    cmbCustomers.ValueMember = "ownerID";

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

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (cmbCustomers.SelectedValue != null)
            {
                try
                {
                    List<Vehicle> vehList = vehControl.GetCustVehicleList(int.Parse(cmbCustomers.SelectedValue.ToString()));
                    cmbSelect.DataSource = vehList;
                    cmbSelect.DisplayMember = "vehicleUnique";
                    cmbSelect.ValueMember = "vehicleID";

                }
                catch (Exception)
                {
                    MessageBox.Show("An error has occured, please try again");
                }
            }
            else
            {
                MessageBox.Show("Please select a vehicle.");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbSelect.SelectedValue == null || cmbCustomers.SelectedValue == null)
            {
                MessageBox.Show("Please make sure to select both a vehicle and owner.");
            }
            else
            {
                int vehicleID = int.Parse(cmbSelect.SelectedValue.ToString());
                int ownerID = int.Parse(cmbCustomers.SelectedValue.ToString());

                //link vehicle to owner (add entry to OwnerVehicle table)
                OwnerVehicle newOwnerVehicle = new OwnerVehicle();
                newOwnerVehicle.ownerID = ownerID;
                newOwnerVehicle.vehicleID = vehicleID;

                int status = ownVehControl.RemoveOwnerVehicle(newOwnerVehicle);

                if (status == 0)
                {
                    MessageBox.Show("You have successfully removed a vehicle from an owner!");
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
