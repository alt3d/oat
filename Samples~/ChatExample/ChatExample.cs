using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace OpenAIToolkit.Samples
{
    public class ChatExample : MonoBehaviour
    {
        public string ApiKey;
        public string Model = "gpt-3.5-turbo";
        public int MaxTokens = 256;
        public float Temperature = 1.0f;

        [Space]
        public Button SendButton;
        public InputField PromptInputField;
        public Text MessagesLogText;
        public ScrollRect MessagesScrollView;
        public Color UserTextColor;
        public Color AssistantTextColor;

        private Client Client { get; set; }
        private List<ChatMessage> Messages { get; set; }

        private void Start()
        {
            // Create the OpenAI Client
            Client = new OpenAIClient(ApiKey);

            // Create the chat history
            Messages = new List<ChatMessage>();

            // Clear the prompt input field
            MessagesLogText.text = string.Empty;

            // Add a listener to the send button
            SendButton.onClick.AddListener(SendRequest);
        }

        private void SendRequest()
        {
            // Create the chat message with the user's prompt
            var message = new ChatMessage {
                Role = ChatRole.User,
                Content = PromptInputField.text
            };

            // Redraw the log with user's prompt
            RedrawMessagesLog(message);

            // Clear the prompt input field
            PromptInputField.SetTextWithoutNotify(string.Empty);

            // Create the chat completion request and set the parameters
            var request = new CreateChatCompletionRequest(Model, Messages) {
                Temperature = Temperature,
                MaxTokens = MaxTokens
            };

            // Send the request and handle the response
            Client.Chat.CreateChatCompletion(request, HandleResponse);
        }

        private void HandleResponse(CreateChatCompletionResponse response)
        {
            // Redraw the log with the assistant's response or log the error
            if (response.Successful)
                RedrawMessagesLog(response.Choices[0].Message);
            else
                Debug.LogError(response.Error.Message);
        }

        private void RedrawMessagesLog(ChatMessage message)
        {
            // Add the message to the chat history
            Messages.Add(message);

            // Select the text color based on the message role
            var textColor = message.Role == ChatRole.User
                ? ColorUtility.ToHtmlStringRGB(UserTextColor)
                : ColorUtility.ToHtmlStringRGB(AssistantTextColor);

            // Redraw the output
            MessagesLogText.text += $"<color=#{textColor}>{message.Content}\n\n</color>";

            // Scroll to the bottom of the scroll view
            Canvas.ForceUpdateCanvases();
            MessagesScrollView.verticalNormalizedPosition = 0;
        }
    }
}