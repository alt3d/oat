namespace OpenAIToolkit
{
    /// <summary>
    ///     Error that can occur when working with the OpenAI.
    /// </summary>
    public class Error
    {
        internal Error() { }

        private Error(string message)
        {
            Message = message;
        }

        /// <summary>
        ///     The message describing the error.
        /// </summary>
        public string Message { get; internal set; }

        /// <summary>
        ///     The type of the error.
        /// </summary>
        public string Type { get; internal set; }

        /// <summary>
        ///     The parameter related to the error.
        /// </summary>
        public string Param { get; internal set; }

        /// <summary>
        ///     The code associated with the error.
        /// </summary>
        public string Code { get; internal set; }

        /// <summary>
        ///     An error indicating a network error.
        /// </summary>
        internal static Error NetworkError => new Error("Network error");
    }
}