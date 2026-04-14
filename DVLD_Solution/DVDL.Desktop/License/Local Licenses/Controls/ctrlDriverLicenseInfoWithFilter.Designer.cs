namespace DVDL.Desktop.License.Local_Licenses.Controls
{
    partial class ctrlDriverLicenseInfoWithFilter
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
            this.gbFilter = new System.Windows.Forms.GroupBox();
            this.btnFindLicenseInfo = new System.Windows.Forms.Button();
            this.txtFilterValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.ctrlDriverLicenseInfo1 = new DVDL.Desktop.License.ctrlDriverLicenseInfo();
            this.gbFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbFilter
            // 
            this.gbFilter.Controls.Add(this.btnFindLicenseInfo);
            this.gbFilter.Controls.Add(this.txtFilterValue);
            this.gbFilter.Controls.Add(this.label1);
            this.gbFilter.Font = new System.Drawing.Font("Tahoma", 12F);
            this.gbFilter.ForeColor = System.Drawing.Color.DimGray;
            this.gbFilter.Location = new System.Drawing.Point(15, 0);
            this.gbFilter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbFilter.Size = new System.Drawing.Size(560, 118);
            this.gbFilter.TabIndex = 0;
            this.gbFilter.TabStop = false;
            this.gbFilter.Text = "Filter";
            // 
            // btnFindLicenseInfo
            // 
            this.btnFindLicenseInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnFindLicenseInfo.FlatAppearance.BorderSize = 2;
            this.btnFindLicenseInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFindLicenseInfo.Font = new System.Drawing.Font("Tahoma", 13F);
            this.btnFindLicenseInfo.Image = global::DVDL.Desktop.Properties.Resources.License_View_32;
            this.btnFindLicenseInfo.Location = new System.Drawing.Point(483, 29);
            this.btnFindLicenseInfo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnFindLicenseInfo.Name = "btnFindLicenseInfo";
            this.btnFindLicenseInfo.Size = new System.Drawing.Size(56, 57);
            this.btnFindLicenseInfo.TabIndex = 31;
            this.btnFindLicenseInfo.UseVisualStyleBackColor = true;
            this.btnFindLicenseInfo.Click += new System.EventHandler(this.btnFindLicenseInfo_Click);
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.Location = new System.Drawing.Point(125, 45);
            this.txtFilterValue.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.Size = new System.Drawing.Size(320, 27);
            this.txtFilterValue.TabIndex = 1;
            this.txtFilterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterValue_KeyPress);
            this.txtFilterValue.Validating += new System.ComponentModel.CancelEventHandler(this.txtFilterValue_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(21, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "LicenseID:";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ctrlDriverLicenseInfo1
            // 
            this.ctrlDriverLicenseInfo1.BackColor = System.Drawing.Color.White;
            this.ctrlDriverLicenseInfo1.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.ctrlDriverLicenseInfo1.Location = new System.Drawing.Point(9, 118);
            this.ctrlDriverLicenseInfo1.Margin = new System.Windows.Forms.Padding(2);
            this.ctrlDriverLicenseInfo1.Name = "ctrlDriverLicenseInfo1";
            this.ctrlDriverLicenseInfo1.Size = new System.Drawing.Size(1069, 406);
            this.ctrlDriverLicenseInfo1.TabIndex = 1;
            // 
            // ctrlDriverLicenseInfoWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ctrlDriverLicenseInfo1);
            this.Controls.Add(this.gbFilter);
            this.Font = new System.Drawing.Font("Tahoma", 8F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ctrlDriverLicenseInfoWithFilter";
            this.Size = new System.Drawing.Size(1086, 526);
            this.gbFilter.ResumeLayout(false);
            this.gbFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbFilter;
        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFindLicenseInfo;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private ctrlDriverLicenseInfo ctrlDriverLicenseInfo1;
    }
}
