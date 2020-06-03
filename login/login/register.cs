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
    public partial class register : Form
    {
        connection con = new connection();
        public register()
        {
            InitializeComponent();
        }

        private void registerAcc_Click(object sender, EventArgs e)
        {
            con.addAccount(txbUsrname.Text, txbPassword.Text);
        }

        private void navLogin_Click_1(object sender, EventArgs e)
        {
            var loginForm = (login)Tag;
            loginForm.Show();
            this.Close();
        }
    }
}
