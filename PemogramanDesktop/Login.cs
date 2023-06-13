using System.IO;
using System.Linq;

namespace PemogramanDesktop
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void returnAdminMenu()
        {
            AdminPanel adminPanel = new AdminPanel();
            this.Hide();
            adminPanel.ShowDialog();
            usernameTextBox.Text = string.Empty;
            passwordTextBox.Text = string.Empty;
            this.Show();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text.Trim();
            string password = passwordTextBox.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return;
            }

            if (username == "admin" && password == "admin")
            {
                returnAdminMenu();
                return;
            }

            string[] lines = new string[] { };
            try
            {
                lines = File.ReadAllLines("users.csv");
            }
            catch (Exception)
            {
                returnAdminMenu();
                return;
            }

            foreach (string line in lines) // Skip the header line
            {
                string[] values = line.Split(',');

                string user = values[0].Trim();
                string pass = values[1].Trim();
                string level = values[2].Trim();

                if (user == username && pass == password)
                {
                    if (level == "Admin")
                    {
                        returnAdminMenu();
                    }
                    else if (level == "Manager")
                    {
                        ManagerPanel managerPanel = new ManagerPanel();
                        this.Hide();
                        managerPanel.ShowDialog();
                        usernameTextBox.Text = string.Empty;
                        passwordTextBox.Text = string.Empty;
                        this.Show();
                        return;
                    }
                    else if (level == "Cashier")
                    {
                        Menu menu = new Menu();
                        this.Hide();
                        menu.ShowDialog();
                        usernameTextBox.Text = string.Empty;
                        passwordTextBox.Text = string.Empty;
                        this.Show();
                        return;
                    }
                }
            }

            MessageBox.Show("Invalid credentials");
        }
    }
}