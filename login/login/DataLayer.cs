﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;

namespace login
{
    public class DataLayer
    {
        // Creates databaseConnection.
        public static string MySQLConnectionString = "datasource=localhost;port=3306;username=root;password=;database=boodschapwijzer;CharSet=utf8"; 
        public MySqlConnection databaseConnection = new MySqlConnection(MySQLConnectionString);

        // Public method used to query to database connection.
        public DataTable Query(string sql, Action<MySqlParameterCollection> addParameters)
        {
            // Creates result variable and opens a new command using the SQL string and database connection.
            var result = new DataTable();
            using (var command = new MySqlCommand(sql, databaseConnection))
            {
                // Add parameters to command and open database connection.
                addParameters(command.Parameters);
                try
                {
                    databaseConnection.Open();
                } catch (Exception x)
                {
                    MessageBox.Show(x.Message);
                }
                // Loads database result using command's ExecuteReader, and loads it into the result variable, then closes the connection.
                try 
                { 
                    result.Load(command.ExecuteReader(CommandBehavior.CloseConnection));
                } catch (Exception x)
                {
                    MessageBox.Show(x.Message);
                }
            }
            return result;
        }
    }
}
