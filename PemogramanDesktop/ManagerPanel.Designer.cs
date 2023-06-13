namespace PemogramanDesktop
{
    partial class ManagerPanel
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
            cashierButton = new Button();
            userButton = new Button();
            SuspendLayout();
            // 
            // cashierButton
            // 
            cashierButton.Location = new Point(12, 12);
            cashierButton.Name = "cashierButton";
            cashierButton.Size = new Size(216, 188);
            cashierButton.TabIndex = 0;
            cashierButton.Text = "Cashier Menu";
            cashierButton.UseVisualStyleBackColor = true;
            cashierButton.Click += cashierButton_Click;
            // 
            // userButton
            // 
            userButton.Location = new Point(244, 12);
            userButton.Name = "userButton";
            userButton.Size = new Size(216, 188);
            userButton.TabIndex = 1;
            userButton.Text = "Item Manager";
            userButton.UseVisualStyleBackColor = true;
            userButton.Click += userButton_Click;
            // 
            // ManagerPanel
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(470, 208);
            Controls.Add(userButton);
            Controls.Add(cashierButton);
            Name = "ManagerPanel";
            Text = "ManagerPanel";
            ResumeLayout(false);
        }

        #endregion

        private Button cashierButton;
        private Button userButton;
    }
}