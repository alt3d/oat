using UnityEngine;
using UnityEngine.Networking;

namespace OpenAIToolkit.Examples
{
    public class CustomSettingsProvider : ScriptableObject, IEndpointsProvider, IAuthenticationInterceptor, IClientSettings
    {
        [Header("Auth settings")]
        public string _apiKey;
        public string _organization;

        [Header("Endpoints settings")]
        public string _createCompletion = "https://api.openai.com/v1/completions";
        public string _createChatCompletion = "https://api.openai.com/v1/chat/completions";
        public string _createEdit = "https://api.openai.com/v1/edits";
        public string _createImage = "https://api.openai.com/v1/images/generations";
        public string _createImageEdit = "https://api.openai.com/v1/images/edits";
        public string _createImageVariant = "https://api.openai.com/v1/images/variations";
        public string _createTranscription = "https://api.openai.com/v1/audio/transcriptions";
        public string _createTranslation = "https://api.openai.com/v1/audio/translations";
        public string _createModeration = "https://api.openai.com/v1/moderations";
        public string _listModels = "https://api.openai.com/v1/models";
        public string _retrieveModel = "https://api.openai.com/v1/models/{0}";

        [Header("Client settings")]
        public bool _isLogWeb = true;

        public string ApiKey => _apiKey;

        public string Organization => _organization;

        public bool IsLogWeb => _isLogWeb;

        public string CreateCompletion()
        {
            return _createCompletion;
        }

        public string CreateChatCompletion()
        {
            return _createChatCompletion;
        }

        public string CreateEdit()
        {
            return _createEdit;
        }

        public string CreateImage()
        {
            return _createImage;
        }

        public string CreateImageEdit()
        {
            return _createImageEdit;
        }

        public string CreateImageVariant()
        {
            return _createImageVariant;
        }

        public string CreateTranscription()
        {
            return _createTranscription;
        }

        public string CreateTranslation()
        {
            return _createTranslation;
        }

        public string CreateModeration()
        {
            return _createModeration;
        }

        public string ListModels()
        {
            return _listModels;
        }

        public string RetrieveModel(string model)
        {
            return string.Format(_retrieveModel, model);
        }

        public void Intercept(UnityWebRequest webRequest)
        {
            webRequest.SetRequestHeader("Authorization", $"Bearer {ApiKey}");

            if (!string.IsNullOrWhiteSpace(Organization))
                webRequest.SetRequestHeader("OpenAI-Organization", Organization);
        }
    }
}