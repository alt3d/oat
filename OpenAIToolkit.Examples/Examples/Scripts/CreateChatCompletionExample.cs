using System.Collections.Generic;
using UnityEngine;

namespace OpenAIToolkit.Examples
{
    public class CreateChatCompletionExample : MonoBehaviour
    {
        public string ApiKey;
        public string Model = "gpt-3.5-turbo";
        public string Message = "Hello!";

        [ContextMenu("Send request")]
        public void SendRequest()
        {
            var client = Factory.CreateClient(ApiKey);

            var message = new ChatMessage {
                Role = ChatRole.User,
                Content = Message
            };
            var messages = new List<ChatMessage> {message};

            var request = new CreateChatCompletionRequest(Model, messages);
            client.Chat.CreateChatCompletion(request, HandleResponse);
        }

        [ContextMenu("Send request async")]
        public async void SendRequestAsync()
        {
            var client = Factory.CreateClient(ApiKey);

            var message = new ChatMessage {
                Role = ChatRole.User,
                Content = Message
            };
            var messages = new List<ChatMessage> {message};

            var request = new CreateChatCompletionRequest(Model, messages);
            var response = await client.Chat.CreateChatCompletionAsync(request);
            HandleResponse(response);
        }

        private void HandleResponse(CreateChatCompletionResponse response)
        {
            if (response.Successful)
            {
                Debug.Log($"CreateChatCompletion.Success. Message: {response.Choices[0].Message.Content}");
            }
            else
            {
                Debug.LogError($"CreateChatCompletion.Error. Message: {response.Error.Message}");
            }
        }
    }
}