using System;
using System.Windows.Forms;

namespace MyGarage.View
{
    public partial class PastDueVehiclesReport : Form
    {
        public PastDueVehiclesReport()
        {
            InitializeComponent();
        }

        private void AllVehiclesReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the '_CS6920_team5_DataSet_NeededNumber30Days.usp_maintenanceNeededNumber30Days' table. You can move, or remove it, as needed.
            this.usp_maintenanceNeededNumber30DaysTableAdapter.Fill(this._CS6920_team5_DataSet_NeededNumber30Days.usp_maintenanceNeededNumber30Days);

            this.reportViewer1.RefreshReport();
        }
    }
}
