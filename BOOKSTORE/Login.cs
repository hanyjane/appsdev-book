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

        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\reyneil\Desktop\Database11.accdb;";
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(l.Text) ||
                string.IsNullOrWhiteSpace(pass.Text))
            {
                MessageBox.Show("Please enter both email and password", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                   
                    string loginQuery = "SELECT Username FROM Users WHERE Email = ? AND [Password] = ?";

                    using (OleDbCommand command = new OleDbCommand(loginQuery, connection))
                    {
                        command.Parameters.AddWithValue("?", txtLoginEmail.Text);
                        command.Parameters.AddWithValue("?", txtLoginPassword.Text);

                       
                        object result = command.ExecuteScalar();

                        if (result != null) 
                        {
                            string username = result.ToString();
                            MessageBox.Show($"Welcome back, {username}!", "Login Successful",
                                          MessageBoxButtons.OK, MessageBoxIcon.Information);

                           
                           mainform mainForm = new mainform();
                            mainForm.Show();
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
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Database Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
