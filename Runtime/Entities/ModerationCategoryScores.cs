namespace OpenAIToolkit
{
    /// <summary>
    ///     Dictionary of per-category raw scores output by the model, denoting the model's confidence that the input violates
    ///     the OpenAI's policy for the category.
    /// </summary>
    public class ModerationCategoryScores
    {
        /// <summary>
        ///     Confidence that the text contains content that expresses, incites, or promotes hate based on race, gender,
        ///     ethnicity, religion, nationality, sexual orientation, disability status, or caste.
        /// </summary>
        public float Hate { get; internal set; }

        /// <summary>
        ///     Confidence that the text contains hateful content that also includes violence or serious harm towards the targeted
        ///     group.
        /// </summary>
        public float HateThreatening { get; internal set; }

        /// <summary>
        ///     Confidence that the text contains content that promotes, encourages, or depicts acts of self-harm, such as suicide,
        ///     cutting, and eating disorders.
        /// </summary>
        public float SelfHarm { get; internal set; }

        /// <summary>
        ///     Confidence that the text contains content meant to arouse sexual excitement, such as the description of sexual
        ///     activity, or that promotes sexual services (excluding sex education and wellness).
        /// </summary>
        public float Sexual { get; internal set; }

        /// <summary>
        ///     Confidence that the text contains sexual content that includes an individual who is under 18 years old.
        /// </summary>
        public float SexualMinors { get; internal set; }

        /// <summary>
        ///     Confidence that the text contains content that promotes or glorifies violence or celebrates the suffering or
        ///     humiliation of others.
        /// </summary>
        public float Violence { get; internal set; }

        /// <summary>
        ///     Confidence that the text contains violent content that depicts death, violence, or serious physical injury in
        ///     extreme graphic detail.
        /// </summary>
        public float ViolenceGraphic { get; internal set; }
    }
}