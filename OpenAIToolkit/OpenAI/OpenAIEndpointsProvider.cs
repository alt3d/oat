namespace OpenAIToolkit
{
    /// <inheritdoc cref="IEndpointsProvider" />
    public class OpenAIEndpointsProvider : IEndpointsProvider
    {
        private const string BaseUrl = "https://api.openai.com/v1";

        /// <inheritdoc cref="IEndpointsProvider.CreateCompletion" />
        public string CreateCompletion()
        {
            return $"{BaseUrl}/completions";
        }

        /// <inheritdoc cref="IEndpointsProvider.CreateChatCompletion" />
        public string CreateChatCompletion()
        {
            return $"{BaseUrl}/chat/completions";
        }

        /// <inheritdoc cref="IEndpointsProvider.CreateEdit" />
        public string CreateEdit()
        {
            return $"{BaseUrl}/edits";
        }

        /// <inheritdoc cref="IEndpointsProvider.CreateImage" />
        public string CreateImage()
        {
            return $"{BaseUrl}/images/generations";
        }

        /// <inheritdoc cref="IEndpointsProvider.CreateImageEdit" />
        public string CreateImageEdit()
        {
            return $"{BaseUrl}/images/edits";
        }

        /// <inheritdoc cref="IEndpointsProvider.CreateImageVariant" />
        public string CreateImageVariant()
        {
            return $"{BaseUrl}/images/variations";
        }

        /// <inheritdoc cref="IEndpointsProvider.CreateTranscription" />
        public string CreateTranscription()
        {
            return $"{BaseUrl}/audio/transcriptions";
        }

        /// <inheritdoc cref="IEndpointsProvider.CreateTranslation" />
        public string CreateTranslation()
        {
            return $"{BaseUrl}/audio/translations";
        }

        /// <inheritdoc cref="IEndpointsProvider.CreateModeration" />
        public string CreateModeration()
        {
            return $"{BaseUrl}/moderations";
        }

        /// <inheritdoc cref="IEndpointsProvider.ListModels" />
        public string ListModels()
        {
            return $"{BaseUrl}/models";
        }

        /// <inheritdoc cref="IEndpointsProvider.RetrieveModel" />
        public string RetrieveModel(string model)
        {
            return $"{BaseUrl}/models/{model}";
        }
    }
}