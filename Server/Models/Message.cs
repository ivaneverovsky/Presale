using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Models
{
    internal class Message
    {
        public string ChatId { get; set; }
        public string MessageOwner { get; set; }
        public string Content { get; set; }
        public Message(string chatId, string messageOwner, string content)
        {
            ChatId = chatId;
            MessageOwner = messageOwner;
            Content = content;
        }
    }
}
