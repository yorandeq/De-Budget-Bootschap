using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;
using Tulpep.NotificationWindow;
using System.Timers;

namespace login
{
    public class connection
    {
        // Load Neccessities.
        DataLayer DataLayer = new DataLayer();
        GlobalMethods GlobalMethods = new GlobalMethods();
        private static System.Timers.Timer notificationsTimer;

        // Method for creating a new account.
        public bool addAccount(string username, string password)
        {
            // Check if user has filled in the textboxes.
            if (username == "" || password == "")
            {
                MessageBox.Show("Voer een gebruikersnaam en wachtwoord in.");
                return false;
            } 
            else
            {
                try
                {
                    DataTable GetUsernameUsers = DataLayer.Query("SELECT username FROM users WHERE username = @Username;", 
                        p =>
                        {
                            p.Add("@Username", MySqlDbType.VarChar, 255).Value = username;
                        });

                    // Checks if user already exists in database. If it already exists, shows a MessageBox.
                    if (GetUsernameUsers.Rows.Count <= 0)
                    {
                        // Generates a new salt and the string to be saved into database.
                        byte[] NewSalt = GlobalMethods.GetSalt();
                        string NewSaltString = Convert.ToBase64String(NewSalt);

                        // Generates a salted hash and the string to be saved into database. Password plaintext has to be converted to bytes array to be properly hashed with salt.
                        byte[] SaltedHash = GlobalMethods.GenerateSaltedHash(Encoding.UTF8.GetBytes(password), NewSalt);
                        string SaltedHashString = Convert.ToBase64String(SaltedHash);

                        // Inserts new account into database.
                        DataLayer.Query("INSERT INTO `users` (username, password, password_salt, admin, amount_shopped) VALUES (@Username, @Password, @PasswordSalt, 0, 0);",
                        p =>
                        {
                            p.Add("@Username", MySqlDbType.VarChar, 255).Value = username;
                            p.Add("@Password", MySqlDbType.VarChar, 255).Value = SaltedHashString;
                            p.Add("@PasswordSalt", MySqlDbType.VarChar, 255).Value = NewSaltString;
                        });
                        MessageBox.Show("uw account is toegevoegd!");
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("De gebruiker '" + username + "' bestaat al.");
                        return false;
                    }
                }
                catch (Exception e) // Catches any errors.
                {
                    MessageBox.Show("Error: " + e);
                    return false;
                }
            }
        }

        // Method for logging into account.
        public bool loginAccount(string loginUsername, string loginPassword)
        {
            // Checks if user has filled in textboxes.
            if (loginUsername == "" || loginPassword == "")
            {
                MessageBox.Show("Voer een gebruikersnaam en wachtwoord in om in te loggen.");
                return false;
            }
            else
            {
                try
                {
                    DataTable GetUsers = DataLayer.Query("SELECT user_id, admin, username, password, password_salt FROM users;", p => {});
                    if(GetUsers.Rows.Count >= 0 || GetUsers != null)
                    {
                        foreach (DataRow User in GetUsers.Select())
                        {
                            // Gets the salt byte array from the selected user.
                            string SaltString = (string)User["password_salt"];
                            byte[] Salt = Convert.FromBase64String(SaltString);

                            // Gets the user password hash byte array from the selected user.
                            string UserPasswordHashString = (string)User["password"];
                            byte[] UserPasswordHash = Convert.FromBase64String(UserPasswordHashString);

                            // Using the salt byte array from the selected user, generates a new salted hash with the typed in login password.
                            byte[] LoginPasswordHash = GlobalMethods.GenerateSaltedHash(Encoding.UTF8.GetBytes(loginPassword), Salt);

                            // Checks if the typed in username is the same username and compares the password hash from the database with the password hash from the typed in login password.
                            if (loginUsername == (string)User["username"] && GlobalMethods.CompareByteArrays(UserPasswordHash, LoginPasswordHash))
                            {
                                // Stores user information in global methods.
                                GlobalMethods.LoginInfo.UserID = (int)User["user_id"];
                                GlobalMethods.LoginInfo.Username = (string)User["username"];
                                GlobalMethods.LoginInfo.Admin = (int)User["admin"];

                                // Gets every notification of current user and displays the amount of unread notifications.
                                DataTable getUserNotifications = DataLayer.Query("SELECT * FROM notifications WHERE (user = @UserId AND state = 0) OR (user = @UserId2 AND state = 1)",
                                p =>
                                {
                                    p.Add("@UserId", MySqlDbType.Int16, 255).Value = User["user_id"];
                                    p.Add("@UserId2", MySqlDbType.Int16, 255).Value = User["user_id"];
                                });

                                // Checks if user has unread notifications and displays a notification if so.
                                if (getUserNotifications.Rows.Count > 0)
                                {
                                    if (getUserNotifications.Rows.Count == 1)
                                    {
                                        GlobalMethods.ShowPopupNotification("Ongelezen notificatie", "Welkom " + User["username"] + ". U hebt " + getUserNotifications.Rows.Count + " ongelezen notificatie.", 10000);
                                    }
                                    else
                                    {
                                        GlobalMethods.ShowPopupNotification("Ongelezen notificaties", "Welkom " + User["username"] + ". U hebt " + getUserNotifications.Rows.Count + " ongelezen notificaties.", 10000);
                                    }
                                }
                                else
                                {
                                    GlobalMethods.ShowPopupNotification("Ingelogd", "Welkom " + User["username"] + ". U hebt geen ongelezen notificaties.", 5000);
                                }
                                return true;
                            }
                        }
                        MessageBox.Show("Uw account bestaat niet of uw gegevens waren onjuist."); // If no user matched the username and password combination.
                        return false;
                    }
                    else // If there are no results from the user query.
                    {
                        MessageBox.Show("Er ging iets mis met de verbinding.");
                        return false;
                    }
                }
                catch (Exception e) // Catches any errors.
                {
                    MessageBox.Show("Error: " + e);
                    return false;
                }
            }
        }

        // Used to start the timer for notification checking.
        public void StartTimer()
        {
            notificationsTimer = new System.Timers.Timer(10000);
            notificationsTimer.Elapsed += checkNewNotifications;
            notificationsTimer.AutoReset = true;
            notificationsTimer.Enabled = true;
        }

        // Method for getting and showing new notifications.
        public void checkNewNotifications(Object source, ElapsedEventArgs e)
        {
            // Gets every notification from user with state 0.
            DataTable NewNotifications = DataLayer.Query("SELECT * FROM notifications WHERE user = @UserId AND state = 0;",
            p =>
            {
                p.Add("@UserId", MySqlDbType.Int32, 255).Value = GlobalMethods.LoginInfo.UserID;
            });
            if (NewNotifications.Rows.Count > 0)
            {
                // Gets current opened form.
                var CurrentOpenForm = Application.OpenForms[0];

                // Shows the notification. ShowPopupNotification has to be done with an invoke on the current active form to show properly.
                CurrentOpenForm.Invoke((MethodInvoker)delegate
                {
                    GlobalMethods.ShowPopupNotification("Nieuwe Notificatie", (string)NewNotifications.Rows[0]["message"], 5000);
                });
                // Sets the shown notification to state 1.
                DataTable setNewNotification = DataLayer.Query("UPDATE notifications SET state = 1 WHERE notification_id = @NotificationId",
                p =>
                {
                    p.Add("@NotificationId", MySqlDbType.Int32, 255).Value = NewNotifications.Rows[0]["notification_id"];
                });
            }
        }

        
    }
}
