using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopQuiz1_CaffeeShopToFile
{
    public partial class AdminPanel : Form
    {
        public AdminPanel()
        {
            InitializeComponent();
        }

        private void cashierButton_Click(object sender, EventArgs e)
        {
            Menu menu = new();
            menu.ShowDialog();
        }

        private void itemButton_Click(object sender, EventArgs e)
        {
            ItemManager menu = new();
            menu.ShowDialog();
        }

        private void userManageButton_Click(object sender, EventArgs e)
        {
            UserManager menu = new();
            menu.ShowDialog();
        }
    }
}
