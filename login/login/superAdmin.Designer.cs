namespace login
{
    partial class superAdmin
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
            this.logout = new System.Windows.Forms.Button();
            this.panelSideMenu = new System.Windows.Forms.Panel();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.navSupermarket = new System.Windows.Forms.Button();
            this.panelSubmenu = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panelSuperAdmin = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelSideMenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            this.panelSubmenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // logout
            // 
            this.logout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(115)))), ((int)(((byte)(230)))));
            this.logout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.logout.FlatAppearance.BorderSize = 0;
            this.logout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logout.ForeColor = System.Drawing.Color.Gainsboro;
            this.logout.Location = new System.Drawing.Point(0, 548);
            this.logout.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.logout.Name = "logout";
            this.logout.Padding = new System.Windows.Forms.Padding(33, 0, 0, 0);
            this.logout.Size = new System.Drawing.Size(267, 55);
            this.logout.TabIndex = 0;
            this.logout.Text = "Logout";
            this.logout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.logout.UseVisualStyleBackColor = false;
            this.logout.Click += new System.EventHandler(this.Logout_Click);
            // 
            // panelSideMenu
            // 
            this.panelSideMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(89)))), ((int)(((byte)(179)))));
            this.panelSideMenu.Controls.Add(this.panelSubmenu);
            this.panelSideMenu.Controls.Add(this.logout);
            this.panelSideMenu.Controls.Add(this.navSupermarket);
            this.panelSideMenu.Controls.Add(this.panelLogo);
            this.panelSideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSideMenu.Location = new System.Drawing.Point(0, 0);
            this.panelSideMenu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelSideMenu.Name = "panelSideMenu";
            this.panelSideMenu.Size = new System.Drawing.Size(267, 603);
            this.panelSideMenu.TabIndex = 1;
            // 
            // panelLogo
            // 
            this.panelLogo.Controls.Add(this.label1);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(267, 123);
            this.panelLogo.TabIndex = 0;
            // 
            // navSupermarket
            // 
            this.navSupermarket.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(89)))), ((int)(((byte)(255)))));
            this.navSupermarket.Dock = System.Windows.Forms.DockStyle.Top;
            this.navSupermarket.FlatAppearance.BorderSize = 0;
            this.navSupermarket.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.navSupermarket.ForeColor = System.Drawing.Color.Gainsboro;
            this.navSupermarket.Location = new System.Drawing.Point(0, 123);
            this.navSupermarket.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.navSupermarket.Name = "navSupermarket";
            this.navSupermarket.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.navSupermarket.Size = new System.Drawing.Size(267, 55);
            this.navSupermarket.TabIndex = 1;
            this.navSupermarket.Text = "Admin";
            this.navSupermarket.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.navSupermarket.UseVisualStyleBackColor = false;
            this.navSupermarket.Click += new System.EventHandler(this.navSupermarket_Click);
            // 
            // panelSubmenu
            // 
            this.panelSubmenu.AutoSize = true;
            this.panelSubmenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.panelSubmenu.Controls.Add(this.button1);
            this.panelSubmenu.Controls.Add(this.button2);
            this.panelSubmenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSubmenu.Location = new System.Drawing.Point(0, 178);
            this.panelSubmenu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelSubmenu.Name = "panelSubmenu";
            this.panelSubmenu.Size = new System.Drawing.Size(267, 110);
            this.panelSubmenu.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Top;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.LightGray;
            this.button2.Location = new System.Drawing.Point(0, 0);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Padding = new System.Windows.Forms.Padding(33, 0, 0, 0);
            this.button2.Size = new System.Drawing.Size(267, 55);
            this.button2.TabIndex = 0;
            this.button2.Text = "Supermarkt Admins";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.LightGray;
            this.button1.Location = new System.Drawing.Point(0, 55);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(33, 0, 0, 0);
            this.button1.Size = new System.Drawing.Size(267, 55);
            this.button1.TabIndex = 1;
            this.button1.Text = "Supermarkten";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panelSuperAdmin
            // 
            this.panelSuperAdmin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(179)))), ((int)(((byte)(255)))));
            this.panelSuperAdmin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSuperAdmin.Location = new System.Drawing.Point(267, 0);
            this.panelSuperAdmin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelSuperAdmin.Name = "panelSuperAdmin";
            this.panelSuperAdmin.Size = new System.Drawing.Size(810, 603);
            this.panelSuperAdmin.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gainsboro;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(267, 123);
            this.label1.TabIndex = 0;
            this.label1.Text = "Super admin";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // superAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 603);
            this.Controls.Add(this.panelSuperAdmin);
            this.Controls.Add(this.panelSideMenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "superAdmin";
            this.Text = "Super Admin";
            this.panelSideMenu.ResumeLayout(false);
            this.panelSideMenu.PerformLayout();
            this.panelLogo.ResumeLayout(false);
            this.panelSubmenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button logout;
        private System.Windows.Forms.Panel panelSideMenu;
        private System.Windows.Forms.Panel panelSubmenu;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button navSupermarket;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Panel panelSuperAdmin;
        private System.Windows.Forms.Label label1;
    }
}