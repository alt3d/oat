namespace OpenAIToolkit
{
    /// <summary>
    ///     Permission for a specific model.
    /// </summary>
    public class Permission
    {
        /// <summary>
        ///     A unique identifier.
        /// </summary>
        public string Id { get; internal set; }

        /// <summary>
        ///     The time when the permission was created. The value is expressed in Unix timestamp format.
        /// </summary>
        public int Created { get; internal set; }

        /// <summary>
        ///     Indicates whether the permission allows creating an engine.
        /// </summary>
        public bool AllowCreateEngine { get; internal set; }

        /// <summary>
        ///     Indicates whether the permission allows sampling.
        /// </summary>
        public bool AllowSampling { get; internal set; }

        /// <summary>
        ///     Indicates whether the permission allows retrieving log probabilities.
        /// </summary>
        public bool AllowLogprobs { get; internal set; }

        /// <summary>
        ///     Indicates whether the permission allows searching indices.
        /// </summary>
        public bool AllowSearchIndices { get; internal set; }

        /// <summary>
        ///     Indicates whether the permission allows viewing information.
        /// </summary>
        public bool AllowView { get; internal set; }

        /// <summary>
        ///     Indicates whether the permission allows fine-tuning the model.
        /// </summary>
        public bool AllowFineTuning { get; internal set; }

        /// <summary>
        ///     The organization associated with the model.
        /// </summary>
        public string Organization { get; internal set; }

        /// <summary>
        ///     Indicates whether the model is blocking.
        /// </summary>
        public bool IsBlocking { get; internal set; }
    }
}