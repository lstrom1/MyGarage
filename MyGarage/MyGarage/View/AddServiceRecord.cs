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
        ServiceRecordController serviceController = new ServiceRecordController();
        ServiceCategoryController categoryControl = new ServiceCategoryController();
        ServiceRecordTypeController serviceTypeControl = new ServiceRecordTypeController(); 

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

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (AllValidInputs())
            {
                ServiceRecord serviceRecord = new ServiceRecord();
                serviceRecord.vehicleID = int.Parse(cmbSelect.SelectedValue.ToString());
                serviceRecord.dateOfService = dtServiceDate.Value;
                serviceRecord.mileage = Convert.ToInt32(txtMilage.Text);

                int serviceRecordID = serviceController.AddServiceRecord(serviceRecord);

                if (serviceRecordID != 0)
                {
                    foreach (var item in chlistType.CheckedItems.OfType<ServiceCategory>())
                    {
                        int categoryID = item.serviceCategoryID;
                        ServiceRecordType serviceType = new Model.ServiceRecordType();
                        serviceType.serviceRecordID = serviceRecordID;
                        serviceType.serviceCategoryID = categoryID;
                        serviceTypeControl.AddServiceRecordType(serviceType);
                    }
                    MessageBox.Show("You have succesfully created a service record");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("There was an error while saving, please try again.");
                }
            }
        }

        private bool AllValidInputs()
        {
            if (cmbSelect.SelectedValue == null ||
                chlistType.SelectedValue == null ||
                txtMilage.Text == "" ||
                dtServiceDate.Text == null)
            {
                MessageBox.Show("Please fill out all fields.");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void txtMilage_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.allowOnlyNumbersKeyPress(e);
        }

        private void allowOnlyNumbersKeyPress(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void AddServiceRecord_Load(object sender, EventArgs e)
        {
            List<ServiceCategory> catList = categoryControl.GetCategoryList();
            chlistType.DataSource = catList;
            chlistType.DisplayMember = "categoryName";
            chlistType.ValueMember = "serviceCategoryID";
        }
    }
}
