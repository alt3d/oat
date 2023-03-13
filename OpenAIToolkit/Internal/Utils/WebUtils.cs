using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

namespace OpenAIToolkit
{
    internal static class WebUtils
    {
        public static UnityWebRequest CreateGet(Client client, string url)
        {
            var webRequest = UnityWebRequest.Get(url);
            AddAuthHeaders(client, webRequest);
            return webRequest;
        }

        public static UnityWebRequest CreatePost<TData>(Client client, string url, TData data)
        {
            var webRequest = UnityWebRequest.Post(url, UnityWebRequest.kHttpVerbPOST);
            AddAuthHeaders(client, webRequest);
            AddRequestBody(webRequest, data);
            return webRequest;
        }

        public static UnityWebRequest CreatePost(Client client, string url, WWWForm data)
        {
            var webRequest = UnityWebRequest.Post(url, data);
            AddAuthHeaders(client, webRequest);
            return webRequest;
        }

        public static void Send<TResponse>(Client client, UnityWebRequest webRequest, Action<TResponse> onSuccess, Action<Error> onError)
        {
            CoroutinesExecutor.Run(HandleRequest(client, webRequest, onSuccess, onError));
        }

        public static async Task<(TResponse responseDto, Error error)> SendAsync<TResponse>(Client client, UnityWebRequest webRequest) where TResponse : class
        {
            if (client.Settings.IsLogWeb)
                LogRequest(webRequest);

            var operation = webRequest.SendWebRequest();
            while (!operation.isDone)
                await Task.Yield();

            if (webRequest.result == UnityWebRequest.Result.ConnectionError)
                return (null, Error.NetworkError);

            if (client.Settings.IsLogWeb)
                LogResponse(webRequest);

            var responseText = webRequest.downloadHandler.text;
            var errorDto = JsonConvert.DeserializeObject<ErrorDto>(responseText);
            if (errorDto?.error != null && !string.IsNullOrWhiteSpace(errorDto.error.message))
            {
                var error = errorDto.Parse();
                return (null, error);
            }

            var responseDto = JsonConvert.DeserializeObject<TResponse>(responseText);
            return (responseDto, null);
        }

        public static void DownloadImages(List<ImageData> images, Action callback)
        {
            var urlList = images.Select(imageData => imageData.Url).ToList();

            void onImageLoaded(string url, Texture2D texture)
            {
                urlList.Remove(url);

                images
                    .First(imageData => imageData.Url == url)
                    .Texture = texture;

                if (urlList.Count == 0)
                {
                    callback?.Invoke();
                }
            }

            foreach (var url in urlList)
            {
                DownloadImage(url, texture => onImageLoaded(url, texture));
            }
        }

        public static async Task DownloadImagesAsync(List<ImageData> images)
        {
            foreach (var image in images)
            {
                var webRequest = UnityWebRequestTexture.GetTexture(image.Url);
                var operation = webRequest.SendWebRequest();
                while (!operation.isDone)
                    await Task.Yield();

                if (webRequest.result != UnityWebRequest.Result.ConnectionError)
                    image.Texture = ((DownloadHandlerTexture) webRequest.downloadHandler).texture;
            }
        }

        private static void DownloadImage(string url, Action<Texture2D> callback)
        {
            CoroutinesExecutor.Run(HandleDownloadImage(url, callback));
        }

        private static IEnumerator HandleDownloadImage(string url, Action<Texture2D> callback)
        {
            var request = UnityWebRequestTexture.GetTexture(url);
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError)
            {
                callback?.Invoke(null);
            }
            else
            {
                var texture = ((DownloadHandlerTexture) request.downloadHandler).texture;
                callback?.Invoke(texture);
            }
        }

        private static IEnumerator HandleRequest<TResponse>(Client client, UnityWebRequest webRequest, Action<TResponse> onSuccess, Action<Error> onError)
        {
            if (client.Settings.IsLogWeb)
                LogRequest(webRequest);

            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.ConnectionError)
            {
                onError?.Invoke(Error.NetworkError);
            }
            else
            {
                if (client.Settings.IsLogWeb)
                    LogResponse(webRequest);

                var responseText = webRequest.downloadHandler.text;
                var errorDto = JsonConvert.DeserializeObject<ErrorDto>(responseText);
                if (errorDto?.error != null && !string.IsNullOrWhiteSpace(errorDto.error.message))
                {
                    var error = errorDto.Parse();
                    onError?.Invoke(error);
                }
                else
                {
                    var responseDto = JsonConvert.DeserializeObject<TResponse>(responseText);
                    onSuccess?.Invoke(responseDto);
                }
            }
        }

        private static void LogRequest(UnityWebRequest webRequest)
        {
            var textForLog = $"Request sent. Url: {webRequest.url}";

            var dataBytes = webRequest.uploadHandler?.data;
            if (dataBytes != null)
            {
                var dataJson = Encoding.UTF8.GetString(dataBytes);
                textForLog += $"\n Data: {dataJson}";
            }

            textForLog += "\n";
            Debug.Log(textForLog);
        }

        private static void LogResponse(UnityWebRequest webRequest)
        {
            var textForLog = $"Response received. Url: {webRequest.url}";

            var dataJson = webRequest.downloadHandler?.text;
            if (!string.IsNullOrWhiteSpace(dataJson))
                textForLog += $"\n Data: {dataJson}";

            textForLog += "\n";
            Debug.Log(textForLog);
        }

        private static void AddAuthHeaders(Client client, UnityWebRequest webRequest)
        {
            Ensure.ArgumentNotNull(client, nameof(client));
            Ensure.ArgumentNotNull(client.Settings, nameof(client.Settings));
            Ensure.ArgumentNotNull(client.AuthProvider.ApiKey, nameof(client.AuthProvider.ApiKey));

            webRequest.SetRequestHeader("Authorization", "Bearer " + client.AuthProvider.ApiKey);

            if (!string.IsNullOrWhiteSpace(client.AuthProvider.Organization))
                webRequest.SetRequestHeader("OpenAI-Organization", client.AuthProvider.Organization);
        }

        private static void AddRequestBody<TData>(UnityWebRequest webRequest, TData data)
        {
            webRequest.SetRequestHeader("Content-Type", "application/json");

            var dataJson = JsonConvert.SerializeObject(data);
            var dataBytes = new UTF8Encoding().GetBytes(dataJson);
            webRequest.uploadHandler = new UploadHandlerRaw(dataBytes);
        }
    }
}