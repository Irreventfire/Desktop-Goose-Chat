using System;
using System.Drawing;
using GooseDesktop;

namespace ChatWithGooseMod
{
    public class ChatWithGooseTask : IGooseTask
    {
        private ChatWindow chatWindow;
        private Random random = new Random();

        public string Name => "ChatWithUser";
        
        // How often the goose should consider opening chat (lower = more frequent)
        public float Weight => 0.3f;

        public bool ShouldRun(GooseEntity goose)
        {
            // Random chance, similar to meme/note frequency
            return random.Next(0, 100) < 5; // 5% chance when evaluated
        }

        public void Run(GooseEntity goose)
        {
            // Close existing window if open
            if (chatWindow != null && !chatWindow.IsDisposed)
            {
                chatWindow.Close();
            }

            // Create new chat window near the goose
            chatWindow = new ChatWindow();
            
            // Position near goose (with some offset so goose doesn't cover it)
            Point goosePosition = goose.Position;
            chatWindow.StartPosition = FormStartPosition.Manual;
            chatWindow.Location = new Point(
                goosePosition.X + 100,
                goosePosition.Y - 50
            );

            chatWindow.Show();
        }
    }
}