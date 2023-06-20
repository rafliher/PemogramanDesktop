using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;
using System;
using System.IO;
using CsvHelper;
using System.Globalization;
using System.Formats.Asn1;
using QRCoder;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Transactions;
using System.Drawing.Imaging;
using System.Net;

namespace PemogramanDesktop
{
    public partial class Menu : Form
    {
        private int total = 0;
        List<TransactionDetail> records = new();

        public Menu()
        {
            InitializeComponent();
        }

        private void launchModal(string itemName, int itemPrice)
        {
            Item item = new Item(itemName, itemPrice);
            MenuAddDetail menuAddDetail = new(item);
            DialogResult result = menuAddDetail.ShowDialog();
            int _p = 0;
            if (result == DialogResult.OK)
            {
                TransactionDetail transaction = new(item.Name, menuAddDetail.amount, menuAddDetail.price);
                records.Add(transaction);
                ordersLabel.Text += $"{menuAddDetail.name} x{menuAddDetail?.amount.ToString()}: Rp. {menuAddDetail.price.ToString()}\n";
                total += menuAddDetail.price;
                priceLabel.Text = "Rp. " + total.ToString() + ",-";
            }
        }

        private async void payButton_Click(object sender, EventArgs e)
        {
            Transaction transaction = new(total);

            foreach (TransactionDetail record in records)
            {
                record.Update(transaction.Id, DateTime.Now);
            }

            string transactionDetailsFilePath = "transactionDetails.csv";
            string recordsFilePath = "records.csv";

            using (StreamWriter writer = new StreamWriter(transactionDetailsFilePath, true))
            using (CsvWriter csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                foreach (TransactionDetail record in records)
                {
                    csvWriter.WriteRecord(record);
                    csvWriter.NextRecord();
                }
            }

            using (StreamWriter writer2 = new StreamWriter(recordsFilePath, true))
            using (CsvWriter csvWriter2 = new CsvWriter(writer2, CultureInfo.InvariantCulture))
            {
                csvWriter2.WriteRecord(transaction);
                csvWriter2.NextRecord();
            }

            records = new(); // Clear the records list

            MessageBox.Show("Total is Rp. " + total.ToString() + ",-");
            priceLabel.Text = "Rp. 0,-";
            ordersLabel.Text = "";
            total = 0;

            string email = Microsoft.VisualBasic.Interaction.InputBox("Enter your email address:", "Email Prompt");

            if (!string.IsNullOrWhiteSpace(email))
            {
                bool isEmailSent = await SendQR(transaction.Id, email);
                if (isEmailSent)
                {
                    MessageBox.Show("The receipt has been sent to your email.", "Receipt sent", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Please check configuration", "Something is wrong", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Email address cannot be empty.", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async Task<bool> SendQR(Guid guid, string email)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(guid.ToString(), QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(10); // Set the size of the QR code image (10 times the module size)

            string qrCodeImagePath = "qrCode.png";
            qrCodeImage.Save(qrCodeImagePath, ImageFormat.Png);

            // Convert the QR code image to base64 string
            byte[] qrCodeImageBytes = File.ReadAllBytes(qrCodeImagePath);
            string qrCodeBase64String = Convert.ToBase64String(qrCodeImageBytes);

            string apiKey = "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";
            string senderEmail = "raflihw1@gmail.com";
            string recipientEmail = email;
            string emailSubject = "Transaction Details";

            // Create the SendGrid client
            SendGridClient sendGridClient = new SendGridClient(apiKey);

            // Create the email message
            SendGridMessage emailMessage = new SendGridMessage();
            emailMessage.SetFrom(new EmailAddress(senderEmail));
            emailMessage.AddTo(new EmailAddress(recipientEmail));
            emailMessage.SetSubject(emailSubject);

            // Add plain text content block
            emailMessage.PlainTextContent = "Transaction details attached.";

            // Attach the QR code image as base64 string
            emailMessage.AddAttachment("QRCode.png", qrCodeBase64String, "image/png", "attachment");

            // Send the email
            var response = await sendGridClient.SendEmailAsync(emailMessage);

            // Check the response status code
            bool isEmailSent = response.StatusCode == HttpStatusCode.Accepted;

            // Delete the temporary QR code image file
            File.Delete(qrCodeImagePath);

            return isEmailSent;
        }

        private void printButton_Click(object sender, EventArgs e)
        {
            PrintDocument document = new PrintDocument();
            document.PrintPage += Document_PrintPage;

            PrintPreviewDialog previewDialog = new PrintPreviewDialog();
            previewDialog.Document = document;
            previewDialog.ShowDialog();
        }

        private void Document_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font font = new Font("Arial", 12, FontStyle.Regular);
            Brush brush = Brushes.Black;
            float lineHeight = font.GetHeight();

            string orders = "Orders: " + ordersLabel.Text;
            string price = "Price: " + priceLabel.Text;

            float x = e.MarginBounds.Left;
            float y = e.MarginBounds.Top;
            e.Graphics!.DrawString("ORDERS", font, brush, x, y);

            y += 2 * lineHeight;
            e.Graphics.DrawString(orders, font, brush, x, y);

            y += 2 * lineHeight;
            e.Graphics.DrawString(price, font, brush, x, y);
        }
        private void recordsButton_Click(object sender, EventArgs e)
        {
            Records records = new();
            records.ShowDialog();
        }
        private void chatButton_Click(object sender, EventArgs e)
        {
            ChatMenu chatMenu = new();
            chatMenu.ShowDialog();
        }
    }
}
