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
            AddGooseMessage("HONK! 🪿 The goose demands your attention! Time to chat!");
        }

        private void InitializeComponents()
        {
            // Window setup
            this.Text = "🪿 Chat with Goose";
            this.Size = new Size(450, 550);
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.BackColor = Color.FromArgb(255, 250, 240);
            this.TopMost = true;
            this.MinimumSize = new Size(400, 400);

            // Chat history display
            chatHistory = new RichTextBox
            {
                Location = new Point(15, 15),
                Size = new Size(405, 420),
                ReadOnly = true,
                BackColor = Color.White,
                Font = new Font("Segoe UI", 10),
                ScrollBars = RichTextBoxScrollBars.Vertical,
                BorderStyle = BorderStyle.FixedSingle
            };

            // Input box
            inputBox = new TextBox
            {
                Location = new Point(15, 450),
                Size = new Size(320, 30),
                Font = new Font("Segoe UI", 10)
            };
            inputBox.KeyPress += InputBox_KeyPress;

            // Send button
            sendButton = new Button
            {
                Text = "Send 🪿",
                Location = new Point(340, 448),
                Size = new Size(80, 34),
                BackColor = Color.FromArgb(255, 200, 100),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };
            sendButton.FlatAppearance.BorderSize = 0;
            sendButton.Click += SendButton_Click;

            // Add controls
            this.Controls.Add(chatHistory);
            this.Controls.Add(inputBox);
            this.Controls.Add(sendButton);
            
            // Handle form closing
            this.FormClosing += ChatWindow_FormClosing;
        }

        private void ChatWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            AddGooseMessage("Fine! Go back to your boring work! HONK! 🪿");
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

            // Get and display goose response with slight delay
            Timer responseTimer = new Timer();
            responseTimer.Interval = 800;
            responseTimer.Tick += (s, e) =>
            {
                string gooseResponse = responseHandler.GetResponse(userMessage);
                AddGooseMessage(gooseResponse);
                responseTimer.Stop();
                responseTimer.Dispose();
            };
            responseTimer.Start();
        }

        private void AddUserMessage(string message)
        {
            chatHistory.SelectionColor = Color.FromArgb(0, 100, 200);
            chatHistory.SelectionFont = new Font(chatHistory.Font, FontStyle.Bold);
            chatHistory.AppendText("You: ");
            chatHistory.SelectionFont = new Font(chatHistory.Font, FontStyle.Regular);
            chatHistory.SelectionColor = Color.Black;
            chatHistory.AppendText(message + "\n\n");
            chatHistory.ScrollToCaret();
        }

        private void AddGooseMessage(string message)
        {
            chatHistory.SelectionColor = Color.FromArgb(200, 100, 0);
            chatHistory.SelectionFont = new Font(chatHistory.Font, FontStyle.Bold);
            chatHistory.AppendText("🪿 Goose: ");
            chatHistory.SelectionFont = new Font(chatHistory.Font, FontStyle.Regular);
            chatHistory.SelectionColor = Color.DarkSlateGray;
            chatHistory.AppendText(message + "\n\n");
            chatHistory.ScrollToCaret();
        }
    }
}