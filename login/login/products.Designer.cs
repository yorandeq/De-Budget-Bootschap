namespace login
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
            this.SuspendLayout();
            // 
            // offersLabel
            // 
            this.offersLabel.AutoSize = true;
            this.offersLabel.Location = new System.Drawing.Point(104, 69);
            this.offersLabel.Name = "offersLabel";
            this.offersLabel.Size = new System.Drawing.Size(35, 13);
            this.offersLabel.TabIndex = 0;
            this.offersLabel.Text = "Offers";
            // 
            // productsLabel
            // 
            this.productsLabel.AutoSize = true;
            this.productsLabel.Location = new System.Drawing.Point(553, 69);
            this.productsLabel.Name = "productsLabel";
            this.productsLabel.Size = new System.Drawing.Size(49, 13);
            this.productsLabel.TabIndex = 1;
            this.productsLabel.Text = "Products";
            // 
            // products
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.productsLabel);
            this.Controls.Add(this.offersLabel);
            this.Name = "products";
            this.Text = "Products";
            this.Load += new System.EventHandler(this.products_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label offersLabel;
        private System.Windows.Forms.Label productsLabel;
    }
}