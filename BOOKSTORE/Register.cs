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
    public partial class Register : Form
    {
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\reyneil\Desktop\Database11.accdb;";

        public Register()//test test 
        {
            InitializeComponent();
            txtPassword.UseSystemPasswordChar = true;
            txtConfirmPassword.UseSystemPasswordChar = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Passwords don't match!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
            if (string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please fill in all fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

           
            if (!txtEmail.Text.Contains("@") || !txtEmail.Text.Contains("."))
            {
                MessageBox.Show("Please enter a valid email address!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    
                    string checkEmailQuery = "SELECT COUNT(*) FROM Users WHERE Email = ?";
                    using (OleDbCommand checkCommand = new OleDbCommand(checkEmailQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("?", txtEmail.Text);
                        int existingUsers = (int)checkCommand.ExecuteScalar();

                        if (existingUsers > 0)
                        {
                            MessageBox.Show("This email is already registered!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                   
                    string insertQuery = "INSERT INTO Users (Username, Email, [Password]) VALUES (?, ?, ?)";
                    using (OleDbCommand command = new OleDbCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("?", txtUsername.Text);
                        command.Parameters.AddWithValue("?", txtEmail.Text);
                        command.Parameters.AddWithValue("?", txtPassword.Text);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Account created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Login loginForm = new Login(); 
                            loginForm.Show();                   
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Registration failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            bool show = chkShowPassword.Checked;

            txtPassword.UseSystemPasswordChar = !show;
            txtConfirmPassword.UseSystemPasswordChar = !show;
        }
    }
}