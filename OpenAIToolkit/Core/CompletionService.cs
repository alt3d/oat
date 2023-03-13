using System;
using System.Threading.Tasks;

namespace OpenAIToolkit
{
    /// <summary>
    ///     Given a prompt, the model will return one or more predicted completions,
    ///     and can also return the probabilities of alternative tokens at each position.
    ///     <a href="https://platform.openai.com/docs/api-reference/completions">See more</a>
    /// </summary>
    public class CompletionService : ServiceBase
    {
        internal CompletionService(Client client) : base(client) { }

        /// <summary>
        ///     Creates a completion for the provided prompt and parameters
        ///     <a href="https://platform.openai.com/docs/api-reference/completions/create">See more</a>
        /// </summary>
        /// <param name="request">A parameters required to generate a completion.</param>
        /// <param name="responseHandler">A delegate that is used to handle the response.</param>
        public void CreateCompletion(CreateCompletionRequest request, Action<CreateCompletionResponse> responseHandler)
        {
            Ensure.ArgumentNotNull(request, nameof(request));
            Ensure.ArgumentNotNull(responseHandler, nameof(responseHandler));

            new CreateCompletionRequestHandler(Client, request, responseHandler).Send();
        }

        /// <summary>
        ///     Creates a completion for the provided prompt and parameters
        ///     <a href="https://platform.openai.com/docs/api-reference/completions/create">See more</a>
        /// </summary>
        /// <param name="request">A parameters required to generate a completion.</param>
        public async Task<CreateCompletionResponse> CreateCompletionAsync(CreateCompletionRequest request)
        {
            Ensure.ArgumentNotNull(request, nameof(request));

            return await new CreateCompletionRequestHandler(Client, request).SendAsync();
        }
    }
}