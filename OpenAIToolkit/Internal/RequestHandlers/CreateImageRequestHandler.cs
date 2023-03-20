using System;
using System.Threading.Tasks;
using UnityEngine.Networking;

namespace OpenAIToolkit
{
    internal class CreateImageRequestHandler : BaseRequestHandler
    {
        private readonly CreateImageRequest Request;
        private readonly Action<CreateImageResponse> ResponseHandler;

        public CreateImageRequestHandler(Client client, CreateImageRequest request, Action<CreateImageResponse> responseHandler) : base(client)
        {
            Request = request;
            ResponseHandler = responseHandler;
        }

        public CreateImageRequestHandler(Client client, CreateImageRequest request) : base(client)
        {
            Request = request;
        }

        public void Send()
        {
            var webRequest = CreateWebRequest();
            WebUtils.Send<ImageResponseDto>(
                Client,
                webRequest,
                responseDto =>
                {
                    var response = CreateResponse(responseDto);
                    if (Request.ResponseFormat == ImageResponseFormat.Texture2D)
                        WebUtils.DownloadImages(response.Images, () => ResponseHandler?.Invoke(response));
                    else
                        ResponseHandler?.Invoke(response);
                },
                error =>
                {
                    var response = CreateResponse(error);
                    ResponseHandler?.Invoke(response);
                }
            );
        }

        public async Task<CreateImageResponse> SendAsync()
        {
            var webRequest = CreateWebRequest();
            var result = await WebUtils.SendAsync<ImageResponseDto>(Client, webRequest);

            if (result.error != null)
                return CreateResponse(result.error);

            var response = CreateResponse(result.responseDto);
            if (Request.ResponseFormat == ImageResponseFormat.Texture2D)
                await WebUtils.DownloadImagesAsync(response.Images);

            return response;
        }

        private UnityWebRequest CreateWebRequest()
        {
            var requestDto = new CreateImageRequestDto {
                prompt = Request.Prompt,
                n = Request.Count,
                response_format = "url",
                user = Request.User
            };

            if (Request.Size != null)
                requestDto.size = Request.Size.Value.GetStringValue();

            return WebUtils.CreatePost(Client, Client.EndpointsProvider.CreateImage(), requestDto);
        }

        private CreateImageResponse CreateResponse(ImageResponseDto responseDto)
        {
            return new CreateImageResponse {
                Created = responseDto.created,
                Images = DtoConverter.Convert(responseDto.data),
                ResponseFormat = Request.ResponseFormat
            };
        }

        private CreateImageResponse CreateResponse(Error error)
        {
            return new CreateImageResponse {
                Error = error
            };
        }
    }
}