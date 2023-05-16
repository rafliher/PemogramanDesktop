using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop5_CaffeeShopWithLogin
{
    public partial class MenuAddDetail : Form
    {
        private string name;
        private int initialPrice;
        public int price;
        public string size = "M";
        public int ice;
        public int sugar;
        public int amount = 1;

        public MenuAddDetail(string _name, int _price)
        {
            InitializeComponent();
            this.Text = _name;
            name = _name;
            initialPrice = _price;
            price = _price;
            totalLabel.Text = "Total: Rp. " + initialPrice.ToString();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            countTotal();
        }

        private void countTotal()
        {
            if (radioButton1.Checked)
            {
                price = initialPrice;
            }
            else
            {
                price = initialPrice + 3000;
            }
            foreach (object item in checkedListBox1.CheckedItems)
            {
                string[] substrings = item.ToString().Split(' ');
                string substring = substrings[substrings.Length - 1];
                substring = substring.Substring(0, substring.Length - 1);
                price += int.Parse(substring);
            }
            price *= amount;
            totalLabel.Text = "Total: Rp. " + price.ToString();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            countTotal();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            countTotal();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            amount = (int)numericUpDown1.Value;
            countTotal();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1 || comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Please specify levels");
            } else
            {
                MessageBox.Show("The total is Rp. " + price.ToString());
                this.Close();
            }
        }
    }
}
