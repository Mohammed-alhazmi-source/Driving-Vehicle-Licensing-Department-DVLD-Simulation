using System;
using System.Windows.Forms;

namespace DVDL.Desktop.Users
{
    public partial class frmShowUserInfo : Form
    {
        private int _UserID = -1;
        public event Action DataBack;

        public frmShowUserInfo(int userID)
        {
            InitializeComponent();
            _UserID = userID;
        }

        private void frmShowUserInfo_Load(object sender, EventArgs e) => ctrlUserCard1.LoadUserInfo(_UserID);

        private void ctrlUserCard1_DataBackEventHandler() => DataBack?.Invoke();

        private void btnClose_Click(object sender, EventArgs e) => this.Close();
    }
}