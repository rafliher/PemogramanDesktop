using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PemogramanDesktop
{
    public partial class SQL : Form
    {
        private List<User> users;
        private string connectionString;


        public SQL()
        {
            InitializeComponent();
            connectionString = Properties.Settings.Default.ConnectionString;
            LoadUserData();
        }

        private void SQL_Load(object sender, EventArgs e)
        {
            LoadUserData();
        }

        private void userDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (userDataGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = userDataGridView.SelectedRows[0];
                string username = selectedRow.Cells["Username"].Value.ToString();
                User selectedUser = users.Find(u => u.Username == username);

                usernameTextBox.Text = selectedUser.Username;
                fullnameTextBox.Text = selectedUser.FullName;
                emailTextBox.Text = selectedUser.Email;
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text.Trim();
            string password = passwordTextBox.Text.Trim();
            string fullName = fullnameTextBox.Text.Trim();
            string email = emailTextBox.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            // Hash the password here before storing it in the database

            // Insert the user into the database
            InsertUser(username, password, fullName, email);

            LoadUserData();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (userDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("No user selected.");
                return;
            }

            DataGridViewRow selectedRow = userDataGridView.SelectedRows[0];
            string username = selectedRow.Cells["Username"].Value.ToString();
            User selectedUser = users.Find(u => u.Username == username);

            string newUsername = usernameTextBox.Text.Trim();
            string newPassword = passwordTextBox.Text.Trim();
            string newFullName = fullnameTextBox.Text.Trim();
            string newEmail = emailTextBox.Text.Trim();

            if (string.IsNullOrEmpty(newUsername) || string.IsNullOrEmpty(newFullName) ||
                string.IsNullOrEmpty(newEmail))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            // Hash the new password here before updating it in the database

            // Update the user in the database
            UpdateUser(selectedUser.Username, newUsername, newPassword, newFullName, newEmail);

            LoadUserData();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (userDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("No user selected.");
                return;
            }

            DataGridViewRow selectedRow = userDataGridView.SelectedRows[0];
            string username = selectedRow.Cells["Username"].Value.ToString();
            User selectedUser = users.Find(u => u.Username == username);

            // Delete the user from the database
            DeleteUser(selectedUser.Username);

            LoadUserData();
        }

        private void LoadUserData()
        {
            users = new List<User>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Users";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string username = reader["Username"].ToString();
                        string password = reader["Password"].ToString();
                        string fullName = reader["FullName"].ToString();
                        string email = reader["Email"].ToString();

                        // Create a new User object and add it to the list
                        User user = new User
                        {
                            Username = username,
                            Password = password,
                            FullName = fullName,
                            Email = email
                        };

                        users.Add(user);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

            // Bind the user data to the DataGridView
            userDataGridView.DataSource = users;
        }

        private void InsertUser(string username, string password, string fullName, string email)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Users (Username, Password, FullName, Email) " +
                               "VALUES (@Username, @Password, @FullName, @Email)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);
                command.Parameters.AddWithValue("@FullName", fullName);
                command.Parameters.AddWithValue("@Email", email);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("User added successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void UpdateUser(string oldUsername, string newUsername, string newPassword, string newFullName, string newEmail)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Users SET Username = @NewUsername, FullName = @FullName, Email = @Email";

                // Update the password if it is not empty
                if (!string.IsNullOrEmpty(newPassword))
                {
                    query += ", Password = @Password";
                }

                query += " WHERE Username = @OldUsername";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@NewUsername", newUsername);
                command.Parameters.AddWithValue("@FullName", newFullName);
                command.Parameters.AddWithValue("@Email", newEmail);
                command.Parameters.AddWithValue("@OldUsername", oldUsername);

                // Update the password parameter if it is not empty
                if (!string.IsNullOrEmpty(newPassword))
                {
                    command.Parameters.AddWithValue("@Password", newPassword);
                }

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("User updated successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void DeleteUser(string username)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Users WHERE Username = @Username";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("User deleted successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void userDataGridView_SelectionChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (userDataGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = userDataGridView.SelectedRows[0];
                string username = selectedRow.Cells["Username"].Value.ToString();
                User selectedUser = users.Find(u => u.Username == username);

                usernameTextBox.Text = selectedUser.Username;
                fullnameTextBox.Text = selectedUser.FullName;
                emailTextBox.Text = selectedUser.Email;
            }
        }
    }
}
