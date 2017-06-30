using MyGarage.Controller;
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
    public partial class DeleteVehicleOwner : Form
    {

        VehicleController vehControl = new VehicleController();
        OwnerController ownControl = new OwnerController();
        OwnerVehicleController ownVehControl = new OwnerVehicleController();

        public DeleteVehicleOwner()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
