using System.IO;
using UnityEngine;

namespace OpenAIToolkit.Samples
{
    public class CreateTranslationSample : MonoBehaviour
    {
        public string ApiKey;
        public string Model = "whisper-1";
        public AudioClip AudioClip;

        [ContextMenu("Send request")]
        public void SendRequest()
        {
#if UNITY_EDITOR
            // Create a new OpenAI client
            var client = new OpenAIClient(ApiKey);

            // Get the audio data
            var audioData = GetAudioData();

            // Create a new transcription request and set the parameters
            var request = new CreateTranslationRequest(Model, audioData);

            // Send the request and handle the response in the callback
            client.Audio.CreateTranslation(request, HandleResponse);
#else
            Debug.LogError("This example only works in the Unity Editor");
#endif
        }

        [ContextMenu("Send request async")]
        public async void SendRequestAsync()
        {
#if UNITY_EDITOR
            // Create a new OpenAI client
            var client = new OpenAIClient(ApiKey);

            // Get the audio data
            var audioData = GetAudioData();

            // Create a new transcription request and set the parameters
            var request = new CreateTranslationRequest(Model, audioData);

            // Send the request asynchronously and wait for the response
            var response = await client.Audio.CreateTranslationAsync(request);

            // Handle the response
            HandleResponse(response);
#else
            Debug.LogError("This example only works in the Unity Editor");
#endif
        }

        private byte[] GetAudioData()
        {
            // Get the absolute path to the audio clip
            var audioClipPath = UnityEditor.AssetDatabase.GetAssetPath(AudioClip);
            audioClipPath = audioClipPath.Replace("Assets", Application.dataPath);

            // Read the bytes from the audio clip and return them
            return File.ReadAllBytes(audioClipPath);
        }

        private static void HandleResponse(CreateTranslationResponse response)
        {
            // Check if the request was successful and log the result
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