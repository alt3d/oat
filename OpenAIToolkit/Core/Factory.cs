namespace OpenAIToolkit
{
    /// <summary>
    ///     Factory class to create a new instance of the <see cref="Client" /> class.
    /// </summary>
    public static class Factory
    {
        /// <summary>
        ///     Factory method to create a new instance of the <see cref="Client" /> class.
        /// </summary>
        public static Client CreateClient(string apiKey, string organization = null)
        {
            var authProvider = new AuthenticationProvider(apiKey, organization);
            var endpointsProvider = new EndpointsProvider();
            var clientSettings = new ClientSettings();

            return CreateClient(endpointsProvider, authProvider, clientSettings);
        }

        /// <summary>
        ///     Factory method to create a new instance of the <see cref="Client" /> class.
        /// </summary>
        public static Client CreateClient(IEndpointsProvider endpointsProvider, IAuthenticationProvider authProvider, IClientSettings clientSettings = null)
        {
            var client = new Client {
                Endpoints = endpointsProvider,
                AuthProvider = authProvider,
                Settings = clientSettings ?? new ClientSettings()
            };

            client.Completion = new CompletionService(client);
            client.Edit = new EditService(client);
            client.Chat = new ChatService(client);
            client.Image = new ImageService(client);
            client.Audio = new AudioService(client);
            client.Model = new ModelService(client);
            client.Moderation = new ModerationService(client);

            return client;
        }
    }
}