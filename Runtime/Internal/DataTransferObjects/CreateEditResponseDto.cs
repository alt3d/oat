using System;
using System.Collections.Generic;

namespace OpenAIToolkit
{
    [Serializable]
    internal class CreateEditResponseDto
    {
        public int created;
        public List<ChoiceDto> choices;
        public UsageDto usage;
    }
}