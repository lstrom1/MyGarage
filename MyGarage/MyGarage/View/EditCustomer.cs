using MyGarage.Controller;
using MyGarage.Model;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MyGarage.View
{
    public partial class EditCustomer : Form
    {

        OwnerController ownControl = new OwnerController();
        Owner editOwner = new Owner(); 

        public EditCustomer()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearchFirst.Text != null && txtSearchLast.Text != null)
            {
                try
                {
                    List<Owner> ownList = ownControl.GetOwners(txtSearchFirst.Text, txtSearchLast.Text);
                    cmbSelect.DataSource = ownList;
                    cmbSelect.DisplayMember = "ownerUnique";
                    cmbSelect.ValueMember = "OwnerID";

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
            if (cmbSelect.SelectedValue == null)
            {
                MessageBox.Show("Please select an owner to edit.");
            }
            else
            {
                try
                {
                    int id = Convert.ToInt32(cmbSelect.SelectedValue.ToString());
                    editOwner = ownControl.GetOwner(id);
                    txtFirstName.Text = editOwner.firstName;
                    txtLastName.Text = editOwner.lastName;
                    txtStreet.Text = editOwner.streetAddress;
                    txtCity.Text = editOwner.city;
                    txtZip.Text = editOwner.zip;
                    cmbState.Text = editOwner.state;
                    txtEmail.Text = editOwner.emailAddress;
                    txtPhoneNum.Text = editOwner.phoneNumber;
                }
                catch
                {
                    MessageBox.Show("An error has occured, please try again");
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (AllValidInputs() && IsValidEmail(txtEmail.Text) && IsValidPhone(txtPhoneNum.Text))
            {
                Owner updatedOwner = new Owner();
                updatedOwner.firstName = txtFirstName.Text;
                updatedOwner.lastName = txtLastName.Text;
                updatedOwner.streetAddress = txtStreet.Text;
                updatedOwner.city = txtCity.Text;
                updatedOwner.state = cmbState.Text;
                updatedOwner.zip = txtZip.Text;
                updatedOwner.emailAddress = txtEmail.Text;
                updatedOwner.phoneNumber = txtPhoneNum.Text;

                int updateStatus = ownControl.UpdateOwner(editOwner, updatedOwner);

                if (updateStatus == 0)
                {
                    MessageBox.Show("You have successfully updated a customer!");
                    this.Close();
                }
                else
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
                }
                else
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
                if (phone.Length > 12 || phone.Length < 10)
                {
                    MessageBox.Show("Invalid phone number length.");
                    return false;
                }
                else if (Regex.IsMatch(phone, @"^\(\d{3}\) ?\d{3}( |-)?\d{4}|^\d{3}( |-)?\d{3}( |-)?\d{4}"))
                {
                    return true;
                }
                else
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

        private bool AllValidInputs()
        {
            if (txtFirstName.Text == "" || txtLastName.Text == "" || txtStreet.Text == "" || txtCity.Text == "" || txtZip.Text == "" || txtPhoneNum.Text == "" || txtEmail.Text == "")
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
    }

}

