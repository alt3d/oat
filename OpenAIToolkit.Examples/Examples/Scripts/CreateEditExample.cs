using UnityEngine;

namespace OpenAIToolkit.Examples
{
    public class CreateEditExample : MonoBehaviour
    {
        public string ApiKey;
        public string Model = "text-davinci-edit-001";
        public string Input = "What day of the wek is it?";
        public string Instruction = "Fix the spelling mistakes";

        [ContextMenu("Send request")]
        public void SendRequest()
        {
            var client = Factory.CreateClient(ApiKey);
            var request = new CreateEditRequest(Model, Input, Instruction);
            client.Edit.CreateEdit(request, HandleResponse);
        }

        [ContextMenu("Send request async")]
        public async void SendRequestAsync()
        {
            var client = Factory.CreateClient(ApiKey);
            var request = new CreateEditRequest(Model, Input, Instruction);
            var response = await client.Edit.CreateEditAsync(request);
            HandleResponse(response);
        }

        private void HandleResponse(CreateEditResponse response)
        {
            if (response.Successful)
            {
                Debug.Log($"CreateEdit.Success. Message: {response.Choices[0].Text}");
            }
            else
            {
                Debug.LogError($"CreateEdit.Error. Message: {response.Error.Message}");
            }
        }
    }
}