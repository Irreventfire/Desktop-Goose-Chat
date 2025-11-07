using System;
using GooseShared;
using SamEngine;

namespace ChatWithGooseMod
{
    public class ModEntryPoint : IMod
    {
        private Random random = new Random();
        private float lastChatCheck = 0;
        private ChatWindow currentChatWindow = null;

        void IMod.Init()
        {
            // Subscribe to the tick event to randomly trigger chat
            InjectionPoints.PostTickEvent += OnPostTick;
            
            API.DebugWrite("Chat With Goose Mod loaded! HONK!");
        }

        private void OnPostTick(GooseEntity goose)
        {
            // Check every 5 seconds if we should open a chat
            if (Time.time - lastChatCheck > 5f)
            {
                lastChatCheck = Time.time;
                
                // 10% chance to open chat window
                if (random.Next(0, 100) < 10)
                {
                    OpenChatWindow(goose);
                }
            }
        }

        private void OpenChatWindow(GooseEntity goose)
        {
            // Don't open multiple chat windows
            if (currentChatWindow != null && !currentChatWindow.IsDisposed)
            {
                return;
            }

            // Create and position chat window near the goose
            currentChatWindow = new ChatWindow();
            currentChatWindow.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            currentChatWindow.Location = new System.Drawing.Point(
                (int)goose.position.x + 100,
                (int)goose.position.y - 50
            );
            currentChatWindow.Show();

            // Optional: Make goose look at the chat window
            goose.direction = 1;
        }
    }
}