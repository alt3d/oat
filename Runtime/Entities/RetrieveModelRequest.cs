namespace OpenAIToolkit
{
    /// <summary>
    ///     A parameters required to retrieve model.
    ///     <a href="https://platform.openai.com/docs/api-reference/models/retrieve">See more</a>
    /// </summary>
    public class RetrieveModelRequest
    {
        /// <inheritdoc cref="RetrieveModelRequest" />
        /// <param name="model">The ID of the model.</param>
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