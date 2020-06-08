﻿using System;
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
            DataTable offers = DataLayer.Query("SELECT brand, category FROM discount_offers", p => { });
            DataRow[] offersRow = offers.Select();
            for (int i = 0; i < offersRow.Length; i++)
            {
                //components
                Panel itemContainer = new Panel();
                PictureBox itemImg = new PictureBox();
                Label itemName = new Label();
                Button itemBtn = new Button();
                //options
                itemContainer.BackColor = SystemColors.ControlDark;
                itemContainer.Height = 100;
                itemContainer.Width = 300;
                itemContainer.Top = YpositionOffers * 112;
                itemContainer.Left = 12;

                //itemImg.Image = Properties.Resources.albert_heijn;
                //itemImg.SizeMode = PictureBoxSizeMode.Zoom;
                //itemImg.Top = 10;
                //itemImg.Left = 10;
                //itemImg.Width = 80;
                //itemImg.Height = 80;

                itemName.Text = offersRow[i][0].ToString();
                itemName.Top = 10;
                itemName.Left = 110;

                itemBtn.Text = offersRow[i][1].ToString();
                itemBtn.BackColor = SystemColors.Control;
                itemBtn.Width = 80;
                itemBtn.Top = 10;
                itemBtn.Left = 210;

                //move next item down
                YpositionOffers++;
                //add panel
                this.Controls.Add(itemContainer);
                //add controls inside panel
                itemContainer.Controls.Add(itemImg);
                itemContainer.Controls.Add(itemName);
                itemContainer.Controls.Add(itemBtn);
            }

            DataTable products = DataLayer.Query("SELECT name, total_price FROM discount_products", p => { });
            DataRow[] productsRow = products.Select();
            for (int i = 0; i < productsRow.Length; i++)
            {
                //components
                Panel itemContainer = new Panel();
                PictureBox itemImg = new PictureBox();
                Label itemName = new Label();
                Button itemBtn = new Button();
                //options
                itemContainer.BackColor = SystemColors.ControlDark;
                itemContainer.Height = 100;
                itemContainer.Width = 300;
                itemContainer.Top = YpositionProducts * 112;
                itemContainer.Left = 320;

                //itemImg.Image = Properties.Resources.albert_heijn;
                //itemImg.SizeMode = PictureBoxSizeMode.Zoom;
                //itemImg.Top = 10;
                //itemImg.Left = 10;
                //itemImg.Width = 80;
                //itemImg.Height = 80;

                itemName.Text = productsRow[i][0].ToString();
                itemName.Top = 10;
                itemName.Left = 110;

                itemBtn.Text = productsRow[i][1].ToString();
                itemBtn.BackColor = SystemColors.Control;
                itemBtn.Width = 80;
                itemBtn.Top = 10;
                itemBtn.Left = 210;

                //move next item down
                YpositionProducts++;
                //add panel
                this.Controls.Add(itemContainer);
                //add controls inside panel
                itemContainer.Controls.Add(itemImg);
                itemContainer.Controls.Add(itemName);
                itemContainer.Controls.Add(itemBtn);
            }
        }
    }
}
