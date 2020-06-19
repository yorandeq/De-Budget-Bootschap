using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace login
{
    public partial class superAdmin : Form
    {
        // Load neccessities.
        GlobalMethods GlobalMethods = new GlobalMethods();
        connection connection = new connection();

        public superAdmin()
        {
            InitializeComponent();
            dgvMarketList.DataSource = connection.getAllSupermarkets();
            dgvUsers.DataSource = connection.getAllUsers();
            button2.BackColor = Color.FromArgb(0, 115, 229);
            button2.Enabled = false;
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            GlobalMethods.SwitchForm(this, new welcomescreen());
        }


        private void button2_Click(object sender, EventArgs e)
        {
            panelAddAdmin.Visible = true;
            panelAddSupermarket.Visible = false;
            panelMarketList.Visible = false;
            panelUserList.Visible = false;
            button2.Enabled = false;
            button2.BackColor = Color.FromArgb(0, 115, 229);
            button1.Enabled = true;
            button1.BackColor = Color.FromArgb(0, 128, 255);
            button4.Enabled = true;
            button4.BackColor = Color.FromArgb(0, 128, 255);
            button5.Enabled = true;
            button5.BackColor = Color.FromArgb(0, 128, 255);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panelAddSupermarket.Visible = true;
            panelAddAdmin.Visible = false;
            panelUserList.Visible = false;
            panelMarketList.Visible = false;
            button1.Enabled = false;
            button1.BackColor = Color.FromArgb(0, 115, 229);
            button2.Enabled = true;
            button2.BackColor = Color.FromArgb(0, 128, 255);
            button4.Enabled = true;
            button4.BackColor = Color.FromArgb(0, 128, 255);
            button5.Enabled = true;
            button5.BackColor = Color.FromArgb(0, 128, 255);
        }

        private void addAdmin_Click(object sender, EventArgs e)
        {
            bool superAdminCheck = true;
            connection.addAccount(txbAddUsrname.Text, txbAddPassword.Text, superAdminCheck, txbMarketName.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
           GlobalMethods.openFile();
        }

        private void addSupermarket_Click(object sender, EventArgs e)
        {
            bool createSupermarket = connection.addSupermarket(txbSupermarketName.Text, txbDescription.Text, txbLink.Text, GlobalMethods.ImageInfo.ImageFile);
            GlobalMethods.ImageInfo.ImageFile = null;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panelMarketList.Visible = true;
            panelAddAdmin.Visible = false;
            panelAddSupermarket.Visible = false;
            panelUserList.Visible = false;
            dgvMarketList.DataSource = connection.getAllSupermarkets();
            button1.Enabled = true;
            button1.BackColor = Color.FromArgb(0, 128, 255);
            button2.Enabled = true;
            button2.BackColor = Color.FromArgb(0, 128, 255);
            button4.Enabled = false;
            button4.BackColor = Color.FromArgb(0, 115, 229);
            button5.Enabled = true;
            button5.BackColor = Color.FromArgb(0, 128, 255);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panelAddSupermarket.Visible = false;
            panelAddAdmin.Visible = false;
            panelMarketList.Visible = false;
            panelUserList.Visible = true;
            dgvUsers.DataSource = connection.getAllUsers();
            button1.Enabled = true;
            button1.BackColor = Color.FromArgb(0, 128, 255);
            button2.Enabled = true;
            button2.BackColor = Color.FromArgb(0, 128, 255);
            button4.Enabled = true;
            button4.BackColor = Color.FromArgb(0, 128, 255);
            button5.Enabled = false;
            button5.BackColor = Color.FromArgb(0, 115, 229);
        }
    }
}
