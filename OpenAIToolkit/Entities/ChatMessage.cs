namespace OpenAIToolkit
{
    /// <summary>
    ///     A chat message data
    /// </summary>
    public class ChatMessage
    {
        /// <summary>
        ///     The role of the message. Can be "system", "user" or "assistant"
        /// </summary>
        public ChatRole Role { get; set; }

        /// <summary>
        ///     The content of the message
        /// </summary>
        public string Content { get; set; }
    }
}