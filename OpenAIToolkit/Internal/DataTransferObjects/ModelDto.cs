using System;
using System.Collections.Generic;

namespace OpenAIToolkit
{
    [Serializable]
    internal class ModelDto
    {
        public string id;
        public int created;
        public string owned_by;
        public List<PermissionDto> permission;
        public string root;
        public string parent;
    }
}