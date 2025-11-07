using System;
using System.Drawing;
using System.Windows.Forms;

namespace ChatWithGooseMod
{
    public class ChatWindow : Form
    {
        private RichTextBox chatHistory;
        private TextBox inputBox;
        private Button sendButton;
        private GooseResponseHandler responseHandler;

        public ChatWindow()
        {
            InitializeComponents();
            responseHandler = new GooseResponseHandler();
            
            // Welcome message from the goose
            AddGooseMessage("HONK! 🪿 I've decided you need to chat with me now!");
        }

        private void InitializeComponents()
        {
            // Window setup
            this.Text = "Chat with Goose";
            this.Size = new Size(400, 500);
            this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
            this.BackColor = Color.White;
            this.TopMost = true;

            // Chat history display (editor-style)
            chatHistory = new RichTextBox
            {
                Location = new Point(10, 10),
                Size = new Size(365, 380),
                ReadOnly = true,
                BackColor = Color.WhiteSmoke,
                Font = new Font("Consolas", 10),
                ScrollBars = RichTextBoxScrollBars.Vertical
            };

            // Input box
            inputBox = new TextBox
            {
                Location = new Point(10, 400),
                Size = new Size(280, 25),
                Font = new Font("Consolas", 10)
            };
            inputBox.KeyPress += InputBox_KeyPress;

            // Send button
            sendButton = new Button
            {
                Text = "Send",
                Location = new Point(295, 398),
                Size = new Size(80, 28)
            };
            sendButton.Click += SendButton_Click;

            // Add controls
            this.Controls.Add(chatHistory);
            this.Controls.Add(inputBox);
            this.Controls.Add(sendButton);
        }

        private void InputBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                SendMessage();
            }
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            SendMessage();
        }

        private void SendMessage()
        {
            string userMessage = inputBox.Text.Trim();
            if (string.IsNullOrEmpty(userMessage))
                return;

            // Display user message
            AddUserMessage(userMessage);
            inputBox.Clear();

            // Get and display goose response
            string gooseResponse = responseHandler.GetResponse(userMessage);
            System.Threading.Thread.Sleep(500); // Brief delay for realism
            AddGooseMessage(gooseResponse);
        }

        private void AddUserMessage(string message)
        {
            chatHistory.SelectionColor = Color.Blue;
            chatHistory.SelectionFont = new Font(chatHistory.Font, FontStyle.Bold);
            chatHistory.AppendText("You: ");
            chatHistory.SelectionFont = new Font(chatHistory.Font, FontStyle.Regular);
            chatHistory.SelectionColor = Color.Black;
            chatHistory.AppendText(message + "\n\n");
            chatHistory.ScrollToCaret();
        }

        private void AddGooseMessage(string message)
        {
            chatHistory.SelectionColor = Color.DarkGreen;
            chatHistory.SelectionFont = new Font(chatHistory.Font, FontStyle.Bold);
            chatHistory.AppendText("Goose: ");
            chatHistory.SelectionFont = new Font(chatHistory.Font, FontStyle.Regular);
            chatHistory.SelectionColor = Color.Black;
            chatHistory.AppendText(message + "\n\n");
            chatHistory.ScrollToCaret();
        }
    }
}