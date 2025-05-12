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
            this.txtLoginPassword = new System.Windows.Forms.TextBox();
            this.txtLoginEmail = new System.Windows.Forms.TextBox();
            this.btnLogin_Click = new System.Windows.Forms.Button();
            this.l = new System.Windows.Forms.Label();
            this.pass = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtLoginPassword
            // 
            this.txtLoginPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoginPassword.Location = new System.Drawing.Point(316, 222);
            this.txtLoginPassword.Name = "txtLoginPassword";
            this.txtLoginPassword.Size = new System.Drawing.Size(220, 31);
            this.txtLoginPassword.TabIndex = 3;
            // 
            // txtLoginEmail
            // 
            this.txtLoginEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoginEmail.Location = new System.Drawing.Point(316, 149);
            this.txtLoginEmail.Name = "txtLoginEmail";
            this.txtLoginEmail.Size = new System.Drawing.Size(220, 31);
            this.txtLoginEmail.TabIndex = 2;
            // 
            // btnLogin_Click
            // 
            this.btnLogin_Click.Location = new System.Drawing.Point(340, 299);
            this.btnLogin_Click.Name = "btnLogin_Click";
            this.btnLogin_Click.Size = new System.Drawing.Size(175, 30);
            this.btnLogin_Click.TabIndex = 4;
            this.btnLogin_Click.Text = "login";
            this.btnLogin_Click.UseVisualStyleBackColor = true;
            this.btnLogin_Click.Click += new System.EventHandler(this.button1_Click);
            // 
            // l
            // 
            this.l.AutoSize = true;
            this.l.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l.Location = new System.Drawing.Point(232, 153);
            this.l.Name = "l";
            this.l.Size = new System.Drawing.Size(57, 24);
            this.l.TabIndex = 5;
            this.l.Text = "Email";
            // 
            // pass
            // 
            this.pass.AutoSize = true;
            this.pass.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pass.Location = new System.Drawing.Point(197, 226);
            this.pass.Name = "pass";
            this.pass.Size = new System.Drawing.Size(92, 24);
            this.pass.TabIndex = 6;
            this.pass.Text = "Password";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pass);
            this.Controls.Add(this.l);
            this.Controls.Add(this.btnLogin_Click);
            this.Controls.Add(this.txtLoginPassword);
            this.Controls.Add(this.txtLoginEmail);
            this.Name = "Login";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtLoginPassword;
        private System.Windows.Forms.TextBox txtLoginEmail;
        private System.Windows.Forms.Button btnLogin_Click;
        private System.Windows.Forms.Label l;
        private System.Windows.Forms.Label pass;
    }
}