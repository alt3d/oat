using System;
using Newtonsoft.Json;

namespace OpenAIToolkit
{
    [Serializable]
    internal class CreateEditRequestDto
    {
        public string model;

        public string input;

        public string instruction;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? n;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public float? temperature;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public float? top_p;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string user;
    }
}