using UnityEngine;

namespace OpenAIToolkit.Examples
{
    public class CustomClientExample : MonoBehaviour
    {
        public ExampleSettingsProvider SettingsProvider;
        public string Model = "text-davinci-003";
        public string Prompt = "Say this is a test";

        [ContextMenu("Send request")]
        public void SendRequest()
        {
            var client = Factory.CreateClient(SettingsProvider, SettingsProvider, SettingsProvider);
            var request = new CreateCompletionRequest(Model, Prompt);
            client.Completion.CreateCompletion(request, HandleResponse);
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