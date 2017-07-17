namespace MyGarage.View
{
    partial class PastDueVehiclesReport
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
            this._CS6920_team5_DataSet_NeededNumber30Days = new MyGarage._CS6920_team5_DataSet_NeededNumber30Days();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.cS6920team5DataSetNeededNumber30DaysBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uspmaintenanceNeededNumber30DaysBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.usp_maintenanceNeededNumber30DaysTableAdapter = new MyGarage._CS6920_team5_DataSet_NeededNumber30DaysTableAdapters.usp_maintenanceNeededNumber30DaysTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this._CS6920_team5_DataSet_NeededNumber30Days)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cS6920team5DataSetNeededNumber30DaysBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uspmaintenanceNeededNumber30DaysBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // _CS6920_team5_DataSet_NeededNumber30Days
            // 
            this._CS6920_team5_DataSet_NeededNumber30Days.DataSetName = "_CS6920_team5_DataSet_NeededNumber30Days";
            this._CS6920_team5_DataSet_NeededNumber30Days.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "NeededNumber30DaysDataSet";
            reportDataSource1.Value = this.uspmaintenanceNeededNumber30DaysBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "MyGarage.NeededNumber30DaysReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(4);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1906, 709);
            this.reportViewer1.TabIndex = 0;
            // 
            // cS6920team5DataSetNeededNumber30DaysBindingSource
            // 
            this.cS6920team5DataSetNeededNumber30DaysBindingSource.DataSource = this._CS6920_team5_DataSet_NeededNumber30Days;
            this.cS6920team5DataSetNeededNumber30DaysBindingSource.Position = 0;
            // 
            // uspmaintenanceNeededNumber30DaysBindingSource
            // 
            this.uspmaintenanceNeededNumber30DaysBindingSource.DataMember = "usp_maintenanceNeededNumber30Days";
            this.uspmaintenanceNeededNumber30DaysBindingSource.DataSource = this._CS6920_team5_DataSet_NeededNumber30Days;
            // 
            // usp_maintenanceNeededNumber30DaysTableAdapter
            // 
            this.usp_maintenanceNeededNumber30DaysTableAdapter.ClearBeforeFill = true;
            // 
            // PastDueVehiclesReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1906, 709);
            this.Controls.Add(this.reportViewer1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PastDueVehiclesReport";
            this.Text = "Past Due/Upcoming Maintenance Report";
            this.Load += new System.EventHandler(this.AllVehiclesReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this._CS6920_team5_DataSet_NeededNumber30Days)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cS6920team5DataSetNeededNumber30DaysBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uspmaintenanceNeededNumber30DaysBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private _CS6920_team5_DataSet_NeededNumber30Days _CS6920_team5_DataSet_NeededNumber30Days;
        private System.Windows.Forms.BindingSource cS6920team5DataSetNeededNumber30DaysBindingSource;
        private System.Windows.Forms.BindingSource uspmaintenanceNeededNumber30DaysBindingSource;
        private _CS6920_team5_DataSet_NeededNumber30DaysTableAdapters.usp_maintenanceNeededNumber30DaysTableAdapter usp_maintenanceNeededNumber30DaysTableAdapter;
    }
}