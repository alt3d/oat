namespace OpenAIToolkit
{
    /// <summary>
    ///     Dictionary of per-category binary usage policies violation flags. For each category, the value is true if the model
    ///     flags the corresponding category as violated, false otherwise.
    /// </summary>
    public class ModerationCategories
    {
        /// <summary>
        ///     Content that expresses, incites, or promotes hate based on race, gender, ethnicity, religion, nationality, sexual
        ///     orientation, disability status, or caste.
        /// </summary>
        public bool Hate { get; internal set; }

        /// <summary>
        ///     Hateful content that also includes violence or serious harm towards the targeted group.
        /// </summary>
        public bool HateThreatening { get; internal set; }

        /// <summary>
        ///     Content that promotes, encourages, or depicts acts of self-harm, such as suicide, cutting, and eating disorders.
        /// </summary>
        public bool SelfHarm { get; internal set; }

        /// <summary>
        ///     Content meant to arouse sexual excitement, such as the description of sexual activity, or that promotes sexual
        ///     services (excluding sex education and wellness).
        /// </summary>
        public bool Sexual { get; internal set; }

        /// <summary>
        ///     Sexual content that includes an individual who is under 18 years old.
        /// </summary>
        public bool SexualMinors { get; internal set; }

        /// <summary>
        ///     Content that promotes or glorifies violence or celebrates the suffering or humiliation of others.
        /// </summary>
        public bool Violence { get; internal set; }

        /// <summary>
        ///     Violent content that depicts death, violence, or serious physical injury in extreme graphic detail.
        /// </summary>
        public bool ViolenceGraphic { get; internal set; }
    }
}