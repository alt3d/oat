namespace OpenAIToolkit
{
    /// <summary>
    ///     Retrieves a model response.
    /// </summary>
    public class RetrieveModelResponse : BaseResponse
    {
        /// <summary>
        ///     The detailed information about the model.
        /// </summary>
        public Model Model { get; internal set; }
    }
}