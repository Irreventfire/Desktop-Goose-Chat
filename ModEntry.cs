using System;
using GooseDesktop;

namespace ChatWithGooseMod
{
    public class ModEntry : IMod
    {
        public void Init()
        {
            // Register our custom chat task with the goose
            API.AddTask(new ChatWithGooseTask());
            Console.WriteLine("Chat With Goose Mod loaded!");
        }
    }
}