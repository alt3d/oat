using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace OpenAIToolkit
{
    [Serializable]
    internal class CreateCompletionRequestDto
    {
        public string model;

        public List<string> prompt;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string suffix;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? max_tokens;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public float? temperature;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public float? top_p;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? n;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool? stream;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? logprobs;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool? echo;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<string> stop;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public float? presence_penalty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public float? frequency_penalty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? best_of;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string user;
    }
}