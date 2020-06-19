namespace login
{
    partial class offer
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
            this.backBtn = new System.Windows.Forms.Button();
            this.offerContainer = new System.Windows.Forms.Panel();
            this.productContainer = new System.Windows.Forms.Panel();
            this.registrationsContainer = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // backBtn
            // 
            this.backBtn.Location = new System.Drawing.Point(13, 13);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(75, 23);
            this.backBtn.TabIndex = 0;
            this.backBtn.Text = "<-- Terug";
            this.backBtn.UseVisualStyleBackColor = true;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // offerContainer
            // 
            this.offerContainer.BackColor = System.Drawing.Color.Gainsboro;
            this.offerContainer.Location = new System.Drawing.Point(12, 42);
            this.offerContainer.Name = "offerContainer";
            this.offerContainer.Size = new System.Drawing.Size(473, 195);
            this.offerContainer.TabIndex = 1;
            // 
            // productContainer
            // 
            this.productContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.productContainer.AutoScroll = true;
            this.productContainer.BackColor = System.Drawing.Color.Gainsboro;
            this.productContainer.Location = new System.Drawing.Point(491, 42);
            this.productContainer.Name = "productContainer";
            this.productContainer.Size = new System.Drawing.Size(300, 396);
            this.productContainer.TabIndex = 2;
            // 
            // registrationsContainer
            // 
            this.registrationsContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.registrationsContainer.AutoScroll = true;
            this.registrationsContainer.BackColor = System.Drawing.Color.Gainsboro;
            this.registrationsContainer.Location = new System.Drawing.Point(13, 243);
            this.registrationsContainer.Name = "registrationsContainer";
            this.registrationsContainer.Size = new System.Drawing.Size(472, 195);
            this.registrationsContainer.TabIndex = 3;
            // 
            // offer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.registrationsContainer);
            this.Controls.Add(this.productContainer);
            this.Controls.Add(this.offerContainer);
            this.Controls.Add(this.backBtn);
            this.Name = "offer";
            this.Text = "offer";
            this.Load += new System.EventHandler(this.offer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Panel offerContainer;
        private System.Windows.Forms.Panel productContainer;
        private System.Windows.Forms.Panel registrationsContainer;
    }
}