using UnityEngine;

namespace OpenAIToolkit.Examples
{
    public class CreateCompletionExample : MonoBehaviour
    {
        public string ApiKey;
        public string Model = "text-davinci-003";
        public string Prompt = "Say this is a test";

        [ContextMenu("Send request")]
        public void SendRequest()
        {
            var client = Factory.CreateClient(ApiKey);
            var request = new CreateCompletionRequest(Model, Prompt);
            client.Completion.CreateCompletion(request, HandleResponse);
        }

        [ContextMenu("Send request async")]
        public async void SendRequestAsync()
        {
            var client = Factory.CreateClient(ApiKey);
            var request = new CreateCompletionRequest(Model, Prompt);
            var response = await client.Completion.CreateCompletionAsync(request);
            HandleResponse(response);
        }

        private void HandleResponse(CreateCompletionResponse response)
        {
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