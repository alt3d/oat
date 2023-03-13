using System;
using System.Threading.Tasks;
using UnityEngine.Networking;

namespace OpenAIToolkit
{
    internal class CreateEditRequestHandler : BaseRequestHandler
    {
        private readonly CreateEditRequest Request;
        private readonly Action<CreateEditResponse> ResponseHandler;

        public CreateEditRequestHandler(Client client, CreateEditRequest request, Action<CreateEditResponse> responseHandler) : base(client)
        {
            Request = request;
            ResponseHandler = responseHandler;
        }

        public CreateEditRequestHandler(Client client, CreateEditRequest request) : base(client)
        {
            Request = request;
        }

        public void Send()
        {
            var webRequest = CreateWebRequest();
            WebUtils.Send<CreateEditResponseDto>(
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

        public async Task<CreateEditResponse> SendAsync()
        {
            var webRequest = CreateWebRequest();
            var result = await WebUtils.SendAsync<CreateEditResponseDto>(Client, webRequest);
            return result.responseDto != null
                ? CreateResponse(result.responseDto)
                : CreateResponse(result.error);
        }

        private UnityWebRequest CreateWebRequest()
        {
            var requestDto = new CreateEditRequestDto {
                model = Request.Model,
                input = Request.Input,
                instruction = Request.Instruction,
                temperature = Request.Temperature,
                top_p = Request.TopP,
                n = Request.Count,
                user = Request.User
            };

            return WebUtils.CreatePost(Client, Client.Endpoints.CreateEdit, requestDto);
        }

        private CreateEditResponse CreateResponse(CreateEditResponseDto responseDto)
        {
            return new CreateEditResponse {
                Created = responseDto.created,
                Choices = DtoConverter.Convert(responseDto.choices),
                Usage = DtoConverter.Convert(responseDto.usage)
            };
        }

        private CreateEditResponse CreateResponse(Error error)
        {
            return new CreateEditResponse {
                Error = error
            };
        }
    }
}