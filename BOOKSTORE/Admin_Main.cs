using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace BOOKSTORE
{
    public partial class Admin_Main : Form
    {
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\reyneil\Desktop\Database11.accdb";

        public Admin_Main()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            List<Book> bookList = LoadBooksFromDatabase();
            DisplayBooks(bookList);
        }

        private List<Book> LoadBooksFromDatabase()
        {
            List<Book> books = new List<Book>();

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT ID, Category, Title, ISBN, Author, Stock, Price, BookCover, Description FROM Books";

                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                using (OleDbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Book book = new Book();
                        book.Id = reader.GetInt32(0);
                        book.Category = reader.GetString(1);
                        book.Title = reader.GetString(2);
                        book.ISBN = reader.GetString(3);
                        book.Author = reader.GetString(4);
                        book.Stock = reader.GetInt32(5);
                        book.Price = reader.GetDecimal(6);
                        book.BookCover = reader.IsDBNull(7) ? null : (byte[])reader[7];
                        book.Description = reader.IsDBNull(8) ? string.Empty : reader.GetString(8);
                        books.Add(book);
                    }
                }
            }

            return books;
        }

        private void DisplayBooks(List<Book> books)
        {
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Padding = new Padding(20);
            flowLayoutPanel1.AutoScroll = true;

            foreach (Book book in books)
            {
                Panel bookPanel = CreateBookPanel(book);
                flowLayoutPanel1.Controls.Add(bookPanel);
            }
        }

        private Panel CreateBookPanel(Book book)
        {
            Panel panel = new Panel();
            panel.Size = new Size(300, 350);
            panel.BackColor = Color.White;
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.Margin = new Padding(15);
            panel.Padding = new Padding(10);

            // Book Cover Image
            PictureBox pictureBox = new PictureBox();
            pictureBox.Size = new Size(180, 220);
            pictureBox.Location = new Point(50, 15);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.BackColor = Color.WhiteSmoke;

            if (book.BookCover != null)
            {
                using (MemoryStream ms = new MemoryStream(book.BookCover))
                {
                    pictureBox.Image = Image.FromStream(ms);
                }
            }
            else
            {
               // pictureBox.Image = Properties.Resources.DefaultBookCover; // Add a default image to your resources
            }

            // Title Label
            Label titleLabel = new Label();
            titleLabel.Text = book.Title;
            titleLabel.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            titleLabel.Location = new Point(10, 240);
            titleLabel.AutoSize = false;
            titleLabel.Size = new Size(280, 40);
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;

            // Author Label
            Label authorLabel = new Label();
            authorLabel.Text = "by " + book.Author;
            authorLabel.Font = new Font("Segoe UI", 8);
            authorLabel.Location = new Point(10, 280);
            authorLabel.AutoSize = false;
            authorLabel.Size = new Size(280, 20);
            authorLabel.TextAlign = ContentAlignment.MiddleCenter;

            // Category Label
            Label categoryLabel = new Label();
            categoryLabel.Text = book.Category;
            categoryLabel.Font = new Font("Segoe UI", 8, FontStyle.Italic);
            categoryLabel.ForeColor = Color.Gray;
            categoryLabel.Location = new Point(10, 300);
            categoryLabel.AutoSize = false;
            categoryLabel.Size = new Size(280, 20);
            categoryLabel.TextAlign = ContentAlignment.MiddleCenter;

            // ISBN Label
            Label isbnLabel = new Label();
            isbnLabel.Text = "ISBN-10: " + book.ISBN;
            isbnLabel.Font = new Font("Segoe UI", 8);
            isbnLabel.Location = new Point(10, 320);
            isbnLabel.AutoSize = false;
            isbnLabel.Size = new Size(280, 20);
            isbnLabel.TextAlign = ContentAlignment.MiddleCenter;

            // Price Label
            Label priceLabel = new Label();
            priceLabel.Text = "Php. " + book.Price.ToString("N2");
            priceLabel.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            priceLabel.ForeColor = Color.DarkGreen;
            priceLabel.Location = new Point(10, 340);
            priceLabel.AutoSize = false;
            priceLabel.Size = new Size(140, 20);
            priceLabel.TextAlign = ContentAlignment.MiddleLeft;

            // Stock Label
            Label stockLabel = new Label();
            stockLabel.Text = "(" + book.Stock + ") in stock";
            stockLabel.Font = new Font("Segoe UI", 8);
            stockLabel.Location = new Point(150, 340);
            stockLabel.AutoSize = false;
            stockLabel.Size = new Size(140, 20);
            stockLabel.TextAlign = ContentAlignment.MiddleRight;

            // Order Button
            Button orderButton = new Button();
            orderButton.Text = "Order Now";
            orderButton.BackColor = Color.SteelBlue;
            orderButton.ForeColor = Color.White;
            orderButton.FlatStyle = FlatStyle.Flat;
            orderButton.FlatAppearance.BorderSize = 0;
            orderButton.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            orderButton.Size = new Size(100, 30);
            orderButton.Location = new Point(90, 370);
            orderButton.Cursor = Cursors.Hand;
            orderButton.Click += (sender, e) => OrderButton_Click(book.Id);

            // Add controls to panel
            panel.Controls.Add(pictureBox);
            panel.Controls.Add(titleLabel);
            panel.Controls.Add(authorLabel);
            panel.Controls.Add(categoryLabel);
            panel.Controls.Add(isbnLabel);
            panel.Controls.Add(priceLabel);
            panel.Controls.Add(stockLabel);
            panel.Controls.Add(orderButton);

            // Add hover effect
            panel.MouseEnter += (sender, e) => panel.BackColor = Color.AliceBlue;
            panel.MouseLeave += (sender, e) => panel.BackColor = Color.White;

            return panel;
        }

        private void OrderButton_Click(int bookId)
        {
            // Handle order button click
            MessageBox.Show($"Order placed for book ID: {bookId}", "Order Confirmation",
                           MessageBoxButtons.OK, MessageBoxIcon.Information);
        }



        private void button1_Click(object sender, EventArgs e)
        {

        }

       
    }
}
