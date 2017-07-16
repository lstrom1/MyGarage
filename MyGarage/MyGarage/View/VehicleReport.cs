using System;
using System.Windows.Forms;

namespace MyGarage.View
{
    public partial class VehicleReport : Form
    {
        public VehicleReport()
        {
            InitializeComponent();
        }

        private void VehicleReport_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
