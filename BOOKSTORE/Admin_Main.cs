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

        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                                  Application.StartupPath + @"\Appsdevdatabase.accdb;";
        public Admin_Main()
        {
            InitializeComponent();
            this.Load += Admin_Main_Load;
        }
            
        private void Admin_Main_Load(object sender, EventArgs e)
        {
            List<Book> bookList = LoadBooksFromDatabase();

            foreach (Book book in bookList)
            {
                AddBookCardToUI(book);
            }
        }

        private List<Book> LoadBooksFromDatabase()
        {
            List<Book> books = new List<Book>();

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT ID, Category, Title, Author, BookCover, ISBN, Price, Stock FROM Books";

                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                using (OleDbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        books.Add(new Book
                        {
                            Id = reader.GetInt32(0),
                            Category = reader.GetString(1),
                            Title = reader.GetString(2),
                            Author = reader.GetString(3),
                            BookCover = reader.IsDBNull(4) ? null : (byte[])reader[4],
                            ISBN = reader.GetString(5),
                            Price = reader.GetDecimal(6),
                            Stock = reader.GetInt32(7)
                        });
                    }
                }
            }
            return books;
        }
        private void AddBookCardToUI(Book book)
        {
            BookCard bookCard = new BookCard();

            Image coverImage = null;
            if (book.BookCover != null)
            {
                using (MemoryStream ms = new MemoryStream(book.BookCover))
                {
                    coverImage = Image.FromStream(ms);
                }
            }
            

            bookCard.SetBookData(
                cover: coverImage,
                title: book.Title,
                author: book.Author,
                category: book.Category,
                isbn: book.ISBN,
                price: book.Price,
                stock: book.Stock
            );

            // Style the card
            bookCard.Size = new Size(200, 350); // Adjust size as needed
            bookCard.Margin = new Padding(10);

            // Handle button clicks
            bookCard.Button1Click += (s, e) => EditBook(book.Id);
            bookCard.Button2Click += (s, e) => DeleteBook(book.Id);

            flowLayoutPanel1.Controls.Add(bookCard);
        }

        private void EditBook(int bookID)
        {
            // Implement edit functionality
            MessageBox.Show($"Editing book ID: {bookID}");
        }

        private void DeleteBook(int bookID)
        {
            if (MessageBox.Show("Delete this book?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM Books WHERE ID = @BookID";
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@BookID", bookID);
                        cmd.ExecuteNonQuery();
                    }
                }
                // Refresh the book display
                flowLayoutPanel1.Controls.Clear();
                Admin_Main_Load(null, EventArgs.Empty);
            }
        }

       
        private void btn_Explore_Click(object sender, EventArgs e)
        {

        }

        private void btn_Update_Click(object sender, EventArgs e)
        {

        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            Bookcreation form = new Bookcreation();
            form.Show();
            this.Hide();
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {

        }
    }
}
