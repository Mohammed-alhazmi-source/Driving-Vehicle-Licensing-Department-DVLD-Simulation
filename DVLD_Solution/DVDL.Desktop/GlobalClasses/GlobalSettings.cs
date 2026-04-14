using DVDL.BLL;
using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;

namespace DVDL.Desktop.Classes
{
    public class GlobalSettings
    {        
        public static clsUser CurrentUser { get; set; }


        public static void RememberUsernameAndPassword(string UserName, string Password)
        {
            string KeyPath = @"HKEY_CURRENT_USER\SOFTWARE\DVLD\UserAccount";
            string KeyUserName = "UserName";
            string KeyValueUserName = UserName;
            string KeyPassword = "Password";
            string KeyValuePassword = Password;

            try
            {
                Registry.SetValue(KeyPath, KeyUserName, KeyValueUserName, RegistryValueKind.String);
                Registry.SetValue(KeyPath, KeyPassword, KeyValuePassword, RegistryValueKind.String);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static bool GetStoredCredential(ref string UserName, ref string Password)
        {
            string KeyPath = @"HKEY_CURRENT_USER\SOFTWARE\DVLD\UserAccount";
            string KeyUserName = "UserName";
            string KeyPassword = "Password";

            try
            {
                string KeyValueUserName = null;
                string KeyValuePassword = null;

                KeyValueUserName = Registry.GetValue(KeyPath, KeyUserName, null) as string;
                KeyValuePassword = Registry.GetValue(KeyPath, KeyPassword, null) as string;

                if (KeyValueUserName != null && KeyValuePassword != null)
                {
                    UserName = KeyValueUserName;
                    Password = KeyValuePassword;
                    return true;
                }

                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool DeleteUserAccountFromRegistry()
        {
            string KeyPath = @"SOFTWARE\DVLD\UserAccount";
            string SubkeyUserName = "UserName";
            string SubkeyPassword = "Password";

            try
            {
                using (RegistryKey baseKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64))
                {
                    using (RegistryKey subKey = baseKey.OpenSubKey(KeyPath, true))
                    {
                        if (subKey != null)
                        {
                            string UserName = subKey.GetValue(SubkeyUserName) as string;
                            string Password = subKey.GetValue(SubkeyPassword) as string;

                            if(UserName != null && Password != null)
                            {
                                subKey.DeleteValue(SubkeyUserName);
                                subKey.DeleteValue(SubkeyPassword);
                                return true;
                            }

                            return false;
                        }

                        else
                            return false;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}