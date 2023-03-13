namespace OpenAIToolkit
{
    /// <summary>
    ///     A parameters required to retrieve model.
    ///     <a href="https://platform.openai.com/docs/api-reference/models/retrieve">See more</a>
    /// </summary>
    public class RetrieveModelRequest
    {
        public RetrieveModelRequest(string model)
        {
            Model = model;
        }

        /// <summary>
        ///     The ID of the model.
        /// </summary>
        public string Model { get; }
    }
}