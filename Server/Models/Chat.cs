﻿namespace Server.Models
{
    internal class Chat
    {
        public string ChatId { get; set; }
        public List<User> Members { get; set; }
        public List<Message> ChatMessages { get; set; }
        public Chat(string chatId, List<User> members, List<Message> chatMessages)
        {
            ChatId = chatId;
            Members = members;
            ChatMessages = chatMessages;
        }
    }
}
