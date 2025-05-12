using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BOOKSTORE
{
    public partial class Admin_Main : Form
    {
        public Admin_Main()
        {
            InitializeComponent();
        }
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\reyneil\Desktop\Database11.accdb";

        private void Admin_Main_Load(object sender, EventArgs e)
        {
            LoadBooks();
        }

        private void LoadBooks()
        {
            flowLayoutPanelBooks.Controls.Clear();

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Books";

                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                using (OleDbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Convert image bytes to Image
                        byte[] imageBytes = reader["BookCover"] as byte[];
                        Image bookImage = null;
                        if (imageBytes != null)
                        {
                            using (MemoryStream ms = new MemoryStream(imageBytes))
                            {
                                bookImage = Image.FromStream(ms);
                            }
                        }

                        // Create and fill the BookCard control
                        BookCard card = new BookCard();
                        card.SetBookData(
                            bookImage,
                            reader["Title"].ToString(),
                            reader["Author"].ToString(),
                            reader["Category"].ToString(),
                            reader["ISBN"].ToString(),
                            Convert.ToDecimal(reader["Price"]),
                            Convert.ToInt32(reader["Stock"]),
                            "Description here..." // Optional: add a description column in your DB
                        );

                        // Add to FlowLayoutPanel
                        flowLayoutPanelBooks.Controls.Add(card);
                    }
                }
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
