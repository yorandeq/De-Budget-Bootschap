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
        // Load neccessities.
        GlobalMethods GlobalMethods = new GlobalMethods();
        connection connection = new connection();

        public register()
        {
            InitializeComponent();
        }

        private void registerAcc_Click(object sender, EventArgs e)
        {
            bool superAdminCheck = false;
            bool createdAcc = connection.addAccount(txbUsrname.Text, txbPassword.Text, superAdminCheck);
            if (createdAcc)
            {
                GlobalMethods.SwitchForm(new login());
            }
        }

        private void navLogin_Click(object sender, EventArgs e)
        {
            GlobalMethods.SwitchForm(new login());
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
