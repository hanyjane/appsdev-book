using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace BOOKSTORE
{
    public partial class Bookcreation : Form
    {
        
        public Bookcreation()
        {
            InitializeComponent();

        }

        private void btn_choosefile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                imagepath.Text = ofd.FileName;
                pictureBox1.Image = Image.FromFile(ofd.FileName); 
            }
        }

        private void btn_confirm_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] imageBytes = null;

                if (!string.IsNullOrEmpty(imagepath.Text))
                {
                    imageBytes = File.ReadAllBytes(imagepath.Text);
                }

                using (OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\reyneil\Desktop\Database11.accdb"))
                {
                    conn.Open();

                    string query = "INSERT INTO Books (Category, Title, ISBN, Author, Stock, Price, BookCover) " +
                                   "VALUES (?, ?, ?, ?, ?, ?, ?)";

                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("?", cmbCategory.Text);
                        cmd.Parameters.AddWithValue("?", txtTitle.Text);
                        cmd.Parameters.AddWithValue("?", txtISBN.Text);
                        cmd.Parameters.AddWithValue("?", txtAuthor.Text);
                        cmd.Parameters.AddWithValue("?", int.Parse(txtStock.Text));
                        cmd.Parameters.AddWithValue("?", decimal.Parse(txtPrice.Text));
                        

                        if (imageBytes != null)
                            cmd.Parameters.Add("?", OleDbType.Binary).Value = imageBytes;
                        else
                            cmd.Parameters.Add("?", OleDbType.Binary).Value = DBNull.Value;

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Book saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving book: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            mainform main = new mainform(); 
            main.Show();                    
            this.Hide();
        }
    }
}
