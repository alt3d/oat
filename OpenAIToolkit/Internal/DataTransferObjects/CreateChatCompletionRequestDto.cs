using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace OpenAIToolkit
{
    [Serializable]
    internal class CreateChatCompletionRequestDto
    {
        public string model;

        public List<ChatMessageDto> messages;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public float? temperature;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public float? top_p;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? n;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool? stream;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<string> stop;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? max_tokens;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public float? presence_penalty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public float? frequency_penalty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string user;
    }
}