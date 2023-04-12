using System;
using System.Collections.Generic;

namespace OpenAIToolkit
{
    [Serializable]
    internal class CreateModerationResponseDto
    {
        public string id;
        public string model;
        public List<ModerationResultDto> results;
    }
}