using System;
using System.Globalization;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace OpenAIToolkit
{
    internal class CreateTranslationRequestHandler : BaseRequestHandler
    {
        private readonly CreateTranslationRequest Request;
        private readonly Action<CreateTranslationResponse> ResponseHandler;

        public CreateTranslationRequestHandler(Client client, CreateTranslationRequest request, Action<CreateTranslationResponse> responseHandler) : base(client)
        {
            Request = request;
            ResponseHandler = responseHandler;
        }

        public CreateTranslationRequestHandler(Client client, CreateTranslationRequest request) : base(client)
        {
            Request = request;
        }

        public void Send()
        {
            var webRequest = CreateWebRequest();

            WebUtils.Send<CreateTranslationResponseDto>(
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
                }
            );
        }

        public async Task<CreateTranslationResponse> SendAsync()
        {
            var webRequest = CreateWebRequest();
            var result = await WebUtils.SendAsync<CreateTranslationResponseDto>(Client, webRequest);
            return result.responseDto != null
                ? CreateResponse(result.responseDto)
                : CreateResponse(result.error);
        }

        private UnityWebRequest CreateWebRequest()
        {
            var requestData = new WWWForm();
            requestData.AddField("model", Request.Model);
            requestData.AddBinaryData("file", Request.Data, "file.mp3");
            requestData.AddField("response_format", "json");

            if (!string.IsNullOrWhiteSpace(Request.Prompt))
                requestData.AddField("prompt", Request.Prompt);

            if (Request.Temperature.HasValue)
                requestData.AddField("temperature", Request.Temperature.Value.ToString(CultureInfo.InvariantCulture));

            return WebUtils.CreatePost(Client, Client.EndpointsProvider.CreateTranslation(), requestData);
        }

        private CreateTranslationResponse CreateResponse(CreateTranslationResponseDto responseDto)
        {
            return new CreateTranslationResponse {
                Text = responseDto.text.Trim()
            };
        }

        private CreateTranslationResponse CreateResponse(Error error)
        {
            return new CreateTranslationResponse {
                Error = error
            };
        }
    }
}