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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.database11DataSet = new BOOKSTORE.Database11DataSet();
            this.database11DataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.database11DataSet1 = new BOOKSTORE.Database11DataSet();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_Back = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.database11DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.database11DataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.database11DataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(24, 342);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 50);
            this.button1.TabIndex = 0;
            this.button1.Text = "Add books";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(24, 242);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(106, 50);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(24, 151);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(106, 50);
            this.button3.TabIndex = 2;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(24, 56);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(106, 50);
            this.button4.TabIndex = 3;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // database11DataSet
            // 
            this.database11DataSet.DataSetName = "Database11DataSet";
            this.database11DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // database11DataSetBindingSource
            // 
            this.database11DataSetBindingSource.DataSource = this.database11DataSet;
            this.database11DataSetBindingSource.Position = 0;
            // 
            // database11DataSet1
            // 
            this.database11DataSet1.DataSetName = "Database11DataSet";
            this.database11DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(174, 12);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(592, 426);
            this.flowLayoutPanel1.TabIndex = 5;
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
            // mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_Back);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "mainform";
            this.Text = "main";
            ((System.ComponentModel.ISupportInitialize)(this.database11DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.database11DataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.database11DataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.BindingSource database11DataSetBindingSource;
        private Database11DataSet database11DataSet;
        private Database11DataSet database11DataSet1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btn_Back;
    }
}