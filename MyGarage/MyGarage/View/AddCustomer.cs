using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyGarage.Model;
using MyGarage.Controller;
using System.Text.RegularExpressions;

namespace MyGarage.View
{
    public partial class AddCustomer : Form
    {

        OwnerController ownControl = new OwnerController(); 

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
                Owner newOwner = new Owner(); 
                newOwner.firstName = txtFirstName.Text;
                newOwner.lastName = txtLastName.Text;
                newOwner.streetAddress = txtStreet.Text;
                newOwner.city = txtCity.Text;
                newOwner.state = cmbState.ValueMember;
                newOwner.zip = txtZip.Text;
                newOwner.phoneNumber = txtPhoneNum.Text;
                newOwner.emailAddress = txtEmail.Text; 
                int addStatus = ownControl.AddOwner(newOwner);
                    if (addStatus == 0)
                    {
                        this.DialogResult = DialogResult.OK;
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
                if (Regex.IsMatch(phone, @"^((1-)?\d{3}-)?\d{3}-\d{4}$"))
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
                if (Regex.IsMatch(year, "^(19|20)[0-9][0-9]"))
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
            if (txtZip.Text.Length != 5)
            {
                MessageBox.Show("Zip code must be five digits long!");
                return false; 
            } else if (txtFirstName.Text == "" || txtLastName.Text == "" || txtStreet.Text == "" || txtCity.Text == "" || txtZip.Text == "" || txtPhoneNum.Text == "" || txtEmail.Text == "" || txtMake.Text == "" || txtVIN.Text == "" || txtYear.Text == "" || txtModel.Text == "")
            {
                MessageBox.Show("Please fill out all fields.");
                return false;
            } else
            {
                return true;
            }
        }
    }
}
