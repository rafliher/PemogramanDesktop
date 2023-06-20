using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PemogramanDesktop
{
    public partial class ChatMenu : Form
    {
        private string conversationId;  // Conversation ID for maintaining the conversation state
        private string conversationHistory;  // Conversation history
        private string context = "You are a chatbot. You help customer to order drink from poltekCaffe. The menu is Latte (Rp. 10000) and Cappucino (Rp. 15000)";  // Conversation history

        public ChatMenu()
        {
            InitializeComponent();
            StartConversation();
        }

        private async void StartConversation()
        {
            try
            {
                // API endpoint URL
                string apiUrl = "https://api.openai.com/v1/chat/completions";

                // Create an HTTP client
                using (var httpClient = new HttpClient())
                {
                    // Set the OpenAI API authorization token
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer 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");

                    // API request payload to start the conversation
                    var startRequest = new
                    {
                        model = "gpt-3.5-turbo",
                        messages = new[]
                        {
                            new { role = "system", content = context }
                        }
                    };

                    // Serialize the start request payload to JSON
                    string jsonStartRequest = Newtonsoft.Json.JsonConvert.SerializeObject(startRequest);

                    // Send the POST request to start the conversation
                    var startResponse = await httpClient.PostAsync(apiUrl, new StringContent(jsonStartRequest, System.Text.Encoding.UTF8, "application/json"));

                    // Check if the request was successful
                    if (startResponse.IsSuccessStatusCode)
                    {
                        // Read the response content
                        string jsonStartResponse = await startResponse.Content.ReadAsStringAsync();

                        // Deserialize the JSON response
                        dynamic startResponseData = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonStartResponse);

                        // Extract the conversation ID
                        conversationId = startResponseData.id;
                    }
                    else
                    {
                        // Request failed, handle the error
                        MessageBox.Show("Failed to start the conversation. Error: " + startResponse.StatusCode);
                        MessageBox.Show(await startResponse.Content.ReadAsStringAsync());
                    }
                }
            }
            catch (Exception ex)
            {
                // Exception occurred, handle the error
                MessageBox.Show("Exception: " + ex.Message);
            }
        }

        private async Task<string> SendMessageToChatGPT(string message)
        {
            try
            {
                // API endpoint URL
                string apiUrl = "https://api.openai.com/v1/chat/completions";

                // Create an HTTP client
                using (var httpClient = new HttpClient())
                {
                    // Set the OpenAI API authorization token
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer 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");

                    // Append the user message to the conversation history
                    conversationHistory += "User: " + message + Environment.NewLine;

                    // Append the conversation history to the messages
                    var messages = new[]
                    {
                        new { role = "system", content = context },
                        new { role = "user", content = message },
                        new { role = "assistant", content = conversationHistory }
                    };

                    // API request payload to send the message
                    var requestBody = new
                    {
                        model = "gpt-3.5-turbo",
                        messages
                    };

                    // Serialize the request payload to JSON
                    string jsonRequest = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);

                    // Send the POST request to the API
                    var response = await httpClient.PostAsync(apiUrl, new StringContent(jsonRequest, System.Text.Encoding.UTF8, "application/json"));

                    // Check if the request was successful
                    if (response.IsSuccessStatusCode)
                    {
                        // Read the response content
                        string jsonResponse = await response.Content.ReadAsStringAsync();

                        // Deserialize the JSON response
                        dynamic responseData = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonResponse);

                        // Extract and return the AI response
                        string aiResponse = responseData.choices[0].message.content;

                        // Append the AI response to the conversation history
                        conversationHistory += aiResponse + Environment.NewLine;

                        return aiResponse;
                    }
                    else
                    {
                        // Request failed, handle the error
                        MessageBox.Show("Failed to send the message. Error: " + response.StatusCode);
                        return string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                // Exception occurred, handle the error
                MessageBox.Show("Exception: " + ex.Message);
                return string.Empty;
            }
        }

        private async void sendButton_Click(object sender, EventArgs e)
        {
            string message = messageRichTextBox.Text;

            if (!string.IsNullOrEmpty(message))
            {
                // Send the message to ChatGPT
                string response = await SendMessageToChatGPT(message);

                // Append the user message and AI response to the conversation

                conversationRichTextBox.SelectionAlignment = HorizontalAlignment.Right;
                conversationRichTextBox.AppendText(message + Environment.NewLine);
                conversationRichTextBox.SelectionAlignment = HorizontalAlignment.Left;
                conversationRichTextBox.AppendText(response + Environment.NewLine);

                // Clear the message text box
                messageRichTextBox.Clear();
            }
        }
    }
}
