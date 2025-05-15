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
            this.SuspendLayout();
            // 
            // mainform
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "mainform";
            this.ResumeLayout(false);

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
    }
}