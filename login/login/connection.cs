using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;

namespace login
{
    public class connection
    {
        
        //public config.database configClass = new config();
        config2 configClass = new config2();
        //Voegt een account toe aan de database
        public void addAccount(string username, string password)
        {
            //Checkt of er iets ingevuld is in de textboxes
            if (username == "" || password == "")
            {
                MessageBox.Show("Voer een gebruikersnaam en wachtwoord in.");
            } 
            else
            {
                try
                {
                    configClass.databaseConnection.Open();
                    string query1 = "SELECT username FROM data WHERE username = '" + username + "';";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query1, configClass.databaseConnection);
                    adapter.Fill(configClass.table);
                    //Checkt of de gebruiker bestaat in de database
                    if (configClass.table.Rows.Count <= 0)
                    {
                        string query2 = "INSERT INTO `data` (username, password) VALUES (@username, @password);";
                        MySqlCommand cmdAdd = new MySqlCommand(query2, configClass.databaseConnection);
                        cmdAdd.Parameters.AddWithValue("@username", username);
                        cmdAdd.Parameters.AddWithValue("@password", password);
                        cmdAdd.Prepare();
                        cmdAdd.ExecuteReader();
                        MessageBox.Show("uw account is toegevoegd!");
                    }
                    //Geeft een melding als de gebruiker al bestaat
                    else
                    {
                        MessageBox.Show("De gebruiker '" + username + "' bestaat al.");
                    }
                    configClass.table.Clear();
                    configClass.databaseConnection.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error: " + e);
                }
            }
        }

        //Checkt of de ingevulde gegevens overeenkomen met die in de database zodat je kan inloggen
        public void loginAccount(string loginUsername, string loginPassword, Form adminPanel)
        {
            //Checkt of er iets ingevuld is in de textboxes
            if (loginUsername == "" || loginPassword == "")
            {
                MessageBox.Show("Voer een gebruikersnaam en wachtwoord in om in te loggen.");
            }
            else
            {
                try
                {
                    configClass.databaseConnection.Open();
                    string query = "SELECT * FROM data WHERE username = @loginUsername AND password = @loginPassword;";
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
                    }
                    else
                    {
                        MySqlDataReader read = cmdSelect.ExecuteReader();
                        if (read.HasRows)
                        {
                            while (read.Read())
                            {
                                string admin = read[0].ToString();
                                if (admin == "admin")
                                {
                                    MessageBox.Show("U bent ingelogd als een super admin!");
                                    adminPanel.Show();
                                    Form login = Application.OpenForms["login"];
                                    login.Hide();
                                }
                                else
                                {
                                    MessageBox.Show("U bent ingelogd als gebruiker!");
                                }
                            }
                        }
                    }
                    configClass.table.Clear();
                    configClass.databaseConnection.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error: " + e);
                }
            }
        }
    }
}
