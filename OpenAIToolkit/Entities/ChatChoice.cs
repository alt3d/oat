namespace OpenAIToolkit
{
    /// <summary>
    ///     A choice in a decision-making process.
    /// </summary>
    public class ChatChoice
    {
        /// <summary>
        ///     The text representation of the choice.
        /// </summary>
        public ChatMessage Message { get; internal set; }

        /// <summary>
        ///     The index of the choice.
        /// </summary>
        public int? Index { get; internal set; }

        /// <summary>
        ///     The reason for finishing the decision-making process.
        /// </summary>
        public string FinishReason { get; internal set; }
    }
}