using System;
using System.Threading.Tasks;

namespace OpenAIToolkit
{
    /// <summary>
    ///     Given a input text, outputs if the model classifies it as violating OpenAI's content policy.
    ///     <a href="https://platform.openai.com/docs/api-reference/moderations">See more</a>
    /// </summary>
    public class ModerationService : ServiceBase
    {
        internal ModerationService(Client client) : base(client) { }

        /// <summary>
        ///     Classifies if text violates OpenAI's Content Policy
        ///     <a href="https://platform.openai.com/docs/api-reference/moderations/create">See more</a>
        /// </summary>
        /// <param name="request">A parameters required to generate a completion.</param>
        /// <param name="responseHandler">A delegate that is used to handle the response.</param>
        public void CreateModeration(CreateModerationRequest request, Action<CreateModerationResponse> responseHandler)
        {
            Ensure.ArgumentNotNull(request, nameof(request));
            Ensure.ArgumentNotNull(responseHandler, nameof(responseHandler));

            new CreateModerationHandler(Client, request, responseHandler).Send();
        }

        /// <summary>
        ///     Classifies if text violates OpenAI's Content Policy
        ///     <a href="https://platform.openai.com/docs/api-reference/moderations/create">See more</a>
        /// </summary>
        /// <param name="request">A parameters required to generate a completion.</param>
        public async Task<CreateModerationResponse> CreateModerationAsync(CreateModerationRequest request)
        {
            Ensure.ArgumentNotNull(request, nameof(request));

            return await new CreateModerationHandler(Client, request).SendAsync();
        }
    }
}