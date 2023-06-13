using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace PemogramanDesktop
{
    public partial class ItemManager : Form
    {
        private DataTable itemsTable;
        private string csvFilePath = "items.csv";

        public ItemManager()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            itemsTable = new DataTable();
            itemsTable.Columns.Add("Name", typeof(string));
            itemsTable.Columns.Add("Price", typeof(decimal));

            LoadItemsFromCSV();
            BindItemsToGrid();
        }

        private void LoadItemsFromCSV()
        {
            if (File.Exists(csvFilePath))
            {
                using (var reader = new StreamReader(csvFilePath))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');

                        if (values.Length == 2)
                        {
                            var name = values[0].Trim();
                            decimal price;

                            if (decimal.TryParse(values[1].Trim(), out price))
                            {
                                itemsTable.Rows.Add(name, price);
                            }
                        }
                    }
                }
            }
        }

        private void BindItemsToGrid()
        {
            dataGridView1.DataSource = itemsTable;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            var newItemForm = new NewItemForm();

            if (newItemForm.ShowDialog() == DialogResult.OK)
            {
                var name = newItemForm.ItemName;
                var price = newItemForm.ItemPrice;

                itemsTable.Rows.Add(name, price);
                SaveItemsToCSV();
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            // Check if a row is selected
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Get the selected row index
                int selectedIndex = dataGridView1.SelectedRows[0].Index;

                // Get the existing data
                string currentName = dataGridView1.Rows[selectedIndex].Cells["Name"].Value.ToString();
                string currentPrice = dataGridView1.Rows[selectedIndex].Cells["Price"].Value.ToString();

                var newItemForm = new NewItemForm();
                newItemForm.setInitialValue(currentName, decimal.Parse(currentPrice.Trim()));

                if (newItemForm.ShowDialog() == DialogResult.OK)
                {
                    string newName = newItemForm.ItemName;
                    string newPrice = newItemForm.ItemPrice.ToString();

                    dataGridView1.Rows[selectedIndex].Cells["Name"].Value = newName;
                    dataGridView1.Rows[selectedIndex].Cells["Price"].Value = newPrice;

                    SaveItemsToCSV();
                }

            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                var rowIndex = selectedRow.Index;

                itemsTable.Rows.RemoveAt(rowIndex);
                SaveItemsToCSV();
            }
        }

        private void SaveItemsToCSV()
        {
            using (var writer = new StreamWriter(csvFilePath))
            {
                foreach (DataRow row in itemsTable.Rows)
                {
                    writer.WriteLine($"{row["Name"]},{row["Price"]}");
                }
            }
        }
    }

    public class NewItemForm : Form
    {
        private Label nameLabel;
        private Label priceLabel;
        private TextBox nameTextBox;
        private TextBox priceTextBox;
        private Button saveButton;
        private Button cancelButton;

        public string ItemName { get; set; }
        public decimal ItemPrice { get; set; }

        public NewItemForm()
        {
            InitializeComponent();
        }

        public void setInitialValue(string itemName, decimal itemPrice)
        {
            ItemName = itemName;
            ItemPrice = itemPrice;
            nameTextBox.Text = itemName;
            priceTextBox.Text = itemPrice.ToString();
        }

        private void InitializeComponent()
        {
            nameLabel = new Label();
            priceLabel = new Label();
            nameTextBox = new TextBox();
            priceTextBox = new TextBox();
            saveButton = new Button();
            cancelButton = new Button();

            nameLabel.Text = "Name:";
            nameLabel.AutoSize = true;
            nameLabel.Location = new System.Drawing.Point(10, 10);

            priceLabel.Text = "Price:";
            priceLabel.AutoSize = true;
            priceLabel.Location = new System.Drawing.Point(10, 40);

            nameTextBox.Location = new System.Drawing.Point(70, 10);
            nameTextBox.Size = new System.Drawing.Size(120, 20);

            priceTextBox.Location = new System.Drawing.Point(70, 40);
            priceTextBox.Size = new System.Drawing.Size(120, 20);

            saveButton.Text = "Save";
            saveButton.Location = new System.Drawing.Point(10, 70);
            saveButton.Size = new System.Drawing.Size(75, 23);
            saveButton.DialogResult = DialogResult.OK;
            saveButton.Click += SaveButton_Click;

            cancelButton.Text = "Cancel";
            cancelButton.Location = new System.Drawing.Point(105, 70);
            cancelButton.Size = new System.Drawing.Size(75, 23);
            cancelButton.DialogResult = DialogResult.Cancel;

            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Controls.Add(nameLabel);
            Controls.Add(priceLabel);
            Controls.Add(nameTextBox);
            Controls.Add(priceTextBox);
            Controls.Add(saveButton);
            Controls.Add(cancelButton);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add Item";
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            ItemName = nameTextBox.Text.Trim();
            decimal price;

            if (decimal.TryParse(priceTextBox.Text.Trim(), out price))
            {
                ItemPrice = price;
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Invalid price value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
