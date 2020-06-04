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
    public partial class superAdmin : Form
    {
        public superAdmin()
        {
            InitializeComponent();
            customizeDesign();
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            var loginForm = (login)Tag;
            loginForm.Show();
            this.Close();
        }

        private void customizeDesign()
        {
            panelSubmenu.Visible = false;
        }

        private void hideSubmenu()
        {
            if(panelSubmenu.Visible == true)
            {
                panelSubmenu.Visible = false;
            }
        }

        private void showSubmenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubmenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        private void navSupermarket_Click(object sender, EventArgs e)
        {
            showSubmenu(panelSubmenu);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            hideSubmenu();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hideSubmenu();
        }
    }
}
