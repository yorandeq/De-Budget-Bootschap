﻿namespace login
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
            this.showTestNotification = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // showTestNotification
            // 
            this.showTestNotification.Location = new System.Drawing.Point(12, 12);
            this.showTestNotification.Name = "showTestNotification";
            this.showTestNotification.Size = new System.Drawing.Size(129, 23);
            this.showTestNotification.TabIndex = 0;
            this.showTestNotification.Text = "Show test notification";
            this.showTestNotification.UseVisualStyleBackColor = true;
            this.showTestNotification.Click += new System.EventHandler(this.showTestNotification_Click);
            // 
            // TESTnotification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.showTestNotification);
            this.Name = "TESTnotification";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button showTestNotification;
    }
}