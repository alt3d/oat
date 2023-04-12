namespace OpenAIToolkit
{
    /// <summary>
    ///     A parameters required to generate a transcription.
    ///     <a href="https://platform.openai.com/docs/api-reference/audio/create">See more</a>
    /// </summary>
    public class CreateTranscriptionRequest
    {
        /// <inheritdoc cref="CreateTranscriptionRequest" />
        /// <param name="model">ID of the model to use. Only whisper-1 is currently available.</param>
        /// <param name="data">Raw audio file data to transcribe. Available formats: mp3, mp4, mpeg, mpga, m4a, wav, or webm.</param>
        public CreateTranscriptionRequest(string model, byte[] data)
        {
            Ensure.ArgumentNotNull(model, nameof(model));
            Ensure.ArgumentNotNull(data, nameof(data));

            Model = model;
            Data = data;
        }

        /// <summary>
        ///     ID of the model to use. Only whisper-1 is currently available.
        /// </summary>
        public string Model { get; }

        /// <summary>
        ///     Raw audio file data to transcribe. Available formats: mp3, mp4, mpeg, mpga, m4a, wav, or webm.
        /// </summary>
        public byte[] Data { get; }

        /// <summary>
        ///     An optional text to guide the model's style or continue a previous audio segment. The prompt should match the audio
        ///     language.
        /// </summary>
        /// <remarks>Defaults to null</remarks>
        public string Prompt { get; set; }

        /// <summary>
        ///     The sampling temperature, between 0 and 1. Higher values like 0.8 will make the output more random, while lower
        ///     values like 0.2 will make it more focused and deterministic. If set to 0, the model will use log probability to
        ///     automatically increase the temperature until certain thresholds are hit.
        /// </summary>
        /// <remarks>Defaults to 0</remarks>
        public float? Temperature { get; set; }

        /// <summary>
        ///     The language of the input audio. Supplying the input language in ISO-639-1 format will improve accuracy and
        ///     latency.
        /// </summary>
        /// <remarks>Defaults to null</remarks>
        public string Language { get; set; }
    }
}