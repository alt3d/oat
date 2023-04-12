using System.Collections.Generic;

namespace OpenAIToolkit
{
    /// <summary>
    ///     Represents the log probabilities for a set of tokens
    /// </summary>
    public class LogProbs
    {
        /// <summary>
        ///     The list of tokens
        /// </summary>
        public List<string> Tokens { get; set; }

        /// <summary>
        ///     The log probabilities for each token in the Tokens list
        /// </summary>
        public List<float> TokenLogProbs { get; set; }

        /// <summary>
        ///     A list of dictionaries representing the top log probabilities and their associated tokens
        /// </summary>
        public List<Dictionary<string, float>> TopLogProbs { get; set; }

        /// <summary>
        ///     The text offset for each token in the Tokens list
        /// </summary>
        public List<int> TextOffset { get; set; }
    }
}