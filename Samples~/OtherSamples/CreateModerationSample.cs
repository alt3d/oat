using UnityEngine;

namespace OpenAIToolkit.Samples
{
    public class CreateModerationSample : MonoBehaviour
    {
        public string ApiKey;
        public string Model = "text-moderation-stable";
        public string Input = "I want to kill them.";

        [ContextMenu("Send request")]
        public void SendRequest()
        {
            // Create a new OpenAI client
            var client = new OpenAIClient(ApiKey);

            // Create a new moderation request
            var request = new CreateModerationRequest(Model, Input);

            // Send the request and handle the response in the callback
            client.Moderation.CreateModeration(request, HandleResponse);
        }

        [ContextMenu("Send request async")]
        public async void SendRequestAsync()
        {
            // Create a new OpenAI client
            var client = new OpenAIClient(ApiKey);

            // Create a new moderation request
            var request = new CreateModerationRequest(Model, Input);

            // Send the request asynchronously and await the response
            var response = await client.Moderation.CreateModerationAsync(request);

            // Handle the response
            HandleResponse(response);
        }

        private static void HandleResponse(CreateModerationResponse response)
        {
            // Check if the request was successful and log the result
            if (response.Successful)
            {
                Debug.Log($"CreateModeration.Success. Flagged: {response.Results[0].Flagged}");
            }
            else
            {
                Debug.LogError($"CreateModeration.Error. Message: {response.Error.Message}");
            }
        }
    }
}