using System.IO;
using UnityEngine;

namespace OpenAIToolkit
{
    public class CreateTranslationExample : MonoBehaviour
    {
        public string ApiKey;
        public string Model = "whisper-1";
        public AudioClip AudioClip;

        [ContextMenu("Send request")]
        public void SendRequest()
        {
#if UNITY_EDITOR
            var client = new OpenAIClient(ApiKey);
            var audioClipPath = UnityEditor.AssetDatabase.GetAssetPath(AudioClip);
            audioClipPath = audioClipPath.Replace("Assets", Application.dataPath);
            var audioData = File.ReadAllBytes(audioClipPath);
            var request = new CreateTranslationRequest(Model, audioData);
            client.Audio.CreateTranslation(request, HandleResponse);
#else
            Debug.LogError("This example only works in the Unity Editor");
#endif
        }

        [ContextMenu("Send request async")]
        public async void SendRequestAsync()
        {
#if UNITY_EDITOR
            var client = new OpenAIClient(ApiKey);
            var audioClipPath = UnityEditor.AssetDatabase.GetAssetPath(AudioClip);
            audioClipPath = audioClipPath.Replace("Assets", Application.dataPath);
            var audioData = File.ReadAllBytes(audioClipPath);
            var request = new CreateTranslationRequest(Model, audioData);
            var response = await client.Audio.CreateTranslationAsync(request);
            HandleResponse(response);
#else
            Debug.LogError("This example only works in the Unity Editor");
#endif
        }

        private void HandleResponse(CreateTranslationResponse response)
        {
            if (response.Successful)
            {
                Debug.Log($"CreateTranslation.Success. Text: {response.Text}");
            }
            else
            {
                Debug.LogError($"CreateTranslation.Error. Message: {response.Error.Message}");
            }
        }
    }
}