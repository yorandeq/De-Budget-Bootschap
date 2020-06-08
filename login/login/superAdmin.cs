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
        OpenFileDialog open = new OpenFileDialog();

        public superAdmin()
        {
            InitializeComponent();
            customizeDesign();
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            Close();
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
            panelAddAdmin.Visible = true;
            panelAddSupermarket.Visible = false;
            hideSubmenu();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panelAddSupermarket.Visible = true;
            panelAddAdmin.Visible = false;
            hideSubmenu();
        }

        private void addAdmin_Click(object sender, EventArgs e)
        {
            bool superAdminCheck = true;
            connection.addAccount(txbAddUsrname.Text, txbAddPassword.Text, superAdminCheck);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            open.Filter = "Files|*.jpg;*.jpeg;*.png";
            open.Title = "Please select an image file to encrypt.";
            if(open.ShowDialog() == DialogResult.OK) {
            }
        }

        private void addSupermarket_Click(object sender, EventArgs e)
        {
            Image superMarketImg = new Bitmap(open.FileName);
            byte[] blobData = GlobalMethods.ImageToByteArray(superMarketImg);
            bool createSupermarket = connection.addSupermarket(txbSupermarketName.Text, txbDescription.Text, txbLink.Text, blobData);
        }
    }
}
