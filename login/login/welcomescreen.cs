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
    public partial class welcomescreen : Form
    {
        // Load Neccessities.
        DataLayer DataLayer = new DataLayer();
        GlobalMethods GlobalMethods = new GlobalMethods();
        List<Panel> NotificationPanels = new List<Panel>();
        connection connection = new connection();



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

        private void navOverview_Click(object sender, EventArgs e)
        {
            GlobalMethods.SwitchForm(this, new welcomescreen());
        }

        private void markReadBtn_Click_1(object sender, EventArgs e)
        {
            GlobalMethods.SwitchForm(this, new stores());
        }

        private void refreshNotificationsBtn_Click_1(object sender, EventArgs e)
        {
            GlobalMethods.SwitchForm(this, new notifications());
        }

        private void notificationContainer_Click(object sender, EventArgs e)
        {
            GlobalMethods.SwitchForm(this, new notifications());
        }

        private void navAdmin_Click(object sender, EventArgs e)
        {
            GlobalMethods.SwitchForm(this, new admin());
        }
        private void welcomescreen_Load(object sender, EventArgs e)
        {
            getDiscountOffers();
            getUnreadUserNotifications();
            balUsr.Text = "€" + connection.getBalance().Rows[0]["balance"].ToString();
        }

        //TODO: Je bent momenteel geregistreerd voor " " producten!

        public void getUnreadUserNotifications()
        {
            int Yposition = 1;

            DataTable getUserNotifications = DataLayer.Query("SELECT * FROM notifications WHERE user = @UserId AND state = 1",
            p => {
                p.Add("@UserId", MySqlDbType.Int16, 255).Value = GlobalMethods.LoginInfo.UserID;
            });
            
            // Check if user has no unread notifications
            if (getUserNotifications.Rows.Count < 1)
            {
                Label notification = new Label();
                notification.Text = "Je hebt geen ongelezen notificaties!";
                notification.ForeColor = Color.WhiteSmoke;
                notification.Top = 80;
                notification.Width = 750;
                notificationContainer.Controls.Add(notification);
            }

            // Show unread user notifications to user through form. (Currently using a listbox for testing purposes, this should be changed later to form elements to fit the design.)
            int rows = 0;
            foreach (DataRow row in getUserNotifications.Select())
            {
               
                ListViewItem notification = new ListViewItem();

                // Options

                notification.Text = (int)row["notification_id"] + ". " + (string)row["message"];
                notification.Font = new Font("Consolas", 13f);
                notification.ForeColor = Color.WhiteSmoke;

                // Move next item down
                Yposition++;

                // Add controls inside panel
                
                rows++;

                notificationContainer.Items.Add(notification);
            }
            label2.Text = "Notificaties: (" + rows.ToString() + ")";
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

        private void addMoney_Click(object sender, EventArgs e)
        {
            // Adds money to the logged in users balance
            DataLayer.Query("UPDATE `users` SET balance = balance + @Balance WHERE user_id = @UserID", 
                p => {
                    p.Add("@Balance", MySqlDbType.Int16, 255).Value = 5.00;
                    p.Add("@UserID", MySqlDbType.Int16, 11).Value = GlobalMethods.LoginInfo.UserID;
                });
            MessageBox.Show("U heeft €5,00 toegevoegd aan uw saldo!");
            balUsr.Text = "€" + connection.getBalance().Rows[0]["balance"].ToString();
        }

        private void exit_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}
