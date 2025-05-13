using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace BOOKSTORE
{
    public partial class Bookcreation : Form
    {

        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                                  Application.StartupPath + @"\Appsdevdatabase.accdb;";
        public Bookcreation()
        {
            InitializeComponent();
        }

        private void btn_choosefile_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                imagepath.Text = fileDialog.FileName;
                pictureBox1.Image = Image.FromFile(fileDialog.FileName);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        // Confirm and save the book data into the database
        private void btn_confirm_Click(object sender, EventArgs e)
        {
            try
            {
                // Convert the image to byte array
                byte[] imageBytes = null;
                if (!string.IsNullOrEmpty(imagepath.Text))
                {
                    imageBytes = File.ReadAllBytes(imagepath.Text);
                }

                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();

                    
                    string insertQuery = @"INSERT INTO Books 
                        (Category, Title, ISBN, Author, Stock, Price, BookCover)
                        VALUES (?, ?, ?, ?, ?, ?, ?)";

                    using (OleDbCommand cmd = new OleDbCommand(insertQuery, conn))
                    {
                       
                        cmd.Parameters.AddWithValue("Category", cmbCategory.Text);
                        cmd.Parameters.AddWithValue("Title", txtTitle.Text);
                        cmd.Parameters.AddWithValue("ISBN", txtISBN.Text);
                        cmd.Parameters.AddWithValue("Author", txtAuthor.Text);
                        cmd.Parameters.AddWithValue("Stock", int.Parse(txtStock.Text));
                        cmd.Parameters.AddWithValue("Price", decimal.Parse(txtPrice.Text));
                        cmd.Parameters.AddWithValue("Description", txtDescription.Text);


                        if (imageBytes != null)
                            cmd.Parameters.Add("BookCover", OleDbType.Binary).Value = imageBytes;
                        else
                            cmd.Parameters.Add("BookCover", OleDbType.Binary).Value = DBNull.Value;

                        
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
