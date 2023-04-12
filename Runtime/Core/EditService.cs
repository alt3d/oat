using System;
using System.Threading.Tasks;

namespace OpenAIToolkit
{
    /// <summary>
    ///     Given a prompt and an instruction, the model will return an edited version of the prompt.
    ///     <a href="https://platform.openai.com/docs/api-reference/edits">See more</a>
    /// </summary>
    public class EditService : ServiceBase
    {
        internal EditService(Client client) : base(client) { }

        /// <summary>
        ///     Creates a new edit for the provided input, instruction, and parameters.
        ///     <a href="https://platform.openai.com/docs/api-reference/edits/create">See more</a>
        /// </summary>
        /// <param name="request">A parameters required to generate a completion.</param>
        /// <param name="responseHandler">A delegate that is used to handle the response.</param>
        public void CreateEdit(CreateEditRequest request, Action<CreateEditResponse> responseHandler)
        {
            Ensure.ArgumentNotNull(request, nameof(request));
            Ensure.ArgumentNotNull(responseHandler, nameof(responseHandler));

            new CreateEditRequestHandler(Client, request, responseHandler).Send();
        }

        /// <summary>
        ///     Creates a new edit for the provided input, instruction, and parameters.
        ///     <a href="https://platform.openai.com/docs/api-reference/edits/create">See more</a>
        /// </summary>
        /// <param name="request">A parameters required to generate a completion.</param>
        public Task<CreateEditResponse> CreateEditAsync(CreateEditRequest request)
        {
            Ensure.ArgumentNotNull(request, nameof(request));

            return new CreateEditRequestHandler(Client, request).SendAsync();
        }
    }
}