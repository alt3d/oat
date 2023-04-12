namespace OpenAIToolkit
{
    /// <summary>
    ///     Represents a moderation result.
    /// </summary>
    public class ModerationResult
    {
        /// <summary>
        ///     Dictionary of per-category binary usage policies violation flags. For each category, the value is true if the model
        ///     flags the corresponding category as violated, false otherwise.
        /// </summary>
        public ModerationCategories Categories { get; internal set; }

        /// <summary>
        ///     Dictionary of per-category raw scores output by the model, denoting the model's confidence that the input violates
        ///     the OpenAI's policy for the category.
        /// </summary>
        public ModerationCategoryScores CategoryScores { get; internal set; }

        /// <summary>
        ///     Set to true if the model classifies the content as violating OpenAI's usage policies, false otherwise
        /// </summary>
        public bool Flagged { get; internal set; }
    }
}