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
            public string Name { get; set; }
            public int Value { get; set; }
        }

        public void refreshDiscountOffersList()
        {
            discountListBox.DataSource = null;
            deleteDiscountListBox.DataSource = null;
            DataTable getDiscountOffers = DataLayer.Query("SELECT offer_id, category FROM discount_offers WHERE supermarket = @Supermarket",
            p =>
            {
                p.Add("@Supermarket", MySqlDbType.Int32, 255).Value = GlobalMethods.LoginInfo.Supermarket;
            });
            ArrayList DiscountOfferList = new ArrayList();
            foreach (DataRow DiscountOffer in getDiscountOffers.Select())
            {
                DiscountOfferList.Add(new ListItem { Name = (string)DiscountOffer["category"], Value = (int)DiscountOffer["offer_id"] });
            }
            discountListBox.ValueMember = "Value";
            discountListBox.DisplayMember = "Name";
            discountListBox.DataSource = DiscountOfferList;
            deleteDiscountListBox.ValueMember = "Value";
            deleteDiscountListBox.DisplayMember = "Name";
            deleteDiscountListBox.DataSource = DiscountOfferList;
        }

        public void refreshProductsList()
        {
            deleteProductsListBox.DataSource = null;
            DataTable getProducts = DataLayer.Query("SELECT discount_products.product_id, discount_products.name, discount_offers.supermarket FROM discount_products " +
                "INNER JOIN discount_offers ON discount_products.discount_offer = discount_offers.offer_id WHERE supermarket = @Supermarket",
                p =>
                {
                    p.Add("@Supermarket", MySqlDbType.Int32, 255).Value = GlobalMethods.LoginInfo.Supermarket;
                });
            ArrayList ProductList = new ArrayList();
            foreach (DataRow Product in getProducts.Select())
            {
                ProductList.Add(new ListItem { Name = (string)Product["name"], Value = (int)Product["product_id"] });
            }
            deleteProductsListBox.ValueMember = "Value";
            deleteProductsListBox.DisplayMember = "Name";
            deleteProductsListBox.DataSource = ProductList;
        }

        public admin()
        {
            InitializeComponent();
            setSupermarketLabel();
            refreshDiscountOffersList();
            refreshProductsList();
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
            // Adds new product to discount offer and resets saved image file.
            DataLayer.Query("INSERT INTO `discount_products` (discount_offer, name, icon, total_price) VALUES (@DiscountOfferID, @Name, @Icon, @TotalPrice);",
            p =>
            {
                p.Add("@DiscountOfferID", MySqlDbType.Int16, 255).Value = discountListBox.SelectedValue;
                p.Add("@Name", MySqlDbType.VarChar, 255).Value = productNameTextBox.Text;
                p.Add("@Icon", MySqlDbType.LongBlob, 255).Value = GlobalMethods.ImageInfo.ImageFile;
                p.Add("@TotalPrice", MySqlDbType.VarChar, 255).Value = productPriceTextBox.Text;
            });
            GlobalMethods.ImageInfo.ImageFile = null;
            refreshProductsList();
            MessageBox.Show("Nieuwe product toegevoegd.");
        }

        private void productIconBtn_Click(object sender, EventArgs e)
        {
            GlobalMethods.openFile();
        }

        private void discountIconBtn_Click(object sender, EventArgs e)
        {
            GlobalMethods.openFile();
        }

        private void addItemsPanelBtn_Click(object sender, EventArgs e)
        {
            deletePanel.Visible = false;
        }

        private void deleteItemsPanelBtn_Click(object sender, EventArgs e)
        {
            deletePanel.Visible = true;
        }

        private void deleteDiscountOfferBtn_Click(object sender, EventArgs e)
        {
            // Deletes selected discount offer in discounts list and refreshes list.
            DataLayer.Query("DELETE FROM `discount_offers` WHERE offer_id = @OfferId;",
            p =>
            {
                p.Add("@OfferId", MySqlDbType.Int16, 255).Value = deleteDiscountListBox.SelectedValue;
            });
            refreshDiscountOffersList();
        }

        private void deleteProductBtn_Click(object sender, EventArgs e)
        {
            // Deletes selected product in products list and refreshes list.
            DataLayer.Query("DELETE FROM `discount_products` WHERE product_id = @ProductId;",
            p =>
            {
                p.Add("@ProductId", MySqlDbType.Int16, 255).Value = deleteProductsListBox.SelectedValue;
            });
            refreshProductsList();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            GlobalMethods.SwitchForm(this, new welcomescreen());
        }

        private void addOfferPanelBtn_Click(object sender, EventArgs e)
        {
            deletePanel.Visible = false;
            addProductPanel.Visible = false;
        }

        private void addProductPanelBtn_Click(object sender, EventArgs e)
        {
            deletePanel.Visible = false;
            addProductPanel.Visible = true;
        }

        private void deleteItemsPanelBtn_Click_1(object sender, EventArgs e)
        {
            deletePanel.Visible = true;
            addProductPanel.Visible = false;
        }
    }
}
