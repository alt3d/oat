using System;

namespace OpenAIToolkit
{
    [Serializable]
    internal class CreateEditRequestDto
    {
        public string model;
        public string input;
        public string instruction;
        public int? n;
        public float? temperature;
        public float? top_p;
        public string user;
    }
}