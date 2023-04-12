using UnityEngine;
using UnityEngine.Networking;

namespace OpenAIToolkit.Samples
{
    public class CustomSettingsProvider : ScriptableObject, IEndpointsProvider, IAuthenticationInterceptor, IClientSettings
    {
        [Header("Custom params")]
        public string UserToken;
        public string ServerBaseUrl = "https://myserver.com/api";

        [Header("Endpoints settings")]
        public string _createCompletion = "completions";
        public string _createChatCompletion = "completions";
        public string _createEdit = "edits";
        public string _createImage = "images/generations";
        public string _createImageEdit = "images/edits";
        public string _createImageVariant = "images/variations";
        public string _createTranscription = "audio/transcriptions";
        public string _createTranslation = "audio/translations";
        public string _createModeration = "moderations";
        public string _listModels = "models";
        public string _retrieveModel = "models/{0}";

        [Header("Client settings")]
        public bool _isLogWeb = true;

        public bool IsLogWeb => _isLogWeb;

        public string CreateCompletion()
        {
            return $"{ServerBaseUrl}/{_createCompletion}";
        }

        public string CreateChatCompletion()
        {
            return $"{ServerBaseUrl}/{_createChatCompletion}";
        }

        public string CreateEdit()
        {
            return $"{ServerBaseUrl}/{_createEdit}";
        }

        public string CreateImage()
        {
            return $"{ServerBaseUrl}/{_createImage}";
        }

        public string CreateImageEdit()
        {
            return $"{ServerBaseUrl}/{_createImageEdit}";
        }

        public string CreateImageVariant()
        {
            return $"{ServerBaseUrl}/{_createImageVariant}";
        }

        public string CreateTranscription()
        {
            return $"{ServerBaseUrl}/{_createTranscription}";
        }

        public string CreateTranslation()
        {
            return $"{ServerBaseUrl}/{_createTranslation}";
        }

        public string CreateModeration()
        {
            return $"{ServerBaseUrl}/{_createModeration}";
        }

        public string ListModels()
        {
            return $"{ServerBaseUrl}/{_listModels}";
        }

        public string RetrieveModel(string model)
        {
            return $"{ServerBaseUrl}/{string.Format(_retrieveModel, model)}";
        }

        public void Intercept(UnityWebRequest webRequest)
        {
            webRequest.SetRequestHeader("Authorization", $"Bearer {UserToken}");
        }
    }
}