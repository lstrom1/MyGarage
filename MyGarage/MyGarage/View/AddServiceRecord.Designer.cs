namespace MyGarage.View
{
    partial class AddServiceRecord
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
            this.btnAll = new System.Windows.Forms.Button();
            this.cmbSelect = new System.Windows.Forms.ComboBox();
            this.txtVinSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.txtMilage = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.dtServiceDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.chlistType = new System.Windows.Forms.CheckedListBox();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
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
            this.label3.Size = new System.Drawing.Size(175, 28);
            this.label3.TabIndex = 4;
            this.label3.Text = "Add Service Record";
            // 
            // btnAll
            // 
            this.btnAll.Location = new System.Drawing.Point(406, 98);
            this.btnAll.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(55, 27);
            this.btnAll.TabIndex = 55;
            this.btnAll.Text = "All";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // cmbSelect
            // 
            this.cmbSelect.FormattingEnabled = true;
            this.cmbSelect.Location = new System.Drawing.Point(65, 133);
            this.cmbSelect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbSelect.Name = "cmbSelect";
            this.cmbSelect.Size = new System.Drawing.Size(258, 25);
            this.cmbSelect.TabIndex = 54;
            // 
            // txtVinSearch
            // 
            this.txtVinSearch.Location = new System.Drawing.Point(65, 100);
            this.txtVinSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtVinSearch.Name = "txtVinSearch";
            this.txtVinSearch.Size = new System.Drawing.Size(258, 25);
            this.txtVinSearch.TabIndex = 52;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(329, 98);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(71, 27);
            this.btnSearch.TabIndex = 53;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(31, 100);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(28, 17);
            this.label16.TabIndex = 56;
            this.label16.Text = "VIN";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(35)))), ((int)(((byte)(6)))));
            this.panel3.Controls.Add(this.label11);
            this.panel3.ForeColor = System.Drawing.Color.White;
            this.panel3.Location = new System.Drawing.Point(0, 51);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(641, 31);
            this.panel3.TabIndex = 57;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(3, 5);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(129, 20);
            this.label11.TabIndex = 4;
            this.label11.Text = "Vehicle Information";
            // 
            // txtMilage
            // 
            this.txtMilage.Location = new System.Drawing.Point(65, 205);
            this.txtMilage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMilage.Name = "txtMilage";
            this.txtMilage.Size = new System.Drawing.Size(258, 25);
            this.txtMilage.TabIndex = 58;
            this.txtMilage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMilage_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 208);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 17);
            this.label1.TabIndex = 59;
            this.label1.Text = "Mileage";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 241);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 17);
            this.label2.TabIndex = 61;
            this.label2.Text = "Type";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(64, 385);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 31);
            this.btnSave.TabIndex = 62;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(145, 385);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 31);
            this.btnClose.TabIndex = 63;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dtServiceDate
            // 
            this.dtServiceDate.Location = new System.Drawing.Point(65, 168);
            this.dtServiceDate.Name = "dtServiceDate";
            this.dtServiceDate.Size = new System.Drawing.Size(258, 25);
            this.dtServiceDate.TabIndex = 64;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 17);
            this.label4.TabIndex = 65;
            this.label4.Text = "Date";
            // 
            // chlistType
            // 
            this.chlistType.FormattingEnabled = true;
            this.chlistType.Location = new System.Drawing.Point(65, 241);
            this.chlistType.Name = "chlistType";
            this.chlistType.Size = new System.Drawing.Size(258, 124);
            this.chlistType.TabIndex = 67;
            // 
            // AddServiceRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 529);
            this.Controls.Add(this.chlistType);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtServiceDate);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMilage);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.btnAll);
            this.Controls.Add(this.cmbSelect);
            this.Controls.Add(this.txtVinSearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "AddServiceRecord";
            this.Text = "AddServiceRecord";
            this.Load += new System.EventHandler(this.AddServiceRecord_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.ComboBox cmbSelect;
        private System.Windows.Forms.TextBox txtVinSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtMilage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DateTimePicker dtServiceDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckedListBox chlistType;
    }
}