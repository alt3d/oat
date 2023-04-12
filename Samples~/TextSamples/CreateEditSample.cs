using UnityEngine;

namespace OpenAIToolkit.Samples
{
    public class CreateEditSample : MonoBehaviour
    {
        public string ApiKey;
        public string Model = "text-davinci-edit-001";
        public string Input = "What day of the wek is it?";
        public string Instruction = "Fix the spelling mistakes";

        [ContextMenu("Send request")]
        public void SendRequest()
        {
            // Create a new OpenAI client
            var client = new OpenAIClient(ApiKey);

            // Create a new text edit request
            var request = new CreateEditRequest(Model, Input, Instruction);

            // Send the request and handle the response in the callback
            client.Edit.CreateEdit(request, HandleResponse);
        }

        [ContextMenu("Send request async")]
        public async void SendRequestAsync()
        {
            // Create a new OpenAI client
            var client = new OpenAIClient(ApiKey);

            // Create a new text edit request
            var request = new CreateEditRequest(Model, Input, Instruction);

            // Send the request asynchronously and await the response
            var response = await client.Edit.CreateEditAsync(request);

            // Handle the response
            HandleResponse(response);
        }

        private static void HandleResponse(CreateEditResponse response)
        {
            // Check if the request was successful and log the result
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