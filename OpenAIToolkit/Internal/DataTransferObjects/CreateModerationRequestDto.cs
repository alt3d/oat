using System;

namespace OpenAIToolkit
{
    [Serializable]
    internal class CreateModerationRequestDto
    {
        public string model;
        public string input;
    }
}