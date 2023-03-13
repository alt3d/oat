using System;

namespace OpenAIToolkit
{
    [Serializable]
    internal class PermissionDto
    {
        public string id;
        public int created;
        public bool allow_create_engine;
        public bool allow_sampling;
        public bool allow_logprobs;
        public bool allow_search_indices;
        public bool allow_view;
        public bool allow_fine_tuning;
        public string organization;
        public bool is_blocking;
    }
}