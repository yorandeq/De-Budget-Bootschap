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
    public partial class stores : Form
    {
        // Load neccessities.
        GlobalMethods GlobalMethods = new GlobalMethods();

        int Yposition = 1;
        DataLayer DataLayer = new DataLayer();

        public stores()
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

        //save what store is clicked and go to the product page
        private void saveStore(object storeId)
        {
            GlobalMethods.StoresInfo.StoreID = int.Parse(storeId.ToString());
            GlobalMethods.SwitchForm(this, new products());
        }

        private void stores_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable GetStores = DataLayer.Query("SELECT * FROM `supermarkets`", p =>{});
                foreach (DataRow row in GetStores.Rows)
                {
                    //components
                    Panel itemContainer = new Panel();
                    PictureBox itemImg = new PictureBox();
                    Label itemName = new Label();
                    Label itemDesc = new Label();
                    Button offerBtn = new Button();
                    Button siteBtn = new Button();
                    //options
                    itemContainer.BackColor = ColorTranslator.FromHtml("#ff9e66");
                    itemContainer.Height = 100;
                    itemContainer.Width = 500;
                    itemContainer.Top = Yposition * 112;
                    itemContainer.Left = 207;

                    itemImg.Image = Image.FromStream(GlobalMethods.convertImg(row["icon"]));
                    itemImg.SizeMode = PictureBoxSizeMode.Zoom;
                    itemImg.Top = 10;
                    itemImg.Left = 10;
                    itemImg.Width = 80;
                    itemImg.Height = 80;

                    itemName.Text = row["name"].ToString();
                    itemName.Top = 10;
                    itemName.Left = 110;
                    itemName.Font = new Font(itemName.Font.Name, 12);

                    itemDesc.Text = row["description"].ToString();
                    itemDesc.AutoSize = false;
                    itemDesc.Top = 32;
                    itemDesc.Left = 113;
                    itemDesc.Width = 277;
                    itemDesc.Height = 58;

                    offerBtn.Text = "Naar offers";
                    offerBtn.BackColor = ColorTranslator.FromHtml("#0080ff");
                    offerBtn.ForeColor = SystemColors.Window;
                    offerBtn.Top = 10;
                    offerBtn.Left = 410;
                    offerBtn.Width = 80;
                    offerBtn.Height = 40;
                    offerBtn.FlatStyle = FlatStyle.Flat;
                    offerBtn.Click += (obj, ev) => { saveStore(row["supermarket_id"]); };

                    siteBtn.Text = "Naar site";
                    siteBtn.BackColor = ColorTranslator.FromHtml("#0080ff");
                    siteBtn.ForeColor = SystemColors.Window;
                    siteBtn.Top = 50;
                    siteBtn.Left = 410;
                    siteBtn.Width = 80;
                    siteBtn.Height = 40;
                    siteBtn.FlatStyle = FlatStyle.Flat;
                    siteBtn.Click += (obj, ev) => { GlobalMethods.openSite(row["link"]); };

                    //move next item down
                    Yposition++;
                    //add panel
                    this.Controls.Add(itemContainer);
                    //add controls inside panel
                    itemContainer.Controls.Add(itemImg);
                    itemContainer.Controls.Add(itemName);
                    itemContainer.Controls.Add(itemDesc);
                    itemContainer.Controls.Add(offerBtn);
                    itemContainer.Controls.Add(siteBtn);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }

        private void ToProducts_Click(object sender, EventArgs e)
        {
            GlobalMethods.SwitchForm(this, new products());
        }

        private void navNotifications_Click(object sender, EventArgs e)
        {
            GlobalMethods.SwitchForm(this, new notifications());
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void navOverview_Click(object sender, EventArgs e)
        {
            GlobalMethods.SwitchForm(this, new welcomescreen());
        }

        private void navSuperadmin_Click(object sender, EventArgs e)
        {
            GlobalMethods.SwitchForm(this, new superAdmin());
        }

        private void navAdmin_Click(object sender, EventArgs e)
        {
            GlobalMethods.SwitchForm(this, new admin());
        }
    }
}
