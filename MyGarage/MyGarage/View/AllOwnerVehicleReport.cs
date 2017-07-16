using System;
using System.Windows.Forms;

namespace MyGarage.View
{
    public partial class AllOwnerVehicleReport : Form
    {

        int reportOwnerID; 
        public AllOwnerVehicleReport(int ownerID)
        {
            InitializeComponent();
            reportOwnerID = ownerID;
        }

        private void MaintenanceReport_Load(object sender, EventArgs e)
        {
            this.usp_maintainanceAllOwnerVehiclesTableAdapter1.Fill(this._CS6920_team5_DataSet_AllOwnerVehicles.usp_maintainanceAllOwnerVehicles, this.reportOwnerID);
            this.reportViewer1.RefreshReport();
        }
    }
}
