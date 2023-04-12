namespace OpenAIToolkit
{
    /// <summary>
    ///     The main class representing the OpenAI Toolkit client.
    ///     Collects all the available services and provides access to them.
    /// </summary>
    public class Client
    {
        /// <summary>
        ///     Create a new instance of the client
        /// </summary>
        public Client()
        {
            Completion = new CompletionService(this);
            Edit = new EditService(this);
            Chat = new ChatService(this);
            Image = new ImageService(this);
            Audio = new AudioService(this);
            Model = new ModelService(this);
            Moderation = new ModerationService(this);

            Settings = new ClientSettings();
        }

        /// <inheritdoc cref="CompletionService" />
        public CompletionService Completion { get; }

        /// <inheritdoc cref="ChatService" />
        public ChatService Chat { get; }

        /// <inheritdoc cref="EditService" />
        public EditService Edit { get; }

        /// <inheritdoc cref="ImageService" />
        public ImageService Image { get; }

        /// <inheritdoc cref="AudioService" />
        public AudioService Audio { get; }

        /// <inheritdoc cref="ModerationService" />
        public ModerationService Moderation { get; }

        /// <inheritdoc cref="ModelService" />
        public ModelService Model { get; }

        /// <inheritdoc cref="IEndpointsProvider" />
        public IEndpointsProvider EndpointsProvider { get; private set; }

        /// <inheritdoc cref="IAuthenticationInterceptor" />
        public IAuthenticationInterceptor AuthProvider { get; private set; }

        /// <inheritdoc cref="IClientSettings" />
        public IClientSettings Settings { get; internal set; }

        /// <summary>
        ///     Set the endpoints provider
        /// </summary>
        /// <param name="endpointsProvider"> Endpoints provider</param>
        /// <returns></returns>
        public Client SetEndpointsProvider(IEndpointsProvider endpointsProvider)
        {
            EndpointsProvider = endpointsProvider;
            return this;
        }

        /// <summary>
        ///     Set the authentication interceptor
        /// </summary>
        /// <param name="authProvider"> Authentication interceptor</param>
        /// <returns></returns>
        public Client SetAuthenticationInterceptor(IAuthenticationInterceptor authProvider)
        {
            AuthProvider = authProvider;
            return this;
        }

        /// <summary>
        ///     Set the client settings
        /// </summary>
        /// <param name="clientSettings"> Client settings</param>
        /// <returns></returns>
        public Client SetClientSettings(IClientSettings clientSettings)
        {
            Settings = clientSettings;
            return this;
        }
    }
}