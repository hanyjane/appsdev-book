namespace BOOKSTORE
{
    partial class mainform
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainform));
            this.btn_Fiction = new System.Windows.Forms.Button();
            this.btn_Romance = new System.Windows.Forms.Button();
            this.btn_Mystery = new System.Windows.Forms.Button();
            this.btn_Fantasy = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_Horror = new System.Windows.Forms.Button();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.txtMinPrice = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaxPrice = new System.Windows.Forms.TextBox();
            this.btn_findAuthor = new System.Windows.Forms.Button();
            this.btn_minmaxPrice = new System.Windows.Forms.Button();
            this.btn_All = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ViewCart = new System.Windows.Forms.Label();
            this.LogOut = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Fiction
            // 
            this.btn_Fiction.Location = new System.Drawing.Point(434, 119);
            this.btn_Fiction.Name = "btn_Fiction";
            this.btn_Fiction.Size = new System.Drawing.Size(70, 24);
            this.btn_Fiction.TabIndex = 0;
            this.btn_Fiction.Text = "Fiction";
            this.btn_Fiction.UseVisualStyleBackColor = true;
            this.btn_Fiction.Click += new System.EventHandler(this.btn_Fiction_Click);
            // 
            // btn_Romance
            // 
            this.btn_Romance.Location = new System.Drawing.Point(510, 119);
            this.btn_Romance.Name = "btn_Romance";
            this.btn_Romance.Size = new System.Drawing.Size(70, 24);
            this.btn_Romance.TabIndex = 1;
            this.btn_Romance.Text = "Romance";
            this.btn_Romance.UseVisualStyleBackColor = true;
            this.btn_Romance.Click += new System.EventHandler(this.btn_Romance_Click);
            // 
            // btn_Mystery
            // 
            this.btn_Mystery.Location = new System.Drawing.Point(662, 119);
            this.btn_Mystery.Name = "btn_Mystery";
            this.btn_Mystery.Size = new System.Drawing.Size(70, 24);
            this.btn_Mystery.TabIndex = 2;
            this.btn_Mystery.Text = "Mystery";
            this.btn_Mystery.UseVisualStyleBackColor = true;
            this.btn_Mystery.Click += new System.EventHandler(this.btn_Mystery_Click);
            // 
            // btn_Fantasy
            // 
            this.btn_Fantasy.Location = new System.Drawing.Point(358, 119);
            this.btn_Fantasy.Name = "btn_Fantasy";
            this.btn_Fantasy.Size = new System.Drawing.Size(70, 24);
            this.btn_Fantasy.TabIndex = 3;
            this.btn_Fantasy.Text = "Fantasy";
            this.btn_Fantasy.UseVisualStyleBackColor = true;
            this.btn_Fantasy.Click += new System.EventHandler(this.btn_Fantasy_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(249, 159);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(523, 390);
            this.flowLayoutPanel1.TabIndex = 20;
            // 
            // btn_Horror
            // 
            this.btn_Horror.Location = new System.Drawing.Point(586, 119);
            this.btn_Horror.Name = "btn_Horror";
            this.btn_Horror.Size = new System.Drawing.Size(70, 24);
            this.btn_Horror.TabIndex = 21;
            this.btn_Horror.Text = "Horror";
            this.btn_Horror.UseVisualStyleBackColor = true;
            this.btn_Horror.Click += new System.EventHandler(this.btn_Horror_Click);
            // 
            // txtAuthor
            // 
            this.txtAuthor.Location = new System.Drawing.Point(347, 24);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(286, 20);
            this.txtAuthor.TabIndex = 22;
            // 
            // txtMinPrice
            // 
            this.txtMinPrice.Location = new System.Drawing.Point(347, 50);
            this.txtMinPrice.Name = "txtMinPrice";
            this.txtMinPrice.Size = new System.Drawing.Size(49, 20);
            this.txtMinPrice.TabIndex = 23;
            this.txtMinPrice.Text = "Min ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(249, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Search by Author:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(249, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Search by Price";
            // 
            // txtMaxPrice
            // 
            this.txtMaxPrice.Location = new System.Drawing.Point(418, 50);
            this.txtMaxPrice.Name = "txtMaxPrice";
            this.txtMaxPrice.Size = new System.Drawing.Size(49, 20);
            this.txtMaxPrice.TabIndex = 27;
            this.txtMaxPrice.Text = "Max";
            // 
            // btn_findAuthor
            // 
            this.btn_findAuthor.Location = new System.Drawing.Point(639, 24);
            this.btn_findAuthor.Name = "btn_findAuthor";
            this.btn_findAuthor.Size = new System.Drawing.Size(48, 20);
            this.btn_findAuthor.TabIndex = 28;
            this.btn_findAuthor.Text = "Find";
            this.btn_findAuthor.UseVisualStyleBackColor = true;
            this.btn_findAuthor.Click += new System.EventHandler(this.btn_findAuthor_Click);
            // 
            // btn_minmaxPrice
            // 
            this.btn_minmaxPrice.Location = new System.Drawing.Point(487, 50);
            this.btn_minmaxPrice.Name = "btn_minmaxPrice";
            this.btn_minmaxPrice.Size = new System.Drawing.Size(48, 20);
            this.btn_minmaxPrice.TabIndex = 29;
            this.btn_minmaxPrice.Text = "Find";
            this.btn_minmaxPrice.UseVisualStyleBackColor = true;
            this.btn_minmaxPrice.Click += new System.EventHandler(this.btn_minmaxPrice_Click);
            // 
            // btn_All
            // 
            this.btn_All.Location = new System.Drawing.Point(282, 119);
            this.btn_All.Name = "btn_All";
            this.btn_All.Size = new System.Drawing.Size(70, 24);
            this.btn_All.TabIndex = 31;
            this.btn_All.Text = "All";
            this.btn_All.UseVisualStyleBackColor = true;
            this.btn_All.Click += new System.EventHandler(this.btn_All_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.Controls.Add(this.ViewCart);
            this.panel1.Controls.Add(this.LogOut);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(243, 600);
            this.panel1.TabIndex = 32;
            // 
            // ViewCart
            // 
            this.ViewCart.AutoSize = true;
            this.ViewCart.BackColor = System.Drawing.Color.Transparent;
            this.ViewCart.Font = new System.Drawing.Font("Stencil", 12F);
            this.ViewCart.ForeColor = System.Drawing.Color.AliceBlue;
            this.ViewCart.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.ViewCart.Location = new System.Drawing.Point(67, 293);
            this.ViewCart.Name = "ViewCart";
            this.ViewCart.Size = new System.Drawing.Size(87, 19);
            this.ViewCart.TabIndex = 35;
            this.ViewCart.Text = "viewcart";
            this.ViewCart.Click += new System.EventHandler(this.label5_Click);
            // 
            // LogOut
            // 
            this.LogOut.AutoSize = true;
            this.LogOut.BackColor = System.Drawing.Color.Transparent;
            this.LogOut.Font = new System.Drawing.Font("Stencil", 12F);
            this.LogOut.ForeColor = System.Drawing.Color.AliceBlue;
            this.LogOut.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.LogOut.Location = new System.Drawing.Point(67, 324);
            this.LogOut.Name = "LogOut";
            this.LogOut.Size = new System.Drawing.Size(69, 19);
            this.LogOut.TabIndex = 34;
            this.LogOut.Text = "logout";
            this.LogOut.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Stencil", 12F);
            this.label3.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label3.Location = new System.Drawing.Point(67, 246);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 19);
            this.label3.TabIndex = 33;
            this.label3.Text = "Explore";
            // 
            // mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.btn_All);
            this.Controls.Add(this.btn_minmaxPrice);
            this.Controls.Add(this.btn_findAuthor);
            this.Controls.Add(this.txtMaxPrice);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMinPrice);
            this.Controls.Add(this.txtAuthor);
            this.Controls.Add(this.btn_Horror);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.btn_Fantasy);
            this.Controls.Add(this.btn_Mystery);
            this.Controls.Add(this.btn_Romance);
            this.Controls.Add(this.btn_Fiction);
            this.Controls.Add(this.panel1);
            this.Name = "mainform";
            this.Text = "main";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Fiction;
        private System.Windows.Forms.Button btn_Romance;
        private System.Windows.Forms.Button btn_Mystery;
        private System.Windows.Forms.Button btn_Fantasy;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btn_Horror;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.TextBox txtMinPrice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMaxPrice;
        private System.Windows.Forms.Button btn_findAuthor;
        private System.Windows.Forms.Button btn_minmaxPrice;
        private System.Windows.Forms.Button btn_All;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LogOut;
        private System.Windows.Forms.Label ViewCart;
    }
}