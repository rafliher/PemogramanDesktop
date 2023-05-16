using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace Desktop5_CaffeeShopWithLogin
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MenuAddDetail menuAddDetail = new("Espresso", 10000);
            menuAddDetail.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MenuAddDetail menuAddDetail = new("Latte", 15000);
            menuAddDetail.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MenuAddDetail menuAddDetail = new("Cappuccino", 12000);
            menuAddDetail.ShowDialog();
        }
    }
}
