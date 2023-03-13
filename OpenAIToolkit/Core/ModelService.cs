using System;
using System.Threading.Tasks;

namespace OpenAIToolkit
{
    /// <summary>
    ///     List and describe the various models available in the API.
    ///     You can refer to the Models documentation to understand what models are available and the differences between them.
    ///     <a href="https://platform.openai.com/docs/api-reference/models">See more</a>
    /// </summary>
    public class ModelService : ServiceBase
    {
        internal ModelService(Client client) : base(client) { }

        /// <summary>
        ///     Lists the currently available models, and provides basic information about each one such as the owner and
        ///     availability.
        ///     <a href="https://platform.openai.com/docs/api-reference/models/list">See more</a>
        /// </summary>
        /// <param name="responseHandler">Delegate that is used to handle the response.</param>
        public void ListModels(Action<ListModelsResponse> responseHandler)
        {
            Ensure.ArgumentNotNull(responseHandler, nameof(responseHandler));

            new ListModelsRequestHandler(Client, responseHandler).Send();
        }

        /// <summary>
        ///     Lists the currently available models, and provides basic information about each one such as the owner and
        ///     availability.
        ///     <a href="https://platform.openai.com/docs/api-reference/models/list">See more</a>
        /// </summary>
        public async Task<ListModelsResponse> ListModelsAsync()
        {
            return await new ListModelsRequestHandler(Client).SendAsync();
        }

        /// <summary>
        ///     Retrieves a model instance, providing basic information about the model such as the owner and permissioning.
        ///     <a href="https://platform.openai.com/docs/api-reference/models/retrieve">See more</a>
        /// </summary>
        /// <param name="request">A parameters required to generate a completion.</param>
        /// <param name="responseHandler">A delegate that is used to handle the response.</param>
        public void RetrieveModel(RetrieveModelRequest request, Action<RetrieveModelResponse> responseHandler)
        {
            Ensure.ArgumentNotNull(request, nameof(request));
            Ensure.ArgumentNotNull(responseHandler, nameof(responseHandler));

            new RetrieveModelRequestHandler(Client, request, responseHandler).Send();
        }

        /// <summary>
        ///     Retrieves a model instance, providing basic information about the model such as the owner and permissioning.
        ///     <a href="https://platform.openai.com/docs/api-reference/models/retrieve">See more</a>
        /// </summary>
        /// <param name="request">A parameters required to generate a completion.</param>
        public async Task<RetrieveModelResponse> RetrieveModelAsync(RetrieveModelRequest request)
        {
            Ensure.ArgumentNotNull(request, nameof(request));

            return await new RetrieveModelRequestHandler(Client, request).SendAsync();
        }
    }
}