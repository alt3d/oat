using System;

namespace OpenAIToolkit
{
    [Serializable]
    internal class ModerationCategoriesDto
    {
        public bool hate;
        public bool hatethreatening;
        public bool selfharm;
        public bool sexual;
        public bool sexualminors;
        public bool violence;
        public bool violencegraphic;
    }
}