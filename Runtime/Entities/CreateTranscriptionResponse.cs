namespace OpenAIToolkit
{
    /// <summary>
    ///     Create transcription response
    /// </summary>
    public class CreateTranscriptionResponse : BaseResponse
    {
        /// <summary>
        ///     The transcription of the audio file.
        /// </summary>
        public string Text { get; internal set; }
    }
}