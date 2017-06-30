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
    public partial class AddServiceRecord : Form
    {

        VehicleController vehControl = new VehicleController(); 

        public AddServiceRecord()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void populateVehicleList(string VIN)
        {
            try
            {
                List<Vehicle> vehicleList = vehControl.GetAllVehicleList(VIN);
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

        private void btnAll_Click(object sender, EventArgs e)
        {
            this.populateVehicleList("%");
        }
    }
}
