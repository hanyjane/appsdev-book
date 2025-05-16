using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BOOKSTORE
{
    public partial class Login : Form
    {

        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                                   Application.StartupPath + @"\Appsdevdatabase.accdb;";
        public Login()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = txtLoginEmail.Text.Trim();
            string password = txtLoginPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both email and password", "Input Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check for hardcoded admin credentials
            if (email == "admin" && password == "pass")
            {
                MessageBox.Show("Welcome, Admin!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Admin_Main adminForm = new Admin_Main();
                adminForm.Show();
                this.Hide();
                return;
            }

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    string loginQuery = "SELECT ID, Username FROM Users WHERE Email = ? AND [Password] = ?";

                    using (OleDbCommand command = new OleDbCommand(loginQuery, connection))
                    {
                        command.Parameters.AddWithValue("?", email);
                        command.Parameters.AddWithValue("?", password);

                        using (OleDbDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int userId = reader.GetInt32(0);  // get ID column
                                string username = reader.GetString(1);

                                MessageBox.Show($"Welcome back, {username}!", "Login Successful",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                                mainform userForm = new mainform(userId);  // pass userId here
                                userForm.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Invalid email or password", "Login Failed",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}