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
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txbLoginPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txbLoginUsrname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.loginAcc = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.navRegister = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("HoloLens MDL2 Assets", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(190, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Op deze pagina kunt u inloggen.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("HoloLens MDL2 Assets", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label3.Location = new System.Drawing.Point(1, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(182, 21);
            this.label3.TabIndex = 7;
            this.label3.Text = "De Budget Boodschap";
            // 
            // txbLoginPassword
            // 
            this.txbLoginPassword.Location = new System.Drawing.Point(12, 125);
            this.txbLoginPassword.Name = "txbLoginPassword";
            this.txbLoginPassword.PasswordChar = '*';
            this.txbLoginPassword.Size = new System.Drawing.Size(100, 20);
            this.txbLoginPassword.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Password";
            // 
            // txbLoginUsrname
            // 
            this.txbLoginUsrname.Location = new System.Drawing.Point(12, 81);
            this.txbLoginUsrname.Name = "txbLoginUsrname";
            this.txbLoginUsrname.Size = new System.Drawing.Size(100, 20);
            this.txbLoginUsrname.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Username";
            // 
            // loginAcc
            // 
            this.loginAcc.Location = new System.Drawing.Point(12, 152);
            this.loginAcc.Name = "loginAcc";
            this.loginAcc.Size = new System.Drawing.Size(75, 23);
            this.loginAcc.TabIndex = 13;
            this.loginAcc.Text = "Login";
            this.loginAcc.UseVisualStyleBackColor = true;
            this.loginAcc.Click += new System.EventHandler(this.loginAcc_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("HoloLens MDL2 Assets", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 182);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(162, 16);
            this.label5.TabIndex = 14;
            this.label5.Text = "Heeft u nog geen account?:";
            // 
            // navRegister
            // 
            this.navRegister.Location = new System.Drawing.Point(12, 201);
            this.navRegister.Name = "navRegister";
            this.navRegister.Size = new System.Drawing.Size(75, 23);
            this.navRegister.TabIndex = 15;
            this.navRegister.Text = "Register";
            this.navRegister.UseVisualStyleBackColor = true;
            this.navRegister.Click += new System.EventHandler(this.navRegister_Click);
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.navRegister);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.loginAcc);
            this.Controls.Add(this.txbLoginPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txbLoginUsrname);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Name = "login";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbLoginPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbLoginUsrname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button loginAcc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button navRegister;
    }
}