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

        private void loginAcc_Click(object sender, EventArgs e)
        {
            var adminForm = new superAdmin();
            adminForm.Tag = this;
            con.loginAccount(txbLoginUsrname.Text, txbLoginPassword.Text, adminForm);
        }

        private void logout_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void navRegister_Click_1(object sender, EventArgs e)
        {
            var registerForm = new register();
            registerForm.Tag = this;
            registerForm.Show(this);
            this.Hide();
        }
    }
}
