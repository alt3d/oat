using System;
using System.Threading.Tasks;
using UnityEngine.Networking;

namespace OpenAIToolkit
{
    internal class ListModelsRequestHandler : BaseRequestHandler
    {
        private readonly Action<ListModelsResponse> ResponseHandler;

        public ListModelsRequestHandler(Client client, Action<ListModelsResponse> responseHandler) : base(client)
        {
            ResponseHandler = responseHandler;
        }

        public ListModelsRequestHandler(Client client) : base(client) { }

        public void Send()
        {
            var webRequest = CreateWebRequest();
            WebUtils.Send<ModelListDto>(
                Client,
                webRequest,
                responseDto =>
                {
                    var response = CreateResponse(responseDto);
                    ResponseHandler?.Invoke(response);
                }, error =>
                {
                    var response = CreateResponse(error);
                    ResponseHandler?.Invoke(response);
                });
        }

        public async Task<ListModelsResponse> SendAsync()
        {
            var webRequest = CreateWebRequest();
            var result = await WebUtils.SendAsync<ModelListDto>(Client, webRequest);
            return result.responseDto != null
                ? CreateResponse(result.responseDto)
                : CreateResponse(result.error);
        }

        private UnityWebRequest CreateWebRequest()
        {
            var url = Client.EndpointsProvider.ListModels();
            return WebUtils.CreateGet(Client, url);
        }

        private ListModelsResponse CreateResponse(ModelListDto responseDto)
        {
            return new ListModelsResponse {
                Models = DtoConverter.Convert(responseDto.data)
            };
        }

        private ListModelsResponse CreateResponse(Error error)
        {
            return new ListModelsResponse {
                Error = error
            };
        }
    }
}