using System;
using System.Threading.Tasks;

namespace OpenAIToolkit
{
    /// <summary>
    ///     Given a chat conversation, the model will return a chat completion response.
    ///     <a href="https://platform.openai.com/docs/api-reference/chat">See more</a>
    /// </summary>
    public class ChatService : ServiceBase
    {
        internal ChatService(Client client) : base(client) { }

        /// <summary>
        ///     Creates a completion for the chat message
        ///     <a href="https://platform.openai.com/docs/api-reference/chat/create">See more</a>
        /// </summary>
        /// <param name="request">A parameters required to generate a completion.</param>
        /// <param name="responseHandler">A delegate that is used to handle the response.</param>
        public void CreateChatCompletion(CreateChatCompletionRequest request, Action<CreateChatCompletionResponse> responseHandler)
        {
            Ensure.ArgumentNotNull(request, nameof(request));
            Ensure.ArgumentNotNull(responseHandler, nameof(responseHandler));

            new CreateChatCompletionRequestHandler(Client, request, responseHandler).Send();
        }

        /// <summary>
        ///     Creates a completion for the chat message
        ///     <a href="https://platform.openai.com/docs/api-reference/chat/create">See more</a>
        /// </summary>
        /// <param name="request">A parameters required to generate a completion.</param>
        public async Task<CreateChatCompletionResponse> CreateChatCompletionAsync(CreateChatCompletionRequest request)
        {
            Ensure.ArgumentNotNull(request, nameof(request));

            return await new CreateChatCompletionRequestHandler(Client, request).SendAsync();
        }
    }
}