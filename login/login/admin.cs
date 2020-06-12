using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Collections;

namespace login
{
    public partial class admin : Form
    {
        // Load Neccessities.
        DataLayer DataLayer = new DataLayer();
        GlobalMethods GlobalMethods = new GlobalMethods();

        public void checkAdmin()
        {
            if (GlobalMethods.LoginInfo.Admin == 1)
            {
                navSuperadmin.Visible = false;
                navAdmin.Visible = true;
            }
            else if (GlobalMethods.LoginInfo.Admin == 2)
            {
                navSuperadmin.Visible = true;
                navAdmin.Visible = false;
            }
            else
            {
                navSuperadmin.Visible = false;
                navAdmin.Visible = false;
            }
        }

        public void setSupermarketLabel()
        {
            DataTable getSupermarket = DataLayer.Query("SELECT * FROM supermarkets WHERE supermarket_id = @SupermarketId",
            p =>
            {
                p.Add("@SupermarketId", MySqlDbType.Int32, 255).Value = GlobalMethods.LoginInfo.Supermarket;
            });
            foreach (DataRow Supermarket in getSupermarket.Select())
            {
                supermarketLabel.Text = "Supermarkt: " + (string)Supermarket["name"];
            }
        }

        class ListItem
        {
            public string DisplayMember;
            public int ValueMember;

            public ListItem(string n, int v)
            {
                DisplayMember = n;
                ValueMember = v;
            }

            public override string ToString()
            {
                return DisplayMember;
            }
        }

        public void refreshDiscountOffersList()
        {
            discountList.Items.Clear();
            DataTable getDiscountOffers = DataLayer.Query("SELECT offer_id, category FROM discount_offers WHERE supermarket = @Supermarket",
            p =>
            {
                p.Add("@Supermarket", MySqlDbType.Int32, 255).Value = GlobalMethods.LoginInfo.Supermarket;
            });
            ArrayList DiscountOfferList = new ArrayList();
            foreach (DataRow DiscountOffer in getDiscountOffers.Select())
            {
                DiscountOfferList.Add(new ListItem((string)DiscountOffer["category"], (int)DiscountOffer["offer_id"]));
            }
            discountList.DataSource = DiscountOfferList;
            discountList.DisplayMember = "DisplayMember";
            discountList.ValueMember = "ValueMember";
        }

        public admin()
        {
            InitializeComponent();
            checkAdmin();
            setSupermarketLabel();
            refreshDiscountOffersList();
        }

        private void navNotifications_Click(object sender, EventArgs e)
        {
            GlobalMethods.SwitchForm(this, new notifications());
        }

        private void navStores_Click(object sender, EventArgs e)
        {
            GlobalMethods.SwitchForm(this, new stores());
        }

        private void addDiscountBtn_Click(object sender, EventArgs e)
        {
            // Adds new discount offer to supermarket.
            DataLayer.Query("INSERT INTO `discount_offers` (supermarket, brand, category, icon, expiration_date, min_amount) VALUES (@SupermarketID, @Brand, @Category, @Icon, @ExpirationDate, @MinAmount);",
            p =>
            {
                p.Add("@SupermarketID", MySqlDbType.Int16, 255).Value = GlobalMethods.LoginInfo.Supermarket;
                p.Add("@Brand", MySqlDbType.VarChar, 255).Value = brandTextBox.Text;
                p.Add("@Category", MySqlDbType.VarChar, 255).Value = categoryTextBox.Text;
                p.Add("@Icon", MySqlDbType.LongBlob, 255).Value = GlobalMethods.ImageInfo.ImageFile;
                p.Add("@ExpirationDate", MySqlDbType.Date, 255).Value = expireDateTime.Value;
                p.Add("@MinAmount", MySqlDbType.Int16, 255).Value = minimumTextBox.Text;
            });
            // Resets saved image file and refreshes discount offers list.
            GlobalMethods.ImageInfo.ImageFile = null;
            refreshDiscountOffersList();
            MessageBox.Show("Nieuwe aanbieding toegevoegd.");
        }

        private void addProductBtn_Click(object sender, EventArgs e)
        {
            Console.WriteLine(discountList.SelectedValue);

            // Adds new product to discount offer and resets saved image file.
           // DataLayer.Query("INSERT INTO `discount_products` (discount_offer, name, icon, total_price) VALUES (@DiscountOfferID, @Name, @Icon, @TotalPrice);",
            //p =>
            //{
            //    p.Add("@DiscountOfferID", MySqlDbType.Int16, 255).Value = null;
            //    p.Add("@Name", MySqlDbType.VarChar, 255).Value = productNameTextBox.Text;
            //    p.Add("@Icon", MySqlDbType.LongBlob, 255).Value = GlobalMethods.ImageInfo.ImageFile;
            //    p.Add("@TotalPrice", MySqlDbType.VarChar, 255).Value = productPriceTextBox.Text;
            //});
            //GlobalMethods.ImageInfo.ImageFile = null;
            MessageBox.Show("Nieuwe product toegevoegd.");
        }

        private void discountList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int ix = 0; ix < discountList.Items.Count; ++ix)
                if (ix != e.Index) discountList.SetItemChecked(ix, false);
        }

        private void productIconBtn_Click(object sender, EventArgs e)
        {
            GlobalMethods.openFile();
        }

        private void discountIconBtn_Click(object sender, EventArgs e)
        {
            GlobalMethods.openFile();
        }
    }
}
