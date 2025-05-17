using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class Cart : Form
    {
        // Database connection and user information
        private int userId;
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
            Path.Combine(Application.StartupPath, "Appsdevdatabase.accdb") + ";";

        // Constructor
        public Cart(int currentUserId)
        {
            InitializeComponent();
            userId = currentUserId;
            LoadCartItems();
        }

        // Load all items in the user's cart
        private void LoadCartItems()
        {
            // Clear existing items
            panelCartItems.Controls.Clear();
            decimal totalPrice = 0;

            // Connect to database
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();

                // SQL query to get cart items with book details
                string query = @"SELECT Books.Id, Books.Title, Books.Author, Books.Price, Books.BookCover, CartItems.Quantity
                         FROM CartItems 
                         INNER JOIN Books ON CartItems.BookId = Books.Id
                         WHERE CartItems.UserId = @userId";

                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                     cmd.Parameters.AddWithValue("@userId", userId);

                    // Read each cart item
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Get book details from database
                            int bookId = Convert.ToInt32(reader["Id"]);
                            string title = reader["Title"].ToString();
                            string author = reader["Author"].ToString();
                            decimal price = Convert.ToDecimal(reader["Price"]);
                            int quantity = Convert.ToInt32(reader["Quantity"]);
                            byte[] imageBytes = reader["BookCover"] as byte[];

                            // Calculate total price
                            totalPrice += price * quantity;

                            // Create a panel for this cart item
                            CreateCartItemPanel(bookId, title, author, price, quantity, imageBytes);
                        }
                    }
                }
            }

            // Update the total price label
            lblTotal.Text = $"Total: ₱{totalPrice:F2}";
        }

        // Creates a panel for a single cart item
        private void CreateCartItemPanel(int bookId, string title, string author, decimal price, int quantity, byte[] imageBytes)
        {
            // Create the main panel for this item
            Panel itemPanel = new Panel()
            {
                Size = new Size(500, 100),
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(0, 0, 0, 10), // Add some space between items
                BackColor = Color.MidnightBlue,
            };

            // Add book cover image
            PictureBox bookCover = new PictureBox
            {
                Size = new Size(60, 80),
                Location = new Point(10, 10),
                SizeMode = PictureBoxSizeMode.Zoom
            };

            if (imageBytes != null)
            {
                bookCover.Image = Image.FromStream(new MemoryStream(imageBytes));
            }

            // Add book title and author label
            Label titleLabel = new Label
            {
                Text = $"{title} by {author}",
                Location = new Point(80, 10),
                AutoSize = true,
                ForeColor = Color.AliceBlue,
            };

            // Add quantity label
            Label quantityLabel = new Label
            {
                Text = $"Quantity: {quantity}",
                Location = new Point(80, 35),
                AutoSize = true,
                ForeColor = Color.AliceBlue,
            };

            // Add price label
            Label priceLabel = new Label
            {
                Text = $"₱{price * quantity:F2}",
                Location = new Point(80, 60),
                ForeColor = Color.Green,
                AutoSize = true
            };

            // Add buttons for quantity adjustment
            Button increaseButton = new Button
            {
                Text = "+",
                Location = new Point(300, 20),
                Size = new Size(30, 25),
                Tag = bookId // Store book ID for event handling
            };

            Button decreaseButton = new Button
            {
                Text = "-",
                Location = new Point(335, 20),
                Size = new Size(30, 25),
                Tag = bookId
            };

            Button removeButton = new Button
            {
                Text = "Remove",
                Location = new Point(370, 20),
                Size = new Size(70, 25),
                Tag = bookId
            };

            // Set up button click events
            increaseButton.Click += IncreaseQuantity_Click;
            decreaseButton.Click += DecreaseQuantity_Click;
            removeButton.Click += RemoveItem_Click;

            // Add all controls to the panel
            itemPanel.Controls.Add(bookCover);
            itemPanel.Controls.Add(titleLabel);
            itemPanel.Controls.Add(quantityLabel);
            itemPanel.Controls.Add(priceLabel);
            itemPanel.Controls.Add(increaseButton);
            itemPanel.Controls.Add(decreaseButton);
            itemPanel.Controls.Add(removeButton);

            // Add the panel to the cart items container
            panelCartItems.Controls.Add(itemPanel);
            panelCartItems.Anchor = AnchorStyles.None;
        }

        // Event handler for increasing quantity
        private void IncreaseQuantity_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int bookId = (int)button.Tag;

            // Get current quantity and increase by 1
            int currentQty = GetCurrentQuantity(bookId);
            UpdateQuantity(bookId, currentQty + 1);
        }

        // Event handler for decreasing quantity
        private void DecreaseQuantity_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int bookId = (int)button.Tag;

            // Get current quantity and decrease by 1 (but not below 1)
            int currentQty = GetCurrentQuantity(bookId);
            if (currentQty > 1)
            {
                UpdateQuantity(bookId, currentQty - 1);
            }
        }
        private void purchaseButton_Click(object sender, EventArgs e)
        {

        }



        // Event handler for removing item
        private void RemoveItem_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int bookId = (int)button.Tag;

            DeleteCartItem(bookId);
        }

        // Gets the current quantity of a book in the cart
        private int GetCurrentQuantity(int bookId)
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT Quantity FROM CartItems WHERE UserId = @userId AND BookId = @bookId";

                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@bookId", bookId);

                    object result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : 0;
                }
            }
        }


        // Updates the quantity of a book in the cart
        private void UpdateQuantity(int bookId, int newQuantity)
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE CartItems SET Quantity = @qty WHERE UserId = @userId AND BookId = @bookId";

                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@qty", newQuantity);
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@bookId", bookId);
                    cmd.ExecuteNonQuery();
                }
            }

            // Refresh the cart display
            LoadCartItems();
        }

        // Removes an item from the cart
        private void DeleteCartItem(int bookId)
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM CartItems WHERE UserId = @userId AND BookId = @bookId";

                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@bookId", bookId);
                    cmd.ExecuteNonQuery();
                }
            }

            // Refresh the cart display
            LoadCartItems();
        }

        // Adds or updates a cart item (called from other forms)
        public void AddOrUpdateCartItem(int bookId, string title, string author, decimal price, int quantity, byte[] imageBytes)
        {
            // First check if the item is already in the cart
            foreach (Panel itemPanel in panelCartItems.Controls.OfType<Panel>())
            {
                if ((int)itemPanel.Tag == bookId)
                {
                    // Update the existing item's quantity and price
                    foreach (Control ctrl in itemPanel.Controls)
                    {
                        if (ctrl is Label lbl && lbl.Text.StartsWith("Quantity:"))
                        {
                            lbl.Text = $"Quantity: {quantity}";
                        }
                        else if (ctrl is Label priceLbl && priceLbl.Text.StartsWith("₱"))
                        {
                            priceLbl.Text = $"₱{price * quantity:F2}";
                        }
                    }
                    return;
                }
            }

            // If not found, create a new cart item panel
            CreateCartItemPanel(bookId, title, author, price, quantity, imageBytes);

            // Update the total price
            UpdateTotal();
        }

        // Updates the total price display
        private void UpdateTotal()
        {
            decimal total = 0;

            // Calculate total by summing up all item prices
            foreach (Panel itemPanel in panelCartItems.Controls)
            {
                foreach (Control ctrl in itemPanel.Controls)
                {
                    if (ctrl is Label lbl && lbl.Text.StartsWith("₱"))
                    {
                        string priceText = lbl.Text.Replace("₱", "");
                        total += decimal.Parse(priceText);
                    }
                }
            }

            // Update the total label
            lblTotal.Text = $"Total: ₱{total:F2}";
        }

        public void ReloadCart()
        {
            LoadCartItems(); // This method should load the cart items from the database and refresh the UI
        }

        private void purchaseButton_Click_1(object sender, EventArgs e)
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();

                // Get all cart items
                string selectQuery = "SELECT BookId, Quantity FROM CartItems WHERE UserId = @userId";
                using (OleDbCommand selectCmd = new OleDbCommand(selectQuery, conn))
                {
                    selectCmd.Parameters.AddWithValue("@userId", userId);
                    using (OleDbDataReader reader = selectCmd.ExecuteReader())
                    {
                        List<(int bookId, int quantity)> items = new List<(int, int)>();
                        while (reader.Read())
                        {
                            items.Add((Convert.ToInt32(reader["BookId"]), Convert.ToInt32(reader["Quantity"])));
                        }

                        if (items.Count == 0)
                        {
                            MessageBox.Show("Your cart is empty.");
                            return;
                        }

                        DialogResult result = MessageBox.Show("Confirm purchase?", "Checkout", MessageBoxButtons.YesNo);
                        if (result != DialogResult.Yes)
                            return;

                        foreach (var item in items)
                        {
                            // Update stock
                            string updateStockQuery = "UPDATE Books SET Stock = Stock - @qty WHERE Id = @bookId";
                            using (OleDbCommand updateCmd = new OleDbCommand(updateStockQuery, conn))
                            {
                                updateCmd.Parameters.AddWithValue("@qty", item.quantity);
                                updateCmd.Parameters.AddWithValue("@bookId", item.bookId);
                                updateCmd.ExecuteNonQuery();
                            }
                        }

                        // Clear cart
                        string deleteCartQuery = "DELETE FROM CartItems WHERE UserId = @userId";
                        using (OleDbCommand deleteCmd = new OleDbCommand(deleteCartQuery, conn))
                        {
                            deleteCmd.Parameters.AddWithValue("@userId", userId);
                            deleteCmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Purchase successful!");
                        LoadCartItems(); // Refresh cart display
                    }
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            mainform form = new mainform(); //Hides
            form.Show();
            this.Hide();
        }

        private void LogOut_Click(object sender, EventArgs e)
        {
            Login form = new Login(); //Hides
            form.Show();
            this.Hide();
        }
    }
}