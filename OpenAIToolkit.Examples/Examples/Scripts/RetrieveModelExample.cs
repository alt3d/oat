using UnityEngine;

namespace OpenAIToolkit.Examples
{
    public class RetrieveModelExample : MonoBehaviour
    {
        public string ApiKey;
        public string ModelId;

        [ContextMenu("Send request")]
        public void SendRequest()
        {
            var client = Factory.CreateClient(ApiKey);
            var request = new RetrieveModelRequest(ModelId);
            client.Model.RetrieveModel(request, HandleResponse);
        }

        [ContextMenu("Send request async")]
        public async void SendRequestAsync()
        {
            var client = Factory.CreateClient(ApiKey);
            var request = new RetrieveModelRequest(ModelId);
            var response = await client.Model.RetrieveModelAsync(request);
            HandleResponse(response);
        }

        private void HandleResponse(RetrieveModelResponse response)
        {
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