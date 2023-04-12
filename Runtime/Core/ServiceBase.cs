namespace OpenAIToolkit
{
    /// <summary>
    ///     Base class for all services.
    /// </summary>
    public abstract class ServiceBase
    {
        /// <summary>
        ///     Client instance.
        /// </summary>
        protected readonly Client Client;

        /// <summary>
        ///     Creates a new instance of the <see cref="ServiceBase" /> class.
        /// </summary>
        protected ServiceBase(Client client)
        {
            Client = client;
        }
    }
}