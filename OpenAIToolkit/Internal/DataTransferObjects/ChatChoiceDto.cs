using System;

namespace OpenAIToolkit
{
    [Serializable]
    internal class ChatChoiceDto
    {
        public ChatMessageDto message;
        public string finish_reason;
        public int? index;
    }
}