using MyGarage.View;
using System;
using System.Windows.Forms;

namespace MyGarage
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            frmPanel.Controls.Clear(); 
            AddCustomer addCust = new AddCustomer();
            addCust.TopLevel = false;
            frmPanel.Controls.Add(addCust);
            addCust.Show();
        }

        private void btnAddVehicle_Click(object sender, EventArgs e)
        {
            frmPanel.Controls.Clear();
            AddVehicle addVeh = new View.AddVehicle();
            addVeh.TopLevel = false;
            frmPanel.Controls.Add(addVeh);
            addVeh.Show(); 
        }

        private void btnEditCustomer_Click(object sender, EventArgs e)
        {
            frmPanel.Controls.Clear();
            EditCustomer editCustomer = new View.EditCustomer();
            editCustomer.TopLevel = false;
            frmPanel.Controls.Add(editCustomer);
            editCustomer.Show();
        }

        private void btnAddService_Click(object sender, EventArgs e)
        {
            frmPanel.Controls.Clear();
            AddServiceType addServiceType = new View.AddServiceType();
            addServiceType.TopLevel = false;
            frmPanel.Controls.Add(addServiceType);
            addServiceType.Show();
        }

        private void btnAddVehicleOwner_Click(object sender, EventArgs e)
        {
            frmPanel.Controls.Clear();
            AddVehicleOwner addVehicleOwner = new View.AddVehicleOwner();
            addVehicleOwner.TopLevel = false;
            frmPanel.Controls.Add(addVehicleOwner);
            addVehicleOwner.Show();
        }
    }
}
