using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using MySql.Data.MySqlClient;

namespace login
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            createAccount();
        }

        private void createAccount()
        {
            string username = txbUsrname.Text;
            string password = txbPassword.Text;
            string MySQLConnectionString = "datasource=localhost;port=3306;username=root;password=;database=logintest;";
            string query = "INSERT INTO data(username, password)VALUES('" + username + "', '" + password + "');";
            MySqlConnection databaseConnection = new MySqlConnection(MySQLConnectionString);
            MySqlCommand cmdAdd = new MySqlCommand(query, databaseConnection);
            MySqlDataReader myReader;

            if (username == "" && password == "")
            {
                MessageBox.Show("Voer een gebruikersnaam en wachtwoord in.");
            }



            try
            {
                databaseConnection.Open();
                myReader = cmdAdd.ExecuteReader();
                MessageBox.Show("Uw account is toegevoegd.");
                while(myReader.Read())
                {

                }
            }
            catch(Exception e)
            {
                MessageBox.Show("Error: " + e.Message);
            }
        }
    }
}
