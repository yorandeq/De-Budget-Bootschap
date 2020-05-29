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
    public class config2
    {
        public static string MySQLConnectionString = "datasource=localhost;port=3306;username=root;password=4037;database=logintest;";
        public MySqlConnection databaseConnection = new MySqlConnection(MySQLConnectionString);
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
    }
}
