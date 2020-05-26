using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace login
{
    public class connection
    {
        public static string MySQLConnectionString = "datasource=localhost;port=3306;username=root;password=;database=logintest;";
        MySqlConnection databaseConnection = new MySqlConnection(MySQLConnectionString);

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

        public void addAccount(string username, string password)
        {
            if (username == "" && password == "")
            {
                MessageBox.Show("Voer een gebruikersnaam en wachtwoord in.");
            } 
            else
            {
                try
                {
                    string query = "INSERT INTO data(username, password)VALUES('" + username + "', '" + password + "');";
                    MySqlCommand cmdAdd = new MySqlCommand(query, databaseConnection);
                    cmdAdd.ExecuteReader();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error: " + e);
                }
                
            }
        }
    }
}
