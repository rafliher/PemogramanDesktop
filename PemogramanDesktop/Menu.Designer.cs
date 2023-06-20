using EllipticCurve.Utils;
using Microsoft.VisualBasic.FileIO;
using PemogramanDesktop;
using System.Diagnostics;

namespace PemogramanDesktop
{
    partial class Menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            ordersLabel = new Label();
            groupBox2 = new GroupBox();
            priceLabel = new Label();
            payButton = new Button();
            button4 = new Button();
            button5 = new Button();
            chatButton = new Button();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(273, 193);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Choose our menu";
            // 
            // ordersLabel
            // 
            ordersLabel.AutoSize = true;
            ordersLabel.Location = new Point(13, 32);
            ordersLabel.Name = "ordersLabel";
            ordersLabel.Size = new Size(0, 20);
            ordersLabel.TabIndex = 1;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(ordersLabel);
            groupBox2.Location = new Point(14, 211);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(555, 229);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Your Orders";
            // 
            // priceLabel
            // 
            priceLabel.AutoSize = true;
            priceLabel.Location = new Point(299, 453);
            priceLabel.Name = "priceLabel";
            priceLabel.Size = new Size(51, 20);
            priceLabel.TabIndex = 3;
            priceLabel.Text = "Rp. 0,-";
            // 
            // payButton
            // 
            payButton.Location = new Point(475, 447);
            payButton.Name = "payButton";
            payButton.Size = new Size(94, 33);
            payButton.TabIndex = 4;
            payButton.Text = "pay";
            payButton.UseVisualStyleBackColor = true;
            payButton.Click += payButton_Click;
            // 
            // button4
            // 
            button4.Location = new Point(15, 447);
            button4.Name = "button4";
            button4.Size = new Size(109, 33);
            button4.TabIndex = 5;
            button4.Text = "printButton";
            button4.UseVisualStyleBackColor = true;
            button4.Click += printButton_Click;
            // 
            // button5
            // 
            button5.Location = new Point(132, 447);
            button5.Name = "button5";
            button5.Size = new Size(130, 33);
            button5.TabIndex = 5;
            button5.Text = "RecordsButton";
            button5.UseVisualStyleBackColor = true;
            button5.Click += recordsButton_Click;
            // 
            // chatButton
            // 
            chatButton.Location = new Point(385, 97);
            chatButton.Name = "chatButton";
            chatButton.Size = new Size(94, 29);
            chatButton.TabIndex = 6;
            chatButton.Text = "use chatbot";
            chatButton.UseVisualStyleBackColor = true;
            chatButton.Click += chatButton_Click;

            List<Item> items = ReadItemsFromCSV("items.csv");

            // Create buttons and labels dynamically based on the item data
            for (int i = 0; i < items.Count; i++)
            {
                Button addButton = new Button();
                Label nameLabel = new Label();
                Label priceLabel = new Label();

                string itemName = items[i].Name;
                int itemPrice = items[i].Price;

                addButton.Location = new Point(225, 28 + i * 35);
                addButton.Name = "addButton" + i;
                addButton.Size = new Size(34, 29);
                addButton.TabIndex = 2;
                addButton.Text = "+";
                addButton.UseVisualStyleBackColor = true;
                addButton.Click += (sender, e) => {
                    launchModal(itemName, itemPrice);
                    };

                nameLabel.AutoSize = true;
                nameLabel.Location = new Point(13, 32 + i * 35);
                nameLabel.Name = "label" + (i + 1);
                nameLabel.Size = new Size(70, 20);
                nameLabel.TabIndex = 0;
                nameLabel.Text = items[i].Name;

                priceLabel.AutoSize = true;
                priceLabel.Location = new Point(124, 32 + i * 35);
                priceLabel.Name = "label" + (i + 1);
                priceLabel.Size = new Size(74, 20);
                priceLabel.TabIndex = 1;
                priceLabel.Text = "Rp. " + items[i].Price.ToString();

                groupBox1.Controls.Add(addButton);
                groupBox1.Controls.Add(nameLabel);
                groupBox1.Controls.Add(priceLabel);
            }
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(581, 496);
            Controls.Add(chatButton);
            Controls.Add(button4);
            Controls.Add(button5);
            Controls.Add(payButton);
            Controls.Add(priceLabel);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "Menu";
            Text = "Caffe PoltekSSN";
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion



        private GroupBox groupBox1;
        private Button button3;
        private Label label5;
        private Label label6;
        private Button button2;
        private Label label3;
        private Label label4;
        private Button button1;
        private Label label2;
        private Label label1;
        private Label ordersLabel;
        private GroupBox groupBox2;
        private Label priceLabel;
        private Button payButton;
        private Button button4;
        private Button button5;

        private List<Item> ReadItemsFromCSV(string filePath)
        {
            List<Item> items = new List<Item>();

            using (TextFieldParser parser = new TextFieldParser(filePath))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    if (fields.Length == 2 && int.TryParse(fields[1], out int price))
                    {
                        Item item = new Item
                        (
                             fields[0],
                            price
                        );
                        items.Add(item);
                    }
                }
            }

            return items;
        }

        private Button chatButton;
    }
}