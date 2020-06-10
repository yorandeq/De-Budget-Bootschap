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
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            panelAddAdmin.Visible = true;
            panelAddSupermarket.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panelAddSupermarket.Visible = true;
            panelAddAdmin.Visible = false;
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
    }
}
