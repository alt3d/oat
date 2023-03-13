using System;
using System.Threading.Tasks;
using UnityEngine.Networking;

namespace OpenAIToolkit
{
    internal class RetrieveModelRequestHandler : BaseRequestHandler
    {
        private readonly RetrieveModelRequest Request;
        private readonly Action<RetrieveModelResponse> ResponseHandler;

        public RetrieveModelRequestHandler(Client client, RetrieveModelRequest request, Action<RetrieveModelResponse> responseHandler) : base(client)
        {
            Request = request;
            ResponseHandler = responseHandler;
        }

        public RetrieveModelRequestHandler(Client client, RetrieveModelRequest request) : base(client)
        {
            Request = request;
        }

        public void Send()
        {
            var webRequest = CreateWebRequest();
            WebUtils.Send<ModelDto>(
                Client,
                webRequest,
                responseDto =>
                {
                    var response = CreateResponse(responseDto);
                    ResponseHandler?.Invoke(response);
                },
                error =>
                {
                    var response = CreateResponse(error);
                    ResponseHandler?.Invoke(response);
                });
        }

        public async Task<RetrieveModelResponse> SendAsync()
        {
            var webRequest = CreateWebRequest();
            var result = await WebUtils.SendAsync<ModelDto>(Client, webRequest);
            return result.responseDto != null
                ? CreateResponse(result.responseDto)
                : CreateResponse(result.error);
        }

        private UnityWebRequest CreateWebRequest()
        {
            var url = string.Format(Client.Endpoints.RetrieveModel, Request.Model);
            return WebUtils.CreateGet(Client, url);
        }

        private RetrieveModelResponse CreateResponse(ModelDto responseDto)
        {
            return new RetrieveModelResponse {
                Model = DtoConverter.Convert(responseDto)
            };
        }

        private RetrieveModelResponse CreateResponse(Error error)
        {
            return new RetrieveModelResponse {
                Error = error
            };
        }
    }
}