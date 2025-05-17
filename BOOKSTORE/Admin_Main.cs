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
                string query = "SELECT ID, Category, Title, Author, BookCover, ISBN, Price, Stock, Description FROM Books";

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
                            Stock = reader.GetInt32(7),
                            Description = reader.GetString(8)
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
                stock: book.Stock,
                description: book.Description
            );
            flowLayoutPanel2.Controls.Add(bookCard);
        }  

        private void Add_Click(object sender, EventArgs e)
        {
            Bookcreation form = new Bookcreation();
            form.Show();
            this.Hide();
        }

        private void LogOut_Click(object sender, EventArgs e)
        {
            Login form = new Login();
            form.Show();
            this.Hide();
        }

        private void Explore_Click(object sender, EventArgs e)
        {
            Admin_Main form = new Admin_Main();            
            form.Show();
            this.Hide();
        }
       
    }
}
