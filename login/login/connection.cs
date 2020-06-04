using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;
//using static config.database;

namespace login
{
    public class connection
    {
        
        //public config.database configClass = new config();
        config2 configClass = new config2();
        //Voegt een account toe aan de database
        public bool addAccount(string username, string password)
        {
            //Checkt of er iets ingevuld is in de textboxes
            if (username == "" || password == "")
            {
                MessageBox.Show("Voer een gebruikersnaam en wachtwoord in.");
                return false;
            } 
            else
            {
                try
                {
                    bool succes = true;
                    configClass.databaseConnection.Open();
                    string query1 = "SELECT username FROM users WHERE username = '" + username + "';";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query1, configClass.databaseConnection);
                    adapter.Fill(configClass.table);
                    //Checkt of de gebruiker bestaat in de database
                    if (configClass.table.Rows.Count <= 0)
                    {
                        string query2 = "INSERT INTO `users` (username, password) VALUES (@username, @password);";
                        MySqlCommand cmdAdd = new MySqlCommand(query2, configClass.databaseConnection);
                        cmdAdd.Parameters.AddWithValue("@username", username);
                        cmdAdd.Parameters.AddWithValue("@password", password);
                        cmdAdd.Prepare();
                        cmdAdd.ExecuteReader();
                        MessageBox.Show("uw account is toegevoegd!");
                        succes = true;
                    }
                    //Geeft een melding als de gebruiker al bestaat
                    else
                    {
                        MessageBox.Show("De gebruiker '" + username + "' bestaat al.");
                        succes = false;
                    }
                    configClass.table.Clear();
                    configClass.databaseConnection.Close();
                    //checkt of user een account kan aanmaken
                    if (succes)
                    {
                        return true;
                    } else
                    {
                        return false;
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error: " + e);
                    return false;
                }
            }
        }

        //Checkt of de ingevulde gegevens overeenkomen met die in de database zodat je kan inloggen
        public bool loginAccount(string loginUsername, string loginPassword)
        {
            //Checkt of er iets ingevuld is in de textboxes
            if (loginUsername == "" || loginPassword == "")
            {
                MessageBox.Show("Voer een gebruikersnaam en wachtwoord in om in te loggen.");
                return false;
            }
            else
            {
                try
                {
                    bool succes = true;
                    configClass.databaseConnection.Open();
                    string query = "SELECT username, password FROM users WHERE username = @loginUsername AND password = @loginPassword;";
                    MySqlCommand cmdSelect = new MySqlCommand(query, configClass.databaseConnection);
                    MySqlDataAdapter adapter = new MySqlDataAdapter();
                    cmdSelect.Parameters.AddWithValue("@loginUsername", loginUsername);
                    cmdSelect.Parameters.AddWithValue("@loginPassword", loginPassword);
                    cmdSelect.Prepare();
                    adapter.SelectCommand = cmdSelect;
                    adapter.Fill(configClass.table);
                    if (configClass.table.Rows.Count <= 0)
                    {
                        MessageBox.Show("Uw account bestaat niet of uw gegevens waren onjuist.");
                        succes = false;
                    }
                    else
                    {
                        MySqlDataReader read = cmdSelect.ExecuteReader();
                        if (read.HasRows)
                        {
                            while (read.Read())
                            {
                                var loginForm = new login();
                                var storesForm = new stores();

                                string admin = read[0].ToString();
                                if (admin == "admin")
                                {
                                    MessageBox.Show("U bent ingelogd als een admin!");
                                } else
                                {
                                    MessageBox.Show("U bent ingelogd als gebruiker!");
                                }
                            }
                        }
                    }
                    configClass.table.Clear();
                    configClass.databaseConnection.Close();
                    //checkt of de user kan inloggen
                    if (succes)
                    {
                        return true;
                    } else
                    {
                        return false;
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error: " + e);
                    return false;
                }
            }
        }
    }
}
