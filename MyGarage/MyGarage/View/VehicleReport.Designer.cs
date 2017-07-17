namespace MyGarage.View
{
    partial class VehicleReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.usp_maintenanceHistoryForSpecifiedVehicleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._CS6920_team5_DataSet_HistoryForSpecifiedVehicle = new MyGarage._CS6920_team5_DataSet_HistoryForSpecifiedVehicle();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.usp_maintenanceHistoryForSpecifiedVehicleTableAdapter = new MyGarage._CS6920_team5_DataSet_HistoryForSpecifiedVehicleTableAdapters.usp_maintenanceHistoryForSpecifiedVehicleTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.usp_maintenanceHistoryForSpecifiedVehicleBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._CS6920_team5_DataSet_HistoryForSpecifiedVehicle)).BeginInit();
            this.SuspendLayout();
            // 
            // usp_maintenanceHistoryForSpecifiedVehicleBindingSource
            // 
            this.usp_maintenanceHistoryForSpecifiedVehicleBindingSource.DataMember = "usp_maintenanceHistoryForSpecifiedVehicle";
            this.usp_maintenanceHistoryForSpecifiedVehicleBindingSource.DataSource = this._CS6920_team5_DataSet_HistoryForSpecifiedVehicle;
            // 
            // _CS6920_team5_DataSet_HistoryForSpecifiedVehicle
            // 
            this._CS6920_team5_DataSet_HistoryForSpecifiedVehicle.DataSetName = "_CS6920_team5_DataSet_HistoryForSpecifiedVehicle";
            this._CS6920_team5_DataSet_HistoryForSpecifiedVehicle.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "HistoryForSpecifiedVehicleDataSet";
            reportDataSource1.Value = this.usp_maintenanceHistoryForSpecifiedVehicleBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "MyGarage.HistoryForSpecifiedVehicleReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(4);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(787, 656);
            this.reportViewer1.TabIndex = 0;
            // 
            // usp_maintenanceHistoryForSpecifiedVehicleTableAdapter
            // 
            this.usp_maintenanceHistoryForSpecifiedVehicleTableAdapter.ClearBeforeFill = true;
            // 
            // VehicleReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 656);
            this.Controls.Add(this.reportViewer1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "VehicleReport";
            this.Text = "Vehicle Maintenance Report";
            this.Load += new System.EventHandler(this.VehicleReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.usp_maintenanceHistoryForSpecifiedVehicleBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._CS6920_team5_DataSet_HistoryForSpecifiedVehicle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private _CS6920_team5_DataSet_HistoryForSpecifiedVehicle _CS6920_team5_DataSet_HistoryForSpecifiedVehicle;
        private _CS6920_team5_DataSet_HistoryForSpecifiedVehicleTableAdapters.usp_maintenanceHistoryForSpecifiedVehicleTableAdapter usp_maintenanceHistoryForSpecifiedVehicleTableAdapter;
        private System.Windows.Forms.BindingSource usp_maintenanceHistoryForSpecifiedVehicleBindingSource;
    }
}