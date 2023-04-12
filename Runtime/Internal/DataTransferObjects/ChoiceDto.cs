using System;

namespace OpenAIToolkit
{
    [Serializable]
    internal class ChoiceDto
    {
        public string text;
        public LogProbsDto logprobs;
        public string finish_reason;
        public int? index;
    }
}