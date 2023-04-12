namespace OpenAIToolkit
{
    /// <summary>
    ///     Create image request
    ///     <a href="https://platform.openai.com/docs/api-reference/images/create">See more</a>
    /// </summary>
    public class CreateImageRequest
    {
        /// <inheritdoc cref="CreateImageRequest" />
        /// <param name="prompt">A text description of the desired image(s). The maximum length is 1000 characters.</param>
        public CreateImageRequest(string prompt)
        {
            Ensure.ArgumentNotNull(prompt, nameof(prompt));

            Prompt = prompt;
            ResponseFormat = ImageResponseFormat.Texture2D;
        }

        /// <summary>
        ///     A text description of the desired image(s). The maximum length is 1000 characters.
        /// </summary>
        public string Prompt { get; }

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