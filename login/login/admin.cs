﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace login
{
    public partial class admin : Form
    {
        public admin()
        {
            InitializeComponent();
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            var loginForm = (login)Tag;
            loginForm.Show();
            this.Close();
        }
    }
}