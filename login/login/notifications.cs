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

        // Method for getting and showing unread user notifications.
        public void getUnreadUserNotifications()
        {
            DataTable getUserNotifications = DataLayer.Query("SELECT * FROM notifications WHERE user = @UserId AND state = 0",
            p => {
                p.Add("@UserId", MySqlDbType.Int16, 255).Value = GlobalMethods.LoginInfo.UserID;
            });

            // Show unread user notifications to user through form. (Currently using a listbox for testing purposes, this should be changed later to form elements to fit the design.)
            notificationsListBox.Items.Clear();
            foreach (DataRow Notification in getUserNotifications.Select())
            {
                notificationsListBox.Items.Add(Notification["message"]);
            }
        }

        public notifications()
        {
            InitializeComponent();
            getUnreadUserNotifications();
        }

        private void showTestPopupBtn_Click(object sender, EventArgs e)
        {
            GlobalMethods.ShowPopupNotification("This is a test title.", "This is a test message.", 5000);
        }

        private void refreshNotificationsBtn_Click(object sender, EventArgs e)
        {
            getUnreadUserNotifications();
        }
    }
}
