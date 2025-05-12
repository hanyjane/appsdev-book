using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BOOKSTORE
{
    public partial class mainform : Form
    {
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\reyneil\Desktop\Database11.accdb";

        public mainform()
        {
            InitializeComponent();
            this.Load += new EventHandler(mainform_Load);
        }

        private void mainform_Load(object sender, EventArgs e)
        {
            List<Book> bookList = LoadBooksFromDatabase();

            for (int i = 0; i < bookList.Count; i++)
            {
                Book book = bookList[i];
                AddBookToUI(book);
            }
        }

        private List<Book> LoadBooksFromDatabase()
        {
            List<Book> books = new List<Book>();

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
   
                string query = "SELECT ID, Category, Title, Author, BookCover FROM Books";

                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                using (OleDbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Book book = new Book();
                        book.Id = reader.GetInt32(0);
                        book.Category = reader.GetString(1);
                        book.Title = reader.GetString(2);
                        book.Author = reader.GetString(3);
                        book.BookCover = reader.IsDBNull(4) ? null : (byte[])reader[4];
                        books.Add(book);
                    }
                }
            }

            return books;
        }

        private void AddBookToUI(Book book)
        {
            Panel panel = new Panel();
            panel.Size = new Size(150, 220);
            panel.BackColor = Color.White;

            PictureBox picture = new PictureBox();
            picture.Size = new Size(100, 120);
            picture.Location = new Point(25, 10);
            picture.SizeMode = PictureBoxSizeMode.Zoom;

            if (book.BookCover != null)
            {
                MemoryStream ms = new MemoryStream(book.BookCover);
                picture.Image = Image.FromStream(ms);
            }

            Label titleLabel = new Label();
            titleLabel.Text = book.Title;
            titleLabel.Location = new Point(10, 140);
            titleLabel.AutoSize = true;

            Label authorLabel = new Label();
            authorLabel.Text = "By " + book.Author;
            authorLabel.Location = new Point(10, 160);
            authorLabel.AutoSize = true;

            panel.Controls.Add(picture);
            panel.Controls.Add(titleLabel);
            panel.Controls.Add(authorLabel);

            flowLayoutPanel1.Controls.Add(panel);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bookcreation form = new Bookcreation();
            form.Show();
            this.Hide();
        }
    
    }

}
