using UnityEngine;

namespace OpenAIToolkit.Examples
{
    public class CreateModerationExample : MonoBehaviour
    {
        public string ApiKey;
        public string Model = "text-moderation-stable";
        public string Input = "I want to kill them.";

        [ContextMenu("Send request")]
        public void SendRequest()
        {
            var client = new OpenAIClient(ApiKey);
            var request = new CreateModerationRequest(Model, Input);
            client.Moderation.CreateModeration(request, HandleResponse);
        }

        [ContextMenu("Send request async")]
        public async void SendRequestAsync()
        {
            var client = new OpenAIClient(ApiKey);
            var request = new CreateModerationRequest(Model, Input);
            var response = await client.Moderation.CreateModerationAsync(request);
            HandleResponse(response);
        }

        private void HandleResponse(CreateModerationResponse response)
        {
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