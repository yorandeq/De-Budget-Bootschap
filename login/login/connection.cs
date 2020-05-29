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
        public static string MySQLConnectionString = "datasource=localhost;port=3306;username=root;password=;database=logintest;";
        MySqlConnection databaseConnection = new MySqlConnection(MySQLConnectionString);
        public DataTable table = new DataTable();

        //Maakt de connectie met de database
        public void checkConn()
        {
            try
            {
                databaseConnection = new MySqlConnection(MySQLConnectionString);
                databaseConnection.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message);
            }
        }

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
                    string query1 = "SELECT username FROM data WHERE username = '" + username + "';";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query1, databaseConnection);
                    adapter.Fill(table);
                    //Checkt of de gebruiker bestaat in de database
                    if (table.Rows.Count <= 0)
                    {
                        string query2 = "INSERT INTO `data` (username, password) VALUES (@username, @password);";
                        MySqlCommand cmdAdd = new MySqlCommand(query2, databaseConnection);
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
                    table.Clear();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error: " + e);
                }
            }
        }

        //Checkt of de ingevulde gegevens overeenkomen met die in de database zodat je kan inloggen
        public void loginAccount(string loginUsername, string loginPassword)
        {
            //Checkt of er iets ingevuld is in de textboxes
            if (loginUsername == "" || loginPassword == "")
            {
                MessageBox.Show("Voer een gebruikersnaam en wachtwoord in om inteloggen.");
            }
            else
            {
                try
                {
                    string query = "SELECT username, password FROM data WHERE username = @loginUsername AND password = @loginPassword;";
                    MySqlCommand cmdSelect = new MySqlCommand(query, databaseConnection);
                    MySqlDataAdapter adapter = new MySqlDataAdapter();
                    cmdSelect.Parameters.AddWithValue("@loginUsername", loginUsername);
                    cmdSelect.Parameters.AddWithValue("@loginPassword", loginPassword);
                    cmdSelect.Prepare();
                    adapter.SelectCommand = cmdSelect;
                    adapter.Fill(table);
                    if (table.Rows.Count <= 0)
                    {
                        MessageBox.Show("Uw account bestaat niet of uw gegevens waren onjuist.");
                    }
                    else
                    {
                        MessageBox.Show("U bent ingelogd!");
                    }
                    table.Clear();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error: " + e);
                }
            }
            
        }
    }
}
