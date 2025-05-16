namespace BOOKSTORE
{
    partial class Admin_Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin_Main));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_Update = new System.Windows.Forms.Button();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.LogOut = new System.Windows.Forms.Label();
            this.Add = new System.Windows.Forms.Label();
            this.Explore = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Controls.Add(this.vScrollBar1);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(54, 424);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(907, 306);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // btn_Update
            // 
            this.btn_Update.Location = new System.Drawing.Point(256, 393);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(95, 26);
            this.btn_Update.TabIndex = 1;
            this.btn_Update.Text = "Update";
            this.btn_Update.UseVisualStyleBackColor = true;
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.Location = new System.Drawing.Point(133, 393);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(104, 26);
            this.btn_Delete.TabIndex = 3;
            this.btn_Delete.Text = "Delete";
            this.btn_Delete.UseVisualStyleBackColor = true;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btn_Update);
            this.panel2.Controls.Add(this.btn_Delete);
            this.panel2.Controls.Add(this.pictureBox4);
            this.panel2.Controls.Add(this.LogOut);
            this.panel2.Controls.Add(this.Add);
            this.panel2.Controls.Add(this.Explore);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1000, 700);
            this.panel2.TabIndex = 33;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(3, 0);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(170, 71);
            this.pictureBox4.TabIndex = 41;
            this.pictureBox4.TabStop = false;
            // 
            // LogOut
            // 
            this.LogOut.AutoSize = true;
            this.LogOut.BackColor = System.Drawing.Color.Transparent;
            this.LogOut.Font = new System.Drawing.Font("Stencil", 15F);
            this.LogOut.ForeColor = System.Drawing.Color.MidnightBlue;
            this.LogOut.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.LogOut.Location = new System.Drawing.Point(855, 27);
            this.LogOut.Name = "LogOut";
            this.LogOut.Size = new System.Drawing.Size(85, 24);
            this.LogOut.TabIndex = 37;
            this.LogOut.Text = "logout";
            this.LogOut.Click += new System.EventHandler(this.LogOut_Click);
            // 
            // Add
            // 
            this.Add.AutoSize = true;
            this.Add.BackColor = System.Drawing.Color.Transparent;
            this.Add.Font = new System.Drawing.Font("Stencil", 15F);
            this.Add.ForeColor = System.Drawing.Color.AliceBlue;
            this.Add.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.Add.Location = new System.Drawing.Point(583, 126);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(48, 24);
            this.Add.TabIndex = 36;
            this.Add.Text = "add";
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // Explore
            // 
            this.Explore.AutoSize = true;
            this.Explore.BackColor = System.Drawing.Color.Transparent;
            this.Explore.Font = new System.Drawing.Font("Stencil", 15F);
            this.Explore.ForeColor = System.Drawing.Color.AliceBlue;
            this.Explore.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.Explore.Location = new System.Drawing.Point(324, 126);
            this.Explore.Name = "Explore";
            this.Explore.Size = new System.Drawing.Size(97, 24);
            this.Explore.TabIndex = 34;
            this.Explore.Text = "Explore";
            this.Explore.Click += new System.EventHandler(this.Explore_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Stencil", 25F);
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label1.Location = new System.Drawing.Point(168, 243);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(290, 80);
            this.label1.TabIndex = 42;
            this.label1.Text = "Welcome back, \r\nADMIN!";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(0, 0);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(20, 241);
            this.vScrollBar1.TabIndex = 4;
            // 
            // Admin_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel2);
            this.Name = "Admin_Main";
            this.Text = "Admin_Main";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label Explore;
        private System.Windows.Forms.Label Add;
        private System.Windows.Forms.Label LogOut;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.VScrollBar vScrollBar1;
    }
}