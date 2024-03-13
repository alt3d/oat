namespace OpenAIToolkit
{
    /// <summary>
    ///     Base abstract class for response.
    /// </summary>
    public class BaseResponse
    {
        /// <summary>
        ///     The error details in case of a failed response.
        /// </summary>
        public Error Error { get; internal set; }

        /// <summary>
        ///     Indicates whether the response was successful.
        /// </summary>
        public bool Successful => Error == null;
    }
}