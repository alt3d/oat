using System;
using System.Threading.Tasks;

namespace OpenAIToolkit
{
    /// <summary>
    ///     Given a prompt and/or an input image, the model will generate a new image.
    ///     <a href="https://platform.openai.com/docs/api-reference/images">See more</a>
    /// </summary>
    public class ImageService : ServiceBase
    {
        internal ImageService(Client client) : base(client) { }

        /// <summary>
        ///     Creates an image given a prompt.
        ///     <a href="https://platform.openai.com/docs/api-reference/images/create">See more</a>
        /// </summary>
        /// <param name="request">A parameters required to generate a completion.</param>
        /// <param name="responseHandler">A delegate that is used to handle the response.</param>
        public void CreateImage(CreateImageRequest request, Action<CreateImageResponse> responseHandler)
        {
            Ensure.ArgumentNotNull(request, nameof(request));
            Ensure.ArgumentNotNull(responseHandler, nameof(responseHandler));

            new CreateImageRequestHandler(Client, request, responseHandler).Send();
        }

        /// <summary>
        ///     Creates an image given a prompt.
        ///     <a href="https://platform.openai.com/docs/api-reference/images/create">See more</a>
        /// </summary>
        /// <param name="request">A parameters required to generate a completion.</param>
        public async Task<CreateImageResponse> CreateImageAsync(CreateImageRequest request)
        {
            Ensure.ArgumentNotNull(request, nameof(request));

            return await new CreateImageRequestHandler(Client, request).SendAsync();
        }

        /// <summary>
        ///     Creates an edited or extended image given an original image and a prompt.
        ///     <a href="https://platform.openai.com/docs/api-reference/images/create-edit">See more</a>
        /// </summary>
        /// <param name="request">A parameters required to generate a completion.</param>
        /// <param name="responseHandler">A delegate that is used to handle the response.</param>
        public void CreateImageEdit(CreateImageEditRequest request, Action<CreateImageEditResponse> responseHandler)
        {
            Ensure.ArgumentNotNull(request, nameof(request));
            Ensure.ArgumentNotNull(responseHandler, nameof(responseHandler));

            new CreateImageEditRequestHandler(Client, request, responseHandler).Send();
        }

        /// <summary>
        ///     Creates an edited or extended image given an original image and a prompt.
        ///     <a href="https://platform.openai.com/docs/api-reference/images/create-edit">See more</a>
        /// </summary>
        /// <param name="request">A parameters required to generate a completion.</param>
        public async Task<CreateImageEditResponse> CreateImageEditAsync(CreateImageEditRequest request)
        {
            Ensure.ArgumentNotNull(request, nameof(request));

            return await new CreateImageEditRequestHandler(Client, request).SendAsync();
        }

        /// <summary>
        ///     Creates a variation of a given image.
        ///     <a href="https://platform.openai.com/docs/api-reference/images/create-variation">See more</a>
        /// </summary>
        /// <param name="request">A parameters required to generate a completion.</param>
        /// <param name="responseHandler">A delegate that is used to handle the response.</param>
        public void CreateImageVariant(CreateImageVariantRequest request, Action<CreateImageVariantResponse> responseHandler)
        {
            Ensure.ArgumentNotNull(request, nameof(request));
            Ensure.ArgumentNotNull(responseHandler, nameof(responseHandler));

            new CreateImageVariantRequestHandler(Client, request, responseHandler).Send();
        }

        /// <summary>
        ///     Creates a variation of a given image.
        ///     <a href="https://platform.openai.com/docs/api-reference/images/create-variation">See more</a>
        /// </summary>
        /// <param name="request">A parameters required to generate a completion.</param>
        public async Task<CreateImageVariantResponse> CreateImageVariantAsync(CreateImageVariantRequest request)
        {
            Ensure.ArgumentNotNull(request, nameof(request));

            return await new CreateImageVariantRequestHandler(Client, request).SendAsync();
        }
    }
}