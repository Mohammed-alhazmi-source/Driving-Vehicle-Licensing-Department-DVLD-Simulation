using DVDL.BLL;
using System;
using System.Windows.Forms;

namespace DVDL.Desktop.Users.Controls
{
    public partial class ctrlUserCard : UserControl
    {
        public ctrlUserCard()
        {
            InitializeComponent();
        }

        public event Action DataBackEventHandler;

        private clsUser _User = null;

        private int _UserID = -1;
        public int UserID => _UserID;

        public clsUser SelectedUserInfo => _User;

        private void _ResetUserInfo()
        {
            _UserID = -1;
            lblUserID.Text = "[?????]";
            lblUserName.Text = "[?????]";
            lblIsActive.Text = "[?????]";
        }

        private void _FillUserInfo()
        {
            _UserID = _User.UserID;
            ctrlPersonCard1.LoadPersonInfo(_User.PersonID);
            lblUserID.Text = _User.UserID.ToString();
            lblUserName.Text = _User.UserName;
            lblIsActive.Text = (_User.IsActive ? "Yes" : "No");
        }

        public void LoadUserInfo(int UserID)
        {
            _UserID = UserID;
            _User = clsUser.FindByUserID(UserID);

            if(_User == null)
            {
                _ResetUserInfo();
                MessageBox.Show("No User With UserID = " + UserID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillUserInfo();
        }

        private void ctrlPersonCard1_DataBackEventHandler()
        {
            DataBackEventHandler?.Invoke();
        }
    }
}