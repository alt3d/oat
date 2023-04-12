using System;
using System.Threading.Tasks;

namespace OpenAIToolkit
{
    /// <summary>
    ///     Turns audio into text.
    ///     <a href="https://platform.openai.com/docs/api-reference/audio">See more</a>
    /// </summary>
    public class AudioService : ServiceBase
    {
        internal AudioService(Client client) : base(client) { }

        /// <summary>
        ///     Transcribes audio into the input language.
        ///     <a href="https://platform.openai.com/docs/api-reference/audio/create">See more</a>
        /// </summary>
        /// <param name="request">A parameters required to generate a completion.</param>
        /// <param name="responseHandler">A delegate that is used to handle the response.</param>
        public void CreateTranscription(CreateTranscriptionRequest request, Action<CreateTranscriptionResponse> responseHandler)
        {
            Ensure.ArgumentNotNull(request, nameof(request));
            Ensure.ArgumentNotNull(responseHandler, nameof(responseHandler));

            new CreateTranscriptionRequestHandler(Client, request, responseHandler).Send();
        }

        /// <summary>
        ///     Transcribes audio into the input language.
        ///     <a href="https://platform.openai.com/docs/api-reference/audio/create">See more</a>
        /// </summary>
        /// <param name="request">A parameters required to generate a completion.</param>
        public async Task<CreateTranscriptionResponse> CreateTranscriptionAsync(CreateTranscriptionRequest request)
        {
            Ensure.ArgumentNotNull(request, nameof(request));

            return await new CreateTranscriptionRequestHandler(Client, request).SendAsync();
        }

        /// <summary>
        ///     Translates audio into English.
        ///     <a href="https://platform.openai.com/docs/api-reference/audio/create">See more</a>
        /// </summary>
        /// <param name="request">A parameters required to generate a completion.</param>
        /// <param name="responseHandler">A delegate that is used to handle the response.</param>
        public void CreateTranslation(CreateTranslationRequest request, Action<CreateTranslationResponse> responseHandler)
        {
            Ensure.ArgumentNotNull(request, nameof(request));
            Ensure.ArgumentNotNull(responseHandler, nameof(responseHandler));

            new CreateTranslationRequestHandler(Client, request, responseHandler).Send();
        }

        /// <summary>
        ///     Translates audio into English.
        ///     <a href="https://platform.openai.com/docs/api-reference/audio/create">See more</a>
        /// </summary>
        /// <param name="request">A parameters required to generate a completion.</param>
        public async Task<CreateTranslationResponse> CreateTranslationAsync(CreateTranslationRequest request)
        {
            Ensure.ArgumentNotNull(request, nameof(request));

            return await new CreateTranslationRequestHandler(Client, request).SendAsync();
        }
    }
}