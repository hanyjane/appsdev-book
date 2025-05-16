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
        private int userId;
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
            Path.Combine(Application.StartupPath, "Appsdevdatabase.accdb") + ";";

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
                         FROM CartItems INNER JOIN Books ON CartItems.BookId = Books.Id
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

                            // Create panel
                            Panel itemPanel = new Panel()
                            {
                                Size = new Size(500, 100),
                                BorderStyle = BorderStyle.FixedSingle
                            };

                            // Book cover
                            PictureBox pic = new PictureBox
                            {
                                Size = new Size(60, 80),
                                Location = new Point(10, 10),
                                SizeMode = PictureBoxSizeMode.Zoom
                            };
                            if (imageBytes != null)
                                pic.Image = Image.FromStream(new MemoryStream(imageBytes));

                            // Labels
                            Label lblTitle = new Label
                            {
                                Text = $"{title} by {author}",
                                Location = new Point(80, 10),
                                AutoSize = true
                            };

                            Label lblQty = new Label
                            {
                                Text = $"Qty: {quantity}",
                                Location = new Point(80, 35),
                                AutoSize = true
                            };

                            Label lblPrice = new Label
                            {
                                Text = $"₱{price * quantity:F2}",
                                Location = new Point(80, 60),
                                ForeColor = Color.Green,
                                AutoSize = true
                            };

                            // Buttons
                            Button btnAdd = new Button { Text = "+", Location = new Point(300, 20), Size = new Size(30, 25) };
                            Button btnMinus = new Button { Text = "-", Location = new Point(335, 20), Size = new Size(30, 25) };
                            Button btnDelete = new Button { Text = "Remove", Location = new Point(370, 20), Size = new Size(70, 25) };

                            btnAdd.Click += (s, e) => { UpdateQuantity(bookId, quantity + 1); };
                            btnMinus.Click += (s, e) => { if (quantity > 1) UpdateQuantity(bookId, quantity - 1); };
                            btnDelete.Click += (s, e) => { DeleteCartItem(bookId); };

                            // Add to panel
                            itemPanel.Controls.AddRange(new Control[] { pic, lblTitle, lblQty, lblPrice, btnAdd, btnMinus, btnDelete });
                            panelCartItems.Controls.Add(itemPanel);
                        }
                    }
                }
            }

            lblTotal.Text = $"Total: ₱{totalPrice:F2}";
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

            LoadCartItems(); // Refresh UI
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

            LoadCartItems(); // Refresh UI
        }



    }
}

