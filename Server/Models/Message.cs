namespace Server.Models
{
    internal class Message
    {
        public string ChatId { get; set; }
        public string MessageOwner { get; set; }
        public string MessageContent { get; set; }
        public string MessageCreated { get; set; }
        public Message(string chatId, string messageOwner, string messageContent, string messageCreated)
        {
            ChatId = chatId;
            MessageOwner = messageOwner;
            MessageContent = messageContent;
            MessageCreated = messageCreated;
        }
    }
}
