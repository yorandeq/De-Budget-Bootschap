namespace login
{
    partial class login
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
            this.panelSideMenu = new System.Windows.Forms.Panel();
            this.panelSubmenu = new System.Windows.Forms.Panel();
            this.navRegister = new System.Windows.Forms.Button();
            this.exit = new System.Windows.Forms.Button();
            this.navSidemenu = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.txbLoginPassword = new System.Windows.Forms.TextBox();
            this.txbLoginUsrname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelSuperAdmin = new System.Windows.Forms.Panel();
            this.loginAcc = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panelSideMenu.SuspendLayout();
            this.panelSubmenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            this.panelSuperAdmin.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSideMenu
            // 
            this.panelSideMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(89)))), ((int)(((byte)(179)))));
            this.panelSideMenu.Controls.Add(this.panelSubmenu);
            this.panelSideMenu.Controls.Add(this.exit);
            this.panelSideMenu.Controls.Add(this.navSidemenu);
            this.panelSideMenu.Controls.Add(this.panelLogo);
            this.panelSideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSideMenu.Location = new System.Drawing.Point(0, 0);
            this.panelSideMenu.Name = "panelSideMenu";
            this.panelSideMenu.Size = new System.Drawing.Size(200, 490);
            this.panelSideMenu.TabIndex = 16;
            // 
            // panelSubmenu
            // 
            this.panelSubmenu.AutoSize = true;
            this.panelSubmenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.panelSubmenu.Controls.Add(this.navRegister);
            this.panelSubmenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSubmenu.Location = new System.Drawing.Point(0, 145);
            this.panelSubmenu.Name = "panelSubmenu";
            this.panelSubmenu.Size = new System.Drawing.Size(200, 45);
            this.panelSubmenu.TabIndex = 2;
            // 
            // navRegister
            // 
            this.navRegister.Dock = System.Windows.Forms.DockStyle.Top;
            this.navRegister.FlatAppearance.BorderSize = 0;
            this.navRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.navRegister.ForeColor = System.Drawing.Color.LightGray;
            this.navRegister.Location = new System.Drawing.Point(0, 0);
            this.navRegister.Name = "navRegister";
            this.navRegister.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.navRegister.Size = new System.Drawing.Size(200, 45);
            this.navRegister.TabIndex = 0;
            this.navRegister.Text = "Registreer";
            this.navRegister.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.navRegister.UseVisualStyleBackColor = true;
            this.navRegister.Click += new System.EventHandler(this.navRegister_Click);
            // 
            // exit
            // 
            this.exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.exit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.exit.FlatAppearance.BorderSize = 0;
            this.exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exit.ForeColor = System.Drawing.Color.Gainsboro;
            this.exit.Location = new System.Drawing.Point(0, 445);
            this.exit.Name = "exit";
            this.exit.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.exit.Size = new System.Drawing.Size(200, 45);
            this.exit.TabIndex = 0;
            this.exit.Text = "Afsluiten";
            this.exit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.exit.UseVisualStyleBackColor = false;
            this.exit.Click += new System.EventHandler(this.logout_Click);
            // 
            // navSidemenu
            // 
            this.navSidemenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(89)))), ((int)(((byte)(255)))));
            this.navSidemenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.navSidemenu.FlatAppearance.BorderSize = 0;
            this.navSidemenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.navSidemenu.ForeColor = System.Drawing.Color.Gainsboro;
            this.navSidemenu.Location = new System.Drawing.Point(0, 100);
            this.navSidemenu.Name = "navSidemenu";
            this.navSidemenu.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.navSidemenu.Size = new System.Drawing.Size(200, 45);
            this.navSidemenu.TabIndex = 1;
            this.navSidemenu.Text = "Heeft u nog geen account?";
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
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Gainsboro;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(200, 100);
            this.label6.TabIndex = 0;
            this.label6.Text = "Inloggen";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txbLoginPassword
            // 
            this.txbLoginPassword.Location = new System.Drawing.Point(215, 245);
            this.txbLoginPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txbLoginPassword.Name = "txbLoginPassword";
            this.txbLoginPassword.PasswordChar = '*';
            this.txbLoginPassword.Size = new System.Drawing.Size(208, 22);
            this.txbLoginPassword.TabIndex = 12;
            // 
            // txbLoginUsrname
            // 
            this.txbLoginUsrname.Location = new System.Drawing.Point(215, 175);
            this.txbLoginUsrname.Margin = new System.Windows.Forms.Padding(4);
            this.txbLoginUsrname.Name = "txbLoginUsrname";
            this.txbLoginUsrname.Size = new System.Drawing.Size(208, 22);
            this.txbLoginUsrname.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(226, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 40);
            this.label1.TabIndex = 14;
            this.label1.Text = "Gebruikersnaam:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelSuperAdmin
            // 
            this.panelSuperAdmin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(179)))), ((int)(((byte)(255)))));
            this.panelSuperAdmin.Controls.Add(this.loginAcc);
            this.panelSuperAdmin.Controls.Add(this.label2);
            this.panelSuperAdmin.Controls.Add(this.label1);
            this.panelSuperAdmin.Controls.Add(this.txbLoginPassword);
            this.panelSuperAdmin.Controls.Add(this.txbLoginUsrname);
            this.panelSuperAdmin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSuperAdmin.Location = new System.Drawing.Point(200, 0);
            this.panelSuperAdmin.Name = "panelSuperAdmin";
            this.panelSuperAdmin.Size = new System.Drawing.Size(608, 490);
            this.panelSuperAdmin.TabIndex = 17;
            // 
            // loginAcc
            // 
            this.loginAcc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.loginAcc.FlatAppearance.BorderSize = 0;
            this.loginAcc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loginAcc.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.loginAcc.Location = new System.Drawing.Point(229, 276);
            this.loginAcc.Margin = new System.Windows.Forms.Padding(5);
            this.loginAcc.Name = "loginAcc";
            this.loginAcc.Size = new System.Drawing.Size(176, 52);
            this.loginAcc.TabIndex = 16;
            this.loginAcc.Text = "Login";
            this.loginAcc.UseVisualStyleBackColor = false;
            this.loginAcc.Click += new System.EventHandler(this.loginAcc_Click);
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(226, 201);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(187, 40);
            this.label2.TabIndex = 15;
            this.label2.Text = "Wachtwoord:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 490);
            this.Controls.Add(this.panelSuperAdmin);
            this.Controls.Add(this.panelSideMenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "login";
            this.ShowIcon = false;
            this.Text = "Inloggen - Budget Boodschapwijzer";
            this.panelSideMenu.ResumeLayout(false);
            this.panelSideMenu.PerformLayout();
            this.panelSubmenu.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            this.panelSuperAdmin.ResumeLayout(false);
            this.panelSuperAdmin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelSideMenu;
        private System.Windows.Forms.Panel panelSubmenu;
        private System.Windows.Forms.Button navRegister;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.Button navSidemenu;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txbLoginPassword;
        private System.Windows.Forms.TextBox txbLoginUsrname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelSuperAdmin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button loginAcc;
    }
}