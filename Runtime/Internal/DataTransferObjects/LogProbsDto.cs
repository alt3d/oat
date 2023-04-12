using System;
using System.Collections.Generic;

namespace OpenAIToolkit
{
    [Serializable]
    internal class LogProbsDto
    {
        public List<string> tokens;
        public List<float> token_logprobs;
        public List<int> text_offset;
        public List<Dictionary<string, float>> top_logprobs;
    }
}