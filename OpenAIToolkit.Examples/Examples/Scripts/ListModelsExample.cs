using UnityEngine;

namespace OpenAIToolkit.Examples
{
    public class ListModelsExample : MonoBehaviour
    {
        public string ApiKey;

        [ContextMenu("Send request")]
        public void SendRequest()
        {
            var client = new OpenAIClient(ApiKey);
            client.Model.ListModels(HandleResponse);
        }

        [ContextMenu("Send request async")]
        public async void SendRequestAsync()
        {
            var client = new OpenAIClient(ApiKey);
            var response = await client.Model.ListModelsAsync();
            HandleResponse(response);
        }

        private void HandleResponse(ListModelsResponse response)
        {
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