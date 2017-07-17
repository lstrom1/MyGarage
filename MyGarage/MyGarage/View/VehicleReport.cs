using System;
using System.Windows.Forms;

namespace MyGarage.View
{
    public partial class VehicleReport : Form
    {
        int reportVehicleID;

        public VehicleReport(int vehicleID)
        {
            InitializeComponent();
            reportVehicleID = vehicleID;
        }

        private void VehicleReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the '_CS6920_team5_DataSet_HistoryForSpecifiedVehicle.usp_maintenanceHistoryForSpecifiedVehicle' table. You can move, or remove it, as needed.
            this.usp_maintenanceHistoryForSpecifiedVehicleTableAdapter.Fill(this._CS6920_team5_DataSet_HistoryForSpecifiedVehicle.usp_maintenanceHistoryForSpecifiedVehicle, reportVehicleID);

            this.reportViewer1.RefreshReport();
        }
    }
}
