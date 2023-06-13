using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace PemogramanDesktop
{
    public partial class Records : Form
    {
        private DataTable recordsTable;
        private string csvFilePath = "records.csv";

        public Records() => InitializeComponent();

        private void MainForm_Load(object sender, EventArgs e)
        {
            recordsTable = new DataTable();
            recordsTable.Columns.Add("id", typeof(string));
            recordsTable.Columns.Add("price", typeof(string));
            recordsTable.Columns.Add("time", typeof(string));

            LoadRecordsFromCSV();
            BindItemsToGrid();
        }

        private void LoadRecordsFromCSV()
        {
            if (File.Exists(csvFilePath))
            {
                using (var reader = new StreamReader(csvFilePath))
                {
                    reader.ReadLine();
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');

                        if (values.Length == 3)
                        {
                            var id = values[0].Trim();
                            var price = values[1].Trim();
                            var time = values[2].Trim();

                            recordsTable.Rows.Add(id, price, time);
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
