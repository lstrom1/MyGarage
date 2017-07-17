namespace MyGarage.View
{
    partial class AllOwnerVehicleReport
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
            this.usp_maintainanceAllOwnerVehiclesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._CS6920_team5_DataSet_AllOwnerVehicles = new MyGarage._CS6920_team5_DataSet_AllOwnerVehicles();
            this.cS6920team5DataSetAllOwnerVehiclesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.usp_maintainanceAllOwnerVehiclesTableAdapter1 = new MyGarage._CS6920_team5_DataSet_AllOwnerVehiclesTableAdapters.usp_maintainanceAllOwnerVehiclesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.usp_maintainanceAllOwnerVehiclesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._CS6920_team5_DataSet_AllOwnerVehicles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cS6920team5DataSetAllOwnerVehiclesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // usp_maintainanceAllOwnerVehiclesBindingSource
            // 
            this.usp_maintainanceAllOwnerVehiclesBindingSource.DataMember = "usp_maintainanceAllOwnerVehicles";
            this.usp_maintainanceAllOwnerVehiclesBindingSource.DataSource = this._CS6920_team5_DataSet_AllOwnerVehicles;
            // 
            // _CS6920_team5_DataSet_AllOwnerVehicles
            // 
            this._CS6920_team5_DataSet_AllOwnerVehicles.DataSetName = "_CS6920_team5_DataSet_AllOwnerVehicles";
            this._CS6920_team5_DataSet_AllOwnerVehicles.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cS6920team5DataSetAllOwnerVehiclesBindingSource
            // 
            this.cS6920team5DataSetAllOwnerVehiclesBindingSource.DataMember = "usp_maintainanceAllOwnerVehicles";
            this.cS6920team5DataSetAllOwnerVehiclesBindingSource.DataSource = this._CS6920_team5_DataSet_AllOwnerVehicles;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "AllOwnerVehiclesDataSet";
            reportDataSource1.Value = this.usp_maintainanceAllOwnerVehiclesBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "MyGarage.AllOwnerVehiclesReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1184, 773);
            this.reportViewer1.TabIndex = 46;
            // 
            // usp_maintainanceAllOwnerVehiclesTableAdapter1
            // 
            this.usp_maintainanceAllOwnerVehiclesTableAdapter1.ClearBeforeFill = true;
            // 
            // AllOwnerVehicleReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 773);
            this.Controls.Add(this.reportViewer1);
            this.Font = new System.Drawing.Font("Segoe UI Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "AllOwnerVehicleReport";
            this.Text = "Customer Vehicle Maintenance Report";
            this.Load += new System.EventHandler(this.MaintenanceReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.usp_maintainanceAllOwnerVehiclesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._CS6920_team5_DataSet_AllOwnerVehicles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cS6920team5DataSetAllOwnerVehiclesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource cS6920team5DataSetAllOwnerVehiclesBindingSource;
        private _CS6920_team5_DataSet_AllOwnerVehicles _CS6920_team5_DataSet_AllOwnerVehicles;
        private _CS6920_team5_DataSet_AllOwnerVehiclesTableAdapters.usp_maintainanceAllOwnerVehiclesTableAdapter usp_maintainanceAllOwnerVehiclesTableAdapter1;
        private System.Windows.Forms.BindingSource usp_maintainanceAllOwnerVehiclesBindingSource;
    }
}