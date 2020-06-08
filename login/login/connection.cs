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
using System.Drawing;

namespace login
{
    public class connection
    {
        // Load Neccessities.
        DataLayer DataLayer = new DataLayer();
        GlobalMethods GlobalMethods = new GlobalMethods();
        private static System.Timers.Timer notificationsTimer;

        // Method for creating a new account.
        public bool addAccount(string username, string password, bool superAdminCheck)
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
                        if (superAdminCheck == true) 
                        {
                            DataLayer.Query("INSERT INTO `users` (username, password, admin, amount_shopped) VALUES (@Username, @Password, 1, 0);",
                            p =>
                            {
                                p.Add("@Username", MySqlDbType.VarChar, 255).Value = username;
                                p.Add("@Password", MySqlDbType.VarChar, 255).Value = password;
                            });
                                MessageBox.Show("uw supermarkt admin account is toegevoegd!");
                        } 
                        else
                        {
                            DataLayer.Query("INSERT INTO `users` (username, password, admin, amount_shopped) VALUES (@Username, @Password, 0, 0);",
                            p =>
                            {
                                p.Add("@Username", MySqlDbType.VarChar, 255).Value = username;
                                p.Add("@Password", MySqlDbType.VarChar, 255).Value = password;
                            });
                                MessageBox.Show("uw account is toegevoegd!");
                        }
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
                            GlobalMethods.LoginInfo.Admin = (int)User["admin"];

                            // Gets every notification of current user and displays the amount of unread notifications.
                            DataTable getUserNotifications = DataLayer.Query("SELECT * FROM notifications WHERE user = @UserId AND state = 0 OR state = 1",
                            p =>
                            {
                                p.Add("@UserId", MySqlDbType.Int16, 255).Value = User["user_id"];
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
                // Shows the notification. ShowPopupNotification has to be done with an invoke on the current active form to show properly.
                Form.ActiveForm.Invoke((MethodInvoker)delegate
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

        // Method for adding a new supermarket to the database
        public bool addSupermarket(string superMarketName, string superMarketDesc, string superMarketLink)
        {
            if (superMarketName == "" || superMarketDesc == "" || superMarketLink == "")
            {
                MessageBox.Show("Voer alle velden in om een supermarkt toetevoegen");
                return false;
            }
            else
            {
                try
                {
                    DataTable GetSupermarketNames = DataLayer.Query("SELECT name FROM supermarkets WHERE name = @SupermarketName;",
                        p =>
                        {
                            p.Add("@SupermarketName", MySqlDbType.VarChar, 255).Value = superMarketName;
                        });

                    // Checks if supermarket already exists in database. If it already exists, shows a MessageBox.
                    if (GetSupermarketNames.Rows.Count <= 0)
                    {
                        DataLayer.Query("INSERT INTO `supermarkets` (name, description, link) VALUES (@Name, @Description, @Link);",
                        p =>
                        {
                            p.Add("@Name", MySqlDbType.VarChar, 255).Value = superMarketName;
                            p.Add("@Description", MySqlDbType.VarChar, 255).Value = superMarketDesc;
                            p.Add("@Link", MySqlDbType.VarChar, 255).Value = superMarketLink;
                        });
                        MessageBox.Show("De supermarkt is toegevoegd!");
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("De supermarkt '" + superMarketName + "' bestaat al.");
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
    }
}
