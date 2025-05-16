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
        // Database connection and user information
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                                   Path.Combine(Application.StartupPath, "Appsdevdatabase.accdb") + ";";
        private int currentUserId;
        private List<CartItem> cart = new List<CartItem>();
        private Cart cartForm = null;


        // Constructor
        public mainform(int userId)
        {
            InitializeComponent();
            currentUserId = userId;
            this.Load += mainform_Load;

        }

        // Form load event handler
        private void mainform_Load(object sender, EventArgs e)
        {
            LoadAllBooks();
        }

        // Load all books from database and display them
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

        // Create a UI panel for a book
        private void CreateBookPanel(Book book)
        {
            // Main panel for the book
            Panel bookPanel = new Panel
            {
                Size = new Size(150, 280),
                BackColor = Color.White,
                Margin = new Padding(10)
            };

            // Book cover image
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

            // Book title label
            Label titleLabel = new Label
            {
                Text = book.Title,
                Location = new Point(10, 140),
                Size = new Size(130, 20),
                Font = new Font("Times New Roman", 9, FontStyle.Bold)
            };

            // Author label
            Label authorLabel = new Label
            {
                Text = "By " + book.Author,
                Location = new Point(10, 160),
                Size = new Size(130, 20),
                Font = new Font("Times New Roman", 8)
            };

            // Price label
            Label priceLabel = new Label
            {
                Text = "₱" + book.Price.ToString("F2"),
                Location = new Point(10, 180),
                Size = new Size(130, 20),
                ForeColor = Color.Green
            };

            // Stock label
            Label stockLabel = new Label
            {
                Text = "Stock: " + book.Stock,
                Location = new Point(10, 200),
                Size = new Size(130, 20)
            };

            // Add to cart button
            Button addToCartButton = new Button
            {
                Text = book.Stock > 0 ? "Add to Cart" : "No Stock",
                Size = new Size(120, 25),
                Location = new Point(15, 230),
                Enabled = book.Stock > 0,
                Tag = book // Store book reference for event handling
            };

            addToCartButton.Click += AddToCartButton_Click;

            // Add controls to the panel
            bookPanel.Controls.Add(coverPicture);
            bookPanel.Controls.Add(titleLabel);
            bookPanel.Controls.Add(authorLabel);
            bookPanel.Controls.Add(priceLabel);
            bookPanel.Controls.Add(stockLabel);
            bookPanel.Controls.Add(addToCartButton);

            // Add panel to the flow layout
            flowLayoutPanel1.Controls.Add(bookPanel);
        }

        // Add to cart button click handler
        private void AddToCartButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Book book = (Book)button.Tag;

            if (book.Stock > 0)
            {
                // Find existing cart item or create new one
                var existingItem = cart.FirstOrDefault(c => c.Book.Id == book.Id);

                if (existingItem != null)
                {
                    existingItem.Quantity++;
                    UpdateCartItemInDatabase(currentUserId, book.Id, existingItem.Quantity);
                }
                else
                {
                    cart.Add(new CartItem { Book = book, Quantity = 1 });
                    AddCartItemToDatabase(currentUserId, book.Id, 1);
                }

                // Refresh cart if open
                if (cartForm != null && !cartForm.IsDisposed)
                {
                    cartForm.ReloadCart(); // This will update the cart UI
                }
            }
        }

        // Update stock label in the book panel
        private void UpdateStockLabel(Control panel, int newStock)
        {
            foreach (Control control in panel.Controls)
            {
                if (control is Label label && label.Text.StartsWith("Stock:"))
                {
                    label.Text = newStock > 0 ? $"Stock: {newStock}" : "Out of stock";
                    break;
                }
            }
        }

        // Add item to cart in database
        private void AddCartItemToDatabase(int userId, int bookId, int quantity)
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO CartItems (UserId, BookId, Quantity) VALUES (?, ?, ?)";

                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", userId);
                    cmd.Parameters.AddWithValue("?", bookId);
                    cmd.Parameters.AddWithValue("?", quantity);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Update cart item quantity in database
        private void UpdateCartItemInDatabase(int userId, int bookId, int quantity)
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE CartItems SET Quantity = ? WHERE UserId = ? AND BookId = ?";

                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", quantity);
                    cmd.Parameters.AddWithValue("?", userId);
                    cmd.Parameters.AddWithValue("?", bookId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void UpdateStockAfterPurchase()
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();

                foreach (CartItem item in cart)
                {
                    string query = "UPDATE Books SET Stock = Stock - ? WHERE ID = ? AND Stock >= ?";

                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("?", item.Quantity);
                        cmd.Parameters.AddWithValue("?", item.Book.Id);
                        cmd.Parameters.AddWithValue("?", item.Quantity);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }


        // View cart button click handler
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

        // Load books by category
        private void LoadBooksByCategory(string category)
        {
            flowLayoutPanel1.Controls.Clear();
            List<Book> books = LoadBooksFromDatabase(category);

            foreach (Book book in books)
            {
                CreateBookPanel(book);
            }
        }

        // Load books by author
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

        // Load books by price range
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
        private void label4_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            loginForm.Show();
            this.Hide();
        }
    }
}