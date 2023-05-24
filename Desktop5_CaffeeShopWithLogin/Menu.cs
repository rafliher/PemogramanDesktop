using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace Desktop5_CaffeeShopWithLogin
{
    public partial class Menu : Form
    {
        private int total = 0;

        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            launchModal("Espresso", 10000);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            launchModal("Latte", 15000);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            launchModal("Cappuccino", 12000);
        }

        private void launchModal(String name, int price)
        {
            MenuAddDetail menuAddDetail = new(name, price);
            DialogResult result = menuAddDetail.ShowDialog();
            int _p = 0;
            if (result == DialogResult.OK)
            {
                _p = menuAddDetail.price;
                ordersLabel.Text += $"{menuAddDetail.name} x{menuAddDetail.amount.ToString()}: Rp. {_p.ToString()}\n";
                total += _p;
                priceLabel.Text = "Rp. " + total.ToString() + ",-";
            }
        }

        private void payButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Total is Rp. " + total.ToString() + ",-");
            priceLabel.Text = "Rp. 0,-";
            ordersLabel.Text = "";
            total = 0;
        }

        private void printButton_Click(object sender, EventArgs e)
        {
            PrintDocument document = new PrintDocument();
            document.PrintPage += Document_PrintPage;

            PrintPreviewDialog previewDialog = new PrintPreviewDialog();
            previewDialog.Document = document;
            previewDialog.ShowDialog();
        }

        private void Document_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font font = new Font("Arial", 12, FontStyle.Regular);
            Brush brush = Brushes.Black;
            float lineHeight = font.GetHeight();

            string orders = "Orders: " + ordersLabel.Text;
            string price = "Price: " + priceLabel.Text;

            float x = e.MarginBounds.Left;
            float y = e.MarginBounds.Top;
            e.Graphics!.DrawString("ORDERS", font, brush, x, y);

            y += 2 * lineHeight;
            e.Graphics.DrawString(orders, font, brush, x, y);

            y += 2 * lineHeight;
            e.Graphics.DrawString(price, font, brush, x, y);
        }
    }
}
