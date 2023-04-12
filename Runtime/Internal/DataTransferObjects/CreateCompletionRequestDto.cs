using System;
using System.Collections.Generic;

namespace OpenAIToolkit
{
    [Serializable]
    internal class CreateCompletionRequestDto
    {
        public string model;
        public List<string> prompt;
        public string suffix;
        public int? max_tokens;
        public float? temperature;
        public float? top_p;
        public int? n;
        public bool? stream;
        public int? logprobs;
        public bool? echo;
        public List<string> stop;
        public float? presence_penalty;
        public float? frequency_penalty;
        public int? best_of;
        public string user;
    }
}