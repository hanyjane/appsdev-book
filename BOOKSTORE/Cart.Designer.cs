namespace BOOKSTORE
{
    partial class Cart
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cart));
            this.lblTotal = new System.Windows.Forms.Label();
            this.purchaseButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelCartItems = new System.Windows.Forms.FlowLayoutPanel();
            this.LogOut = new System.Windows.Forms.Label();
            this.ViewCart = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTotal
            // 
            this.lblTotal.AccessibleRole = System.Windows.Forms.AccessibleRole.ScrollBar;
            this.lblTotal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblTotal.Location = new System.Drawing.Point(314, 430);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(53, 19);
            this.lblTotal.TabIndex = 1;
            this.lblTotal.Text = "lblTotal";
            // 
            // purchaseButton
            // 
            this.purchaseButton.ForeColor = System.Drawing.Color.MidnightBlue;
            this.purchaseButton.Location = new System.Drawing.Point(186, 422);
            this.purchaseButton.Name = "purchaseButton";
            this.purchaseButton.Size = new System.Drawing.Size(122, 31);
            this.purchaseButton.TabIndex = 2;
            this.purchaseButton.Text = "Purchase";
            this.purchaseButton.UseVisualStyleBackColor = true;
            this.purchaseButton.Click += new System.EventHandler(this.purchaseButton_Click_1);
            // 
            // panel1
            // 
            this.panel1.AccessibleRole = System.Windows.Forms.AccessibleRole.ScrollBar;
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.panelCartItems);
            this.panel1.Controls.Add(this.purchaseButton);
            this.panel1.Controls.Add(this.LogOut);
            this.panel1.Controls.Add(this.ViewCart);
            this.panel1.Controls.Add(this.lblTotal);
            this.panel1.ForeColor = System.Drawing.Color.Transparent;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(867, 535);
            this.panel1.TabIndex = 21;
            // 
            // panelCartItems
            // 
            this.panelCartItems.AccessibleRole = System.Windows.Forms.AccessibleRole.ScrollBar;
            this.panelCartItems.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelCartItems.AutoScroll = true;
            this.panelCartItems.BackColor = System.Drawing.Color.Transparent;
            this.panelCartItems.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panelCartItems.ForeColor = System.Drawing.Color.Transparent;
            this.panelCartItems.Location = new System.Drawing.Point(167, 145);
            this.panelCartItems.Name = "panelCartItems";
            this.panelCartItems.Size = new System.Drawing.Size(525, 274);
            this.panelCartItems.TabIndex = 0;
            // 
            // LogOut
            // 
            this.LogOut.AutoSize = true;
            this.LogOut.BackColor = System.Drawing.Color.Transparent;
            this.LogOut.Font = new System.Drawing.Font("Stencil", 13F);
            this.LogOut.ForeColor = System.Drawing.Color.MidnightBlue;
            this.LogOut.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.LogOut.Location = new System.Drawing.Point(766, 23);
            this.LogOut.Name = "LogOut";
            this.LogOut.Size = new System.Drawing.Size(76, 21);
            this.LogOut.TabIndex = 46;
            this.LogOut.Text = "logout";
            this.LogOut.Click += new System.EventHandler(this.LogOut_Click);
            // 
            // ViewCart
            // 
            this.ViewCart.AutoSize = true;
            this.ViewCart.BackColor = System.Drawing.Color.Transparent;
            this.ViewCart.Font = new System.Drawing.Font("Stencil", 15F);
            this.ViewCart.ForeColor = System.Drawing.Color.AliceBlue;
            this.ViewCart.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.ViewCart.Location = new System.Drawing.Point(407, 80);
            this.ViewCart.Name = "ViewCart";
            this.ViewCart.Size = new System.Drawing.Size(60, 24);
            this.ViewCart.TabIndex = 36;
            this.ViewCart.Text = "Cart";
            // 
            // Cart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(847, 485);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.MidnightBlue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Cart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cart";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button purchaseButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label ViewCart;
        private System.Windows.Forms.Label LogOut;
        private System.Windows.Forms.FlowLayoutPanel panelCartItems;
    }
}