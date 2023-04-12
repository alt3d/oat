using System.Collections.Generic;

namespace OpenAIToolkit
{
    /// <summary>
    ///     Create image edit response
    ///     <a href="https://platform.openai.com/docs/api-reference/images/create-edit">See more</a>
    /// </summary>
    public class CreateImageEditResponse : BaseResponse
    {
        /// <summary>
        ///     Represents the time when the response was created. The value is expressed in Unix timestamp format.
        /// </summary>
        public int Created { get; internal set; }

        /// <summary>
        ///     The list of image data
        /// </summary>
        public List<ImageData> Images { get; internal set; }

        /// <summary>
        ///     The format in which the response should be returned
        /// </summary>
        public ImageResponseFormat ResponseFormat { get; set; }
    }
}