using UnityEngine;

namespace OpenAIToolkit
{
    /// <summary>
    ///     Represents the data of an image in the OpenAI API.
    /// </summary>
    public class ImageData
    {
        /// <summary>
        ///     The URL of the image.
        /// </summary>
        public string Url { get; internal set; }

        /// <summary>
        ///     The `Texture2D` representation of the image.
        /// </summary>
        public Texture2D Texture { get; internal set; }
    }
}