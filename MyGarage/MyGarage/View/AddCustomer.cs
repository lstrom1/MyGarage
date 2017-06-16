using System;
using System.Windows.Forms;
using MyGarage.Model;
using MyGarage.Controller;
using System.Text.RegularExpressions;

namespace MyGarage.View
{
    public partial class AddCustomer : Form
    {

        OwnerController ownControl = new OwnerController();
        VehicleController vehControl = new VehicleController(); 

        public AddCustomer()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddCustomer_Load(object sender, EventArgs e)
        {
            cmbState.SelectedIndex = 0; 
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (AllValidInputs() && IsValidEmail(txtEmail.Text) && IsValidPhone(txtPhoneNum.Text) && IsValidYear(txtYear.Text))
            {
                //add new owner
                Owner newOwner = new Owner(); 
                newOwner.firstName = txtFirstName.Text;
                newOwner.lastName = txtLastName.Text;
                newOwner.streetAddress = txtStreet.Text;
                newOwner.city = txtCity.Text;
                newOwner.state = cmbState.Text;
                newOwner.zip = txtZip.Text;
                newOwner.phoneNumber = txtPhoneNum.Text;
                newOwner.emailAddress = txtEmail.Text;

                //add new vehicle
                Vehicle newVehicle = new Vehicle();
                newVehicle.make = txtMake.Text;
                newVehicle.model = txtModel.Text;
                newVehicle.VIN = txtVIN.Text;
                newVehicle.year = txtYear.Text;

                int addStatus = vehControl.AddVehicle(newVehicle); 
                int addStatus1 = ownControl.AddOwner(newOwner);

                    if (addStatus == 0 && addStatus1 == 0)
                    {
                        MessageBox.Show("You have successfully created a new customer!");
                        this.Close(); 
                    } else
                    {
                        MessageBox.Show("There was an error while saving, please try again."); 
                    }
             } 

        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                if (addr.Address == email)
                {
                    return true;
                } else
                {
                    MessageBox.Show("Please provide a valid e-mail address.");
                    return false;
                }
            }
            catch
            {
                MessageBox.Show("Please provide a valid e-mail address.");
                return false;
            }
        } 

        private bool IsValidPhone(string phone)
        {
            try
            {
                if (Regex.IsMatch(phone, @"^\(\d{3}\) ?\d{3}( |-)?\d{4}|^\d{3}( |-)?\d{3}( |-)?\d{4}"))
                {
                    return true;  
                } else
                {
                    MessageBox.Show("Please provide a valid phone number.");
                    return false;
                }
            }
            catch (Exception)
            {
                throw; 
            }
        }

        private bool IsValidYear(string year) { 
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
            if (txtFirstName.Text == "" || txtLastName.Text == "" || txtStreet.Text == "" || txtCity.Text == "" || txtZip.Text == "" || txtPhoneNum.Text == "" || txtEmail.Text == "" || txtMake.Text == "" || txtVIN.Text == "" || txtYear.Text == "" || txtModel.Text == "")
            {
                MessageBox.Show("Please fill out all fields.");
                return false;
            }
            else if (txtZip.Text.Length != 5)
            {
                MessageBox.Show("Zip code must be five digits long!");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void allowOnlyNumbersKeyPress(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtZip_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.allowOnlyNumbersKeyPress(e);
        }

        private void txtPhoneNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.allowOnlyNumbersKeyPress(e);
        }

        private void txtYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.allowOnlyNumbersKeyPress(e);
        }
    }
}
