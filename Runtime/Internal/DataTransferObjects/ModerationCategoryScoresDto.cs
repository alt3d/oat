using System;

namespace OpenAIToolkit
{
    [Serializable]
    internal class ModerationCategoryScoresDto
    {
        public float hate;
        public float hatethreatening;
        public float selfharm;
        public float sexual;
        public float sexualminors;
        public float violence;
        public float violencegraphic;
    }
}