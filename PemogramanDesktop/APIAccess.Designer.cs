namespace PemogramanDesktop
{
    partial class APIAccess
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
            APIDataGridView = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)APIDataGridView).BeginInit();
            SuspendLayout();
            // 
            // APIDataGridView
            // 
            APIDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            APIDataGridView.Location = new Point(6, 8);
            APIDataGridView.Name = "APIDataGridView";
            APIDataGridView.RowHeadersWidth = 51;
            APIDataGridView.RowTemplate.Height = 29;
            APIDataGridView.Size = new Size(784, 429);
            APIDataGridView.TabIndex = 0;
            // 
            // APIAccess
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(APIDataGridView);
            Name = "APIAccess";
            Text = "APIAccess";
            ((System.ComponentModel.ISupportInitialize)APIDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView APIDataGridView;
    }
}