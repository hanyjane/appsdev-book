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
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                                   Path.Combine(Application.StartupPath, "Appsdevdatabase.accdb") + ";";


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

        private List<Book> LoadBooksFromDatabase(string category = null)
        {
            List<Book> books = new List<Book>();

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT ID, Category, Title, Author, BookCover, Price, Stock FROM Books WHERE 1=1";

                if (!string.IsNullOrEmpty(category))
                {
                    query += " AND Category = ?";
                }

                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    if (!string.IsNullOrEmpty(category))
                    {
                        cmd.Parameters.AddWithValue("?", category);
                    }

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
                                Price = reader.GetDecimal(5),
                                Stock = reader.GetInt32(6)
                            });
                        }
                    }
                }
            }

            return books;
        }


        private void AddBookToUI(Book book)
        {
            Panel panel = new Panel();
            panel.Size = new Size(150, 280);
            panel.BackColor = Color.White;
            panel.Margin = new Padding(10);

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
            titleLabel.Size = new Size(130, 20);
            titleLabel.Font = new Font("Arial", 9, FontStyle.Bold);

            Label authorLabel = new Label();
            authorLabel.Text = "By " + book.Author;
            authorLabel.Location = new Point(10, 160);
            authorLabel.Size = new Size(130, 20);
            authorLabel.Font = new Font("Arial", 8);

            Label priceLabel = new Label();
            priceLabel.Text = "₱" + book.Price.ToString("F2");
            priceLabel.Location = new Point(10, 180);
            priceLabel.Size = new Size(130, 20);
            priceLabel.ForeColor = Color.Green;

            Label stockLabel = new Label();
            stockLabel.Text = "Stock: " + book.Stock;
            stockLabel.Location = new Point(10, 200);
            stockLabel.Size = new Size(130, 20);

            Button btnAddToCart = new Button();
            btnAddToCart.Text = "Add to Cart";
            btnAddToCart.Size = new Size(120, 25);
            btnAddToCart.Location = new Point(15, 230);
            btnAddToCart.Click += (s, e) => {
                MessageBox.Show($"Added '{book.Title}' to cart!");
                // You can extend this to actually manage a cart system
            };

            panel.Controls.Add(picture);
            panel.Controls.Add(titleLabel);
            panel.Controls.Add(authorLabel);
            panel.Controls.Add(priceLabel);
            panel.Controls.Add(stockLabel);
            panel.Controls.Add(btnAddToCart);

            flowLayoutPanel1.Controls.Add(panel);
        }


        private void LoadBooksByCategory(string category)
        {
            flowLayoutPanel1.Controls.Clear();
            List<Book> books = LoadBooksFromDatabase(category);
            foreach (Book book in books)
            {
                AddBookToUI(book);
            }
        }
        //it will append the books in here 
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        //and if i click this it will filter by category which is fiction and it will show books that are fiction in flowLayoutPanel1
        private void btn_Fiction_Click(object sender, EventArgs e)
        {
            LoadBooksByCategory("Fiction");
        }

        private void btn_Romance_Click(object sender, EventArgs e)
        {
            LoadBooksByCategory("Romance");
        }

        private void btn_Mystery_Click(object sender, EventArgs e)
        {
            LoadBooksByCategory("Mystery");
        }

        private void btn_Fantasy_Click(object sender, EventArgs e)
        {
            LoadBooksByCategory("Fantasy");
        }

        private void btn_Horror_Click(object sender, EventArgs e)
        {
            LoadBooksByCategory("Horror");
        }
    }

}
