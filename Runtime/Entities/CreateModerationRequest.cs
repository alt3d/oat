namespace OpenAIToolkit
{
    /// <summary>
    ///     A parameters required to create moderation.
    ///     <a href="https://platform.openai.com/docs/api-reference/moderations/create">See more</a>
    /// </summary>
    public class CreateModerationRequest
    {
        /// <inheritdoc cref="CreateModerationRequest" />
        /// <param name="model">ID of the model to use. Available values: text-moderation-stable and text-moderation-latest.</param>
        /// <param name="input">The input text to classify.</param>
        public CreateModerationRequest(string model, string input)
        {
            Ensure.ArgumentNotNull(model, nameof(model));
            Ensure.ArgumentNotNull(input, nameof(input));

            Model = model;
            Input = input;
        }

        /// <summary>
        ///     ID of the model to use. Available values: text-moderation-stable and text-moderation-latest.
        /// </summary>
        public string Model { get; }

        /// <summary>
        ///     The input text to classify.
        /// </summary>
        public string Input { get; }
    }
}