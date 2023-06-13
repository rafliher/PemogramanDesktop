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

        private void loginButton_Click(object sender, EventArgs e)
        {
            String username = usernameTextBox.Text.Trim();
            String password = passwordTextBox.Text.Trim();

            if (username == null || password == null )
            {
                return;
            }
            if (password == "admin")
            {
                AdminPanel adminPanel = new();
                this.Hide();
                adminPanel.ShowDialog();
                this.Show();
            }
            else if (password == "1234")
            {
                Menu menu = new();
                this.Hide();
                menu.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Invalid credential");
            }
        }
    }
}