using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace OpenAIToolkit.Examples
{
    public class ChatDemo : MonoBehaviour
    {
        public string ApiKey;
        public string Model = "gpt-3.5-turbo";
        [Space]
        public int MaxTokens = 256;
        public float Temperature = 1.0f;
        [Space]
        public InputField InputField;
        public Text OutputText;
        [Space]
        public ScrollRect ScrollView;
        public Color InputColor;
        public Color ResponseColor;

        private Client Client { get; set; }
        private List<ChatMessage> Messages { get; set; }

        private void Start()
        {
            Messages = new List<ChatMessage>();
            OutputText.text = string.Empty;
            Client = new OpenAIClient(ApiKey);
        }

        public void SendRequest()
        {
            var message = new ChatMessage {
                Role = ChatRole.User,
                Content = InputField.text
            };

            RedrawOutput(message);
            InputField.SetTextWithoutNotify(string.Empty);

            var request = new CreateChatCompletionRequest(Model, Messages) {
                Temperature = Temperature,
                MaxTokens = MaxTokens
            };

            Client.Chat.CreateChatCompletion(request, HandleResponse);
        }

        private void HandleResponse(CreateChatCompletionResponse response)
        {
            if (response.Successful)
                RedrawOutput(response.Choices[0].Message);
            else
                Debug.LogError(response.Error.Message);
        }

        private void RedrawOutput(ChatMessage message)
        {
            Messages.Add(message);

            var hexColor = message.Role == ChatRole.User
                ? ColorUtility.ToHtmlStringRGB(InputColor)
                : ColorUtility.ToHtmlStringRGB(ResponseColor);

            OutputText.text += $"<color=#{hexColor}>{message.Content}\n\n</color>";
            Canvas.ForceUpdateCanvases();
            ScrollView.verticalNormalizedPosition = 0;
        }
    }
}