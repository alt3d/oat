using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace OpenAIToolkit
{
    internal class CreateImageEditRequestHandler : BaseRequestHandler
    {
        private readonly CreateImageEditRequest Request;
        private readonly Action<CreateImageEditResponse> ResponseHandler;

        public CreateImageEditRequestHandler(Client client, CreateImageEditRequest request, Action<CreateImageEditResponse> responseHandler) : base(client)
        {
            Request = request;
            ResponseHandler = responseHandler;
        }

        public CreateImageEditRequestHandler(Client client, CreateImageEditRequest request) : base(client)
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

        public async Task<CreateImageEditResponse> SendAsync()
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
            requestData.AddField("prompt", Request.Prompt);
            requestData.AddField("response_format", "url");

            if (Request.Mask != null)
                requestData.AddBinaryData("mask", Request.Mask.EncodeToPNG());
            if (Request.Count != null)
                requestData.AddField("n", Request.Count.Value);
            if (Request.Size != null)
                requestData.AddField("size", Request.Size.Value.GetStringValue());
            if (Request.User != null)
                requestData.AddField("user", Request.User);

            return WebUtils.CreatePost(Client, Client.Endpoints.CreateImageEdit, requestData);
        }

        private CreateImageEditResponse CreateResponse(ImageResponseDto dto)
        {
            return new CreateImageEditResponse {
                Created = dto.created,
                Images = DtoConverter.Convert(dto.data),
                ResponseFormat = Request.ResponseFormat
            };
        }

        private CreateImageEditResponse CreateResponse(Error error)
        {
            return new CreateImageEditResponse {
                Error = error
            };
        }
    }
}