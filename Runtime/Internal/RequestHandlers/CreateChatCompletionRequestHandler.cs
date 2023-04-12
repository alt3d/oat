using System;
using System.Threading.Tasks;
using UnityEngine.Networking;

namespace OpenAIToolkit
{
    internal class CreateChatCompletionRequestHandler : BaseRequestHandler
    {
        private readonly CreateChatCompletionRequest Request;
        private readonly Action<CreateChatCompletionResponse> ResponseHandler;

        public CreateChatCompletionRequestHandler(Client client, CreateChatCompletionRequest request, Action<CreateChatCompletionResponse> responseHandler) : base(client)
        {
            Request = request;
            ResponseHandler = responseHandler;
        }

        public CreateChatCompletionRequestHandler(Client client, CreateChatCompletionRequest request) : base(client)
        {
            Request = request;
        }

        public void Send()
        {
            var webRequest = CreateWebRequest();
            WebUtils.Send<CreateChatCompletionResponseDto>(
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

        public async Task<CreateChatCompletionResponse> SendAsync()
        {
            var webRequest = CreateWebRequest();
            var result = await WebUtils.SendAsync<CreateChatCompletionResponseDto>(Client, webRequest);
            return result.responseDto != null
                ? CreateResponse(result.responseDto)
                : CreateResponse(result.error);
        }

        private UnityWebRequest CreateWebRequest()
        {
            var requestDto = new CreateChatCompletionRequestDto {
                model = Request.Model,
                messages = DtoConverter.Convert(Request.Messages),
                temperature = Request.Temperature,
                top_p = Request.TopP,
                n = Request.Count,
                stream = Request.Stream,
                stop = Request.Stop,
                max_tokens = Request.MaxTokens,
                presence_penalty = Request.PresencePenalty,
                frequency_penalty = Request.FrequencyPenalty,
                user = Request.User
            };

            return WebUtils.CreatePost(Client, Client.EndpointsProvider.CreateChatCompletion(), requestDto);
        }

        private CreateChatCompletionResponse CreateResponse(CreateChatCompletionResponseDto responseDto)
        {
            return new CreateChatCompletionResponse {
                Id = responseDto.id,
                Created = responseDto.created,
                Model = responseDto.model,
                Choices = DtoConverter.Convert(responseDto.choices),
                Usage = DtoConverter.Convert(responseDto.usage)
            };
        }

        private CreateChatCompletionResponse CreateResponse(Error error)
        {
            return new CreateChatCompletionResponse {
                Error = error
            };
        }
    }
}