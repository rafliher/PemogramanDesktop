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
            button3 = new Button();
            label5 = new Label();
            label6 = new Label();
            button2 = new Button();
            label3 = new Label();
            label4 = new Label();
            button1 = new Button();
            label2 = new Label();
            label1 = new Label();
            ordersLabel = new Label();
            groupBox2 = new GroupBox();
            priceLabel = new Label();
            payButton = new Button();
            button4 = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(273, 152);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Choose our menu";
            // 
            // button3
            // 
            button3.Location = new Point(225, 97);
            button3.Name = "button3";
            button3.Size = new Size(34, 29);
            button3.TabIndex = 8;
            button3.Text = "+";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(124, 102);
            label5.Name = "label5";
            label5.Size = new Size(74, 20);
            label5.TabIndex = 7;
            label5.Text = "Rp. 12000";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(13, 102);
            label6.Name = "label6";
            label6.Size = new Size(87, 20);
            label6.TabIndex = 6;
            label6.Text = "Cappuccino";
            // 
            // button2
            // 
            button2.Location = new Point(225, 62);
            button2.Name = "button2";
            button2.Size = new Size(34, 29);
            button2.TabIndex = 5;
            button2.Text = "+";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(124, 66);
            label3.Name = "label3";
            label3.Size = new Size(74, 20);
            label3.TabIndex = 4;
            label3.Text = "Rp. 15000";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(13, 66);
            label4.Name = "label4";
            label4.Size = new Size(42, 20);
            label4.TabIndex = 3;
            label4.Text = "Latte";
            // 
            // button1
            // 
            button1.Location = new Point(225, 28);
            button1.Name = "button1";
            button1.Size = new Size(34, 29);
            button1.TabIndex = 2;
            button1.Text = "+";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(124, 32);
            label2.Name = "label2";
            label2.Size = new Size(74, 20);
            label2.TabIndex = 1;
            label2.Text = "Rp. 10000";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 32);
            label1.Name = "label1";
            label1.Size = new Size(70, 20);
            label1.TabIndex = 0;
            label1.Text = "Espresso ";
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
            groupBox2.Location = new Point(12, 174);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(555, 229);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Your Orders";
            // 
            // priceLabel
            // 
            priceLabel.AutoSize = true;
            priceLabel.Location = new Point(329, 427);
            priceLabel.Name = "priceLabel";
            priceLabel.Size = new Size(51, 20);
            priceLabel.TabIndex = 3;
            priceLabel.Text = "Rp. 0,-";
            // 
            // payButton
            // 
            payButton.Location = new Point(473, 418);
            payButton.Name = "payButton";
            payButton.Size = new Size(94, 29);
            payButton.TabIndex = 4;
            payButton.Text = "pay";
            payButton.UseVisualStyleBackColor = true;
            payButton.Click += payButton_Click;
            // 
            // button4
            // 
            button4.Location = new Point(13, 410);
            button4.Name = "button4";
            button4.Size = new Size(109, 33);
            button4.TabIndex = 5;
            button4.Text = "printButton";
            button4.UseVisualStyleBackColor = true;
            button4.Click += printButton_Click;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(581, 456);
            Controls.Add(button4);
            Controls.Add(payButton);
            Controls.Add(priceLabel);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "Menu";
            Text = "Caffe PoltekSSN";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
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
    }
}