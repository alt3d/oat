using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace OpenAIToolkit
{
    internal class CreateImageVariantRequestHandler : BaseRequestHandler
    {
        private readonly CreateImageVariantRequest Request;
        private readonly Action<CreateImageVariantResponse> ResponseHandler;

        public CreateImageVariantRequestHandler(Client client, CreateImageVariantRequest request, Action<CreateImageVariantResponse> responseHandler) : base(client)
        {
            Request = request;
            ResponseHandler = responseHandler;
        }

        public CreateImageVariantRequestHandler(Client client, CreateImageVariantRequest request) : base(client)
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

        public async Task<CreateImageVariantResponse> SendAsync()
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
            var requestData = new WWWForm();
            requestData.AddBinaryData("image", Request.Image.EncodeToPNG());
            requestData.AddField("response_format", "url");

            if (Request.Count != null)
                requestData.AddField("n", Request.Count.Value);
            if (Request.Size != null)
                requestData.AddField("size", Request.Size.Value.GetStringValue());
            if (Request.User != null)
                requestData.AddField("user", Request.User);

            return WebUtils.CreatePost(Client, Client.EndpointsProvider.CreateImageVariant(), requestData);
        }

        private CreateImageVariantResponse CreateResponse(ImageResponseDto responseDto)
        {
            return new CreateImageVariantResponse {
                Created = responseDto.created,
                Images = DtoConverter.Convert(responseDto.data),
                ResponseFormat = Request.ResponseFormat
            };
        }

        private CreateImageVariantResponse CreateResponse(Error error)
        {
            return new CreateImageVariantResponse {
                Error = error
            };
        }
    }
}