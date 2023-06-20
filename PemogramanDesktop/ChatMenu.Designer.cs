namespace PemogramanDesktop
{
    partial class ChatMenu
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
            sendButton = new Button();
            messageRichTextBox = new RichTextBox();
            conversationRichTextBox = new RichTextBox();
            SuspendLayout();
            // 
            // sendButton
            // 
            sendButton.Location = new Point(683, 384);
            sendButton.Name = "sendButton";
            sendButton.Size = new Size(105, 54);
            sendButton.TabIndex = 0;
            sendButton.Text = "send";
            sendButton.UseVisualStyleBackColor = true;
            sendButton.Click += sendButton_Click;
            // 
            // messageRichTextBox
            // 
            messageRichTextBox.Location = new Point(18, 384);
            messageRichTextBox.Name = "messageRichTextBox";
            messageRichTextBox.Size = new Size(661, 54);
            messageRichTextBox.TabIndex = 1;
            messageRichTextBox.Text = "";
            // 
            // conversationRichTextBox
            // 
            conversationRichTextBox.Enabled = false;
            conversationRichTextBox.Location = new Point(20, 9);
            conversationRichTextBox.Name = "conversationRichTextBox";
            conversationRichTextBox.ReadOnly = true;
            conversationRichTextBox.Size = new Size(765, 354);
            conversationRichTextBox.TabIndex = 2;
            conversationRichTextBox.Text = "";
            // 
            // ChatMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(conversationRichTextBox);
            Controls.Add(messageRichTextBox);
            Controls.Add(sendButton);
            Name = "ChatMenu";
            Text = "Order Bot";
            ResumeLayout(false);
        }

        #endregion

        private Button sendButton;
        private RichTextBox messageRichTextBox;
        private RichTextBox conversationRichTextBox;
    }
}