namespace OpenAIToolkit
{
    /// <summary>
    ///     OpenAI client implementation
    /// </summary>
    public class OpenAIClient : Client
    {
        /// <summary>
        ///     Create a new instance of the OpenAI client
        /// </summary>
        /// <param name="apiKey">
        ///     The OpenAI API uses API keys for authentication.
        ///     Visit your <a href="https://beta.openai.com/account/api-keys">API Keys page</a>
        ///     to retrieve the API key you'll use in your requests.
        ///     Remember that your API key is a secret!
        ///     Do not share it with others or expose it in any client-side code(browsers,apps).
        ///     Production requests must be routed through your own backend server where your API key
        ///     can be securely loaded from an environment variable or key management service.
        /// </param>
        /// <param name="organisation">
        ///     For users who belong to multiple organizations, you can pass a header
        ///     to specify which organization is used for an API request.
        ///     Usage from these API requests will count against the specified organization's subscription quota.
        ///     Organization IDs can be found on your
        ///     <a href="https://beta.openai.com/account/org-settings">Organization settings</a> page.
        /// </param>
        public OpenAIClient(string apiKey, string organisation = null)
        {
            SetAuthenticationInterceptor(new OpenAIAuthenticationInterceptor(apiKey, organisation));
            SetEndpointsProvider(new OpenAIEndpointsProvider());
            SetClientSettings(new ClientSettings());
        }
    }
}