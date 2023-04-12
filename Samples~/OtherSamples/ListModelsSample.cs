using UnityEngine;

namespace OpenAIToolkit.Samples
{
    public class ListModelsSample : MonoBehaviour
    {
        public string ApiKey;

        [ContextMenu("Send request")]
        public void SendRequest()
        {
            // Create a new OpenAI client
            var client = new OpenAIClient(ApiKey);

            // Send the request and handle the response in the callback
            client.Model.ListModels(HandleResponse);
        }

        [ContextMenu("Send request async")]
        public async void SendRequestAsync()
        {
            // Create a new OpenAI client
            var client = new OpenAIClient(ApiKey);

            // Send the request asynchronously and await the response
            var response = await client.Model.ListModelsAsync();

            // Handle the response
            HandleResponse(response);
        }

        private static void HandleResponse(ListModelsResponse response)
        {
            // Check if the request was successful and log the result
            if (response.Successful)
            {
                Debug.Log($"ListModels.Success. Models count: {response.Models.Count}");
            }
            else
            {
                Debug.LogError($"ListModels.Error. Message: {response.Error.Message}");
            }
        }
    }
}