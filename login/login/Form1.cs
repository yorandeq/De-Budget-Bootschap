﻿using System;
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
        connection con = new connection();
        public Form1()
        {
            InitializeComponent();
            con.checkConn();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.addAccount(txbUsrname.Text, txbPassword.Text);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void navLogin_Click(object sender, EventArgs e)
        {
            var loginForm = new Form2();
            Hide();
            loginForm.Show();
        }
    }
}
