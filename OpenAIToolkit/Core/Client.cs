namespace OpenAIToolkit
{
    /// <summary>
    ///     The main class representing the OpenAI Toolkit client.
    ///     Collects all the available services and provides access to them.
    /// </summary>
    public class Client
    {
        /// <inheritdoc cref="CompletionService" />
        public CompletionService Completion { get; internal set; }

        /// <inheritdoc cref="ChatService" />
        public ChatService Chat { get; internal set; }

        /// <inheritdoc cref="EditService" />
        public EditService Edit { get; internal set; }

        /// <inheritdoc cref="ImageService" />
        public ImageService Image { get; internal set; }

        /// <inheritdoc cref="AudioService" />
        public AudioService Audio { get; internal set; }

        /// <inheritdoc cref="ModerationService" />
        public ModerationService Moderation { get; internal set; }

        /// <inheritdoc cref="ModelService" />
        public ModelService Model { get; internal set; }

        /// <inheritdoc cref="IEndpointsProvider" />
        public IEndpointsProvider Endpoints { get; internal set; }

        /// <inheritdoc cref="IAuthenticationProvider" />
        public IAuthenticationProvider AuthProvider { get; internal set; }

        /// <inheritdoc cref="IClientSettings" />
        public IClientSettings Settings { get; internal set; }
    }
}