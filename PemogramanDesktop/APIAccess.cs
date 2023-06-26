using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace PemogramanDesktop
{
    public partial class APIAccess : Form
    {
        private const string apiUrl = "https://retoolapi.dev/VFa5wi/data";

        public APIAccess()
        {
            InitializeComponent();
            LoadDataFromAPI();
        }

        private async void LoadDataFromAPI()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string jsonData = await client.GetStringAsync(apiUrl);

                    List<DataObject> data = JsonConvert.DeserializeObject<List<DataObject>>(jsonData);
                    APIDataGridView.DataSource = data;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while loading data from the API: {ex.Message}");
                }
            }
        }
    }

    public class DataObject
    {
        public int id { get; set; }
        public string Nama { get; set; }
        public string Email { get; set; }
        public string Perusahaan { get; set; }
    }
}
