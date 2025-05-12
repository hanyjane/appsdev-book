namespace BOOKSTORE
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtLoginPassword = new System.Windows.Forms.TextBox();
            this.pass = new System.Windows.Forms.Label();
            this.txtLoginEmail = new System.Windows.Forms.TextBox();
            this.l = new System.Windows.Forms.Label();
            this.btnLogin_Click = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Controls.Add(this.txtLoginPassword);
            this.panel1.Controls.Add(this.pass);
            this.panel1.Controls.Add(this.txtLoginEmail);
            this.panel1.Controls.Add(this.l);
            this.panel1.Controls.Add(this.btnLogin_Click);
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 581);
            this.panel1.TabIndex = 7;
            // 
            // txtLoginPassword
            // 
            this.txtLoginPassword.BackColor = System.Drawing.SystemColors.Info;
            this.txtLoginPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoginPassword.Location = new System.Drawing.Point(211, 399);
            this.txtLoginPassword.Name = "txtLoginPassword";
            this.txtLoginPassword.Size = new System.Drawing.Size(486, 31);
            this.txtLoginPassword.TabIndex = 3;
            this.txtLoginPassword.UseSystemPasswordChar = true;
            // 
            // pass
            // 
            this.pass.AutoSize = true;
            this.pass.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pass.Location = new System.Drawing.Point(235, 406);
            this.pass.Name = "pass";
            this.pass.Size = new System.Drawing.Size(92, 24);
            this.pass.TabIndex = 6;
            this.pass.Text = "Password";
            // 
            // txtLoginEmail
            // 
            this.txtLoginEmail.BackColor = System.Drawing.SystemColors.Info;
            this.txtLoginEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoginEmail.Location = new System.Drawing.Point(211, 274);
            this.txtLoginEmail.Name = "txtLoginEmail";
            this.txtLoginEmail.Size = new System.Drawing.Size(486, 31);
            this.txtLoginEmail.TabIndex = 2;
            // 
            // l
            // 
            this.l.AutoSize = true;
            this.l.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l.Location = new System.Drawing.Point(235, 278);
            this.l.Name = "l";
            this.l.Size = new System.Drawing.Size(57, 24);
            this.l.TabIndex = 5;
            this.l.Text = "Email";
            // 
            // btnLogin_Click
            // 
            this.btnLogin_Click.BackColor = System.Drawing.Color.Transparent;
            this.btnLogin_Click.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLogin_Click.BackgroundImage")));
            this.btnLogin_Click.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLogin_Click.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin_Click.Location = new System.Drawing.Point(581, 459);
            this.btnLogin_Click.Name = "btnLogin_Click";
            this.btnLogin_Click.Size = new System.Drawing.Size(116, 52);
            this.btnLogin_Click.TabIndex = 4;
            this.btnLogin_Click.UseVisualStyleBackColor = false;
            this.btnLogin_Click.Click += new System.EventHandler(this.button1_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.panel1);
            this.Name = "Login";
            this.Text = "Login";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtLoginPassword;
        private System.Windows.Forms.Label pass;
        private System.Windows.Forms.TextBox txtLoginEmail;
        private System.Windows.Forms.Label l;
        private System.Windows.Forms.Button btnLogin_Click;
    }
}