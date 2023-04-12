using System.Collections.Generic;
using UnityEngine;

namespace OpenAIToolkit.Samples
{
    public class CreateChatCompletionSample : MonoBehaviour
    {
        public string ApiKey;
        public string Model = "gpt-3.5-turbo";
        public string Message = "Hello!";

        [ContextMenu("Send request")]
        public void SendRequest()
        {
            // Create a new OpenAI client
            var client = new OpenAIClient(ApiKey);

            // Create a new chat message
            var message = new ChatMessage {
                Role = ChatRole.User,
                Content = Message
            };

            // Create a list of chat messages
            var messages = new List<ChatMessage> {message};

            // Create a new chat completion request
            var request = new CreateChatCompletionRequest(Model, messages);

            // Send the request and handle the response in the callback
            client.Chat.CreateChatCompletion(request, HandleResponse);
        }

        [ContextMenu("Send request async")]
        public async void SendRequestAsync()
        {
            // Create a new OpenAI client
            var client = new OpenAIClient(ApiKey);

            // Create a new chat message
            var message = new ChatMessage {
                Role = ChatRole.User,
                Content = Message
            };

            // Create a list of chat messages
            var messages = new List<ChatMessage> {message};

            // Create a new chat completion request
            var request = new CreateChatCompletionRequest(Model, messages);

            // Send the request asynchronously and await the response
            var response = await client.Chat.CreateChatCompletionAsync(request);

            // Handle the response
            HandleResponse(response);
        }

        private static void HandleResponse(CreateChatCompletionResponse response)
        {
            // Check if the response was successful and log the result
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