﻿namespace login
{
    partial class welcomescreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.navNotifications = new System.Windows.Forms.Button();
            this.panelSideMenu = new System.Windows.Forms.Panel();
            this.navAdmin = new System.Windows.Forms.Button();
            this.navSuperadmin = new System.Windows.Forms.Button();
            this.navOverview = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panelSubmenu = new System.Windows.Forms.Panel();
            this.navStores = new System.Windows.Forms.Button();
            this.exit = new System.Windows.Forms.Button();
            this.navSidemenu = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.refreshNotificationsBtn = new System.Windows.Forms.Button();
            this.markReadBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.imageContainer = new System.Windows.Forms.ListView();
            this.notificationContainer = new System.Windows.Forms.ListView();
            this.panelSideMenu.SuspendLayout();
            this.panelSubmenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            this.SuspendLayout();
            // 
            // navNotifications
            // 
            this.navNotifications.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.navNotifications.Cursor = System.Windows.Forms.Cursors.Default;
            this.navNotifications.Dock = System.Windows.Forms.DockStyle.Top;
            this.navNotifications.FlatAppearance.BorderSize = 0;
            this.navNotifications.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.navNotifications.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.navNotifications.ForeColor = System.Drawing.Color.LightGray;
            this.navNotifications.Location = new System.Drawing.Point(0, 343);
            this.navNotifications.Margin = new System.Windows.Forms.Padding(4);
            this.navNotifications.Name = "navNotifications";
            this.navNotifications.Padding = new System.Windows.Forms.Padding(33, 0, 0, 0);
            this.navNotifications.Size = new System.Drawing.Size(267, 55);
            this.navNotifications.TabIndex = 5;
            this.navNotifications.Text = "Notificaties";
            this.navNotifications.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.navNotifications.UseVisualStyleBackColor = false;
            this.navNotifications.Click += new System.EventHandler(this.navNotifications_Click);
            // 
            // panelSideMenu
            // 
            this.panelSideMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(89)))), ((int)(((byte)(179)))));
            this.panelSideMenu.Controls.Add(this.navAdmin);
            this.panelSideMenu.Controls.Add(this.navSuperadmin);
            this.panelSideMenu.Controls.Add(this.navNotifications);
            this.panelSideMenu.Controls.Add(this.navOverview);
            this.panelSideMenu.Controls.Add(this.button1);
            this.panelSideMenu.Controls.Add(this.panelSubmenu);
            this.panelSideMenu.Controls.Add(this.exit);
            this.panelSideMenu.Controls.Add(this.navSidemenu);
            this.panelSideMenu.Controls.Add(this.panelLogo);
            this.panelSideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSideMenu.Location = new System.Drawing.Point(0, 0);
            this.panelSideMenu.Margin = new System.Windows.Forms.Padding(4);
            this.panelSideMenu.Name = "panelSideMenu";
            this.panelSideMenu.Size = new System.Drawing.Size(267, 613);
            this.panelSideMenu.TabIndex = 21;
            // 
            // navAdmin
            // 
            this.navAdmin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.navAdmin.Dock = System.Windows.Forms.DockStyle.Top;
            this.navAdmin.FlatAppearance.BorderSize = 0;
            this.navAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.navAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.navAdmin.ForeColor = System.Drawing.Color.LightGray;
            this.navAdmin.Location = new System.Drawing.Point(0, 453);
            this.navAdmin.Margin = new System.Windows.Forms.Padding(4);
            this.navAdmin.Name = "navAdmin";
            this.navAdmin.Padding = new System.Windows.Forms.Padding(33, 0, 0, 0);
            this.navAdmin.Size = new System.Drawing.Size(267, 55);
            this.navAdmin.TabIndex = 7;
            this.navAdmin.Text = "Admin paneel";
            this.navAdmin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.navAdmin.UseVisualStyleBackColor = false;
            // 
            // navSuperadmin
            // 
            this.navSuperadmin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.navSuperadmin.Dock = System.Windows.Forms.DockStyle.Top;
            this.navSuperadmin.FlatAppearance.BorderSize = 0;
            this.navSuperadmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.navSuperadmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.navSuperadmin.ForeColor = System.Drawing.Color.LightGray;
            this.navSuperadmin.Location = new System.Drawing.Point(0, 398);
            this.navSuperadmin.Margin = new System.Windows.Forms.Padding(4);
            this.navSuperadmin.Name = "navSuperadmin";
            this.navSuperadmin.Padding = new System.Windows.Forms.Padding(33, 0, 0, 0);
            this.navSuperadmin.Size = new System.Drawing.Size(267, 55);
            this.navSuperadmin.TabIndex = 6;
            this.navSuperadmin.Text = "Superadmin paneel";
            this.navSuperadmin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.navSuperadmin.UseVisualStyleBackColor = false;
            this.navSuperadmin.Click += new System.EventHandler(this.navSuperadmin_Click);
            // 
            // navOverview
            // 
            this.navOverview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.navOverview.Dock = System.Windows.Forms.DockStyle.Top;
            this.navOverview.FlatAppearance.BorderSize = 0;
            this.navOverview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.navOverview.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.navOverview.ForeColor = System.Drawing.Color.LightGray;
            this.navOverview.Location = new System.Drawing.Point(0, 288);
            this.navOverview.Margin = new System.Windows.Forms.Padding(4);
            this.navOverview.Name = "navOverview";
            this.navOverview.Padding = new System.Windows.Forms.Padding(33, 0, 0, 0);
            this.navOverview.Size = new System.Drawing.Size(267, 55);
            this.navOverview.TabIndex = 4;
            this.navOverview.Text = "Overzicht";
            this.navOverview.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.navOverview.UseVisualStyleBackColor = false;
            this.navOverview.Click += new System.EventHandler(this.navOverview_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(89)))), ((int)(((byte)(255)))));
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.button1.ForeColor = System.Drawing.Color.Gainsboro;
            this.button1.Location = new System.Drawing.Point(0, 233);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.button1.Size = new System.Drawing.Size(267, 55);
            this.button1.TabIndex = 3;
            this.button1.Text = "Gebruiker:";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // panelSubmenu
            // 
            this.panelSubmenu.AutoSize = true;
            this.panelSubmenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.panelSubmenu.Controls.Add(this.navStores);
            this.panelSubmenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSubmenu.Location = new System.Drawing.Point(0, 178);
            this.panelSubmenu.Margin = new System.Windows.Forms.Padding(4);
            this.panelSubmenu.Name = "panelSubmenu";
            this.panelSubmenu.Size = new System.Drawing.Size(267, 55);
            this.panelSubmenu.TabIndex = 2;
            // 
            // navStores
            // 
            this.navStores.Dock = System.Windows.Forms.DockStyle.Top;
            this.navStores.FlatAppearance.BorderSize = 0;
            this.navStores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.navStores.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.navStores.ForeColor = System.Drawing.Color.LightGray;
            this.navStores.Location = new System.Drawing.Point(0, 0);
            this.navStores.Margin = new System.Windows.Forms.Padding(4);
            this.navStores.Name = "navStores";
            this.navStores.Padding = new System.Windows.Forms.Padding(33, 0, 0, 0);
            this.navStores.Size = new System.Drawing.Size(267, 55);
            this.navStores.TabIndex = 0;
            this.navStores.Text = "Aanbiedingen bekijken";
            this.navStores.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.navStores.UseVisualStyleBackColor = true;
            this.navStores.Click += new System.EventHandler(this.navStores_Click);
            // 
            // exit
            // 
            this.exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(115)))), ((int)(((byte)(230)))));
            this.exit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.exit.FlatAppearance.BorderSize = 0;
            this.exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.exit.ForeColor = System.Drawing.Color.Gainsboro;
            this.exit.Location = new System.Drawing.Point(0, 558);
            this.exit.Margin = new System.Windows.Forms.Padding(4);
            this.exit.Name = "exit";
            this.exit.Padding = new System.Windows.Forms.Padding(33, 0, 0, 0);
            this.exit.Size = new System.Drawing.Size(267, 55);
            this.exit.TabIndex = 0;
            this.exit.Text = "Exit";
            this.exit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.exit.UseVisualStyleBackColor = false;
            // 
            // navSidemenu
            // 
            this.navSidemenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(89)))), ((int)(((byte)(255)))));
            this.navSidemenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.navSidemenu.FlatAppearance.BorderSize = 0;
            this.navSidemenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.navSidemenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.navSidemenu.ForeColor = System.Drawing.Color.Gainsboro;
            this.navSidemenu.Location = new System.Drawing.Point(0, 123);
            this.navSidemenu.Margin = new System.Windows.Forms.Padding(4);
            this.navSidemenu.Name = "navSidemenu";
            this.navSidemenu.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.navSidemenu.Size = new System.Drawing.Size(267, 55);
            this.navSidemenu.TabIndex = 1;
            this.navSidemenu.Text = "Aanbiedingen:";
            this.navSidemenu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.navSidemenu.UseVisualStyleBackColor = false;
            // 
            // panelLogo
            // 
            this.panelLogo.Controls.Add(this.label6);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Margin = new System.Windows.Forms.Padding(4);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(267, 123);
            this.panelLogo.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Gainsboro;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(267, 123);
            this.label6.TabIndex = 0;
            this.label6.Text = "De Budget Boodschapwijzer";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label4.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Location = new System.Drawing.Point(289, 43);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(554, 36);
            this.label4.TabIndex = 20;
            this.label4.Text = "Welkom op de budget boodschap wijzer!";
            // 
            // refreshNotificationsBtn
            // 
            this.refreshNotificationsBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(89)))), ((int)(((byte)(255)))));
            this.refreshNotificationsBtn.FlatAppearance.BorderSize = 0;
            this.refreshNotificationsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.refreshNotificationsBtn.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.refreshNotificationsBtn.Location = new System.Drawing.Point(738, 536);
            this.refreshNotificationsBtn.Margin = new System.Windows.Forms.Padding(4);
            this.refreshNotificationsBtn.Name = "refreshNotificationsBtn";
            this.refreshNotificationsBtn.Size = new System.Drawing.Size(319, 64);
            this.refreshNotificationsBtn.TabIndex = 19;
            this.refreshNotificationsBtn.Text = "Bekijk alle notificaties";
            this.refreshNotificationsBtn.UseVisualStyleBackColor = false;
            this.refreshNotificationsBtn.Click += new System.EventHandler(this.refreshNotificationsBtn_Click_1);
            // 
            // markReadBtn
            // 
            this.markReadBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(89)))), ((int)(((byte)(255)))));
            this.markReadBtn.FlatAppearance.BorderSize = 0;
            this.markReadBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.markReadBtn.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.markReadBtn.Location = new System.Drawing.Point(738, 279);
            this.markReadBtn.Margin = new System.Windows.Forms.Padding(4);
            this.markReadBtn.Name = "markReadBtn";
            this.markReadBtn.Size = new System.Drawing.Size(319, 64);
            this.markReadBtn.TabIndex = 18;
            this.markReadBtn.Text = "Bekijk alle aanbiedingen";
            this.markReadBtn.UseVisualStyleBackColor = false;
            this.markReadBtn.Click += new System.EventHandler(this.markReadBtn_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(289, 108);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 36);
            this.label1.TabIndex = 22;
            this.label1.Text = "Aanbiedingen:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(289, 347);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 36);
            this.label2.TabIndex = 23;
            this.label2.Text = "Notificaties:";
            // 
            // imageContainer
            // 
            this.imageContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(179)))), ((int)(((byte)(255)))));
            this.imageContainer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.imageContainer.HideSelection = false;
            this.imageContainer.Location = new System.Drawing.Point(295, 158);
            this.imageContainer.Name = "imageContainer";
            this.imageContainer.Size = new System.Drawing.Size(763, 114);
            this.imageContainer.TabIndex = 24;
            this.imageContainer.UseCompatibleStateImageBehavior = false;
            this.imageContainer.Click += new System.EventHandler(this.navStores_Click);
            // 
            // notificationContainer
            // 
            this.notificationContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(179)))), ((int)(((byte)(255)))));
            this.notificationContainer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.notificationContainer.HideSelection = false;
            this.notificationContainer.Location = new System.Drawing.Point(294, 398);
            this.notificationContainer.Name = "notificationContainer";
            this.notificationContainer.Scrollable = false;
            this.notificationContainer.Size = new System.Drawing.Size(763, 131);
            this.notificationContainer.TabIndex = 25;
            this.notificationContainer.UseCompatibleStateImageBehavior = false;
            this.notificationContainer.View = System.Windows.Forms.View.List;
            this.notificationContainer.Click += new System.EventHandler(this.notificationContainer_Click);
            // 
            // welcomescreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(179)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1070, 613);
            this.Controls.Add(this.notificationContainer);
            this.Controls.Add(this.imageContainer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelSideMenu);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.refreshNotificationsBtn);
            this.Controls.Add(this.markReadBtn);
            this.Name = "welcomescreen";
            this.Text = "Overzicht - De Budget Boodschapwijzer";
            this.Load += new System.EventHandler(this.welcomescreen_Load);
            this.panelSideMenu.ResumeLayout(false);
            this.panelSideMenu.PerformLayout();
            this.panelSubmenu.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button navNotifications;
        private System.Windows.Forms.Panel panelSideMenu;
        private System.Windows.Forms.Button navAdmin;
        private System.Windows.Forms.Button navSuperadmin;
        private System.Windows.Forms.Button navOverview;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panelSubmenu;
        private System.Windows.Forms.Button navStores;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.Button navSidemenu;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button refreshNotificationsBtn;
        private System.Windows.Forms.Button markReadBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView imageContainer;
        private System.Windows.Forms.ListView notificationContainer;
    }
}