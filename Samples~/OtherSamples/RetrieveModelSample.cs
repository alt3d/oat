using UnityEngine;

namespace OpenAIToolkit.Samples
{
    public class RetrieveModelSample : MonoBehaviour
    {
        public string ApiKey;
        public string Model;

        [ContextMenu("Send request")]
        public void SendRequest()
        {
            // Create a new OpenAI client
            var client = new OpenAIClient(ApiKey);

            // Create a new retrieve model request
            var request = new RetrieveModelRequest(Model);

            // Send the request and handle the response in the callback
            client.Model.RetrieveModel(request, HandleResponse);
        }

        [ContextMenu("Send request async")]
        public async void SendRequestAsync()
        {
            // Create a new OpenAI client
            var client = new OpenAIClient(ApiKey);

            // Create a new retrieve model request
            var request = new RetrieveModelRequest(Model);

            // Send the request asynchronously and await the response
            var response = await client.Model.RetrieveModelAsync(request);

            // Handle the response
            HandleResponse(response);
        }

        private static void HandleResponse(RetrieveModelResponse response)
        {
            // Check if the request was successful and log the result
            if (response.Successful)
            {
                Debug.Log($"RetrieveModel.Success. ModelId: {response.Model.Id}");
            }
            else
            {
                Debug.LogError($"RetrieveModel.Error. Message: {response.Error.Message}");
            }
        }
    }
}