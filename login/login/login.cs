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
        connection con = new connection();
        public login()
        {
            InitializeComponent();
        }

        private void navRegister_Click(object sender, EventArgs e)
        {
            var registerForm = new register();
            Hide();
            registerForm.Show();
        }

        private void loginAcc_Click(object sender, EventArgs e)
        {
            con.loginAccount(txbLoginUsrname.Text, txbLoginPassword.Text);
        }
    }
}
