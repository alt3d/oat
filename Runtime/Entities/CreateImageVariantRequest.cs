using UnityEngine;

namespace OpenAIToolkit
{
    /// <summary>
    ///     Create image variant request
    ///     <a href="https://platform.openai.com/docs/api-reference/images/create-variation">See more</a>
    /// </summary>
    public class CreateImageVariantRequest
    {
        /// <inheritdoc cref="CreateImageVariantRequest" />
        /// <param name="image">The image to use as the basis for the variation(s). Must be less than 4MB, and square.</param>
        public CreateImageVariantRequest(Texture2D image)
        {
            Ensure.ArgumentNotNull(image, nameof(image));

            Image = image;
            ResponseFormat = ImageResponseFormat.Texture2D;
        }

        /// <summary>
        ///     The image to use as the basis for the variation(s). Must be less than 4MB, and square.
        /// </summary>
        public Texture2D Image { get; }

        /// <summary>
        ///     The number of images to generate. Must be between 1 and 10.
        /// </summary>
        /// <remarks>Defaults to 1</remarks>
        public int? Count { get; set; }

        /// <summary>
        ///     The size of the generated images. Must be one of 256x256, 512x512, or 1024x1024.
        /// </summary>
        /// <remarks>Defaults to 1024x1024</remarks>
        public ImageSize? Size { get; set; }

        /// <summary>
        ///     The format in which the response should be returned
        /// </summary>
        public ImageResponseFormat ResponseFormat { get; set; }

        /// <summary>
        ///     A unique identifier representing your end-user, which can help OpenAI to monitor and detect abuse.
        /// </summary>
        /// <remarks>Defaults to null</remarks>
        public string User { get; set; }
    }
}