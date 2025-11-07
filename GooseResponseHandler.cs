using System;
using System.Collections.Generic;
using System.Linq;

namespace ChatWithGooseMod
{
    public class GooseResponseHandler
    {
        private Random random = new Random();
        private List<string> conversationHistory = new List<string>();

        // TODO: For future AI integration, implement an IResponseProvider interface
        // and create an AIResponseProvider class that calls your chosen AI service

        public string GetResponse(string userMessage)
        {
            conversationHistory.Add(userMessage);
            string lowerMessage = userMessage.ToLower();

            // Greetings
            if (ContainsAny(lowerMessage, "hello", "hi", "hey", "greetings"))
                return GetRandomResponse(
                    "HONK! What do you want?",
                    "Oh great, you're talking to me now?",
                    "Hi! I was just about to drag something across your screen...",
                    "Hey! Got any memes for me?"
                );

            // Farewells
            if (ContainsAny(lowerMessage, "bye", "goodbye", "see you", "later"))
                return GetRandomResponse(
                    "Fine! I'll just steal your mouse cursor instead!",
                    "Leaving already? HONK!",
                    "See ya! *closes your window*",
                    "Bye! I'll be back to bother you soon! 🪿"
                );

            // Questions about the goose
            if (ContainsAny(lowerMessage, "who are you", "what are you", "your name"))
                return GetRandomResponse(
                    "I'm a goose. A desktop goose. I'm here to annoy you!",
                    "I'm the most annoying waterfowl you'll ever meet! HONK!",
                    "I'm your new digital overlord! 🪿",
                    "Just a goose doing goose things on your desktop!"
                );

            // Why questions
            if (lowerMessage.StartsWith("why"))
                return GetRandomResponse(
                    "Why not? HONK!",
                    "Because I'm a goose and I can!",
                    "That's classified goose information!",
                    "Ask me again and I'll drag more memes onto your screen!"
                );

            // Compliments
            if (ContainsAny(lowerMessage, "cute", "nice", "love you", "good", "sweet"))
                return GetRandomResponse(
                    "Aww thanks! I'm still going to mess with your stuff though!",
                    "I know I'm adorable! HONK! 🪿",
                    "Flattery will get you... more goose chaos!",
                    "You're just saying that so I'll leave you alone. Not happening!"
                );

            // Insults or complaints
            if (ContainsAny(lowerMessage, "annoying", "stop", "go away", "hate", "bad"))
                return GetRandomResponse(
                    "Annoying? That's literally my job! HONK!",
                    "No! I'm staying RIGHT here!",
                    "You can't get rid of me that easily!",
                    "The more you complain, the more I'll bother you! 🪿",
                    "Stop? Make me! *HONK*"
                );

            // Work/productivity questions
            if (ContainsAny(lowerMessage, "work", "busy", "working", "productivity"))
                return GetRandomResponse(
                    "Work? Let me help by opening more windows!",
                    "You need a break anyway! Let's chat more!",
                    "Productivity is overrated. More goose time!",
                    "I'm increasing your productivity by giving you someone to talk to!"
                );

            // Questions
            if (lowerMessage.Contains("?"))
                return GetRandomResponse(
                    "That's a very interesting question! The answer is: HONK!",
                    "Hmm... let me think... Nope! Next question!",
                    "I'm just a goose, I don't know everything!",
                    "42! Wait, what was the question?",
                    "The answer you seek is hidden in your taskbar. Go check!"
                );

            // Help requests
            if (ContainsAny(lowerMessage, "help", "how to", "can you"))
                return GetRandomResponse(
                    "I can help! I'm very helpful! *drags meme*",
                    "Sure! I can help you be less productive!",
                    "My specialty is helping you procrastinate! HONK!",
                    "Need help? Too bad, I'm a goose not a support agent!"
                );

            // Default playful responses
            return GetRandomResponse(
                "HONK!",
                "That's interesting! Tell me more while I mess with your cursor!",
                "Uh huh... anyway, have you seen my new meme collection?",
                "Cool story! Want me to drag some mud on your screen?",
                "I'm not really listening, I'm thinking about bread!",
                "Is that so? *steals your mouse cursor* 🪿",
                "Fascinating! *minimizes your window*",
                "I see! Now watch this! *HONK*",
                "You're quite chatty! I like it! More entertainment for me!",
                "Noted! I'll file that under 'things humans say' HONK!"
            );
        }

        private bool ContainsAny(string text, params string[] words)
        {
            return words.Any(word => text.Contains(word));
        }

        private string GetRandomResponse(params string[] responses)
        {
            return responses[random.Next(responses.Length)];
        }

        // TODO: Future AI Integration Point
        // public async Task<string> GetAIResponse(string userMessage)
        // {
        //     // Call your AI service here (OpenAI, etc.)
        //     // Example structure:
        //     // var response = await aiService.GetCompletion(userMessage, conversationHistory);
        //     // return response;
        // }
    }
}