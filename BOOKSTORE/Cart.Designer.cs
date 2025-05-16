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
            this.panelCartItems = new System.Windows.Forms.FlowLayoutPanel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.purchaseButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LogOut = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ViewCart = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCartItems
            // 
            this.panelCartItems.AccessibleRole = System.Windows.Forms.AccessibleRole.ScrollBar;
            this.panelCartItems.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelCartItems.AutoScroll = true;
            this.panelCartItems.BackColor = System.Drawing.Color.Transparent;
            this.panelCartItems.ForeColor = System.Drawing.Color.Transparent;
            this.panelCartItems.Location = new System.Drawing.Point(141, 203);
            this.panelCartItems.Name = "panelCartItems";
            this.panelCartItems.Size = new System.Drawing.Size(704, 305);
            this.panelCartItems.TabIndex = 0;
            // 
            // lblTotal
            // 
            this.lblTotal.AccessibleRole = System.Windows.Forms.AccessibleRole.ScrollBar;
            this.lblTotal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.lblTotal.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblTotal.Location = new System.Drawing.Point(388, 175);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(44, 15);
            this.lblTotal.TabIndex = 1;
            this.lblTotal.Text = "lblTotal";
            // 
            // purchaseButton
            // 
            this.purchaseButton.ForeColor = System.Drawing.Color.MidnightBlue;
            this.purchaseButton.Location = new System.Drawing.Point(592, 159);
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
            this.panel1.Controls.Add(this.LogOut);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.ViewCart);
            this.panel1.Controls.Add(this.lblTotal);
            this.panel1.Controls.Add(this.purchaseButton);
            this.panel1.Controls.Add(this.panelCartItems);
            this.panel1.ForeColor = System.Drawing.Color.Transparent;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1000, 600);
            this.panel1.TabIndex = 21;
            // 
            // LogOut
            // 
            this.LogOut.AutoSize = true;
            this.LogOut.BackColor = System.Drawing.Color.Transparent;
            this.LogOut.Font = new System.Drawing.Font("Stencil", 15F);
            this.LogOut.ForeColor = System.Drawing.Color.MidnightBlue;
            this.LogOut.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.LogOut.Location = new System.Drawing.Point(887, 20);
            this.LogOut.Name = "LogOut";
            this.LogOut.Size = new System.Drawing.Size(85, 24);
            this.LogOut.TabIndex = 46;
            this.LogOut.Text = "logout";
            this.LogOut.Click += new System.EventHandler(this.LogOut_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Stencil", 15F);
            this.label3.ForeColor = System.Drawing.Color.AliceBlue;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label3.Location = new System.Drawing.Point(354, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 24);
            this.label3.TabIndex = 37;
            this.label3.Text = "Explore";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // ViewCart
            // 
            this.ViewCart.AutoSize = true;
            this.ViewCart.BackColor = System.Drawing.Color.Transparent;
            this.ViewCart.Font = new System.Drawing.Font("Stencil", 15F);
            this.ViewCart.ForeColor = System.Drawing.Color.AliceBlue;
            this.ViewCart.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.ViewCart.Location = new System.Drawing.Point(542, 88);
            this.ViewCart.Name = "ViewCart";
            this.ViewCart.Size = new System.Drawing.Size(108, 24);
            this.ViewCart.TabIndex = 36;
            this.ViewCart.Text = "viewcart";
            // 
            // Cart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.MidnightBlue;
            this.Name = "Cart";
            this.Text = "Cart";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel panelCartItems;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button purchaseButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label ViewCart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LogOut;
    }
}