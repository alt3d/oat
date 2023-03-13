namespace OpenAIToolkit
{
    /// <summary>
    ///     Collection of settings for the OpenAIToolkit client.
    /// </summary>
    public interface IClientSettings
    {
        /// <summary>
        ///     If true, the client will log all web requests and responses.
        /// </summary>
        bool IsLogWeb { get; }
    }
}