using System;

namespace OpenAIToolkit
{
    [Serializable]
    internal class ChatMessageDto
    {
        public string role;
        public string content;

        public ChatRole ParseRole()
        {
            switch (role)
            {
                case "system": return ChatRole.System;
                case "user": return ChatRole.User;
                case "assistant": return ChatRole.Assistant;
                default: throw new ArgumentException($"Invalid ChatRole: {role}");
            }
        }
    }
}