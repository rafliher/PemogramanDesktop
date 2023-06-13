using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace PemogramanDesktop
{
    public partial class UserManager : Form
    {
        private DataTable usersTable;
        private string csvFilePath = "users.csv";

        public UserManager()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            usersTable = new DataTable();
            usersTable.Columns.Add("username", typeof(string));
            usersTable.Columns.Add("password", typeof(string));
            usersTable.Columns.Add("level", typeof(string));

            LoadUsersFromCSV();
            BindItemsToGrid();
        }

        private void LoadUsersFromCSV()
        {
            if (File.Exists(csvFilePath))
            {
                using (var reader = new StreamReader(csvFilePath))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');

                        if (values.Length == 3)
                        {
                            var username = values[0].Trim();
                            var password = values[1].Trim();
                            var level = values[2].Trim();

                            usersTable.Rows.Add(username, password, level);
                        }
                    }
                }
            }
        }

        private void BindItemsToGrid()
        {
            dataGridView1.DataSource = usersTable;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            var newUserForm = new NewUserForm();

            if (newUserForm.ShowDialog() == DialogResult.OK)
            {
                var username = newUserForm.username;
                var password = newUserForm.password;
                var level = newUserForm.level;

                usersTable.Rows.Add(username, password, level);
                SaveUsersToCSV();
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                var rowIndex = selectedRow.Index;

                usersTable.Rows.RemoveAt(rowIndex);
                SaveUsersToCSV();
            }
        }

        private void SaveUsersToCSV()
        {
            using (var writer = new StreamWriter(csvFilePath))
            {
                foreach (DataRow row in usersTable.Rows)
                {
                    writer.WriteLine($"{row["username"]},{row["password"]},{row["level"]}");
                }
            }
        }
    }

    public class NewUserForm : Form
    {
        private Label usernameLabel;
        private Label passwordLabel;
        private Label levelLabel;
        private TextBox usernameTextBox;
        private TextBox passwordTextBox;
        private ComboBox levelComboBox;
        private Button saveButton;
        private Button cancelButton;

        public string username { get; private set; }
        public string password { get; private set; }
        public string level { get; private set; }

        public NewUserForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            usernameLabel = new Label();
            passwordLabel = new Label();
            levelLabel = new Label();
            usernameTextBox = new TextBox();
            passwordTextBox = new TextBox();
            levelComboBox = new ComboBox();
            saveButton = new Button();
            cancelButton = new Button();

            usernameLabel.Text = "Username:";
            usernameLabel.AutoSize = true;
            usernameLabel.Location = new System.Drawing.Point(10, 10);

            passwordLabel.Text = "Password:";
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new System.Drawing.Point(10, 40);

            levelLabel.Text = "Level:";
            levelLabel.AutoSize = true;
            levelLabel.Location = new System.Drawing.Point(10, 70);

            usernameTextBox.Location = new System.Drawing.Point(110, 10);
            usernameTextBox.Size = new System.Drawing.Size(120, 20);

            passwordTextBox.Location = new System.Drawing.Point(110, 40);
            passwordTextBox.Size = new System.Drawing.Size(120, 20);

            levelComboBox.Location = new System.Drawing.Point(110, 70);
            levelComboBox.Size = new System.Drawing.Size(120, 20);
            levelComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            levelComboBox.FormattingEnabled = true;
            levelComboBox.Items.AddRange(new object[] {
            "Manager",
            "Cashier"});

            saveButton.Text = "Save";
            saveButton.Location = new System.Drawing.Point(10, 100);
            saveButton.Size = new System.Drawing.Size(75, 23);
            saveButton.DialogResult = DialogResult.OK;
            saveButton.Click += SaveButton_Click;

            cancelButton.Text = "Cancel";
            cancelButton.Location = new System.Drawing.Point(105, 100);
            cancelButton.Size = new System.Drawing.Size(75, 23);
            cancelButton.DialogResult = DialogResult.Cancel;

            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Controls.Add(usernameLabel);
            Controls.Add(passwordLabel);
            Controls.Add(levelLabel);
            Controls.Add(usernameTextBox);
            Controls.Add(passwordTextBox);
            Controls.Add(levelComboBox);
            Controls.Add(saveButton);
            Controls.Add(cancelButton);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add User";
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            username = usernameTextBox.Text.Trim();
            password = passwordTextBox.Text.Trim();
            level = levelComboBox.Text.Trim();
        }
    }
}
