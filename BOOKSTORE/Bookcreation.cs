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
                byte[] imageBytes = null;
                if (!string.IsNullOrEmpty(imagepath.Text))
                {
                    imageBytes = File.ReadAllBytes(imagepath.Text);
                }

                if (!int.TryParse(txtStock.Text, out int stock))
                {
                    MessageBox.Show("Invalid stock value.");
                    return;
                }

                if (!decimal.TryParse(txtPrice.Text, out decimal price))
                {
                    MessageBox.Show("Invalid price value.");
                    return;
                }

                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();

                    string insertQuery = @"INSERT INTO Books 
                (Category, Title, ISBN, Author, Stock, Price, Description, BookCover)
                VALUES (?, ?, ?, ?, ?, ?, ?, ?)";

                    using (OleDbCommand cmd = new OleDbCommand(insertQuery, conn))
                    {
                        cmd.Parameters.Add("Category", OleDbType.VarChar).Value = cmbCategory.Text;
                        cmd.Parameters.Add("Title", OleDbType.VarChar).Value = txtTitle.Text;
                        cmd.Parameters.Add("ISBN", OleDbType.VarChar).Value = txtISBN.Text;
                        cmd.Parameters.Add("Author", OleDbType.VarChar).Value = txtAuthor.Text;
                        cmd.Parameters.Add("Stock", OleDbType.Integer).Value = stock;
                        cmd.Parameters.Add("Price", OleDbType.Currency).Value = price;
                        cmd.Parameters.Add("Description", OleDbType.VarChar).Value = txtDescription.Text;
                        cmd.Parameters.Add("BookCover", OleDbType.Binary).Value = imageBytes ?? (object)DBNull.Value;

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

        private void Bookcreation_Load(object sender, EventArgs e)
        {

        }
    }
}
