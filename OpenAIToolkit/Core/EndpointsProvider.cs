namespace OpenAIToolkit
{
    /// <inheritdoc cref="IEndpointsProvider" />
    public class EndpointsProvider : IEndpointsProvider
    {
        /// <inheritdoc cref="IEndpointsProvider.CreateCompletion" />
        public string CreateCompletion => "https://api.openai.com/v1/completions";

        /// <inheritdoc cref="IEndpointsProvider.CreateChatCompletion" />
        public string CreateChatCompletion => "https://api.openai.com/v1/chat/completions";

        /// <inheritdoc cref="IEndpointsProvider.CreateEdit" />
        public string CreateEdit => "https://api.openai.com/v1/edits";

        /// <inheritdoc cref="IEndpointsProvider.CreateImage" />
        public string CreateImage => "https://api.openai.com/v1/images/generations";

        /// <inheritdoc cref="IEndpointsProvider.CreateImageEdit" />
        public string CreateImageEdit => "https://api.openai.com/v1/images/edits";

        /// <inheritdoc cref="IEndpointsProvider.CreateImageVariant" />
        public string CreateImageVariant => "https://api.openai.com/v1/images/variations";

        /// <inheritdoc cref="IEndpointsProvider.CreateTranscription" />
        public string CreateTranscription => "https://api.openai.com/v1/audio/transcriptions";

        /// <inheritdoc cref="IEndpointsProvider.CreateTranslation" />
        public string CreateTranslation => "https://api.openai.com/v1/audio/translations";

        /// <inheritdoc cref="IEndpointsProvider.CreateModeration" />
        public string CreateModeration => "https://api.openai.com/v1/moderations";

        /// <inheritdoc cref="IEndpointsProvider.ListModels" />
        public string ListModels => "https://api.openai.com/v1/models";

        /// <inheritdoc cref="IEndpointsProvider.RetrieveModel" />
        public string RetrieveModel => "https://api.openai.com/v1/models/{0}";
    }
}