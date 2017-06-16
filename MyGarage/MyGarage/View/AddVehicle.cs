using MyGarage.Controller;
using MyGarage.Model;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MyGarage.View
{
    public partial class AddVehicle : Form
    {

        VehicleController vehControl = new VehicleController(); 

        public AddVehicle()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (AllValidInputs() && IsValidYear(txtYear.Text))
            {

                //add new vehicle
                Vehicle newVehicle = new Vehicle();
                newVehicle.make = txtMake.Text;
                newVehicle.model = txtModel.Text;
                newVehicle.VIN = txtVIN.Text;
                newVehicle.year = txtYear.Text;

                int addStatus = vehControl.AddVehicle(newVehicle);

                if (addStatus == 0)
                {
                    MessageBox.Show("You have successfully created a new vehicle!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("There was an error while saving, please try again.");
                }
            }

        }

        private bool IsValidYear(string year)
        {
            try
            {
                if (Regex.IsMatch(year, "^(19|20)[0-9][0-9]") && Convert.ToInt32(year) <= DateTime.Now.Year)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Please provide a valid year.");
                    return false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please provide a valid year.");
                return false;
            }
        }

        private bool AllValidInputs()
        {
            if (txtMake.Text == "" || txtVIN.Text == "" || txtYear.Text == "" || txtModel.Text == "")
            {
                MessageBox.Show("Please fill out all fields.");
                return false;
            }
            else if (txtVIN.Text.Length < 11 || txtVIN.Text.Length > 17)
            {
                MessageBox.Show("VIN must be between 11 and 17 digits long!");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void allowOnlyNumbersKeyPress(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.allowOnlyNumbersKeyPress(e);
        }
    }
}

