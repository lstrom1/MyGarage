namespace MyGarage.View
{
    partial class AddVehicle
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtVIN = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtMake = new System.Windows.Forms.TextBox();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbSelect = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSearchLast = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSearchFirst = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(641, 45);
            this.panel1.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Light", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 28);
            this.label3.TabIndex = 4;
            this.label3.Text = "Add New Vehicle";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(35)))), ((int)(((byte)(6)))));
            this.panel3.Controls.Add(this.label11);
            this.panel3.ForeColor = System.Drawing.Color.White;
            this.panel3.Location = new System.Drawing.Point(0, 51);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(641, 31);
            this.panel3.TabIndex = 19;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(3, 7);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(129, 20);
            this.label11.TabIndex = 4;
            this.label11.Text = "Vehicle Information";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(24, 102);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(28, 17);
            this.label15.TabIndex = 22;
            this.label15.Text = "VIN";
            // 
            // txtVIN
            // 
            this.txtVIN.Location = new System.Drawing.Point(64, 98);
            this.txtVIN.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtVIN.Name = "txtVIN";
            this.txtVIN.Size = new System.Drawing.Size(203, 25);
            this.txtVIN.TabIndex = 21;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(291, 102);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(38, 17);
            this.label14.TabIndex = 24;
            this.label14.Text = "Make";
            // 
            // txtMake
            // 
            this.txtMake.Location = new System.Drawing.Point(335, 99);
            this.txtMake.Name = "txtMake";
            this.txtMake.Size = new System.Drawing.Size(203, 25);
            this.txtMake.TabIndex = 23;
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(335, 137);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(69, 25);
            this.txtYear.TabIndex = 30;
            this.txtYear.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtYear_KeyPress);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(297, 140);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(32, 17);
            this.label12.TabIndex = 29;
            this.label12.Text = "Year";
            // 
            // txtModel
            // 
            this.txtModel.Location = new System.Drawing.Point(64, 140);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(203, 25);
            this.txtModel.TabIndex = 28;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(15, 140);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(43, 17);
            this.label13.TabIndex = 27;
            this.label13.Text = "Model";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(227, 356);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 31);
            this.btnClose.TabIndex = 32;
            this.btnClose.Text = "Cancel";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(146, 356);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 31);
            this.btnSave.TabIndex = 31;
            this.btnSave.Text = "Add";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(35)))), ((int)(((byte)(6)))));
            this.panel2.Controls.Add(this.label1);
            this.panel2.ForeColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(0, 195);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(641, 31);
            this.panel2.TabIndex = 57;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Select Customer";
            // 
            // cmbSelect
            // 
            this.cmbSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSelect.FormattingEnabled = true;
            this.cmbSelect.Location = new System.Drawing.Point(30, 318);
            this.cmbSelect.Name = "cmbSelect";
            this.cmbSelect.Size = new System.Drawing.Size(272, 25);
            this.cmbSelect.TabIndex = 55;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(320, 279);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 27);
            this.btnSearch.TabIndex = 54;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 282);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 17);
            this.label2.TabIndex = 53;
            this.label2.Text = "Last Name";
            // 
            // txtSearchLast
            // 
            this.txtSearchLast.Location = new System.Drawing.Point(99, 279);
            this.txtSearchLast.Name = "txtSearchLast";
            this.txtSearchLast.Size = new System.Drawing.Size(203, 25);
            this.txtSearchLast.TabIndex = 52;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 241);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 17);
            this.label4.TabIndex = 51;
            this.label4.Text = "First Name";
            // 
            // txtSearchFirst
            // 
            this.txtSearchFirst.Location = new System.Drawing.Point(99, 241);
            this.txtSearchFirst.Name = "txtSearchFirst";
            this.txtSearchFirst.Size = new System.Drawing.Size(203, 25);
            this.txtSearchFirst.TabIndex = 50;
            // 
            // AddVehicle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 529);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.cmbSelect);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSearchLast);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSearchFirst);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtModel);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtMake);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtVIN);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "AddVehicle";
            this.Text = "AddVehicle";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtVIN;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtMake;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbSelect;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSearchLast;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSearchFirst;
    }
}