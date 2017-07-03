using MyGarage.Controller;
using MyGarage.Model;
using System;
using System.Windows.Forms;

namespace MyGarage.View
{
    public partial class AddServiceType : Form
    {
        ServiceCategoryController serControl = new ServiceCategoryController(); 

        public AddServiceType()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (AllValidInputs()) {
                ServiceCategory serviceCat = new ServiceCategory();
                serviceCat.categoryName = txtServiceName.Text;
                serviceCat.mileageIntervals = Convert.ToInt32(txtMileFreq.Text);
                serviceCat.numberOfDays = Convert.ToInt32(txtDayFreq.Text);

                int addStatus = serControl.AddServiceCategory(serviceCat);

                if (addStatus == 0)
                {
                    MessageBox.Show("You have successfully created a new service category!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("There was an error while saving, please try again.");
                }

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool AllValidInputs()
        {
            if (txtDayFreq.Text == "" ||
                txtMileFreq.Text == "" ||
                txtServiceName.Text == "")
            {
                MessageBox.Show("Please fill out all fields.");
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

        private void txtMileFreq_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.allowOnlyNumbersKeyPress(e);
        }

        private void txtDayFreq_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.allowOnlyNumbersKeyPress(e);
        }


    }
}
