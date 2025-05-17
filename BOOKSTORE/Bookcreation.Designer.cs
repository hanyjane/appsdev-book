namespace BOOKSTORE
{
    partial class Bookcreation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Bookcreation));
            this.label1 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtISBN = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.imagepath = new System.Windows.Forms.TextBox();
            this.btn_choosefile = new System.Windows.Forms.Button();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.btn_confirm = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btn_Logout = new System.Windows.Forms.Label();
            this.btn_AdminMain = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Book Title :";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(113, 42);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(157, 25);
            this.txtTitle.TabIndex = 1;
            // 
            // txtISBN
            // 
            this.txtISBN.Location = new System.Drawing.Point(113, 112);
            this.txtISBN.Name = "txtISBN";
            this.txtISBN.Size = new System.Drawing.Size(157, 25);
            this.txtISBN.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "ISBN :";
            // 
            // txtAuthor
            // 
            this.txtAuthor.Location = new System.Drawing.Point(113, 152);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(157, 25);
            this.txtAuthor.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Author :";
            // 
            // txtStock
            // 
            this.txtStock.Location = new System.Drawing.Point(113, 192);
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(157, 25);
            this.txtStock.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 195);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Stock :";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(113, 231);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(157, 25);
            this.txtPrice.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 234);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Price :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "Category :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(283, 44);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 17);
            this.label7.TabIndex = 11;
            this.label7.Text = "Book Cover :";
            // 
            // imagepath
            // 
            this.imagepath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imagepath.Location = new System.Drawing.Point(286, 74);
            this.imagepath.Multiline = true;
            this.imagepath.Name = "imagepath";
            this.imagepath.Size = new System.Drawing.Size(175, 41);
            this.imagepath.TabIndex = 12;
            // 
            // btn_choosefile
            // 
            this.btn_choosefile.Location = new System.Drawing.Point(381, 38);
            this.btn_choosefile.Name = "btn_choosefile";
            this.btn_choosefile.Size = new System.Drawing.Size(80, 29);
            this.btn_choosefile.TabIndex = 13;
            this.btn_choosefile.Text = "Choose file";
            this.btn_choosefile.UseVisualStyleBackColor = true;
            this.btn_choosefile.Click += new System.EventHandler(this.btn_choosefile_Click);
            // 
            // cmbCategory
            // 
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Items.AddRange(new object[] {
            "Fiction",
            "Romance",
            "Mystery",
            "Fantasy",
            "Horror"});
            this.cmbCategory.Location = new System.Drawing.Point(113, 75);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(157, 25);
            this.cmbCategory.TabIndex = 14;
            // 
            // btn_confirm
            // 
            this.btn_confirm.Location = new System.Drawing.Point(329, 358);
            this.btn_confirm.Name = "btn_confirm";
            this.btn_confirm.Size = new System.Drawing.Size(102, 28);
            this.btn_confirm.TabIndex = 15;
            this.btn_confirm.Text = "CONFIRM";
            this.btn_confirm.UseVisualStyleBackColor = true;
            this.btn_confirm.Click += new System.EventHandler(this.btn_confirm_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(286, 121);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(175, 231);
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(141, 273);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(129, 79);
            this.txtDescription.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 273);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(133, 17);
            this.label8.TabIndex = 19;
            this.label8.Text = "Book Description :";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.txtISBN);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtDescription);
            this.panel1.Controls.Add(this.txtTitle);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btn_confirm);
            this.panel1.Controls.Add(this.txtAuthor);
            this.panel1.Controls.Add(this.cmbCategory);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btn_choosefile);
            this.panel1.Controls.Add(this.txtStock);
            this.panel1.Controls.Add(this.imagepath);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtPrice);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(268, 151);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(478, 396);
            this.panel1.TabIndex = 20;
            // 
            // panel2
            // 
            this.panel2.AccessibleRole = System.Windows.Forms.AccessibleRole.ScrollBar;
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.btn_Logout);
            this.panel2.Controls.Add(this.btn_AdminMain);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1000, 600);
            this.panel2.TabIndex = 21;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.ErrorImage")));
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(3, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(170, 71);
            this.pictureBox2.TabIndex = 39;
            this.pictureBox2.TabStop = false;
            // 
            // btn_Logout
            // 
            this.btn_Logout.AutoSize = true;
            this.btn_Logout.BackColor = System.Drawing.Color.Transparent;
            this.btn_Logout.Font = new System.Drawing.Font("Stencil", 15F);
            this.btn_Logout.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btn_Logout.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_Logout.Location = new System.Drawing.Point(887, 20);
            this.btn_Logout.Name = "btn_Logout";
            this.btn_Logout.Size = new System.Drawing.Size(85, 24);
            this.btn_Logout.TabIndex = 38;
            this.btn_Logout.Text = "logout";
            this.btn_Logout.Click += new System.EventHandler(this.btn_Logout_Click);
            // 
            // btn_AdminMain
            // 
            this.btn_AdminMain.AutoSize = true;
            this.btn_AdminMain.BackColor = System.Drawing.Color.Transparent;
            this.btn_AdminMain.Font = new System.Drawing.Font("Stencil", 15F);
            this.btn_AdminMain.ForeColor = System.Drawing.Color.AliceBlue;
            this.btn_AdminMain.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_AdminMain.Location = new System.Drawing.Point(359, 113);
            this.btn_AdminMain.Name = "btn_AdminMain";
            this.btn_AdminMain.Size = new System.Drawing.Size(97, 24);
            this.btn_AdminMain.TabIndex = 37;
            this.btn_AdminMain.Text = "explore";
            this.btn_AdminMain.Click += new System.EventHandler(this.btn_AdminMain_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Stencil", 15F);
            this.label9.ForeColor = System.Drawing.Color.AliceBlue;
            this.label9.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label9.Location = new System.Drawing.Point(567, 113);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 24);
            this.label9.TabIndex = 35;
            this.label9.Text = "add";
            // 
            // Bookcreation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(980, 557);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Bookcreation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bookcreation";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtISBN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox imagepath;
        private System.Windows.Forms.Button btn_choosefile;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Button btn_confirm;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label btn_AdminMain;
        private System.Windows.Forms.Label btn_Logout;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}