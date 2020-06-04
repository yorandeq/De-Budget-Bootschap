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
    public partial class register : Form
    {
        connection con = new connection();
        public register()
        {
            InitializeComponent();
        }

        private void registerAcc_Click(object sender, EventArgs e)
        {
            bool createdAcc = con.addAccount(txbUsrname.Text, txbPassword.Text);
            if (createdAcc)
            {
                var loginForm = new login();
                Close();
                loginForm.Show();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void navLogin_Click(object sender, EventArgs e)
        {
            var loginForm = new login();
            Close();
            loginForm.Show();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
