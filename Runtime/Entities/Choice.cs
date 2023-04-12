namespace OpenAIToolkit
{
    /// <summary>
    ///     A choice in a decision-making process.
    /// </summary>
    public class Choice
    {
        /// <summary>
        ///     The text representation of the choice.
        /// </summary>
        public string Text { get; internal set; }

        /// <summary>
        ///     The index of the choice.
        /// </summary>
        public int? Index { get; internal set; }

        /// <summary>
        ///     The log probabilities associated with the choice.
        /// </summary>
        public LogProbs LogProbs { get; internal set; }

        /// <summary>
        ///     The reason for finishing the decision-making process.
        /// </summary>
        public string FinishReason { get; internal set; }
    }
}