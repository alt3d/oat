using System.Collections.Generic;

namespace OpenAIToolkit
{
    /// <summary>
    ///     Create completion request
    ///     <a href="https://platform.openai.com/docs/api-reference/completions/create">See more</a>
    /// </summary>
    public class CreateCompletionRequest
    {
        /// <inheritdoc cref="CreateCompletionRequest" />
        /// <param name="model">ID of the model to use.</param>
        /// <param name="prompt">
        ///     The prompt to generate completions for, encoded as a string, array of strings,
        ///     array of tokens, or array of token arrays.
        /// </param>
        public CreateCompletionRequest(string model, string prompt)
        {
            Ensure.ArgumentNotNull(model, nameof(model));
            Ensure.ArgumentNotNull(prompt, nameof(prompt));

            Model = model;
            Prompts = new List<string> {prompt};
        }

        /// <inheritdoc cref="CreateCompletionRequest" />
        /// <param name="model">ID of the model to use.</param>
        /// <param name="prompts">
        ///     The prompts to generate completions for, encoded as a string, array of strings,
        ///     array of tokens, or array of token arrays.
        /// </param>
        public CreateCompletionRequest(string model, List<string> prompts)
        {
            Ensure.ArgumentNotNull(model, nameof(model));
            Ensure.ArgumentNotNull(prompts, nameof(prompts));

            Model = model;
            Prompts = prompts;
        }

        /// <summary>
        ///     ID of the model to use.
        /// </summary>
        public string Model { get; }

        /// <summary>
        ///     The prompt(s) to generate completions for, encoded as a string, array of strings, array of tokens, or array of
        ///     token arrays.
        /// </summary>
        /// <remarks>Defaults to endoftext</remarks>
        public List<string> Prompts { get; }

        /// <summary>
        ///     The suffix that comes after a completion of inserted text.
        /// </summary>
        /// <remarks>Defaults to null</remarks>
        public string Suffix { get; set; }

        /// <summary>
        ///     The maximum number of tokens to generate in the completion.
        ///     The token count of your prompt plus max_tokens cannot exceed the model's context length.
        ///     Most models have a context length of 2048 tokens (except for the newest models, which support 4096).
        /// </summary>
        /// <remarks>Defaults to 16</remarks>
        public int? MaxTokens { get; set; }

        /// <summary>
        ///     What sampling temperature to use. Higher values means the model will take more risks.
        ///     Try 0.9 for more creative applications, and 0 (argmax sampling) for ones with a well-defined answer.
        /// </summary>
        /// <remarks>Defaults to 1</remarks>
        public float? Temperature { get; set; }

        /// <summary>
        ///     An alternative to sampling with temperature, called nucleus sampling,
        ///     where the model considers the results of the tokens with top_p probability mass.
        ///     So 0.1 means only the tokens comprising the top 10% probability mass are considered.
        /// </summary>
        /// <remarks>Defaults to 1</remarks>
        public float? TopP { get; set; }

        /// <summary>
        ///     How many completions to generate for each prompt.
        /// </summary>
        /// <remarks>Defaults to 1</remarks>
        public int? Count { get; set; }

        /// <summary>
        ///     Whether to stream back partial progress.
        ///     If set, tokens will be sent as data-only server-sent events as they become available,
        ///     with the stream terminated by a data: [DONE] message.
        /// </summary>
        /// <remarks>Defaults to false</remarks>
        public bool? Stream { get; set; }

        /// <summary>
        ///     Include the log probabilities on the logprobs most likely tokens, as well the chosen tokens.
        ///     For example, if logprobs is 5, the API will return a list of the 5 most likely tokens.
        ///     The API will always return the logprob of the sampled token, so there may be up to logprobs+1 elements in the
        ///     response.
        ///     The maximum value for logprobs is 5. If you need more than this, please contact us through our Help center and
        ///     describe your use case.
        /// </summary>
        /// <remarks>Defaults to null</remarks>
        public int? Logprobs { get; set; }

        /// <summary>
        ///     Echo back the prompt in addition to the completion
        /// </summary>
        /// <remarks>Defaults to false</remarks>
        public bool? Echo { get; set; }

        /// <summary>
        ///     Up to 4 sequences where the API will stop generating further tokens. The returned text will not contain the stop
        ///     sequence.
        /// </summary>
        /// <remarks>Defaults to null</remarks>
        public List<string> Stop { get; set; }

        /// <summary>
        ///     Number between -2.0 and 2.0. Positive values penalize new tokens based on whether they appear in the text so far,
        ///     increasing the model's likelihood to talk about new topics.
        /// </summary>
        /// <remarks>Defaults to 0</remarks>
        public float? PresencePenalty { get; set; }

        /// <summary>
        ///     Number between -2.0 and 2.0. Positive values penalize new tokens based on their existing frequency in the text so
        ///     far,
        ///     decreasing the model's likelihood to repeat the same line verbatim.
        /// </summary>
        /// <remarks>Defaults to 0</remarks>
        public float? FrequencyPenalty { get; set; }

        /// <summary>
        ///     Generates best_of completions server-side and returns the "best" (the one with the highest log probability per
        ///     token).
        ///     Results cannot be streamed.
        /// </summary>
        /// <remarks>Defaults to 1</remarks>
        public int? BestOf { get; set; }

        /// <summary>
        ///     A unique identifier representing your end-user, which can help OpenAI to monitor and detect abuse.
        /// </summary>
        /// <remarks>Defaults to null</remarks>
        public string User { get; set; }
    }
}