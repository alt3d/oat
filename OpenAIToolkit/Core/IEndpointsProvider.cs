namespace OpenAIToolkit
{
    /// <summary>
    ///     The collection of endpoints for requests.
    /// </summary>
    public interface IEndpointsProvider
    {
        /// <summary>
        ///     API endpoint for creating a completion.
        /// </summary>
        string CreateCompletion { get; }

        /// <summary>
        ///     API endpoint for creating a chat completion.
        /// </summary>
        string CreateChatCompletion { get; }

        /// <summary>
        ///     API endpoint for creating an edit.
        /// </summary>
        string CreateEdit { get; }

        /// <summary>
        ///     API endpoint for creating an image.
        /// </summary>
        string CreateImage { get; }

        /// <summary>
        ///     API endpoint for creating an image edit.
        /// </summary>
        string CreateImageEdit { get; }

        /// <summary>
        ///     API endpoint for creating an image variant.
        /// </summary>
        string CreateImageVariant { get; }

        /// <summary>
        ///     API endpoint for creating a transcription.
        /// </summary>
        string CreateTranscription { get; }

        /// <summary>
        ///     API endpoint for creating a translation.
        /// </summary>
        string CreateTranslation { get; }

        /// <summary>
        ///     API endpoint for creating a moderation.
        /// </summary>
        string CreateModeration { get; }

        /// <summary>
        ///     API endpoint for getting list the currently available models
        /// </summary>
        string ListModels { get; }

        /// <summary>
        ///     API endpoint for retrieving a model.
        /// </summary>
        string RetrieveModel { get; }
    }
}