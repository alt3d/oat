using UnityEngine;

namespace OpenAIToolkit
{
    /// <summary>
    ///     Create image edit request
    ///     <a href="https://platform.openai.com/docs/api-reference/images/create-edit">See more</a>
    /// </summary>
    public class CreateImageEditRequest
    {
        /// <inheritdoc cref="CreateImageEditRequest" />
        /// <param name="image">
        ///     The image to edit. Must be a valid PNG file, less than 4MB, and square.
        ///     If mask is not provided, image must have transparency, which will be used as the mask.
        /// </param>
        /// <param name="prompt">A text description of the desired image(s). The maximum length is 1000 characters.</param>
        public CreateImageEditRequest(Texture2D image, string prompt)
        {
            Ensure.ArgumentNotNull(image, nameof(image));
            Ensure.ArgumentNotNull(prompt, nameof(prompt));

            Image = image;
            Prompt = prompt;
            ResponseFormat = ImageResponseFormat.Texture2D;
        }

        /// <inheritdoc cref="CreateImageEditRequest" />
        /// <param name="image">The image to edit. Must be a valid PNG file, less than 4MB, and square.</param>
        /// <param name="mask">
        ///     An additional image whose fully transparent areas (e.g. where alpha is zero) indicate where image
        ///     should be edited. Must be a valid PNG file, less than 4MB, and have the same dimensions as image.
        /// </param>
        /// <param name="prompt">A text description of the desired image(s). The maximum length is 1000 characters.</param>
        public CreateImageEditRequest(Texture2D image, Texture2D mask, string prompt)
        {
            Ensure.ArgumentNotNull(image, nameof(image));
            Ensure.ArgumentNotNull(mask, nameof(mask));
            Ensure.ArgumentNotNull(prompt, nameof(prompt));

            Image = image;
            Mask = mask;
            Prompt = prompt;
            ResponseFormat = ImageResponseFormat.Texture2D;
        }

        /// <summary>
        ///     The image to edit. Must be less than 4MB, and square.
        ///     If mask is not provided, image must have transparency, which will be used as the mask.
        /// </summary>
        public Texture2D Image { get; set; }

        /// <summary>
        ///     An additional image whose fully transparent areas (e.g. where alpha is zero) indicate where image should be edited.
        ///     Must be less than 4MB, and have the same dimensions as image.
        /// </summary>
        /// <remarks>Defaults to null</remarks>
        public Texture2D Mask { get; set; }

        /// <summary>
        ///     A text description of the desired image(s). The maximum length is 1000 characters.
        /// </summary>
        public string Prompt { get; set; }

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