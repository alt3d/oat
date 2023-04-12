namespace OpenAIToolkit
{
    internal abstract class BaseRequestHandler
    {
        protected readonly Client Client;

        protected readonly DtoConverter DtoConverter;

        protected BaseRequestHandler(Client client)
        {
            Client = client;
            DtoConverter = new DtoConverter();
        }
    }
}