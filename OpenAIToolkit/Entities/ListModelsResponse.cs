using System.Collections.Generic;

namespace OpenAIToolkit
{
    /// <summary>
    ///     Lists the currently available models, and provides basic information about each one such as the owner and
    ///     availability.
    /// </summary>
    public class ListModelsResponse : BaseResponse
    {
        /// <summary>
        ///     A list of available models on the OpenAI platform
        /// </summary>
        public List<Model> Models { get; internal set; }
    }
}