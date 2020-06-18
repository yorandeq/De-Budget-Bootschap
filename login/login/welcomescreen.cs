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
using Tulpep.NotificationWindow;

namespace login
{
    public partial class welcomescreen : Form
    {
        // Load Neccessities.
        DataLayer DataLayer = new DataLayer();
        GlobalMethods GlobalMethods = new GlobalMethods();
        List<Panel> NotificationPanels = new List<Panel>();

      

        // Method for setting notifications that are checked to the read state in the database.
        public void setReadNotifications()
        {
            foreach (Panel itemContainer in NotificationPanels)
            {
                // Checks the container controls for the notification id and checkbox value.
                CheckBox itemCheckbox = itemContainer.Controls.Find("NotificationCheckbox", true)[0] as CheckBox;
                Label itemId = itemContainer.Controls.Find("ItemId", true)[0] as Label;

                // If the checkbox was checked, sets the state to 2 and removes the container.
                if (itemCheckbox.Checked == true)
                {
                    DataTable setUserNotifications = DataLayer.Query("UPDATE notifications SET state = 2 WHERE notification_id = @NotificationId",
                    p =>
                    {
                        p.Add("@NotificationId", MySqlDbType.Int32, 255).Value = itemId.Text;
                    });
                    itemContainer.Dispose();
                }
            }
        }

        public welcomescreen()
        {
            InitializeComponent();
        }

     

        private void markReadBtn_Click(object sender, EventArgs e)
        {
            setReadNotifications();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void navStores_Click(object sender, EventArgs e)
        {
            GlobalMethods.SwitchForm(this, new stores());
        }

        private void navSuperadmin_Click(object sender, EventArgs e)
        {
            GlobalMethods.SwitchForm(this, new superAdmin());
        }

        private void navNotifications_Click(object sender, EventArgs e)
        {
            GlobalMethods.SwitchForm(this, new notifications());
        }

        private void markReadBtn_Click_1(object sender, EventArgs e)
        {
            GlobalMethods.SwitchForm(this, new stores());
        }

        private void refreshNotificationsBtn_Click_1(object sender, EventArgs e)
        {
            GlobalMethods.SwitchForm(this, new notifications());
        }

        private void welcomescreen_Load(object sender, EventArgs e)
        {
            getDiscountOffers();
            getUnreadUserNotifications();
        }

        public void getUnreadUserNotifications()
        {
            int Yposition = 1;

            DataTable getUserNotifications = DataLayer.Query("SELECT * FROM notifications WHERE user = @UserId AND state = 1",
            p => {
                
                p.Add("@UserId", MySqlDbType.Int16, 255).Value = GlobalMethods.LoginInfo.UserID;
                
                // if !hasrows, return 'je hebt geen nieuwe notificaties'
               
            });
            if (getUserNotifications.Rows.Count < 1)
            {
                Label notification = new Label();
                notification.Text = "Je hebt geen ongelezen notificaties!";
                notification.ForeColor = Color.WhiteSmoke;
                notification.Top = 80;
                notificationContainer.Controls.Add(notification);
            }

            

            // Show unread user notifications to user through form. (Currently using a listbox for testing purposes, this should be changed later to form elements to fit the design.)
            foreach (DataRow row in getUserNotifications.Select())
            {
                
                Label notification = new Label();

                // Options

                notification.Text = (string)row["message"];
                notification.ForeColor = Color.WhiteSmoke;
                notification.Top = 80;
                notification.Left = 1 + Yposition * 40;
                notification.Width = 750;

               
                // Move next item down
                Yposition++;

                // Add controls inside panel
                notificationContainer.Controls.Add(notification);
            }
        }

        public void getDiscountOffers()
        {
            int Yposition = 1;
            try
            {
                DataTable GetOffers = DataLayer.Query("SELECT `icon` FROM `discount_offers` LIMIT 4", p => { });
                foreach (DataRow row in GetOffers.Rows)
                {
                    PictureBox icon = new PictureBox();


                    icon.Image = Image.FromStream(GlobalMethods.convertImg(row["icon"]));
                    icon.SizeMode = PictureBoxSizeMode.Zoom;
                    icon.Top = 5;
                    icon.Left = 1 + Yposition * 100;
                    icon.Width = 80;
                    icon.Height = 80;

                    Yposition++;

                    imageContainer.Controls.Add(icon);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }

        private void navOverview_Click(object sender, EventArgs e)
        {
            GlobalMethods.SwitchForm(this, new welcomescreen());
        }
    }
}
