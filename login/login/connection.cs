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
                        DataLayer.Query("INSERT INTO `users` (username, password, admin, amount_shopped) VALUES (@Username, @Password, 0, 0);",
                        p =>
                        {
                            p.Add("@Username", MySqlDbType.VarChar, 255).Value = username;
                            p.Add("@Password", MySqlDbType.VarChar, 255).Value = password;
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
                    DataTable GetUser = DataLayer.Query("SELECT user_id, admin, username, password FROM users WHERE username = @loginUsername AND password = @loginPassword;",
                        p =>
                        {
                            p.Add("@loginUsername", MySqlDbType.VarChar, 255).Value = loginUsername;
                            p.Add("@loginPassword", MySqlDbType.VarChar, 255).Value = loginPassword;
                        });
                    // Checks if username and password combination exists.
                    if (GetUser.Rows.Count <= 0 && GetUser != null)
                    {
                        MessageBox.Show("Uw account bestaat niet of uw gegevens waren onjuist.");
                        return false;
                    }
                    else
                    {
                        // Cycles through query result of GetUser.
                        foreach (DataRow User in GetUser.Select())
                        {
                            // Stores user information in global methods.
                            GlobalMethods.LoginInfo.UserID = (int)User["user_id"];
                            GlobalMethods.LoginInfo.Username = (string)User["username"];

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
                                    GlobalMethods.ShowPopupNotification("U hebt een notificatie", "Welkom " + User["username"] + ". U hebt " + getUserNotifications.Rows.Count + " ongelezen notificatie.", 10000);
                                }
                                else
                                {
                                    GlobalMethods.ShowPopupNotification("U hebt notificaties", "Welkom " + User["username"] + ". U hebt " + getUserNotifications.Rows.Count + " ongelezen notificaties.", 10000);
                                }
                            }
                            else
                            {
                                GlobalMethods.ShowPopupNotification("Ingelogd", "Welkom " + User["username"] + ". U hebt geen ongelezen notificaties.", 5000);
                            }
                        }
                        return true;
                    }
                }
                catch (Exception e) // Catches any errors.
                {
                    MessageBox.Show("Error: " + e);
                    return false;
                }
            }
        }
        public DataTable query(string query)
        {
            DataTable table = DataLayer.Query(query,
                parameters =>
                {
                    
                });

            return table;
        }
    }
}
