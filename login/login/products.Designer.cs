﻿namespace login
{
    partial class products
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
            this.offersLabel = new System.Windows.Forms.Label();
            this.productsLabel = new System.Windows.Forms.Label();
            this.panelSideMenu = new System.Windows.Forms.Panel();
            this.navAdmin = new System.Windows.Forms.Button();
            this.navSuperadmin = new System.Windows.Forms.Button();
            this.navNotifications = new System.Windows.Forms.Button();
            this.navOverview = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panelSubmenu = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.exit = new System.Windows.Forms.Button();
            this.navSidemenu = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.panelSideMenu.SuspendLayout();
            this.panelSubmenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            this.SuspendLayout();
            // 
            // offersLabel
            // 
            this.offersLabel.AutoSize = true;
            this.offersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.offersLabel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.offersLabel.Location = new System.Drawing.Point(206, 9);
            this.offersLabel.Name = "offersLabel";
            this.offersLabel.Size = new System.Drawing.Size(162, 29);
            this.offersLabel.TabIndex = 0;
            this.offersLabel.Text = "Aanbiedingen";
            // 
            // productsLabel
            // 
            this.productsLabel.AutoSize = true;
            this.productsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.productsLabel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.productsLabel.Location = new System.Drawing.Point(503, 9);
            this.productsLabel.Name = "productsLabel";
            this.productsLabel.Size = new System.Drawing.Size(123, 29);
            this.productsLabel.TabIndex = 1;
            this.productsLabel.Text = "Producten";
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
            this.panelSideMenu.Name = "panelSideMenu";
            this.panelSideMenu.Size = new System.Drawing.Size(200, 485);
            this.panelSideMenu.TabIndex = 19;
            // 
            // navAdmin
            // 
            this.navAdmin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.navAdmin.Dock = System.Windows.Forms.DockStyle.Top;
            this.navAdmin.FlatAppearance.BorderSize = 0;
            this.navAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.navAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.navAdmin.ForeColor = System.Drawing.Color.LightGray;
            this.navAdmin.Location = new System.Drawing.Point(0, 370);
            this.navAdmin.Name = "navAdmin";
            this.navAdmin.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.navAdmin.Size = new System.Drawing.Size(200, 45);
            this.navAdmin.TabIndex = 7;
            this.navAdmin.Text = "Admin paneel";
            this.navAdmin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.navAdmin.UseVisualStyleBackColor = false;
            this.navAdmin.Click += new System.EventHandler(this.navAdmin_Click);
            // 
            // navSuperadmin
            // 
            this.navSuperadmin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.navSuperadmin.Dock = System.Windows.Forms.DockStyle.Top;
            this.navSuperadmin.FlatAppearance.BorderSize = 0;
            this.navSuperadmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.navSuperadmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.navSuperadmin.ForeColor = System.Drawing.Color.LightGray;
            this.navSuperadmin.Location = new System.Drawing.Point(0, 325);
            this.navSuperadmin.Name = "navSuperadmin";
            this.navSuperadmin.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.navSuperadmin.Size = new System.Drawing.Size(200, 45);
            this.navSuperadmin.TabIndex = 6;
            this.navSuperadmin.Text = "Superadmin paneel";
            this.navSuperadmin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.navSuperadmin.UseVisualStyleBackColor = false;
            this.navSuperadmin.Click += new System.EventHandler(this.navSuperadmin_Click);
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
            this.navNotifications.Location = new System.Drawing.Point(0, 280);
            this.navNotifications.Name = "navNotifications";
            this.navNotifications.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.navNotifications.Size = new System.Drawing.Size(200, 45);
            this.navNotifications.TabIndex = 5;
            this.navNotifications.Text = "Notificaties";
            this.navNotifications.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.navNotifications.UseVisualStyleBackColor = false;
            this.navNotifications.Click += new System.EventHandler(this.navNotifications_Click);
            // 
            // navOverview
            // 
            this.navOverview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.navOverview.Dock = System.Windows.Forms.DockStyle.Top;
            this.navOverview.FlatAppearance.BorderSize = 0;
            this.navOverview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.navOverview.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.navOverview.ForeColor = System.Drawing.Color.LightGray;
            this.navOverview.Location = new System.Drawing.Point(0, 235);
            this.navOverview.Name = "navOverview";
            this.navOverview.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.navOverview.Size = new System.Drawing.Size(200, 45);
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
            this.button1.Location = new System.Drawing.Point(0, 190);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.button1.Size = new System.Drawing.Size(200, 45);
            this.button1.TabIndex = 3;
            this.button1.Text = "Gebruiker:";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // panelSubmenu
            // 
            this.panelSubmenu.AutoSize = true;
            this.panelSubmenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.panelSubmenu.Controls.Add(this.button2);
            this.panelSubmenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSubmenu.Location = new System.Drawing.Point(0, 145);
            this.panelSubmenu.Name = "panelSubmenu";
            this.panelSubmenu.Size = new System.Drawing.Size(200, 45);
            this.panelSubmenu.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(115)))), ((int)(((byte)(229)))));
            this.button2.Dock = System.Windows.Forms.DockStyle.Top;
            this.button2.Enabled = false;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(115)))), ((int)(((byte)(229)))));
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(115)))), ((int)(((byte)(229)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.button2.ForeColor = System.Drawing.Color.LightGray;
            this.button2.Location = new System.Drawing.Point(0, 0);
            this.button2.Name = "button2";
            this.button2.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.button2.Size = new System.Drawing.Size(200, 45);
            this.button2.TabIndex = 1;
            this.button2.Text = "Aanbiedingen bekijken";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // exit
            // 
            this.exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.exit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.exit.FlatAppearance.BorderSize = 0;
            this.exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.exit.ForeColor = System.Drawing.Color.Gainsboro;
            this.exit.Location = new System.Drawing.Point(0, 440);
            this.exit.Name = "exit";
            this.exit.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.exit.Size = new System.Drawing.Size(200, 45);
            this.exit.TabIndex = 0;
            this.exit.Text = "Afsluiten";
            this.exit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.exit.UseVisualStyleBackColor = false;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // navSidemenu
            // 
            this.navSidemenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(89)))), ((int)(((byte)(255)))));
            this.navSidemenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.navSidemenu.FlatAppearance.BorderSize = 0;
            this.navSidemenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.navSidemenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.navSidemenu.ForeColor = System.Drawing.Color.Gainsboro;
            this.navSidemenu.Location = new System.Drawing.Point(0, 100);
            this.navSidemenu.Name = "navSidemenu";
            this.navSidemenu.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.navSidemenu.Size = new System.Drawing.Size(200, 45);
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
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(200, 100);
            this.panelLogo.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Gainsboro;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(200, 100);
            this.label6.TabIndex = 0;
            this.label6.Text = "De Budget Boodschapwijzer";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // products
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(179)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(800, 485);
            this.Controls.Add(this.panelSideMenu);
            this.Controls.Add(this.productsLabel);
            this.Controls.Add(this.offersLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "products";
            this.ShowIcon = false;
            this.Text = "Producten - Budget Boodschapwijzer";
            this.Load += new System.EventHandler(this.products_Load);
            this.panelSideMenu.ResumeLayout(false);
            this.panelSideMenu.PerformLayout();
            this.panelSubmenu.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label offersLabel;
        private System.Windows.Forms.Label productsLabel;
        private System.Windows.Forms.Panel panelSideMenu;
        private System.Windows.Forms.Button navAdmin;
        private System.Windows.Forms.Button navSuperadmin;
        private System.Windows.Forms.Button navNotifications;
        private System.Windows.Forms.Button navOverview;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panelSubmenu;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.Button navSidemenu;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button2;
    }
}