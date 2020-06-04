namespace login
{
    partial class notifications
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
            this.showTestPopupBtn = new System.Windows.Forms.Button();
            this.refreshNotificationsBtn = new System.Windows.Forms.Button();
            this.notificationsListBox = new System.Windows.Forms.CheckedListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // showTestPopupBtn
            // 
            this.showTestPopupBtn.Location = new System.Drawing.Point(12, 72);
            this.showTestPopupBtn.Name = "showTestPopupBtn";
            this.showTestPopupBtn.Size = new System.Drawing.Size(129, 23);
            this.showTestPopupBtn.TabIndex = 0;
            this.showTestPopupBtn.Text = "Show test pop-up";
            this.showTestPopupBtn.UseVisualStyleBackColor = true;
            this.showTestPopupBtn.Click += new System.EventHandler(this.showTestPopupBtn_Click);
            // 
            // refreshNotificationsBtn
            // 
            this.refreshNotificationsBtn.Location = new System.Drawing.Point(147, 72);
            this.refreshNotificationsBtn.Name = "refreshNotificationsBtn";
            this.refreshNotificationsBtn.Size = new System.Drawing.Size(117, 23);
            this.refreshNotificationsBtn.TabIndex = 1;
            this.refreshNotificationsBtn.Text = "Refresh Notifications";
            this.refreshNotificationsBtn.UseVisualStyleBackColor = true;
            this.refreshNotificationsBtn.Click += new System.EventHandler(this.refreshNotificationsBtn_Click);
            // 
            // notificationsListBox
            // 
            this.notificationsListBox.CheckOnClick = true;
            this.notificationsListBox.FormattingEnabled = true;
            this.notificationsListBox.Items.AddRange(new object[] {
            "test1",
            "test2"});
            this.notificationsListBox.Location = new System.Drawing.Point(12, 101);
            this.notificationsListBox.Name = "notificationsListBox";
            this.notificationsListBox.Size = new System.Drawing.Size(776, 334);
            this.notificationsListBox.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("HoloLens MDL2 Assets", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(216, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "Op deze pagina ziet u uw notificaties.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("HoloLens MDL2 Assets", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label3.Location = new System.Drawing.Point(1, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(182, 21);
            this.label3.TabIndex = 9;
            this.label3.Text = "De Budget Boodschap";
            // 
            // notifications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.notificationsListBox);
            this.Controls.Add(this.refreshNotificationsBtn);
            this.Controls.Add(this.showTestPopupBtn);
            this.Name = "notifications";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button showTestPopupBtn;
        private System.Windows.Forms.Button refreshNotificationsBtn;
        private System.Windows.Forms.CheckedListBox notificationsListBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}