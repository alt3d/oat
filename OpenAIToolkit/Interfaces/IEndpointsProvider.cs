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
        string CreateCompletion();

        /// <summary>
        ///     API endpoint for creating a chat completion.
        /// </summary>
        string CreateChatCompletion();

        /// <summary>
        ///     API endpoint for creating an edit.
        /// </summary>
        string CreateEdit();

        /// <summary>
        ///     API endpoint for creating an image.
        /// </summary>
        string CreateImage();

        /// <summary>
        ///     API endpoint for creating an image edit.
        /// </summary>
        string CreateImageEdit();

        /// <summary>
        ///     API endpoint for creating an image variant.
        /// </summary>
        string CreateImageVariant();

        /// <summary>
        ///     API endpoint for creating a transcription.
        /// </summary>
        string CreateTranscription();

        /// <summary>
        ///     API endpoint for creating a translation.
        /// </summary>
        string CreateTranslation();

        /// <summary>
        ///     API endpoint for creating a moderation.
        /// </summary>
        string CreateModeration();

        /// <summary>
        ///     API endpoint for getting list the currently available models
        /// </summary>
        string ListModels();

        /// <summary>
        ///     API endpoint for retrieving a model.
        /// </summary>
        string RetrieveModel(string model);
    }
}