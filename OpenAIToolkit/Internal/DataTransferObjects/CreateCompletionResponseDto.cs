using System;
using System.Collections.Generic;

namespace OpenAIToolkit
{
    [Serializable]
    internal class CreateCompletionResponseDto
    {
        public string id;
        public int created;
        public string model;
        public List<ChoiceDto> choices;
        public UsageDto usage;
    }
}