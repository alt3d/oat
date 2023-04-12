using System;
using System.Collections.Generic;

namespace OpenAIToolkit
{
    [Serializable]
    internal class CreateChatCompletionResponseDto
    {
        public string id;
        public int created;
        public string model;
        public List<ChatChoiceDto> choices;
        public UsageDto usage;
    }
}