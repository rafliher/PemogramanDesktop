namespace PemogramanDesktop
{
    partial class AdminPanel
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
            itemButton = new Button();
            userManageButton = new Button();
            APIButton = new Button();
            SuspendLayout();
            // 
            // cashierButton
            // 
            cashierButton.Location = new Point(12, 12);
            cashierButton.Name = "cashierButton";
            cashierButton.Size = new Size(132, 188);
            cashierButton.TabIndex = 0;
            cashierButton.Text = "Cashier Menu";
            cashierButton.UseVisualStyleBackColor = true;
            cashierButton.Click += cashierButton_Click;
            // 
            // itemButton
            // 
            itemButton.Location = new Point(150, 12);
            itemButton.Name = "itemButton";
            itemButton.Size = new Size(124, 188);
            itemButton.TabIndex = 1;
            itemButton.Text = "Manage Item";
            itemButton.UseVisualStyleBackColor = true;
            itemButton.Click += itemButton_Click;
            // 
            // userManageButton
            // 
            userManageButton.Location = new Point(280, 12);
            userManageButton.Name = "userManageButton";
            userManageButton.Size = new Size(124, 188);
            userManageButton.TabIndex = 2;
            userManageButton.Text = "Manage User";
            userManageButton.UseVisualStyleBackColor = true;
            userManageButton.Click += userManageButton_Click;
            // 
            // APIButton
            // 
            APIButton.Location = new Point(14, 205);
            APIButton.Name = "APIButton";
            APIButton.Size = new Size(389, 48);
            APIButton.TabIndex = 3;
            APIButton.Text = "Access API";
            APIButton.UseVisualStyleBackColor = true;
            APIButton.Click += APIButton_Click;
            // 
            // AdminPanel
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(412, 259);
            Controls.Add(APIButton);
            Controls.Add(userManageButton);
            Controls.Add(itemButton);
            Controls.Add(cashierButton);
            Name = "AdminPanel";
            Text = "AdminPanel";
            ResumeLayout(false);
        }

        #endregion

        private Button cashierButton;
        private Button itemButton;
        private Button userManageButton;
        private Button APIButton;
    }
}