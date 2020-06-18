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
    public partial class products : Form
    {
        // Load neccessities.
        GlobalMethods GlobalMethods = new GlobalMethods();
        connection connection = new connection();
        DataLayer DataLayer = new DataLayer();

        int YpositionProducts = 1;
        int YpositionOffers = 1;

        public products()
        {
            InitializeComponent();
        }

        private void products_Load(object sender, EventArgs e)
        {
            DataTable offers = DataLayer.Query("SELECT o.brand, o.category, o.icon FROM discount_offers o WHERE supermarket = " + GlobalMethods.StoresInfo.StoreID,
                p => { });
            DataRow[] offersRow = offers.Select();
            for (int i = 0; i < offersRow.Length; i++)
            {
                //components
                Panel itemContainer = new Panel();
                PictureBox itemImg = new PictureBox();
                Label itemName = new Label();
                Label itemCategory = new Label();
                Button itemBtn = new Button();
                //options
                itemContainer.BackColor = ColorTranslator.FromHtml("#ff9e66");
                itemContainer.Height = 100;
                itemContainer.Width = 250;
                itemContainer.Top = YpositionOffers * 112;
                itemContainer.Left = 207;

                itemImg.Image = Image.FromStream(GlobalMethods.convertImg(offersRow[i][2]));
                itemImg.SizeMode = PictureBoxSizeMode.Zoom;
                itemImg.Top = 10;
                itemImg.Left = 10;
                itemImg.Width = 80;
                itemImg.Height = 80;

                itemName.Text = offersRow[i][0].ToString();
                itemName.Top = 50;
                itemName.Left = 110;

                itemCategory.Text = offersRow[i][1].ToString();
                itemCategory.Top = 10;
                itemCategory.Left = 110;

                itemBtn.Text = "Kopen";
                itemBtn.BackColor = ColorTranslator.FromHtml("#0080ff");
                itemBtn.ForeColor = SystemColors.Window;
                itemBtn.Width = 80;
                itemBtn.Top = 75;
                itemBtn.Left = 160;
                itemBtn.FlatStyle = FlatStyle.Flat;

                //move next item down
                YpositionOffers++;
                //add panel
                this.Controls.Add(itemContainer);
                //add controls inside panel
                itemContainer.Controls.Add(itemImg);
                itemContainer.Controls.Add(itemName);
                itemContainer.Controls.Add(itemCategory);
                itemContainer.Controls.Add(itemBtn);
            }

            DataTable products = DataLayer.Query("SELECT p.name, p.total_price, p.icon FROM discount_products p " +
                "INNER JOIN discount_offers o ON p.discount_offer = o.offer_id WHERE o.supermarket = " + GlobalMethods.StoresInfo.StoreID,
                p => { });
            DataRow[] productsRow = products.Select();
            for (int i = 0; i < productsRow.Length; i++)
            {
                //components
                Panel itemContainer = new Panel();
                PictureBox itemImg = new PictureBox();
                Label itemName = new Label();
                Label itemPrice = new Label();
                Button itemBtn = new Button();
                //options
                itemContainer.BackColor = ColorTranslator.FromHtml("#ff9e66");
                itemContainer.Height = 100;
                itemContainer.Width = 250;
                itemContainer.Top = YpositionProducts * 112;
                itemContainer.Left = 520;

                itemImg.Image = Image.FromStream(GlobalMethods.convertImg(productsRow[i][2]));
                itemImg.SizeMode = PictureBoxSizeMode.Zoom;
                itemImg.Top = 10;
                itemImg.Left = 20;
                itemImg.Width = 80;
                itemImg.Height = 80;

                itemName.Text = productsRow[i][0].ToString();
                itemName.Top = 10;
                itemName.Left = 110;

                itemPrice.Text = "Prijs: €" + productsRow[i][1].ToString();
                itemPrice.Top = 50;
                itemPrice.Left = 110;

                itemBtn.Text = "Kopen";
                itemBtn.BackColor = ColorTranslator.FromHtml("#0080ff");
                itemBtn.ForeColor = SystemColors.Window;
                itemBtn.Width = 80;
                itemBtn.Top = 75;
                itemBtn.Left = 160;
                itemBtn.FlatStyle = FlatStyle.Flat;

                //move next item down
                YpositionProducts++;
                //add panel
                this.Controls.Add(itemContainer);
                //add controls inside panel
                itemContainer.Controls.Add(itemImg);
                itemContainer.Controls.Add(itemName);
                itemContainer.Controls.Add(itemPrice);
                itemContainer.Controls.Add(itemBtn);
            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void navStores_Click(object sender, EventArgs e)
        {
            GlobalMethods.SwitchForm(this, new stores());
        }

        private void navNotifications_Click(object sender, EventArgs e)
        {
            GlobalMethods.SwitchForm(this, new notifications());
        }

        private void navOverview_Click(object sender, EventArgs e)
        {
            GlobalMethods.SwitchForm(this, new welcomescreen());
        }
    }
}
