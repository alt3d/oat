namespace OpenAIToolkit
{
    /// <summary>
    ///     Create edit request
    ///     <a href="https://platform.openai.com/docs/api-reference/edits/create">See more</a>
    /// </summary>
    public class CreateEditRequest
    {
        /// <inheritdoc cref="CreateEditRequest" />
        /// <param name="model">ID of the model to use. You can use the text-davinci-edit-001 or code-davinci-edit-001 model.</param>
        /// <param name="input">The input text to use as a starting point for the edit.</param>
        /// <param name="instruction">The instruction that tells the model how to edit the prompt.</param>
        public CreateEditRequest(string model, string input, string instruction)
        {
            Ensure.ArgumentNotNull(model, nameof(model));
            Ensure.ArgumentNotNull(input, nameof(input));
            Ensure.ArgumentNotNull(instruction, nameof(instruction));

            Model = model;
            Input = input;
            Instruction = instruction;
        }

        /// <summary>
        ///     ID of the model to use. You can use the text-davinci-edit-001 or code-davinci-edit-001 model.
        /// </summary>
        public string Model { get; }

        /// <summary>
        ///     The input text to use as a starting point for the edit.
        /// </summary>
        public string Input { get; }

        /// <summary>
        ///     The instruction that tells the model how to edit the prompt.
        /// </summary>
        public string Instruction { get; }

        /// <summary>
        ///     How many edits to generate for the input and instruction.
        /// </summary>
        /// <remarks>Defaults to 1</remarks>
        public int? Count { get; set; }

        /// <summary>
        ///     What sampling temperature to use. Higher values means the model will take more risks.
        ///     Try 0.9 for more creative applications, and 0 (argmax sampling) for ones with a well-defined answer.
        ///     We generally recommend altering this or TopP but not both.
        /// </summary>
        /// <remarks>Defaults to 1</remarks>
        public float? Temperature { get; set; }

        /// <summary>
        ///     An alternative to sampling with temperature, called nucleus sampling,
        ///     where the model considers the results of the tokens with top_p probability mass.
        ///     So 0.1 means only the tokens comprising the top 10% probability mass are considered.
        ///     We generally recommend altering this or temperature but not both.
        /// </summary>
        /// <remarks>Defaults to 1</remarks>
        public float? TopP { get; set; }

        /// <summary>
        ///     A unique identifier representing your end-user, which can help OpenAI to monitor and detect abuse.
        /// </summary>
        /// <remarks>Defaults to null</remarks>
        public string User { get; set; }
    }
}