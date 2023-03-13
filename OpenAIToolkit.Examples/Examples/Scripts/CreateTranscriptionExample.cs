using System.IO;
using UnityEngine;

namespace OpenAIToolkit
{
    public class CreateTranscriptionExample : MonoBehaviour
    {
        public string ApiKey;
        public string Model = "whisper-1";
        public AudioClip AudioClip;

        [ContextMenu("Send request")]
        public void SendRequest()
        {
#if UNITY_EDITOR
            var client = Factory.CreateClient(ApiKey);
            var audioClipPath = UnityEditor.AssetDatabase.GetAssetPath(AudioClip);
            audioClipPath = audioClipPath.Replace("Assets", Application.dataPath);
            var audioData = File.ReadAllBytes(audioClipPath);
            var request = new CreateTranscriptionRequest(Model, audioData);
            client.Audio.CreateTranscription(request, HandleResponse);
#else
            Debug.LogError("This example only works in the Unity Editor");
#endif
        }

        [ContextMenu("Send request async")]
        public async void SendRequestAsync()
        {
#if UNITY_EDITOR
            var client = Factory.CreateClient(ApiKey);
            var audioClipPath = UnityEditor.AssetDatabase.GetAssetPath(AudioClip);
            audioClipPath = audioClipPath.Replace("Assets", Application.dataPath);
            var audioData = File.ReadAllBytes(audioClipPath);
            var request = new CreateTranscriptionRequest(Model, audioData);
            var response = await client.Audio.CreateTranscriptionAsync(request);
            HandleResponse(response);
#else
            Debug.LogError("This example only works in the Unity Editor");
#endif
        }

        private void HandleResponse(CreateTranscriptionResponse response)
        {
            if (response.Successful)
            {
                Debug.Log($"CreateTranscription.Success. Text: {response.Text}");
            }
            else
            {
                Debug.LogError($"CreateTranscription.Error. Message: {response.Error.Message}");
            }
        }
    }
}