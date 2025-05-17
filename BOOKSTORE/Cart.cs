using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace BOOKSTORE
{
    public partial class Cart : Form
    {
        private int userId;
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                          Application.StartupPath + @"\Appsdevdatabase.accdb;";

        public Cart(int currentUserId)
        {
            InitializeComponent();
            userId = currentUserId;
            LoadCartItems();
        }

        private void LoadCartItems()
        {
            panelCartItems.Controls.Clear();
            decimal totalPrice = 0;

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                string query = @"SELECT Books.Id, Books.Title, Books.Author, Books.Price, Books.BookCover, CartItems.Quantity
                                 FROM CartItems 
                                 INNER JOIN Books ON CartItems.BookId = Books.Id
                                 WHERE CartItems.UserId = @userId";

                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);

                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int bookId = Convert.ToInt32(reader["Id"]);
                            string title = reader["Title"].ToString();
                            string author = reader["Author"].ToString();
                            decimal price = Convert.ToDecimal(reader["Price"]);
                            int quantity = Convert.ToInt32(reader["Quantity"]);
                            byte[] imageBytes = reader["BookCover"] as byte[];

                            totalPrice += price * quantity;
                            CreateCartItemPanel(bookId, title, author, price, quantity, imageBytes);
                        }
                    }
                }
            }

            lblTotal.Text = $"Total: ₱{totalPrice:F2}";
        }

        private void CreateCartItemPanel(int bookId, string title, string author, decimal price, int quantity, byte[] imageBytes)
        {
            Panel itemPanel = new Panel()
            {
                Size = new Size(500, 100),
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(0, 0, 0, 10),
                BackColor = Color.MidnightBlue,
            };

            PictureBox bookCover = new PictureBox
            {
                Size = new Size(60, 80),
                Location = new Point(10, 10),
                SizeMode = PictureBoxSizeMode.Zoom
            };

            if (imageBytes != null)
                bookCover.Image = Image.FromStream(new MemoryStream(imageBytes));

            Label titleLabel = new Label
            {
                Text = $"{title} by {author}",
                Location = new Point(80, 10),
                AutoSize = true,
                ForeColor = Color.AliceBlue,
            };

            Label quantityLabel = new Label
            {
                Text = $"Quantity: {quantity}",
                Location = new Point(80, 35),
                AutoSize = true,
                ForeColor = Color.AliceBlue,
            };

            Label priceLabel = new Label
            {
                Text = $"₱{price * quantity:F2}",
                Location = new Point(80, 60),
                ForeColor = Color.Green,
                AutoSize = true
            };

            Button increaseButton = new Button
            {
                Text = "+",
                Location = new Point(300, 20),
                Size = new Size(30, 25),
                Tag = bookId
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

            increaseButton.Click += IncreaseQuantity_Click;
            decreaseButton.Click += DecreaseQuantity_Click;
            removeButton.Click += RemoveItem_Click;

            itemPanel.Controls.Add(bookCover);
            itemPanel.Controls.Add(titleLabel);
            itemPanel.Controls.Add(quantityLabel);
            itemPanel.Controls.Add(priceLabel);
            itemPanel.Controls.Add(increaseButton);
            itemPanel.Controls.Add(decreaseButton);
            itemPanel.Controls.Add(removeButton);

            panelCartItems.Controls.Add(itemPanel);
            panelCartItems.Anchor = AnchorStyles.None;
        }

        private void IncreaseQuantity_Click(object sender, EventArgs e)
        {
            int bookId = (int)((Button)sender).Tag;
            int currentQty = GetCurrentQuantity(bookId);
            UpdateQuantity(bookId, currentQty + 1);
        }

        private void DecreaseQuantity_Click(object sender, EventArgs e)
        {
            int bookId = (int)((Button)sender).Tag;
            int currentQty = GetCurrentQuantity(bookId);
            if (currentQty > 1)
                UpdateQuantity(bookId, currentQty - 1);
        }

        private void RemoveItem_Click(object sender, EventArgs e)
        {
            int bookId = (int)((Button)sender).Tag;
            DeleteCartItem(bookId);
        }

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

            LoadCartItems();
        }

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

            LoadCartItems();
        }

        public void ReloadCart()
        {
            LoadCartItems();
        }

        private void purchaseButton_Click_1(object sender, EventArgs e)
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();

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

                        if (MessageBox.Show("Confirm purchase?", "Checkout", MessageBoxButtons.YesNo) != DialogResult.Yes)
                            return;

                        foreach (var item in items)
                        {
                            string updateStockQuery = "UPDATE Books SET Stock = Stock - @qty WHERE Id = @bookId";
                            using (OleDbCommand updateCmd = new OleDbCommand(updateStockQuery, conn))
                            {
                                updateCmd.Parameters.AddWithValue("@qty", item.quantity);
                                updateCmd.Parameters.AddWithValue("@bookId", item.bookId);
                                updateCmd.ExecuteNonQuery();
                            }
                        }

                        string deleteCartQuery = "DELETE FROM CartItems WHERE UserId = @userId";
                        using (OleDbCommand deleteCmd = new OleDbCommand(deleteCartQuery, conn))
                        {
                            deleteCmd.Parameters.AddWithValue("@userId", userId);
                            deleteCmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Purchase successful!");
                        LoadCartItems();
                    }
                }
            }
        }

        private void LogOut_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }
    }
}
