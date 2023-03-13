namespace OpenAIToolkit
{
    /// <summary>
    ///     Create translation response
    /// </summary>
    public class CreateTranslationResponse : BaseResponse
    {
        /// <summary>
        ///     The translation of the audio file.
        /// </summary>
        public string Text { get; internal set; }
    }
}