using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace BOOKSTORE
{
    public partial class mainform : Form
    {

        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                                Application.StartupPath + @"\Appsdevdatabase.accdb;";
        private int currentUserId;
        private Cart cartForm = null;

      
        public mainform(int userId)
        {
            InitializeComponent();
            currentUserId = userId;
            this.Load += mainform_Load;
        }

        private void mainform_Load(object sender, EventArgs e)
        {
            LoadAllBooks();
        }
    
        private void LoadAllBooks()
        {
            flowLayoutPanel1.Controls.Clear();
            List<Book> books = LoadBooksFromDatabase();

            foreach (Book book in books)
            {
                CreateBookPanel(book);
            }
        }

        // Load books from database with optional category filter
        private List<Book> LoadBooksFromDatabase(string category = null)
        {
            List<Book> books = new List<Book>();

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT ID, Category, Title, Author, BookCover, Price, Stock FROM Books";

                // Add category filter if specified
                if (!string.IsNullOrEmpty(category))
                {
                    query += " WHERE Category = ?";
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

    
        private void CreateBookPanel(Book book)
        {    
            Panel bookPanel = new Panel
            {
                Size = new Size(150, 280),
                BackColor = Color.AliceBlue,
                Margin = new Padding(10),
            };

          
            PictureBox coverPicture = new PictureBox
            {
                Size = new Size(100, 120),
                Location = new Point(25, 10),
                SizeMode = PictureBoxSizeMode.Zoom
            };


            if (book.BookCover != null)
            {
                using (MemoryStream ms = new MemoryStream(book.BookCover))
                {
                    coverPicture.Image = Image.FromStream(ms);
                }
            }

           
            Label titleLabel = new Label
            {
                Text = book.Title,
                Location = new Point(10, 140),
                Size = new Size(130, 20),
                Font = new Font("Times New Roman", 9, FontStyle.Bold)
            };

          
            Label authorLabel = new Label
            {
                Text = "By " + book.Author,
                Location = new Point(10, 160),
                Size = new Size(130, 20),
                Font = new Font("Times New Roman", 9, FontStyle.Italic)
            };

            
            Label priceLabel = new Label
            {
                Text = "₱" + book.Price.ToString("F2"),
                Location = new Point(10, 180),
                Size = new Size(130, 20),
                ForeColor = Color.Green
            };

           
            Label stockLabel = new Label
            {
                Text = "Stock: " + book.Stock,
                Location = new Point(10, 200),
                Size = new Size(130, 20)
            };

           
            Button addToCartButton = new Button
            {
                Text = book.Stock > 0 ? "Add to Cart" : "No Stock",
                Size = new Size(120, 25),
                Location = new Point(15, 230),
                Enabled = book.Stock > 0,
                Tag = book 
            };

            addToCartButton.Click += AddToCartButton_Click;
    
            bookPanel.Controls.Add(coverPicture);
            bookPanel.Controls.Add(titleLabel);
            bookPanel.Controls.Add(authorLabel);
            bookPanel.Controls.Add(priceLabel);
            bookPanel.Controls.Add(stockLabel);
            bookPanel.Controls.Add(addToCartButton);
      
            flowLayoutPanel1.Controls.Add(bookPanel);
        }
            

        private void AddToCartButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Book book = (Book)button.Tag;

            if (book.Stock > 0)
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
         
                    string checkQuery = "SELECT Quantity FROM CartItems WHERE UserId = ? AND BookId = ?";
                    using (OleDbCommand checkCmd = new OleDbCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("?", currentUserId);
                        checkCmd.Parameters.AddWithValue("?", book.Id);

                        object result = checkCmd.ExecuteScalar();

                        if (result != null) 
                        {
                            int currentQuantity = Convert.ToInt32(result);
                            string updateQuery = "UPDATE CartItems SET Quantity = ? WHERE UserId = ? AND BookId = ?";
                            using (OleDbCommand updateCmd = new OleDbCommand(updateQuery, conn))
                            {
                                updateCmd.Parameters.AddWithValue("?", currentQuantity + 1);
                                updateCmd.Parameters.AddWithValue("?", currentUserId);
                                updateCmd.Parameters.AddWithValue("?", book.Id);
                                updateCmd.ExecuteNonQuery();
                            }
                        }
                        else 
                        {
                            string insertQuery = "INSERT INTO CartItems (UserId, BookId, Quantity) VALUES (?, ?, ?)";
                            using (OleDbCommand insertCmd = new OleDbCommand(insertQuery, conn))
                            {
                                insertCmd.Parameters.AddWithValue("?", currentUserId);
                                insertCmd.Parameters.AddWithValue("?", book.Id);
                                insertCmd.Parameters.AddWithValue("?", 1);
                                insertCmd.ExecuteNonQuery();
                            }
                        }
                    }
                }

                if (cartForm != null && !cartForm.IsDisposed)
                {
                    cartForm.ReloadCart();
                }
            }
        }

        private void ViewCart_Click(object sender, EventArgs e)
        {
            if (cartForm == null || cartForm.IsDisposed)
            {
                cartForm = new Cart(currentUserId);
                cartForm.Show();
            }
            else
            {
                cartForm.BringToFront();
            }
        }

        private void LoadBooksByCategory(string category)
        {
            flowLayoutPanel1.Controls.Clear();
            List<Book> books = LoadBooksFromDatabase(category);

            foreach (Book book in books)
            {
                CreateBookPanel(book);
            }
        }

        private List<Book> LoadBooksByAuthor(string author)
        {
            List<Book> books = new List<Book>();

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT ID, Category, Title, Author, BookCover, Price, Stock FROM Books WHERE Author LIKE ?";

                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", "%" + author + "%");

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

        private List<Book> LoadBooksByPriceRange(decimal minPrice, decimal maxPrice)
        {
            List<Book> books = new List<Book>();

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT ID, Category, Title, Author, BookCover, Price, Stock FROM Books WHERE Price BETWEEN ? AND ?";

                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", minPrice);
                    cmd.Parameters.AddWithValue("?", maxPrice);

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

        // Category filter buttons
        private void btn_All_Click(object sender, EventArgs e) => LoadAllBooks();
        private void btn_Fiction_Click(object sender, EventArgs e) => LoadBooksByCategory("Fiction");
        private void btn_Romance_Click(object sender, EventArgs e) => LoadBooksByCategory("Romance");
        private void btn_Mystery_Click(object sender, EventArgs e) => LoadBooksByCategory("Mystery");
        private void btn_Fantasy_Click(object sender, EventArgs e) => LoadBooksByCategory("Fantasy");
        private void btn_Horror_Click(object sender, EventArgs e) => LoadBooksByCategory("Horror");

        // Search by author button
        private void btn_findAuthor_Click(object sender, EventArgs e)
        {
            string author = txtAuthor.Text.Trim();

            if (string.IsNullOrWhiteSpace(author))
            {
                MessageBox.Show("Please enter an author name.");
                return;
            }

            flowLayoutPanel1.Controls.Clear();
            List<Book> books = LoadBooksByAuthor(author);

            foreach (Book book in books)
            {
                CreateBookPanel(book);
            }
        }

        // Search by price range button
        private void btn_minmaxPrice_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtMinPrice.Text.Trim(), out decimal minPrice) ||
                !decimal.TryParse(txtMaxPrice.Text.Trim(), out decimal maxPrice))
            {
                MessageBox.Show("Please enter valid numeric values for both minimum and maximum prices.");
                return;
            }

            if (minPrice > maxPrice)
            {
                MessageBox.Show("Minimum price cannot be greater than maximum price.");
                return;
            }

            flowLayoutPanel1.Controls.Clear();
            List<Book> books = LoadBooksByPriceRange(minPrice, maxPrice);

            foreach (Book book in books)
            {
                CreateBookPanel(book);
            }
        }

        // Logout button
        private void LogOut_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            loginForm.Show();
            this.Hide();
        }
    }
}