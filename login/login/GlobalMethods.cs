using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tulpep.NotificationWindow;
using System.IO;
using System.Timers;
using System.Security.Cryptography;

namespace login
{
    // When included, these methods can be used in any csharp file.
    class GlobalMethods
    {
        // Used to store login session info.
        public static class LoginInfo
        {
            public static int UserID;
            public static string Username;
            public static int Admin;
        }

        // Method for switching forms quickly.
        public void SwitchForm(Form newForm)
        {
            Form.ActiveForm.Hide();
            newForm.Show();
        }

        // Method for creating a popup notification.
        public void ShowPopupNotification(string titleText, string contentText, int PopupDuration)
        {
            PopupNotifier PopUp = new PopupNotifier();
            PopUp.TitleText = titleText;
            PopUp.ContentText = contentText;
            PopUp.Delay = PopupDuration;
            PopUp.Popup();
        }

        // Generates a random salt.
        public static byte[] GetSalt()
        {
            var salt = new byte[32];
            using (var random = new RNGCryptoServiceProvider())
            {
                random.GetNonZeroBytes(salt);
            }
            return salt;
        }

        // Generates a salted hash based on plaintext and salt.
        public byte[] GenerateSaltedHash(byte[] plainText, byte[] salt)
        {
            HashAlgorithm algorithm = new SHA256Managed();
            byte[] plainTextWithSaltBytes = new byte[plainText.Length + salt.Length];

            for (int i = 0; i < plainText.Length; i++)
            {
                plainTextWithSaltBytes[i] = plainText[i];
            }
            for (int i = 0; i < salt.Length; i++)
            {
                plainTextWithSaltBytes[plainText.Length + i] = salt[i];
            }

            return algorithm.ComputeHash(plainTextWithSaltBytes);
        }

        // Checks if 2 byte arrays are the same. Used for comparing salted hashes.
        public static bool CompareByteArrays(byte[] array1, byte[] array2)
        {
            if (array1.Length != array2.Length)
            {
                return false;
            }
            for (int i = 0; i < array1.Length; i++)
            {
                if (array1[i] != array2[i])
                {
                    return false;
                }
            }
            return true;
        }

        // Method for converting blobs from databases to MemoryStream wich can be used as for images
        public MemoryStream convertImg(object img)
        {
            byte[] byteImg = (byte[])img;
            MemoryStream msImg = new MemoryStream(byteImg);
            return msImg;
        }

        //opensite
        public void openSite(string href)
        {
            System.Diagnostics.Process.Start(href);
        }
    }
}
