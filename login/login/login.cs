using System;
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
    public partial class login : Form
    {
        // Load neccessities.
        GlobalMethods GlobalMethods = new GlobalMethods();
        connection connection = new connection();

        public login()
        {
            InitializeComponent();
        }

        private void navRegister_Click(object sender, EventArgs e)
        {
            GlobalMethods.SwitchForm(new register());
        }

        private void loginAcc_Click(object sender, EventArgs e)
        {
            connection.loginAccount(txbLoginUsrname.Text, txbLoginPassword.Text);
        }
    }
}
