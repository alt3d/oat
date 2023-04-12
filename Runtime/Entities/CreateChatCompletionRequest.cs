using System.Collections.Generic;

namespace OpenAIToolkit
{
    /// <summary>
    ///     A parameters required to generate a completion.
    ///     <a href="https://platform.openai.com/docs/api-reference/chat/create">See more</a>
    /// </summary>
    public class CreateChatCompletionRequest
    {
        /// <inheritdoc cref="CreateChatCompletionRequest" />
        /// <param name="model">ID of the model to use. Currently, only gpt-3.5-turbo and gpt-3.5-turbo-0301 are supported.</param>
        /// <param name="messages"> The messages to generate chat completions for, in the chat format.</param>
        public CreateChatCompletionRequest(string model, List<ChatMessage> messages)
        {
            Ensure.ArgumentNotNull(model, nameof(model));
            Ensure.ArgumentNotNull(messages, nameof(messages));

            Model = model;
            Messages = messages;
        }

        /// <summary>
        ///     ID of the model to use. Currently, only gpt-3.5-turbo and gpt-3.5-turbo-0301 are supported.
        /// </summary>
        public string Model { get; }

        /// <summary>
        ///     The messages to generate chat completions for, in the chat format.
        /// </summary>
        public List<ChatMessage> Messages { get; }

        /// <summary>
        ///     What sampling temperature to use, between 0 and 2. Higher values like 0.8 will make the output more random, while
        ///     lower values like 0.2 will make it more focused and deterministic.
        /// </summary>
        /// <remarks>Defaults to 1</remarks>
        public float? Temperature { get; set; }

        /// <summary>
        ///     An alternative to sampling with temperature, called nucleus sampling, where the model considers the results of the
        ///     tokens with top_p probability mass. So 0.1 means only the tokens comprising the top 10% probability mass are
        ///     considered.
        /// </summary>
        /// <remarks>Defaults to 1</remarks>
        public float? TopP { get; set; }

        /// <summary>
        ///     How many chat completion choices to generate for each input message.
        /// </summary>
        /// <remarks>Defaults to 1</remarks>
        public int? Count { get; set; }

        /// <summary>
        ///     If set, partial message deltas will be sent, like in ChatGPT. Tokens will be sent as data-only server-sent events
        ///     as they become available, with the stream terminated by a data: [DONE] message.
        /// </summary>
        /// <remarks>Defaults to false</remarks>
        public bool? Stream { get; set; }

        /// <summary>
        ///     Up to 4 sequences where the API will stop generating further tokens.
        /// </summary>
        /// <remarks>Defaults to null</remarks>
        public List<string> Stop { get; set; }

        /// <summary>
        ///     The maximum number of tokens allowed for the generated answer. By default, the number of tokens the model can
        ///     return will be (4096 - prompt tokens).
        /// </summary>
        /// <remarks>Defaults to inf</remarks>
        public int? MaxTokens { get; set; }

        /// <summary>
        ///     Number between -2.0 and 2.0. Positive values penalize new tokens based on whether they appear in the text so far,
        ///     increasing the model's likelihood to talk about new topics.
        /// </summary>
        /// <remarks>Defaults to 0</remarks>
        public float? PresencePenalty { get; set; }

        /// <summary>
        ///     Number between -2.0 and 2.0. Positive values penalize new tokens based on their existing frequency in the text so
        ///     far, decreasing the model's likelihood to repeat the same line verbatim.
        /// </summary>
        /// <remarks>Defaults to 0</remarks>
        public float? FrequencyPenalty { get; set; }

        /// <summary>
        ///     A unique identifier representing your end-user, which can help OpenAI to monitor and detect abuse.
        /// </summary>
        /// <remarks>Defaults to null</remarks>
        public string User { get; set; }
    }
}