using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace DesktopQuiz1_CaffeeShopToFile
{
    public partial class Records : Form
    {
        private DataTable recordsTable;
        private string csvFilePath = "records.csv";

        public Records() => InitializeComponent();

        private void MainForm_Load(object sender, EventArgs e)
        {
            recordsTable = new DataTable();
            recordsTable.Columns.Add("name", typeof(string));
            recordsTable.Columns.Add("amount", typeof(string));
            recordsTable.Columns.Add("price", typeof(string));
            recordsTable.Columns.Add("time", typeof(string));

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

                        if (values.Length == 4)
                        {
                            var username = values[0].Trim();
                            var password = values[1].Trim();
                            var level = values[2].Trim();
                            var level2 = values[3].Trim();

                            recordsTable.Rows.Add(username, password, level, level2);
                        }
                    }
                }
            }
        }

        private void BindItemsToGrid()
        {
            dataGridView1.DataSource = recordsTable;
        }
    }

}
