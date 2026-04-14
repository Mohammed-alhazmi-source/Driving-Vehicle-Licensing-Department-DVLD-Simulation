using DVDL.DAL;
using System;
using System.Data;
using System.Security.Cryptography;
using System.Text;

namespace DVDL.BLL
{
    public class clsUser
    {
        public enum enMode { Add = 0, Update = 1 };
        public enMode Mode = enMode.Add;

        public int UserID { get; set; }
        public int PersonID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public clsPerson PersonInfo { get; set; }

        public clsUser()
        {
            UserID = -1;
            PersonID = -1;
            UserName = "";
            Password = "";
            IsActive = false;
            Mode = enMode.Add;
        }

        private clsUser(int UserID, int PersonID, string UserName, string Password, bool IsActive)
        {
            this.UserID = UserID;
            this.PersonID = PersonID;
            this.UserName = UserName;
            this.Password = Password;
            this.IsActive = IsActive;
            this.PersonInfo = clsPerson.Find(PersonID);
            Mode = enMode.Update;
        }

        private bool _AddNewUser()
        {
            this.Password = ComputeHast(this.Password);
            this.UserID = clsUserData.AddNewUser(this.PersonID, this.UserName, this.Password, this.IsActive);

            return (this.UserID != -1);
        }

        private bool _UpdateUser()
        {
            this.Password = ComputeHast(this.Password);
            return clsUserData.UpdateUser(this.UserID, this.PersonID, this.UserName, this.Password, this.IsActive);
        }

        public static bool DeleteUser(int UserID) => clsUserData.DeleteUser(UserID);

        public static clsUser FindByUserID(int UserID)
        {
            int PersonID = -1;
            string UserName = "", Password = "";
            bool IsActive = false;

            bool IsFind = clsUserData.GetUserInfoByUserID(UserID, ref PersonID, ref UserName, ref Password, ref IsActive);

            if (IsFind)
                return new clsUser(UserID, PersonID, UserName, Password, IsActive);

            return null;
        }

        public static clsUser FindByUsernameAndPassword(string UserName, string Password)
        {
            int UserID = -1, PersonID = -1;
            bool IsActive = false;

            bool IsFind = clsUserData.GetUserInfoByUsernameAndPassword(ref UserID, ref PersonID, UserName, Password, ref IsActive);

            if (IsFind)
                return new clsUser(UserID, PersonID, UserName, Password, IsActive);

            return null;
        }

        public static clsUser FindByPersonID(int PersonID)
        {
            int UserID = -1;
            string UserName = "", Password = "";
            bool IsActive = false;

            bool IsFind = clsUserData.GetUserInfoByPersonID(ref UserID, PersonID, ref UserName, ref Password, ref IsActive);

            if (IsFind)
                return new clsUser(UserID, PersonID, UserName, Password, IsActive);

            return null;
        }

        public static bool IsUserExist(int UserID) => clsUserData.IsUserExist(UserID);

        public static bool IsUserExist(string UserName) => clsUserData.IsUserExist(UserName);

        public static bool IsUserExistForPersonID(int PersonID) => clsUserData.IsUserExistForPersonID(PersonID);

        public bool ChangePassword(int UserID, string NewPassword)
        {
            string HashedPassword = ComputeHast(NewPassword);
            return clsUserData.ChangePassword(UserID, HashedPassword);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.Add:
                    if (_AddNewUser())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;

                case enMode.Update:
                    return _UpdateUser();
            }

            return false;
        }

        public static DataTable GetAllUsers() => clsUserData.GetAllUsers();


        public static string ComputeHast(string Password)
        {
            using(SHA256  sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(Password));

                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }
    }
}