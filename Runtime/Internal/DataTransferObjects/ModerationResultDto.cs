using System;

namespace OpenAIToolkit
{
    [Serializable]
    internal class ModerationResultDto
    {
        public ModerationCategoriesDto categories;
        public ModerationCategoryScoresDto category_scores;
        public bool flagged;
    }
}