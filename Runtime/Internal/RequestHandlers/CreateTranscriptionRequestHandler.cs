using System;
using System.Globalization;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace OpenAIToolkit
{
    internal class CreateTranscriptionRequestHandler : BaseRequestHandler
    {
        private readonly CreateTranscriptionRequest Request;
        private readonly Action<CreateTranscriptionResponse> ResponseHandler;

        public CreateTranscriptionRequestHandler(Client client, CreateTranscriptionRequest request, Action<CreateTranscriptionResponse> responseHandler) : base(client)
        {
            Request = request;
            ResponseHandler = responseHandler;
        }

        public CreateTranscriptionRequestHandler(Client client, CreateTranscriptionRequest request) : base(client)
        {
            Request = request;
        }

        public void Send()
        {
            var webRequest = CreateWebRequest();

            WebUtils.Send<CreateTranscriptionResponseDto>(
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

        public async Task<CreateTranscriptionResponse> SendAsync()
        {
            var webRequest = CreateWebRequest();
            var result = await WebUtils.SendAsync<CreateTranscriptionResponseDto>(Client, webRequest);
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

            if (!string.IsNullOrWhiteSpace(Request.Language))
                requestData.AddField("language", Request.Language);

            return WebUtils.CreatePost(Client, Client.EndpointsProvider.CreateTranscription(), requestData);
        }

        private CreateTranscriptionResponse CreateResponse(CreateTranscriptionResponseDto responseDto)
        {
            return new CreateTranscriptionResponse {
                Text = responseDto.text.Trim()
            };
        }

        private CreateTranscriptionResponse CreateResponse(Error error)
        {
            return new CreateTranscriptionResponse {
                Error = error
            };
        }
    }
}