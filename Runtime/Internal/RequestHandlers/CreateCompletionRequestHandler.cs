using System;
using System.Threading.Tasks;
using UnityEngine.Networking;

namespace OpenAIToolkit
{
    internal class CreateCompletionRequestHandler : BaseRequestHandler
    {
        private readonly CreateCompletionRequest Request;
        private readonly Action<CreateCompletionResponse> ResponseHandler;

        public CreateCompletionRequestHandler(Client client, CreateCompletionRequest request, Action<CreateCompletionResponse> responseHandler) : base(client)
        {
            Request = request;
            ResponseHandler = responseHandler;
        }

        public CreateCompletionRequestHandler(Client client, CreateCompletionRequest request) : base(client)
        {
            Request = request;
        }

        public void Send()
        {
            var webRequest = CreateWebRequest();
            WebUtils.Send<CreateCompletionResponseDto>(
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

        public async Task<CreateCompletionResponse> SendAsync()
        {
            var webRequest = CreateWebRequest();
            var result = await WebUtils.SendAsync<CreateCompletionResponseDto>(Client, webRequest);
            return result.responseDto != null
                ? CreateResponse(result.responseDto)
                : CreateResponse(result.error);
        }

        private UnityWebRequest CreateWebRequest()
        {
            var requestDto = new CreateCompletionRequestDto {
                model = Request.Model,
                prompt = Request.Prompts,
                suffix = Request.Suffix,
                max_tokens = Request.MaxTokens,
                temperature = Request.Temperature,
                top_p = Request.TopP,
                n = Request.Count,
                stream = Request.Stream,
                logprobs = Request.Logprobs,
                echo = Request.Echo,
                stop = Request.Stop,
                presence_penalty = Request.PresencePenalty,
                frequency_penalty = Request.FrequencyPenalty,
                best_of = Request.BestOf,
                user = Request.User
            };

            return WebUtils.CreatePost(Client, Client.EndpointsProvider.CreateCompletion(), requestDto);
        }

        private CreateCompletionResponse CreateResponse(CreateCompletionResponseDto responseDto)
        {
            return new CreateCompletionResponse {
                Id = responseDto.id,
                Created = responseDto.created,
                Model = responseDto.model,
                Choices = DtoConverter.Convert(responseDto.choices),
                Usage = DtoConverter.Convert(responseDto.usage)
            };
        }

        private CreateCompletionResponse CreateResponse(Error error)
        {
            return new CreateCompletionResponse {
                Error = error
            };
        }
    }
}