using System;

namespace OpenAIToolkit
{
    [Serializable]
    internal class UsageDto
    {
        public int prompt_tokens;
        public int completion_tokens;
        public int total_tokens;
    }
}