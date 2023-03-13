namespace OpenAIToolkit
{
    /// <inheritdoc cref="IAuthenticationProvider" />
    public class AuthenticationProvider : IAuthenticationProvider
    {
        /// <summary>
        ///     Creates a new instance of the <see cref="AuthenticationProvider" /> class.
        /// </summary>
        /// <param name="apiKey">The private key provided by OpenAI.</param>
        /// <param name="organization">The organization id provided by OpenAI.</param>
        public AuthenticationProvider(string apiKey, string organization = null)
        {
            ApiKey = apiKey;
            Organization = organization;
        }

        /// <inheritdoc cref="IAuthenticationProvider.ApiKey" />
        public string ApiKey { get; }

        /// <inheritdoc cref="IAuthenticationProvider.Organization" />
        public string Organization { get; }
    }
}