using UnityEngine;

namespace OpenAIToolkit.Examples
{
    public class ExampleSettingsProvider : ScriptableObject, IEndpointsProvider, IAuthenticationProvider, IClientSettings
    {
        [Header("Auth settings")]
        public string apiKey;
        public string organization;

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

        public string ApiKey => apiKey;

        public string Organization => organization;

        public bool IsLogWeb => _isLogWeb;

        public string CreateCompletion => _createCompletion;

        public string CreateChatCompletion => _createChatCompletion;

        public string CreateEdit => _createEdit;

        public string CreateImage => _createImage;

        public string CreateImageEdit => _createImageEdit;

        public string CreateImageVariant => _createImageVariant;

        public string CreateTranscription => _createTranscription;

        public string CreateTranslation => _createTranslation;

        public string CreateModeration => _createModeration;

        public string ListModels => _listModels;

        public string RetrieveModel => _retrieveModel;
    }
}