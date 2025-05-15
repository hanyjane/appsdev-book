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
            this.btn_Fiction = new System.Windows.Forms.Button();
            this.btn_Romance = new System.Windows.Forms.Button();
            this.btn_Mystery = new System.Windows.Forms.Button();
            this.btn_Fantasy = new System.Windows.Forms.Button();
            this.btn_Back = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_Horror = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Fiction
            // 
            this.btn_Fiction.Location = new System.Drawing.Point(55, 103);
            this.btn_Fiction.Name = "btn_Fiction";
            this.btn_Fiction.Size = new System.Drawing.Size(106, 29);
            this.btn_Fiction.TabIndex = 0;
            this.btn_Fiction.Text = "Fiction";
            this.btn_Fiction.UseVisualStyleBackColor = true;
            this.btn_Fiction.Click += new System.EventHandler(this.btn_Fiction_Click);
            // 
            // btn_Romance
            // 
            this.btn_Romance.Location = new System.Drawing.Point(167, 103);
            this.btn_Romance.Name = "btn_Romance";
            this.btn_Romance.Size = new System.Drawing.Size(106, 29);
            this.btn_Romance.TabIndex = 1;
            this.btn_Romance.Text = "Romance";
            this.btn_Romance.UseVisualStyleBackColor = true;
            this.btn_Romance.Click += new System.EventHandler(this.btn_Romance_Click);
            // 
            // btn_Mystery
            // 
            this.btn_Mystery.Location = new System.Drawing.Point(279, 103);
            this.btn_Mystery.Name = "btn_Mystery";
            this.btn_Mystery.Size = new System.Drawing.Size(106, 29);
            this.btn_Mystery.TabIndex = 2;
            this.btn_Mystery.Text = "Mystery";
            this.btn_Mystery.UseVisualStyleBackColor = true;
            this.btn_Mystery.Click += new System.EventHandler(this.btn_Mystery_Click);
            // 
            // btn_Fantasy
            // 
            this.btn_Fantasy.Location = new System.Drawing.Point(391, 103);
            this.btn_Fantasy.Name = "btn_Fantasy";
            this.btn_Fantasy.Size = new System.Drawing.Size(106, 29);
            this.btn_Fantasy.TabIndex = 3;
            this.btn_Fantasy.Text = "Fantasy";
            this.btn_Fantasy.UseVisualStyleBackColor = true;
            this.btn_Fantasy.Click += new System.EventHandler(this.btn_Fantasy_Click);
            // 
            // btn_Back
            // 
            this.btn_Back.Location = new System.Drawing.Point(12, 12);
            this.btn_Back.Name = "btn_Back";
            this.btn_Back.Size = new System.Drawing.Size(75, 23);
            this.btn_Back.TabIndex = 11;
            this.btn_Back.Text = "back";
            this.btn_Back.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(57, 149);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(698, 278);
            this.flowLayoutPanel1.TabIndex = 20;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // btn_Horror
            // 
            this.btn_Horror.Location = new System.Drawing.Point(503, 103);
            this.btn_Horror.Name = "btn_Horror";
            this.btn_Horror.Size = new System.Drawing.Size(106, 29);
            this.btn_Horror.TabIndex = 21;
            this.btn_Horror.Text = "Horror";
            this.btn_Horror.UseVisualStyleBackColor = true;
            this.btn_Horror.Click += new System.EventHandler(this.btn_Horror_Click);
            // 
            // mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_Horror);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.btn_Back);
            this.Controls.Add(this.btn_Fantasy);
            this.Controls.Add(this.btn_Mystery);
            this.Controls.Add(this.btn_Romance);
            this.Controls.Add(this.btn_Fiction);
            this.Name = "mainform";
            this.Text = "main";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Fiction;
        private System.Windows.Forms.Button btn_Romance;
        private System.Windows.Forms.Button btn_Mystery;
        private System.Windows.Forms.Button btn_Fantasy;

        private System.Windows.Forms.Button btn_Back;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btn_Horror;
    }
}