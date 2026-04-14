namespace DVDL.Desktop.License.Controls
{
    partial class ctrlDriverLicenses
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tcLicensesHistory = new System.Windows.Forms.TabControl();
            this.tpLocalLicensesHistory = new System.Windows.Forms.TabPage();
            this.lblLocalLicensesRecordsCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvLocalLicenses = new System.Windows.Forms.DataGridView();
            this.cmsLocalLicensesHistory = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ShowLocalLicenseInfoItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tpInternationalLicensesHistroy = new System.Windows.Forms.TabPage();
            this.lblInternationalLicensesRecordsCount = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvInternalLicenses = new System.Windows.Forms.DataGridView();
            this.cmsInternationalLicensesHistoryItem = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ShowInternationalLicenseItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DetainLicenseItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.tcLicensesHistory.SuspendLayout();
            this.tpLocalLicensesHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalLicenses)).BeginInit();
            this.cmsLocalLicensesHistory.SuspendLayout();
            this.tpInternationalLicensesHistroy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternalLicenses)).BeginInit();
            this.cmsInternationalLicensesHistoryItem.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tcLicensesHistory);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 13F);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(15, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1123, 293);
            this.groupBox1.TabIndex = 47;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Driver Licenses";
            // 
            // tcLicensesHistory
            // 
            this.tcLicensesHistory.Controls.Add(this.tpLocalLicensesHistory);
            this.tcLicensesHistory.Controls.Add(this.tpInternationalLicensesHistroy);
            this.tcLicensesHistory.Font = new System.Drawing.Font("Tahoma", 11F);
            this.tcLicensesHistory.Location = new System.Drawing.Point(6, 33);
            this.tcLicensesHistory.Name = "tcLicensesHistory";
            this.tcLicensesHistory.SelectedIndex = 0;
            this.tcLicensesHistory.Size = new System.Drawing.Size(1111, 254);
            this.tcLicensesHistory.TabIndex = 0;
            // 
            // tpLocalLicensesHistory
            // 
            this.tpLocalLicensesHistory.BackColor = System.Drawing.Color.White;
            this.tpLocalLicensesHistory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tpLocalLicensesHistory.Controls.Add(this.lblLocalLicensesRecordsCount);
            this.tpLocalLicensesHistory.Controls.Add(this.label2);
            this.tpLocalLicensesHistory.Controls.Add(this.label1);
            this.tpLocalLicensesHistory.Controls.Add(this.dgvLocalLicenses);
            this.tpLocalLicensesHistory.Font = new System.Drawing.Font("Tahoma", 11F);
            this.tpLocalLicensesHistory.Location = new System.Drawing.Point(4, 27);
            this.tpLocalLicensesHistory.Name = "tpLocalLicensesHistory";
            this.tpLocalLicensesHistory.Padding = new System.Windows.Forms.Padding(3);
            this.tpLocalLicensesHistory.Size = new System.Drawing.Size(1103, 223);
            this.tpLocalLicensesHistory.TabIndex = 0;
            this.tpLocalLicensesHistory.Text = "Local";
            // 
            // lblLocalLicensesRecordsCount
            // 
            this.lblLocalLicensesRecordsCount.AutoSize = true;
            this.lblLocalLicensesRecordsCount.ForeColor = System.Drawing.Color.Black;
            this.lblLocalLicensesRecordsCount.Location = new System.Drawing.Point(108, 188);
            this.lblLocalLicensesRecordsCount.Name = "lblLocalLicensesRecordsCount";
            this.lblLocalLicensesRecordsCount.Size = new System.Drawing.Size(22, 18);
            this.lblLocalLicensesRecordsCount.TabIndex = 3;
            this.lblLocalLicensesRecordsCount.Text = "??";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(6, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "# Records:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(11, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Local Licenses History:";
            // 
            // dgvLocalLicenses
            // 
            this.dgvLocalLicenses.AllowUserToAddRows = false;
            this.dgvLocalLicenses.AllowUserToDeleteRows = false;
            this.dgvLocalLicenses.AllowUserToOrderColumns = true;
            this.dgvLocalLicenses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLocalLicenses.BackgroundColor = System.Drawing.Color.White;
            this.dgvLocalLicenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocalLicenses.ContextMenuStrip = this.cmsLocalLicensesHistory;
            this.dgvLocalLicenses.Location = new System.Drawing.Point(6, 37);
            this.dgvLocalLicenses.Name = "dgvLocalLicenses";
            this.dgvLocalLicenses.ReadOnly = true;
            this.dgvLocalLicenses.Size = new System.Drawing.Size(1091, 148);
            this.dgvLocalLicenses.TabIndex = 0;
            // 
            // cmsLocalLicensesHistory
            // 
            this.cmsLocalLicensesHistory.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowLocalLicenseInfoItem,
            this.DetainLicenseItem});
            this.cmsLocalLicensesHistory.Name = "contextMenuStrip1";
            this.cmsLocalLicensesHistory.Size = new System.Drawing.Size(220, 102);
            // 
            // ShowLocalLicenseInfoItem
            // 
            this.ShowLocalLicenseInfoItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.ShowLocalLicenseInfoItem.Image = global::DVDL.Desktop.Properties.Resources.License_View_32;
            this.ShowLocalLicenseInfoItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ShowLocalLicenseInfoItem.Name = "ShowLocalLicenseInfoItem";
            this.ShowLocalLicenseInfoItem.Size = new System.Drawing.Size(218, 38);
            this.ShowLocalLicenseInfoItem.Text = "Show License Info";
            this.ShowLocalLicenseInfoItem.Click += new System.EventHandler(this.ShowLocalLicenseInfoItem_Click);
            // 
            // tpInternationalLicensesHistroy
            // 
            this.tpInternationalLicensesHistroy.BackColor = System.Drawing.Color.White;
            this.tpInternationalLicensesHistroy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tpInternationalLicensesHistroy.Controls.Add(this.lblInternationalLicensesRecordsCount);
            this.tpInternationalLicensesHistroy.Controls.Add(this.label5);
            this.tpInternationalLicensesHistroy.Controls.Add(this.label3);
            this.tpInternationalLicensesHistroy.Controls.Add(this.dgvInternalLicenses);
            this.tpInternationalLicensesHistroy.Location = new System.Drawing.Point(4, 27);
            this.tpInternationalLicensesHistroy.Name = "tpInternationalLicensesHistroy";
            this.tpInternationalLicensesHistroy.Padding = new System.Windows.Forms.Padding(3);
            this.tpInternationalLicensesHistroy.Size = new System.Drawing.Size(1103, 223);
            this.tpInternationalLicensesHistroy.TabIndex = 1;
            this.tpInternationalLicensesHistroy.Text = "International";
            // 
            // lblInternationalLicensesRecordsCount
            // 
            this.lblInternationalLicensesRecordsCount.AutoSize = true;
            this.lblInternationalLicensesRecordsCount.ForeColor = System.Drawing.Color.Black;
            this.lblInternationalLicensesRecordsCount.Location = new System.Drawing.Point(108, 188);
            this.lblInternationalLicensesRecordsCount.Name = "lblInternationalLicensesRecordsCount";
            this.lblInternationalLicensesRecordsCount.Size = new System.Drawing.Size(22, 18);
            this.lblInternationalLicensesRecordsCount.TabIndex = 5;
            this.lblInternationalLicensesRecordsCount.Text = "??";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(6, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 18);
            this.label5.TabIndex = 4;
            this.label5.Text = "# Records:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(4, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(203, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "International Licenses History:";
            // 
            // dgvInternalLicenses
            // 
            this.dgvInternalLicenses.AllowUserToAddRows = false;
            this.dgvInternalLicenses.AllowUserToDeleteRows = false;
            this.dgvInternalLicenses.AllowUserToOrderColumns = true;
            this.dgvInternalLicenses.BackgroundColor = System.Drawing.Color.White;
            this.dgvInternalLicenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInternalLicenses.ContextMenuStrip = this.cmsInternationalLicensesHistoryItem;
            this.dgvInternalLicenses.Location = new System.Drawing.Point(6, 37);
            this.dgvInternalLicenses.Name = "dgvInternalLicenses";
            this.dgvInternalLicenses.ReadOnly = true;
            this.dgvInternalLicenses.Size = new System.Drawing.Size(1091, 148);
            this.dgvInternalLicenses.TabIndex = 1;
            // 
            // cmsInternationalLicensesHistoryItem
            // 
            this.cmsInternationalLicensesHistoryItem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowInternationalLicenseItem});
            this.cmsInternationalLicensesHistoryItem.Name = "cmsInternationalLicensesHistoryItem";
            this.cmsInternationalLicensesHistoryItem.Size = new System.Drawing.Size(219, 42);
            // 
            // ShowInternationalLicenseItem
            // 
            this.ShowInternationalLicenseItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.ShowInternationalLicenseItem.Image = global::DVDL.Desktop.Properties.Resources.License_View_32;
            this.ShowInternationalLicenseItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ShowInternationalLicenseItem.Name = "ShowInternationalLicenseItem";
            this.ShowInternationalLicenseItem.Size = new System.Drawing.Size(218, 38);
            this.ShowInternationalLicenseItem.Text = "Show License Info";
            this.ShowInternationalLicenseItem.Click += new System.EventHandler(this.ShowInternationalLicenseItem_Click);
            // 
            // DetainLicenseItem
            // 
            this.DetainLicenseItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.DetainLicenseItem.Image = global::DVDL.Desktop.Properties.Resources.Detain_32;
            this.DetainLicenseItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.DetainLicenseItem.Name = "DetainLicenseItem";
            this.DetainLicenseItem.Size = new System.Drawing.Size(219, 38);
            this.DetainLicenseItem.Text = "Detain License";
            this.DetainLicenseItem.Click += new System.EventHandler(this.DetainLicenseItem_Click);
            // 
            // ctrlDriverLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.groupBox1);
            this.Name = "ctrlDriverLicenses";
            this.Size = new System.Drawing.Size(1164, 325);
            this.groupBox1.ResumeLayout(false);
            this.tcLicensesHistory.ResumeLayout(false);
            this.tpLocalLicensesHistory.ResumeLayout(false);
            this.tpLocalLicensesHistory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalLicenses)).EndInit();
            this.cmsLocalLicensesHistory.ResumeLayout(false);
            this.tpInternationalLicensesHistroy.ResumeLayout(false);
            this.tpInternationalLicensesHistroy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternalLicenses)).EndInit();
            this.cmsInternationalLicensesHistoryItem.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tcLicensesHistory;
        private System.Windows.Forms.TabPage tpLocalLicensesHistory;
        private System.Windows.Forms.Label lblLocalLicensesRecordsCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvLocalLicenses;
        private System.Windows.Forms.TabPage tpInternationalLicensesHistroy;
        private System.Windows.Forms.Label lblInternationalLicensesRecordsCount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvInternalLicenses;
        private System.Windows.Forms.ContextMenuStrip cmsLocalLicensesHistory;
        private System.Windows.Forms.ToolStripMenuItem ShowLocalLicenseInfoItem;
        private System.Windows.Forms.ContextMenuStrip cmsInternationalLicensesHistoryItem;
        private System.Windows.Forms.ToolStripMenuItem ShowInternationalLicenseItem;
        private System.Windows.Forms.ToolStripMenuItem DetainLicenseItem;
    }
}
