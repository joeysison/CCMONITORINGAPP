namespace ccMonitoringApp
{
    partial class frmSearchParam
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearchParam));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.txtRelocSrch = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtPaxNameSrch = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtRefNumSrch = new System.Windows.Forms.TextBox();
            this.dgvCCData = new System.Windows.Forms.DataGridView();
            this.btnSelect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCCData)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkAll);
            this.groupBox2.Controls.Add(this.btnSearch);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.txtRelocSrch);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.txtPaxNameSrch);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.txtRefNumSrch);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(510, 79);
            this.groupBox2.TabIndex = 36;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "SEARCH";
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(285, 48);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(45, 20);
            this.chkAll.TabIndex = 43;
            this.chkAll.Text = "All";
            this.chkAll.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(359, 44);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(134, 27);
            this.btnSearch.TabIndex = 42;
            this.btnSearch.Text = "SEARCH";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.commandButtonAction);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(39, 49);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(44, 13);
            this.label17.TabIndex = 41;
            this.label17.Text = "Reloc:";
            // 
            // txtRelocSrch
            // 
            this.txtRelocSrch.BackColor = System.Drawing.SystemColors.Window;
            this.txtRelocSrch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRelocSrch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRelocSrch.ForeColor = System.Drawing.SystemColors.Highlight;
            this.txtRelocSrch.Location = new System.Drawing.Point(87, 44);
            this.txtRelocSrch.Name = "txtRelocSrch";
            this.txtRelocSrch.Size = new System.Drawing.Size(159, 19);
            this.txtRelocSrch.TabIndex = 40;
            this.txtRelocSrch.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(262, 24);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(68, 13);
            this.label16.TabIndex = 39;
            this.label16.Text = "Pax Name:";
            // 
            // txtPaxNameSrch
            // 
            this.txtPaxNameSrch.BackColor = System.Drawing.SystemColors.Window;
            this.txtPaxNameSrch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPaxNameSrch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaxNameSrch.ForeColor = System.Drawing.SystemColors.Highlight;
            this.txtPaxNameSrch.Location = new System.Drawing.Point(334, 19);
            this.txtPaxNameSrch.Name = "txtPaxNameSrch";
            this.txtPaxNameSrch.Size = new System.Drawing.Size(159, 19);
            this.txtPaxNameSrch.TabIndex = 38;
            this.txtPaxNameSrch.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(32, 24);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(49, 13);
            this.label15.TabIndex = 37;
            this.label15.Text = "CC NO:";
            // 
            // txtRefNumSrch
            // 
            this.txtRefNumSrch.BackColor = System.Drawing.SystemColors.Window;
            this.txtRefNumSrch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRefNumSrch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRefNumSrch.ForeColor = System.Drawing.SystemColors.Highlight;
            this.txtRefNumSrch.Location = new System.Drawing.Point(87, 19);
            this.txtRefNumSrch.Name = "txtRefNumSrch";
            this.txtRefNumSrch.Size = new System.Drawing.Size(159, 19);
            this.txtRefNumSrch.TabIndex = 1;
            this.txtRefNumSrch.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dgvCCData
            // 
            this.dgvCCData.AllowUserToAddRows = false;
            this.dgvCCData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCCData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCCData.Location = new System.Drawing.Point(13, 98);
            this.dgvCCData.MultiSelect = false;
            this.dgvCCData.Name = "dgvCCData";
            this.dgvCCData.ReadOnly = true;
            this.dgvCCData.ShowEditingIcon = false;
            this.dgvCCData.Size = new System.Drawing.Size(509, 150);
            this.dgvCCData.TabIndex = 37;
            this.dgvCCData.Visible = false;
            // 
            // btnSelect
            // 
            this.btnSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelect.Location = new System.Drawing.Point(371, 254);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(134, 27);
            this.btnSelect.TabIndex = 43;
            this.btnSelect.Text = "CANCEL";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.commandButtonAction);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 266);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 15);
            this.label1.TabIndex = 44;
            this.label1.Text = "use % for * parameters in pax name";
            // 
            // frmSearchParam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(534, 290);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.dgvCCData);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSearchParam";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ":: SEARCH ::";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCCData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtRelocSrch;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtPaxNameSrch;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtRefNumSrch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvCCData;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.Label label1;
    }
}