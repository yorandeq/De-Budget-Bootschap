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
using Tulpep.NotificationWindow;

namespace login
{
    public partial class notifications : Form
    {
        // Load Neccessities.
        DataLayer DataLayer = new DataLayer();
        GlobalMethods GlobalMethods = new GlobalMethods();
        List<Panel> NotificationPanels = new List<Panel>();

        // Method for getting and showing unread user notifications.
        public void getUnreadUserNotifications()
        {
            int Yposition = 1;

            DataTable getUserNotifications = DataLayer.Query("SELECT * FROM notifications WHERE user = @UserId AND state = 1",
            p => {
                p.Add("@UserId", MySqlDbType.Int16, 255).Value = GlobalMethods.LoginInfo.UserID;
            });

            // Remove and reset previous notifications.
            foreach (Panel itemContainer in NotificationPanels)
            {
                itemContainer.Dispose();
            }
            NotificationPanels.Clear();

            // Show unread user notifications to user through form. (Currently using a listbox for testing purposes, this should be changed later to form elements to fit the design.)
            foreach (DataRow Notification in getUserNotifications.Select())
            {
                // Components
                Panel itemContainer = new Panel();
                Label itemName = new Label();
                CheckBox itemCheckbox = new CheckBox();
                Label itemId = new Label();

                // Options
                itemContainer.BackColor = SystemColors.ControlDark;
                itemContainer.Height = 30;
                itemContainer.Width = 750;
                itemContainer.Top = 62 + Yposition * 40;
                itemContainer.Left = 12;

                itemName.Text = (string)Notification["message"];
                itemName.Top = 10;
                itemName.Left = 25;
                itemName.Width = 750;

                itemId.Name = "ItemId";
                itemId.Text = Notification["notification_id"].ToString();
                itemId.Width = 0;
                itemId.Height = 0;

                itemCheckbox.Name = "NotificationCheckbox";
                itemCheckbox.Left = 10;
                itemCheckbox.Top = 5;

                // Move next item down
                Yposition++;

                // Add panel
                this.Controls.Add(itemContainer);
                NotificationPanels.Add(itemContainer);

                // Add controls inside panel
                itemContainer.Controls.Add(itemName);
                itemContainer.Controls.Add(itemId);
                itemContainer.Controls.Add(itemCheckbox);
            }
        }

        // Method for setting notifications that are checked to the read state.
        public void setReadNotifications()
        {
            foreach (Panel itemContainer in NotificationPanels)
            {
                // Checks the container controls for the notification id and checkbox value.
                CheckBox itemCheckbox = itemContainer.Controls.Find("NotificationCheckbox", true)[0] as CheckBox;
                Label itemId = itemContainer.Controls.Find("ItemId", true)[0] as Label;

                // If the checkbox was checked, sets the state to 2 and removes the container.
                if(itemCheckbox.Checked == true)
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

        public notifications()
        {
            InitializeComponent();
            getUnreadUserNotifications();
        }

        private void refreshNotificationsBtn_Click(object sender, EventArgs e)
        {
            getUnreadUserNotifications();
        }

        private void markReadBtn_Click(object sender, EventArgs e)
        {
            setReadNotifications();
        }
    }
}
