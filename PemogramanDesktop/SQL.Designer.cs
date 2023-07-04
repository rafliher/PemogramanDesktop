namespace PemogramanDesktop
{
    partial class SQL
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
            userDataGridView = new DataGridView();
            usernameTextBox = new TextBox();
            emailTextBox = new TextBox();
            fullnameTextBox = new TextBox();
            passwordTextBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            addButton = new Button();
            updateButton = new Button();
            deleteButton = new Button();
            ((System.ComponentModel.ISupportInitialize)userDataGridView).BeginInit();
            SuspendLayout();
            // 
            // userDataGridView
            // 
            userDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            userDataGridView.Location = new Point(10, 12);
            userDataGridView.Name = "userDataGridView";
            userDataGridView.RowHeadersWidth = 51;
            userDataGridView.RowTemplate.Height = 29;
            userDataGridView.Size = new Size(778, 310);
            userDataGridView.TabIndex = 0;
            userDataGridView.CellClick += userDataGridView_SelectionChanged;
            // 
            // usernameTextBox
            // 
            usernameTextBox.Enabled = false;
            usernameTextBox.Location = new Point(227, 345);
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.Size = new Size(280, 27);
            usernameTextBox.TabIndex = 1;
            // 
            // emailTextBox
            // 
            emailTextBox.Location = new Point(227, 378);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.Size = new Size(280, 27);
            emailTextBox.TabIndex = 2;
            // 
            // fullnameTextBox
            // 
            fullnameTextBox.Location = new Point(227, 411);
            fullnameTextBox.Name = "fullnameTextBox";
            fullnameTextBox.Size = new Size(280, 27);
            fullnameTextBox.TabIndex = 3;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(227, 444);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.PasswordChar = '*';
            passwordTextBox.Size = new Size(280, 27);
            passwordTextBox.TabIndex = 4;
            passwordTextBox.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(135, 352);
            label1.Name = "label1";
            label1.Size = new Size(73, 20);
            label1.TabIndex = 5;
            label1.Text = "username";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(135, 385);
            label2.Name = "label2";
            label2.Size = new Size(46, 20);
            label2.TabIndex = 6;
            label2.Text = "email";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(135, 418);
            label3.Name = "label3";
            label3.Size = new Size(67, 20);
            label3.TabIndex = 7;
            label3.Text = "fullname";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(135, 451);
            label4.Name = "label4";
            label4.Size = new Size(72, 20);
            label4.TabIndex = 8;
            label4.Text = "password";
            // 
            // addButton
            // 
            addButton.Location = new Point(568, 374);
            addButton.Name = "addButton";
            addButton.Size = new Size(94, 29);
            addButton.TabIndex = 9;
            addButton.Text = "Add";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // updateButton
            // 
            updateButton.Location = new Point(568, 409);
            updateButton.Name = "updateButton";
            updateButton.Size = new Size(94, 29);
            updateButton.TabIndex = 10;
            updateButton.Text = "Update";
            updateButton.UseVisualStyleBackColor = true;
            updateButton.Click += updateButton_Click;
            // 
            // deleteButton
            // 
            deleteButton.Location = new Point(568, 444);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(94, 29);
            deleteButton.TabIndex = 11;
            deleteButton.Text = "Delete";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += deleteButton_Click;
            // 
            // SQL
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 490);
            Controls.Add(deleteButton);
            Controls.Add(updateButton);
            Controls.Add(addButton);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(passwordTextBox);
            Controls.Add(fullnameTextBox);
            Controls.Add(emailTextBox);
            Controls.Add(usernameTextBox);
            Controls.Add(userDataGridView);
            Name = "SQL";
            Text = "SQL";
            ((System.ComponentModel.ISupportInitialize)userDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView userDataGridView;
        private TextBox usernameTextBox;
        private TextBox emailTextBox;
        private TextBox fullnameTextBox;
        private TextBox passwordTextBox;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button addButton;
        private Button updateButton;
        private Button deleteButton;
    }
}