using System;
using System.Collections.Generic;

namespace OpenAIToolkit
{
    [Serializable]
    internal class CreateChatCompletionRequestDto
    {
        public string model;
        public List<ChatMessageDto> messages;
        public List<string> stop;
        public string user;
        public float? frequency_penalty;
        public int? max_tokens;
        public int? n;
        public float? presence_penalty;
        public bool? stream;
        public float? temperature;
        public float? top_p;
    }
}