using UnityEngine;

namespace OpenAIToolkit.Samples
{
    public class CreateCompletionSample : MonoBehaviour
    {
        public string ApiKey;
        public string Model = "text-davinci-003";
        public string Prompt = "Say this is a test";

        [ContextMenu("Send request")]
        public void SendRequest()
        {
            // Create a new OpenAI client
            var client = new OpenAIClient(ApiKey);

            // Create a new text completion request
            var request = new CreateCompletionRequest(Model, Prompt);

            // Send the request and handle the response in the callback
            client.Completion.CreateCompletion(request, HandleResponse);
        }

        [ContextMenu("Send request async")]
        public async void SendRequestAsync()
        {
            // Create a new OpenAI client
            var client = new OpenAIClient(ApiKey);

            // Create a new text completion request
            var request = new CreateCompletionRequest(Model, Prompt);

            // Send the request asynchronously and await the response
            var response = await client.Completion.CreateCompletionAsync(request);

            // Handle the response
            HandleResponse(response);
        }

        private static void HandleResponse(CreateCompletionResponse response)
        {
            // Check if the request was successful and log the result
            if (response.Successful)
            {
                Debug.Log($"CreateCompletion.Success. Message: {response.Choices[0].Text}");
            }
            else
            {
                Debug.LogError($"CreateCompletion.Error. Message: {response.Error.Message}");
            }
        }
    }
}