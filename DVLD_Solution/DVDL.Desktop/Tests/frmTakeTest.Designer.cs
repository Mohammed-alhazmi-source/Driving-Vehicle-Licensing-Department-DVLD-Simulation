namespace DVDL.Desktop.Tests
{
    partial class frmTakeTest
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
            this.ctrlScheduledTest1 = new DVDL.Desktop.Tests.Controls.ctrlScheduledTest();
            this.SuspendLayout();
            // 
            // ctrlScheduledTest1
            // 
            this.ctrlScheduledTest1.BackColor = System.Drawing.Color.White;
            this.ctrlScheduledTest1.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.ctrlScheduledTest1.Location = new System.Drawing.Point(-12, -1);
            this.ctrlScheduledTest1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ctrlScheduledTest1.Name = "ctrlScheduledTest1";
            this.ctrlScheduledTest1.Size = new System.Drawing.Size(661, 534);
            this.ctrlScheduledTest1.TabIndex = 0;
            this.ctrlScheduledTest1.TestTypeID = DVDL.BLL.clsTestType.enTestType.VisionTest;
            this.ctrlScheduledTest1.OnClosed += new System.Action(this.ctrlScheduledTest1_OnClosed);
            // 
            // frmTakeTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(641, 540);
            this.Controls.Add(this.ctrlScheduledTest1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmTakeTest";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Take Test";
            this.Load += new System.EventHandler(this.fTakeTest_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ctrlScheduledTest ctrlScheduledTest1;
    }
}