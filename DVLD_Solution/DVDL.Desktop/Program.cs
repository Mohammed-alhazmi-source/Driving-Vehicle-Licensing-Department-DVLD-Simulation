using DVDL.Desktop.License.Local_Licenses;
using System;
using System.Windows.Forms;

namespace DVDL.Desktop
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //DateTime dateTime = new DateTime(2025, 11, 15);
            //if (DateTime.Now > dateTime)
            //{
            //    MessageBox.Show("تم انتهاء فترة النسخة للاستخدام مرة اخرى يرجى التواصل مع الشركة", "تحديث", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

            //else
                Application.Run(new frmLogin());
        }
    }
}