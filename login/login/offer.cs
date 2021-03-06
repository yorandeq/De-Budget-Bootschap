﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace login
{
    public partial class offer : Form
    {
        // Load neccessities.
        GlobalMethods GlobalMethods = new GlobalMethods();
        connection connection = new connection();
        DataLayer DataLayer = new DataLayer();
        int Yproducts = 0;

        public offer()
        {
            InitializeComponent();
            navAdmin.Visible = false;
            navSuperadmin.Visible = false;
            if (GlobalMethods.LoginInfo.Admin == 1)
            {
                navAdmin.Visible = true;
            } 
            if (GlobalMethods.LoginInfo.Admin == 2)
            {
                navSuperadmin.Visible = true;
            }
        }

        private void offer_Load(object sender, EventArgs e)
        {
            DataTable GetOffer = DataLayer.Query("SELECT brand, category, icon, expiration_date, min_amount FROM `discount_offers` WHERE `offer_id` = @OfferId",
                p =>
                {
                    p.Add("@OfferId", MySqlDbType.Int32, 255).Value = GlobalMethods.StoresInfo.OfferID;
                });
            DataRow[] offerRow = GetOffer.Select();

            //components
            PictureBox offerImg = new PictureBox();
            Label offerName = new Label();
            Label offerBrand = new Label();
            Label offerExpiration = new Label();
            Label offerAmount = new Label();

            string date = offerRow[0][3].ToString();
            date = date.Remove(date.Length - 8);

            //options
            offerImg.Image = Image.FromStream(GlobalMethods.convertImg(offerRow[0][2]));
            offerImg.SizeMode = PictureBoxSizeMode.Zoom;
            offerImg.Top = 10;
            offerImg.Left = 10;
            offerImg.Width = 100;
            offerImg.Height = 100;

            offerName.Text = offerRow[0][1].ToString();
            offerName.Top = 10;
            offerName.Left = 110;
            offerName.Width = 353;
            offerName.Font = new Font(offerName.Font.Name, 12);

            offerBrand.Text = "Merk: " + offerRow[0][0].ToString();
            offerBrand.Top = 35;
            offerBrand.Left = 110;
            offerBrand.Width = 243;

            offerExpiration.Text = "Verloopdatum: " + date;
            offerExpiration.Top = 60;
            offerExpiration.Left = 110;
            offerExpiration.Width = 243;

            offerAmount.Text = "Minimaal aantal: " + offerRow[0][4].ToString();
            offerAmount.Top = 85;
            offerAmount.Left = 110;
            offerAmount.Width = 243;

            //add controls
            offerContainer.Controls.Add(offerImg);
            offerContainer.Controls.Add(offerName);
            offerContainer.Controls.Add(offerBrand);
            offerContainer.Controls.Add(offerExpiration);
            offerContainer.Controls.Add(offerAmount);

            DataTable GetProducts = DataLayer.Query("SELECT p.product_id, p.name, p.icon, p.total_price, COUNT(r.product_amount), o.min_amount, bought_by FROM `discount_products` p LEFT JOIN `discount_offers` o ON p.discount_offer = o.offer_id LEFT JOIN `registration` r ON p.product_id = r.product WHERE o.offer_id = @OfferId GROUP BY p.product_id, p.name",
                p =>
                {
                    p.Add("@OfferId", MySqlDbType.Int32, 255).Value = GlobalMethods.StoresInfo.OfferID;
                });
            foreach (DataRow productRow in GetProducts.Rows)
            {
                //SELECT p.product_id, p.name, p.icon, p.total_price, COUNT(r.product_amount), o.min_amount FROM `discount_products` p LEFT JOIN `discount_offers` o ON p.discount_offer = o.offer_id LEFT JOIN `registration` r ON p.product_id = r.product WHERE o.offer_id = 3 GROUP BY p.product_id, p.name

                //components
                Panel productPanel = new Panel();
                PictureBox productImg = new PictureBox();
                Label productName = new Label();
                Label productPrice = new Label();
                Label productProgress = new Label();
                Button productBtn = new Button();

                //options
                productPanel.BackColor = ColorTranslator.FromHtml("#ff9e66");
                productPanel.Height = 140;
                productPanel.Width = 265;
                productPanel.Top = Yproducts * 152;
                productPanel.Left = 10;

                productImg.Image = Image.FromStream(GlobalMethods.convertImg(productRow["icon"]));
                productImg.SizeMode = PictureBoxSizeMode.Zoom;
                productImg.Top = 10;
                productImg.Left = 10;
                productImg.Width = 80;
                productImg.Height = 80;

                productName.Text = productRow["name"].ToString();
                productName.Top = 10;
                productName.Left = 110;

                productPrice.Text = "Prijs: €" + productRow["total_price"].ToString() + " per stuk";
                productPrice.Top = 35;
                productPrice.Left = 110;

                productProgress.Text = $"Registraties: {productRow[4]}/{productRow["min_amount"]}";
                productProgress.Top = 110;
                productProgress.Left = 10;
                productProgress.Width = 165;

                DataTable getRegisteredEntry = DataLayer.Query("SELECT * FROM registration WHERE user = @UserId;",
                p =>
                {
                    p.Add("@UserId", MySqlDbType.Int32, 255).Value = GlobalMethods.LoginInfo.UserID;
                });

                bool hasRegister = false;
                foreach(DataRow RegisterEntry in getRegisteredEntry.Select())
                {
                    if(Convert.ToInt64(RegisterEntry["product"]) == Convert.ToInt64(productRow["product_id"]))
                    {
                        hasRegister = true;
                        if (int.Parse(productRow[4].ToString()) < int.Parse(productRow["min_amount"].ToString()))
                        {
                            productBtn.Text = "Inschrijven";
                            productBtn.BackColor = ColorTranslator.FromHtml("#0080ff");
                            productBtn.ForeColor = SystemColors.Window;
                            productBtn.Width = 80;
                            productBtn.Top = 107;
                            productBtn.Left = 175;
                            productBtn.FlatStyle = FlatStyle.Flat;
                            productBtn.Click += (obj, ev) => { connection.place_registration(productRow["name"], productRow["product_id"], productRow["total_price"]); GlobalMethods.refreshForm(this, new offer()); };
                        }
                        else if (productRow[6].ToString() != "" && (int)productRow[6] == GlobalMethods.LoginInfo.UserID)
                        {
                            productBtn.Text = "Gehaald";
                            productBtn.BackColor = ColorTranslator.FromHtml("#0080ff");
                            productBtn.ForeColor = SystemColors.Window;
                            productBtn.Width = 80;
                            productBtn.Top = 107;
                            productBtn.Left = 175;
                            productBtn.FlatStyle = FlatStyle.Flat;
                            productBtn.Click += (obj, ev) => { connection.del_registrations(Int16.Parse(productRow["product_id"].ToString())); GlobalMethods.refreshForm(this, new offer()); };
                        }
                        else if (productRow[6].ToString() == "")
                        {
                            productBtn.Text = "Ophalen";
                            productBtn.BackColor = ColorTranslator.FromHtml("#0080ff");
                            productBtn.ForeColor = SystemColors.Window;
                            productBtn.Width = 80;
                            productBtn.Top = 107;
                            productBtn.Left = 175;
                            productBtn.FlatStyle = FlatStyle.Flat;
                            productBtn.Click += (obj, ev) => { connection.get_products(Int16.Parse(productRow["product_id"].ToString()), GlobalMethods.LoginInfo.UserID, productRow["name"].ToString()); GlobalMethods.refreshForm(this, new offer()); };
                        }
                        else
                        {
                            productBtn.Visible = false;
                        }
                    }
                }

                if(hasRegister == false)
                {
                    if (int.Parse(productRow[4].ToString()) < int.Parse(productRow["min_amount"].ToString()))
                    {
                        productBtn.Text = "Inschrijven";
                        productBtn.BackColor = ColorTranslator.FromHtml("#0080ff");
                        productBtn.ForeColor = SystemColors.Window;
                        productBtn.Width = 80;
                        productBtn.Top = 107;
                        productBtn.Left = 175;
                        productBtn.FlatStyle = FlatStyle.Flat;
                        productBtn.Click += (obj, ev) => { connection.place_registration(productRow["name"], productRow["product_id"], productRow["total_price"]); GlobalMethods.refreshForm(this, new offer()); };
                    }
                    else if (productRow["bought_by"].ToString() != "")
                    {
                        productBtn.Visible = false;
                    }
                    else
                    {
                        productBtn.Visible = false;
                    }
                }

                //move next item down
                Yproducts++;

                //add panel
                productContainer.Controls.Add(productPanel);

                //add controls
                productPanel.Controls.Add(productImg);
                productPanel.Controls.Add(productName);
                productPanel.Controls.Add(productPrice);
                productPanel.Controls.Add(productProgress);
                productPanel.Controls.Add(productBtn);
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            GlobalMethods.SwitchForm(this, new products());
        }

        private void navAdmin_Click(object sender, EventArgs e)
        {
            GlobalMethods.SwitchForm(this, new admin());
        }

        private void navSuperadmin_Click(object sender, EventArgs e)
        {
            GlobalMethods.SwitchForm(this, new superAdmin());
        }

        private void navNotifications_Click(object sender, EventArgs e)
        {
            GlobalMethods.SwitchForm(this, new notifications());
        }

        private void navOverview_Click(object sender, EventArgs e)
        {
            GlobalMethods.SwitchForm(this, new welcomescreen());
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
