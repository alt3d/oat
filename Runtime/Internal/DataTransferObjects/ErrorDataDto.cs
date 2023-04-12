using System;

namespace OpenAIToolkit
{
    [Serializable]
    internal class ErrorDataDto
    {
        public string message;
        public string type;
        public string param;
        public string code;
    }
}