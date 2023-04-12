using System;
using System.Threading.Tasks;
using UnityEngine.Networking;

namespace OpenAIToolkit
{
    internal class CreateModerationHandler : BaseRequestHandler
    {
        private readonly CreateModerationRequest Request;
        private readonly Action<CreateModerationResponse> ResponseHandler;

        public CreateModerationHandler(Client client, CreateModerationRequest request, Action<CreateModerationResponse> responseHandler) : base(client)
        {
            Request = request;
            ResponseHandler = responseHandler;
        }

        public CreateModerationHandler(Client client, CreateModerationRequest request) : base(client)
        {
            Request = request;
        }

        public void Send()
        {
            var webRequest = CreateWebRequest();
            WebUtils.Send<CreateModerationResponseDto>(
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

        public async Task<CreateModerationResponse> SendAsync()
        {
            var webRequest = CreateWebRequest();
            var result = await WebUtils.SendAsync<CreateModerationResponseDto>(Client, webRequest);
            return result.responseDto != null
                ? CreateResponse(result.responseDto)
                : CreateResponse(result.error);
        }

        private UnityWebRequest CreateWebRequest()
        {
            var requestDto = new CreateModerationRequestDto {
                model = Request.Model,
                input = Request.Input
            };

            return WebUtils.CreatePost(Client, Client.EndpointsProvider.CreateModeration(), requestDto);
        }

        private CreateModerationResponse CreateResponse(CreateModerationResponseDto responseDto)
        {
            return new CreateModerationResponse {
                Id = responseDto.id,
                Model = responseDto.model,
                Results = DtoConverter.Convert(responseDto.results)
            };
        }

        private CreateModerationResponse CreateResponse(Error error)
        {
            return new CreateModerationResponse {
                Error = error
            };
        }
    }
}