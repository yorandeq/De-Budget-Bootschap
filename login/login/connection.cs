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
using System.Globalization;

namespace login
{
    public class connection
    {
        // Load Neccessities.
        DataLayer DataLayer = new DataLayer();
        GlobalMethods GlobalMethods = new GlobalMethods();
        private static System.Timers.Timer notificationsTimer;

        // Method for creating a new account.
        public bool addAccount(string username, string password, bool superAdminCheck, string superMarketName)
        {
            // Check if user has filled in the textboxes.
            if (username == "" || password == "" || superMarketName == "")
            {
                MessageBox.Show("Vul alstublieft alle velden in.");
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

                        // Checks if the user that is trying to add an account is a superadmin
                        if (superAdminCheck == true) 
                        {
                            // Retrieves the supermarketID of the filled in name of the supermarket
                            DataTable GetSuperMarketID = DataLayer.Query("SELECT supermarket_id FROM supermarkets WHERE name = @SupermarketName;",
                                p =>
                                {
                                    p.Add("@SupermarketName", MySqlDbType.VarChar, 255).Value = superMarketName;
                                });
                            if (GetSuperMarketID.Rows.Count > 0)
                            {
                                // Inserts de admin of a specific supermarket into the database
                                DataRow row = GetSuperMarketID.Rows[0];
                                int superMarketID = int.Parse(row["supermarket_id"].ToString());
                                DataLayer.Query("INSERT INTO `users` (username, password, password_salt, admin, admin_supermarket, amount_shopped) VALUES (@Username, @Password, @PasswordSalt, 1, @StoreID, 0);",
                                    p =>
                                    {
                                        p.Add("@Username", MySqlDbType.VarChar, 255).Value = username;
                                        p.Add("@Password", MySqlDbType.VarChar, 255).Value = SaltedHashString;
                                        p.Add("@PasswordSalt", MySqlDbType.VarChar, 255).Value = NewSaltString;
                                        p.Add("@StoreID", MySqlDbType.VarChar, 255).Value = superMarketID;
                                    });
                                MessageBox.Show("Uw supermarkt admin account voor de " + superMarketName + " is toegevoegd!");
                            }
                            else
                            {
                                MessageBox.Show("De ingevulde supermarkt bestaat niet of moet nog toegevoegd worden.");
                            }
                        } 
                        else
                        {
                            // Inserts new account into database.
                            DataLayer.Query("INSERT INTO `users` (username, password, password_salt, admin, amount_shopped) VALUES (@Username, @Password, @PasswordSalt, 0, 0);",
                            p =>
                            {
                                p.Add("@Username", MySqlDbType.VarChar, 255).Value = username;
                                p.Add("@Password", MySqlDbType.VarChar, 255).Value = SaltedHashString;
                                p.Add("@PasswordSalt", MySqlDbType.VarChar, 255).Value = NewSaltString;
                            });
                            MessageBox.Show("Uw account is toegevoegd.");
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
                    DataTable GetUsers = DataLayer.Query("SELECT * FROM users;", p => {});
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
                                // Stores user information in global methods. In admin_supermarket it first checks if the value isn't null.
                                GlobalMethods.LoginInfo.UserID = (int)User["user_id"];
                                GlobalMethods.LoginInfo.Username = (string)User["username"];
                                GlobalMethods.LoginInfo.Admin = (int)User["admin"];
                                GlobalMethods.LoginInfo.Supermarket = User["admin_supermarket"] != DBNull.Value ? (int)User["admin_supermarket"] : 0;
                                
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

        // Method for adding a new supermarket to the database
        public bool addSupermarket(string superMarketName, string superMarketDesc, string superMarketLink, byte[] blobImg)
        {
            if (superMarketName == "" || superMarketDesc == "" || superMarketLink == "" || blobImg == null)
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
                        DataLayer.Query("INSERT INTO `supermarkets` (name, icon, description, link) VALUES (@Name, @Icon, @Description, @Link);",
                        p =>
                        {
                            p.Add("@Name", MySqlDbType.VarChar, 255).Value = superMarketName;
                            p.Add("@Icon", MySqlDbType.LongBlob, 255).Value = blobImg;
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

        public void place_registration(object productName, object productId, object price)
        {
            var confirmResult = MessageBox.Show($"Wilt u {productName.ToString()} kopen voor € {price.ToString()}?", "Product kopen", MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    int user_id = GlobalMethods.LoginInfo.UserID;
                    int product_id = (int)productId;
                    int product_amount = 1;
                    float paid = (float)price;
                    DataLayer.Query("INSERT INTO `registration` (`registration_id`, `user`, `product`, `product_amount`, `paid`) VALUES (NULL, @UserId, @ProductId, @ProductAmount, @TotalPrice)",
                            p =>
                            {
                                p.Add("@UserId", MySqlDbType.Int32, 255).Value = user_id;
                                p.Add("@ProductId", MySqlDbType.Int32, 255).Value = product_id;
                                p.Add("@ProductAmount", MySqlDbType.Int32, 255).Value = product_amount;
                                p.Add("@TotalPrice", MySqlDbType.Float, 255).Value = paid;
                            });
                    MessageBox.Show("Bedankt voor uw bestelling!");
                    SubtractBalance(paid);

                    // Checks if number of registers has reached the minimum.
                    DataTable MinAmount = DataLayer.Query("SELECT discount_offers.min_amount, COUNT(registration.product) FROM discount_products INNER JOIN discount_offers ON discount_products.discount_offer = discount_offers.offer_id INNER JOIN registration ON discount_products.product_id = registration.product WHERE discount_products.product_id = @ProductId",
                        p =>
                        {
                            p.Add("@ProductId", MySqlDbType.Int32, 255).Value = product_id;
                        });
                    foreach(DataRow MinAmountRow in MinAmount.Rows)
                    {
                        if(Convert.ToInt64(MinAmountRow[0]) == Convert.ToInt64(MinAmountRow[1]))
                        {
                            // Adds notification for all registered users.
                            DataTable RegisteredUsersProducts = DataLayer.Query("SELECT users.user_id, discount_products.name FROM discount_products INNER JOIN registration ON registration.product = discount_products.product_id INNER JOIN users ON users.user_id = registration.user WHERE discount_products.product_id = @ProductId",
                            p =>
                            {
                                p.Add("@ProductId", MySqlDbType.Int32, 255).Value = product_id;
                            });
                            foreach (DataRow RegisteredUser in RegisteredUsersProducts.Select())
                            {
                                DataLayer.Query("INSERT INTO `notifications` (`notification_id`, `user`, `message`, `state`) VALUES (NULL, @UserId, 'Uw geregistreerde product" + RegisteredUser["name"] + " kan nu opgehaald worden.', '0') ",
                                p =>
                                {
                                    p.Add("@UserId", MySqlDbType.Int32, 255).Value = RegisteredUser["user_id"];
                                });
                            }
                        }
                    }
                } 
                catch (Exception e)
                {
                    MessageBox.Show("Error: " + e);
                }
            }
        }

        // Method for retrieving all the supermarkets so I can display them in a datagridview
        public DataTable getAllSupermarkets()
        {
            DataTable supermarketList = DataLayer.Query("SELECT supermarket_id, name, description, link FROM supermarkets", p => { });
            return supermarketList;
        }

        // Method for retrieving all the supermarket admins so I can display them in a datagridview
        public DataTable getAllUsers()
        {
            DataTable userList = DataLayer.Query("SELECT user_id, username, admin, admin_supermarket FROM users", p => { });
            return userList;
        }

        // Method for retrieving the balance of the logged in user

        public DataTable getBalance()
        {
            DataTable getBalance = DataLayer.Query("SELECT balance FROM `users` WHERE user_id = @UserID",
                p =>
                {
                    p.Add("@Balance", MySqlDbType.Int16, 255).Value = 5.00;
                    p.Add("@UserID", MySqlDbType.Int16, 11).Value = GlobalMethods.LoginInfo.UserID;
                });
            return getBalance;
        }

        // Method for subtracting balance
        public void SubtractBalance(float paid)
        {
            DataTable getBalance = DataLayer.Query("SELECT balance FROM `users` WHERE user_id = @UserID",
                p =>
                {
                    p.Add("@UserID", MySqlDbType.Int16, 11).Value = GlobalMethods.LoginInfo.UserID;
                });

            float newBalance = float.Parse(getBalance.Rows[0]["balance"].ToString()) - paid;

            DataTable setBalance = DataLayer.Query("UPDATE `users` SET balance = @Balance WHERE user_id = @UserId",
                p =>
                {
                    p.Add("@Balance", MySqlDbType.Decimal, 255).Value = newBalance;
                    p.Add("@UserID", MySqlDbType.Int16, 11).Value = GlobalMethods.LoginInfo.UserID;
                });
        }

        // Method for deleting a specific user from the database

        public void delUser(int selectedUser)
        {
            DataLayer.Query("DELETE FROM `users` WHERE user_id = @UserID",
                p =>
                {
                    p.Add("@UserID", MySqlDbType.Int16, 11).Value = selectedUser;
                });
        }

        // Method for deleting supermarkets from the databas

        public void delStore(int selectedStore)
        {
            DataLayer.Query("DELETE FROM `supermarkets` WHERE supermarket_id = @StoreID",
                p =>
                {
                    p.Add("@StoreID", MySqlDbType.Int16, 11).Value = selectedStore;
                });
        }
    }
}
