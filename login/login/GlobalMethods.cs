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
using System.Drawing;
using System.Data;

namespace login
{
    // When included, these methods can be used in any csharp file.
    class GlobalMethods
    {
        // Load neccessities.
        DataLayer DataLayer = new DataLayer();

        // Used to store login session info.
        public static class LoginInfo
        {
            public static int UserID;
            public static string Username;
            public static int Admin;
            public static int Supermarket;
        }

        // Used to store info about what stores and products have been selected
        public static class StoresInfo
        {
            public static int StoreID;
            public static int OfferID;
            //public static int ProductID;
        }

        // Saves image to sent it to the database
        public static class ImageInfo
        {
            public static byte[] ImageFile;
        }

        // Method for switching forms quickly.
        public void SwitchForm(Form previousForm, Form newForm)
        {
            previousForm.Hide();
            newForm.Show();
            newForm.Location = previousForm.Location;
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

        //Method for converting images to Byte array
        public static byte[] ImageToByteArray(Image imageIn)
        {
            var ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        // Method for picking a file
        public void openFile()
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Files|*.jpg;*.jpeg;*.png";
            open.Title = "Please select an image file to encrypt.";
            if (open.ShowDialog() == DialogResult.OK)
            {
                Image superMarketImg = new Bitmap(open.FileName);
                byte[] blobData = ImageToByteArray(superMarketImg);
                ImageInfo.ImageFile = blobData;
            }
        }

        //opensite
        public void openSite(object href)
        {
            System.Diagnostics.Process.Start(href.ToString());
        }

        public void ExpireOffers()
        {
            long todayTicks = DateTime.Today.Ticks;
            long todayMilliseconds = todayTicks / TimeSpan.TicksPerMillisecond;

            DataTable expirationOffers = DataLayer.Query("SELECT offer_id, expiration_date FROM discount_offers", 
                p => { });

            foreach (DataRow row in expirationOffers.Rows)
            {
                long dateTicks = row.Field<DateTime>("expiration_date").Ticks;
                long dateMilliseconds = dateTicks / TimeSpan.TicksPerMillisecond;

                if (dateMilliseconds - todayMilliseconds < 0)
                {
                    DataLayer.Query("DELETE FROM discount_offers WHERE offer_id = " + row["offer_id"],
                        p => { });
                }
            }
        }
    }
}
