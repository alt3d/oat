using System;

namespace OpenAIToolkit
{
    [Serializable]
    internal class CreateImageRequestDto
    {
        public string prompt;
        public int? n;
        public string size;
        public string response_format;
        public string user;
    }
}