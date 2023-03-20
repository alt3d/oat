using UnityEngine;

namespace OpenAIToolkit.Examples
{
    public class CustomServerExample : MonoBehaviour
    {
        public CustomSettingsProvider SettingsProvider;
        public string Model = "text-davinci-003";
        public string Prompt = "Say this is a test";

        [ContextMenu("Send completion request")]
        public void SendCompletionRequest()
        {
            var client = new Client()
                .SetAuthenticationInterceptor(SettingsProvider)
                .SetEndpointsProvider(SettingsProvider)
                .SetClientSettings(SettingsProvider);

            var request = new CreateCompletionRequest(Model, Prompt);
            client.Completion.CreateCompletion(request, HandleResponse);
        }

        private static void HandleResponse(CreateCompletionResponse response)
        {
            if (response.Successful)
            {
                Debug.Log($"CustomServerExample.Success. Message: {response.Choices[0].Text}");
            }
            else
            {
                Debug.LogError($"CustomServerExample.Error. Message: {response.Error.Message}");
            }
        }
    }
}