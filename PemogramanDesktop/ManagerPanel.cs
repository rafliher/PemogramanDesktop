﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PemogramanDesktop
{
    public partial class ManagerPanel : Form
    {
        public ManagerPanel()
        {
            InitializeComponent();
        }

        private void cashierButton_Click(object sender, EventArgs e)
        {
            Menu menu = new();
            menu.ShowDialog();
        }

        private void userButton_Click(object sender, EventArgs e)
        {
            ItemManager itemManager = new();
            itemManager.ShowDialog();
        }
    }
}
