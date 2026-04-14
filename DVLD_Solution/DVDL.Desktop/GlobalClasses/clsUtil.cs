using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVDL.Desktop.Classes
{
    public class clsUtil
    {
        public static string GenerateGUID() => Guid.NewGuid().ToString();

        public static bool CreateFolderIfDoesNotExist(string FolderPath)
        {
            if (!Directory.Exists(FolderPath))
            {
                Directory.CreateDirectory(FolderPath);
                return true;
            }

            return true;
        }

        public static string ReplaceFileNameToGUID(string SourceFile)
        {
            string FileName = SourceFile;
            FileInfo file = new FileInfo(FileName);
            string Extension = file.Extension;
            return GenerateGUID() + Extension;
        }

        public static bool CopyImageToProjectImagesFolder(ref string SourceFile)
        {
            string DestinationFolder = @"E:\DVLD_People_Images\"; // مجلد الصور لتخزين صور المشروع فيه

            if (!CreateFolderIfDoesNotExist(DestinationFolder))
                return false;

            string DestinationFile = DestinationFolder + ReplaceFileNameToGUID(SourceFile);

            try
            {
                File.Copy(SourceFile, DestinationFile, true);
            }
            catch (IOException iox)
            {
                MessageBox.Show(iox.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            SourceFile = DestinationFile;
            return true;
        }

        public static string EncryptPassword(string Password, int Key = 3)
        {
            string EncryptedPassword = string.Empty;

            for (int Character = 0; Character < Password.Length; Character++)
            {
                EncryptedPassword += (char)(Password[Character] + (char)Key);
            }
            return EncryptedPassword;
        }

        public static string DecryptPassword(string Password, int Key = 3)
        {
            string DecryptedPassword = string.Empty;

            for (int Character = 0; Character < Password.Length; Character++)
            {
                DecryptedPassword += (char)(Password[Character] - (char)Key);
            }
            return DecryptedPassword;
        }

        public static void RememberUsernameAndPassword(string UserName, string Password)
        {
            string Record = UserName + "#" + Password;

            using (StreamWriter sw = File.CreateText("UsersAccounts.txt"))
                sw.WriteLine(Record);
        }

        public static bool GetStoredCredential(ref string UserName, ref string Password)
        {
            string Record = "";
            string FilePath = @"E:\IT\CourseNinteen\DVLD_Project\DVLD_Solution\DVDL.Desktop\bin\Debug\UsersAccounts.txt";

            if (File.Exists(FilePath))
            {
                using (StreamReader sr = File.OpenText(FilePath))
                {
                    Record = sr.ReadLine();
                    if (!string.IsNullOrEmpty(Record))
                    {
                        string[] AccountUser = Record.Split('#');
                        UserName = AccountUser[0];
                        Password = AccountUser[1];
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool DeleteUserAccountFromFile()
        {
            string FilePath = @"E:\IT\CourseNinteen\DVLD_Project\DVLD_Solution\DVDL.Desktop\bin\Debug\UsersAccounts.txt";

            if (File.Exists(FilePath))
            {
                using (StreamWriter sw = File.CreateText(FilePath))
                {
                    sw.Write("");
                }

                return true;
            }

            return false;
        }

        public static string Encrypt(string plainText, string key = "1234567890123456")
        {
            using (Aes aesAlg = Aes.Create())
            {
                // Set the key and IV for AES encryption
                aesAlg.Key = Encoding.UTF8.GetBytes(key);
                aesAlg.IV = new byte[aesAlg.BlockSize / 8];


                // Create an encryptor
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);


                // Encrypt the data
                using (var msEncrypt = new System.IO.MemoryStream())
                {
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    using (var swEncrypt = new System.IO.StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(plainText);
                    }


                    // Return the encrypted data as a Base64-encoded string
                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }

        public static string Decrypt(string cipherText, string key = "1234567890123456")
        {
            using (Aes aesAlg = Aes.Create())
            {
                // Set the key and IV for AES decryption
                aesAlg.Key = Encoding.UTF8.GetBytes(key);
                aesAlg.IV = new byte[aesAlg.BlockSize / 8];


                // Create a decryptor
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);


                // Decrypt the data
                using (var msDecrypt = new System.IO.MemoryStream(Convert.FromBase64String(cipherText)))
                using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                using (var srDecrypt = new System.IO.StreamReader(csDecrypt))
                {
                    // Read the decrypted data from the StreamReader
                    return srDecrypt.ReadToEnd();
                }
            }
        }
    }
}