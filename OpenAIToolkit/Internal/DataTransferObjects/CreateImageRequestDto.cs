using System;
using Newtonsoft.Json;

namespace OpenAIToolkit
{
    [Serializable]
    internal class CreateImageRequestDto
    {
        public string prompt;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? n;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string size;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string response_format;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string user;
    }
}