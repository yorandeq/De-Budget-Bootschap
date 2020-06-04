using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;
using Tulpep.NotificationWindow;

namespace login
{
    public class connection
    {
        // Load Neccessities.
        DataLayer DataLayer = new DataLayer();
        GlobalMethods GlobalMethods = new GlobalMethods();

        // Method for creating a new account.
        public void addAccount(string username, string password)
        {
            // Check if user has filled in the textboxes.
            if (username == "" || password == "")
            {
                MessageBox.Show("Voer een gebruikersnaam en wachtwoord in.");
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
                        DataLayer.Query("INSERT INTO `users` (username, password, admin, amount_shopped) VALUES (@Username, @Password, 0, 0);",
                        p =>
                        {
                            p.Add("@Username", MySqlDbType.VarChar, 255).Value = username;
                            p.Add("@Password", MySqlDbType.VarChar, 255).Value = password;
                        });
                        MessageBox.Show("uw account is toegevoegd!");
                    }
                    else
                    {
                        MessageBox.Show("De gebruiker '" + username + "' bestaat al.");
                    }
                }
                catch (Exception e) // Catches any errors.
                {
                    MessageBox.Show("Error: " + e);
                }
            }
        }

        // Method for logging into account.
        public void loginAccount(string loginUsername, string loginPassword)
        {
            // Checks if user has filled in textboxes.
            if (loginUsername == "" || loginPassword == "")
            {
                MessageBox.Show("Voer een gebruikersnaam en wachtwoord in om in te loggen.");
            }
            else
            {
                try
                {
                    DataTable GetUser = DataLayer.Query("SELECT user_id, admin, username, password FROM users WHERE username = @loginUsername AND password = @loginPassword;",
                        p =>
                        {
                            p.Add("@loginUsername", MySqlDbType.VarChar, 255).Value = loginUsername;
                            p.Add("@loginPassword", MySqlDbType.VarChar, 255).Value = loginPassword;
                        });
                    // Checks if username and password combination exists.
                    if (GetUser.Rows.Count <= 0)
                    {
                        MessageBox.Show("Uw account bestaat niet of uw gegevens waren onjuist.");
                    }
                    else
                    {
                        // Checks if username and password combination is not null
                        if (GetUser != null)
                        {
                            // Cycles through query result of GetUser.
                            foreach (DataRow User in GetUser.Select())
                            {
                                // Stores user information on global methods.
                                GlobalMethods.LoginInfo.UserID = (int)User["user_id"];
                                GlobalMethods.LoginInfo.Username = (string)User["username"];

                                // Redirects to user page. (This one should be changed when the user page gets added. Currently redirects to notifications page.)
                                GlobalMethods.SwitchForm(new notifications());

                                // Gets every notification of current user and displays the amount of unread notifications.
                                DataTable getUserNotifications = DataLayer.Query("SELECT * FROM notifications WHERE user = @UserId AND state = 0",
                                p =>
                                {
                                    p.Add("@UserId", MySqlDbType.Int16, 255).Value = User["user_id"];
                                });

                                // Checks if user has unread notifications and displays a notification if so.
                                if (getUserNotifications.Rows.Count > 0)
                                {
                                    if (getUserNotifications.Rows.Count == 1)
                                    {
                                        GlobalMethods.ShowPopupNotification("You have Unread Notifications", "Welcome " + User["username"] + ". You have " + getUserNotifications.Rows.Count + " unread notification.", 10000);
                                    }
                                    else
                                    {
                                        GlobalMethods.ShowPopupNotification("You have Unread Notifications", "Welcome " + User["username"] + ". You have " + getUserNotifications.Rows.Count + " unread notifications.", 10000);
                                    }
                                }
                                else
                                {
                                    GlobalMethods.ShowPopupNotification("Logged in", "Welcome " + User["username"] + ". You have no unread notifications.", 5000);
                                }
                            }
                        }
                    }
                }
                catch (Exception e) // Catches any errors.
                {
                    MessageBox.Show("Error: " + e);
                }
            }
            
        }
    }
}
