namespace OpenAIToolkit
{
    /// <inheritdoc cref="IClientSettings" />
    public class ClientSettings : IClientSettings
    {
        /// <summary>
        ///     Creates a new instance of the <see cref="ClientSettings" /> class.
        /// </summary>
        public ClientSettings(bool isLogWeb = true)
        {
            IsLogWeb = isLogWeb;
        }

        /// <inheritdoc cref="IClientSettings.IsLogWeb" />
        public bool IsLogWeb { get; }
    }
}